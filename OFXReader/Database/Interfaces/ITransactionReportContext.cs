using OFXReader.Models.Domain;
using System.Collections.Generic;

namespace OFXReader.Database.Interfaces
{
    public interface ITransactionReportContext
    {
        List<Transaction> GetAllTransactions();

        void InsertTransactions(List<Transaction> transactions);
    }
}
