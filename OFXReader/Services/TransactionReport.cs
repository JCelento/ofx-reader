using OFXReader.Database.Interfaces;
using OFXReader.Models.Domain;
using OFXReader.Models.File;
using OFXReader.Services.Interfaces;
using System.Collections.Generic;

namespace OFXReader.Services
{
    public class TransactionReport : ITransactionReport
    {
        private ITransactionReportContext _transactionReportContext { get; set; }

        public TransactionReport(ITransactionReportContext transactionReportContext)
        {
            _transactionReportContext = transactionReportContext;
        }

        public void AddTransactionsFromFile(OFXFileObject fileData)
        {
            var transactionList = new List<Transaction>();

            foreach(var transaction in fileData.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKTRANLIST.STMTTRN)
            {
                transactionList.Add(new Transaction(transaction));
            }

            _transactionReportContext.InsertTransactions(transactionList);

        }

        public List<Transaction> GetAllTransactions()
        {
           var transactions = _transactionReportContext.GetAllTransactions();

            return transactions;

        }
    }
}
