using Microsoft.AspNetCore.Mvc;
using OFXReader.Models.Domain;
using OFXReader.Services.Interfaces;
using System.Collections.Generic;

namespace OFXReader.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        private readonly ITransactionReport _transactionReport;

        public TransactionsController(ITransactionReport transactionReport)
        {
            _transactionReport = transactionReport;
        }

        [HttpGet("report")]
        public List<Transaction> GetTransactions()
        {
            return _transactionReport.GetAllTransactions();
        }
    }
}
