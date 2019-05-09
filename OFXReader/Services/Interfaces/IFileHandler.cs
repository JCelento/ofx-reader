using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace OFXReader.Services.Interfaces
{
    public interface IFileHandler
    {
        Task Upload(IFormFileCollection files);
    }
}
