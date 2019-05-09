using OFXReader.Models.Domain;
using OFXReader.Models.File;
using System.Collections.Generic;

namespace OFXReader.Services.Interfaces
{
    public interface ITransactionReport
    {
        void AddTransactionsFromFile(OFXFileObject fileData);

        List<Transaction> GetAllTransactions();
    }
}
