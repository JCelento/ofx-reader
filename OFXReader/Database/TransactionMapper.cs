using MySql.Data.MySqlClient;
using OFXReader.Models.Domain;
using System;

namespace OFXReader.Database
{
    public class TransactionMapper
    {
        public Transaction MapToObject(MySqlDataReader reader)
        {
            var transaction = new Transaction
            (
                id : Convert.ToInt32(reader["Id"]),
                hash: reader["Hash"].ToString(),
                type: reader["Type"].ToString(),
                date: Convert.ToDateTime(reader["Date"]),
                amount: float.Parse(reader["Amount"].ToString()),
                fitid: reader["FITID"].ToString(),
                description: reader["Description"].ToString()
            );

            return transaction;
        }
    }
}
