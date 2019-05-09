using System;
using System.IO;
using System.Linq;
using OFXReader.Models.File;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using OFXReader.Services.Helpers;
using Microsoft.AspNetCore.Hosting;
using OFXReader.Services.Interfaces;

namespace OFXReader.Services
{
    public class FileHandler : IFileHandler
    {
        private readonly ITransactionReport _transactionReport;
        private readonly IHostingEnvironment _hostingEnvironment;
        private const string folderName = "Upload";

        public FileHandler(ITransactionReport transactionReport, IHostingEnvironment hostingEnviroment)
        {
            _transactionReport = transactionReport;
            _hostingEnvironment = hostingEnviroment;
        }
       
        public async Task Upload(IFormFileCollection files)
        {
            long size = files.Sum(f => f.Length);
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            string fullPath = "";
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (files.Any())
            {
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                        fullPath = Path.Combine(newPath, fileName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }

                        await Task.Run(() => Read(fullPath));
                    }

                }
            }
        }

        private void Read(string filePath)
        {
            try
            {
                var fixedString = XmlConverter.FixBadXmlText(filePath);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(OFXFileObject));
                var steamFile = GenerateStreamFromString(fixedString);
                var result = xmlSerializer.Deserialize(steamFile);

                steamFile.Close();               

                _transactionReport.AddTransactionsFromFile(result as OFXFileObject);

            }
            catch (Exception ex)
            { throw new ApplicationException($"Invalid File : {ex}"); };

        }

        private Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

    }
}
