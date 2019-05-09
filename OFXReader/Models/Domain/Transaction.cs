using OFXReader.Models.File;
using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace OFXReader.Models.Domain
{
    public class Transaction
    {
        public int Id { get; set; }

        public string Hash { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public float Amount { get; set; }

        public string FITID { get; set; }

        public string Description { get; set; }

        public Transaction(TransactionInfo transactionInfo)
        {
            Type = transactionInfo.TRNTYPE;
            Date = DateTime.ParseExact(transactionInfo.DTPOSTED.Substring(0, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            Amount = float.Parse(transactionInfo.TRNAMT);
            FITID = transactionInfo.FITID;
            Description = transactionInfo.MEMO;
            AssignHash();
        }

        public Transaction(int id, string hash, string type, DateTime date, float amount, string fitid, string description)
        {
            Id = id;
            Hash = hash;
            Date = date;
            Type = type;
            Amount = amount;
            FITID = fitid;
            Description = description;
        }

        public void AssignHash()
        {
            byte[] hash;
            using (MD5 md5 = MD5.Create())
            {
                md5.Initialize();
                md5.ComputeHash(Encoding.UTF8.GetBytes($"{Date.ToString()}{Amount.ToString()}{Description}"));
                hash = md5.Hash;
            }

            Hash = BitConverter.ToString(hash);
        }
    }
}
