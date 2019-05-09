using MySql.Data.MySqlClient;
using OFXReader.Models.Domain;
using System.Collections.Generic;
using OFXReader.Database.Interfaces;

namespace OFXReader.Database
{
    public class TransactionReportContext : ITransactionReportContext
    {
        private string ConnectionString { get; set; }
        private TransactionMapper TransactionMapper {get;set;}

        public TransactionReportContext(string connectionString)
        {
            ConnectionString = connectionString;
            TransactionMapper = new TransactionMapper();
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Transaction> GetAllTransactions()
        {
            var list = new List<Transaction>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Transaction", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(TransactionMapper.MapToObject(reader));
                    }
                }
                conn.Close();
            }
            return list;
        }

        public void InsertTransactions(List<Transaction> transactions)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("insert into Transaction (hash, type, date, amount, fitid, description) values(?Hash, ?Type, ?Date, ?Amount, ?FITID, ?Description)", conn);

                using (cmd)
                {
                    foreach(var transaction in transactions)
                    {
                        cmd.Parameters.AddWithValue("?Hash", transaction.Hash);
                        cmd.Parameters.AddWithValue("?Type", transaction.Type);
                        cmd.Parameters.AddWithValue("?Date", transaction.Date);
                        cmd.Parameters.AddWithValue("?Amount", transaction.Amount);
                        cmd.Parameters.AddWithValue("?FITID", transaction.FITID);
                        cmd.Parameters.AddWithValue("?Description", transaction.Description);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        catch (MySqlException ex)
                        {
                            if (ex.Message.Contains("Duplicate entry"))
                            {
                                cmd.Parameters.Clear();
                                continue;
                            }

                            throw(ex);
                        }

                    }
                    
                }

                conn.Close();
            }
        }
    }
}
