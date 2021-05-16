using System;
using Microsoft.Data.Sqlite;

namespace seed_sqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqliteConnection("Data Source=../Data/todo.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                            @"insert into Product(id, name, price) values('0f8fad5b-d9cb-469f-a165-70867728950e', 'Product X', 5)";

                connection.Close();
            }
        }
    }
}
