using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace BasicCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World.");

            
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                // PostgeSQL-style connection string
                string connstring = "Server=127.0.0.1; Port=5433; User Id=postgres; Password=root; Database=postgres;";
                // Making connection with Npgsql provider
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                // sql statement
                //string sql = "SELECT table_schema,table_name FROM information_schema.tables ORDER BY table_schema,table_name";
                string sql1 = "CREATE TABLE crud_table (id UUID PRIMARY KEY,name varchar(40));";
                string sql2 = "insert into crud_table values (uuid_generate_v4())";
                string sql3 = "SELECT * FROM crud_table";


                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand(sql3, conn);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                    Console.Write("{0}\t{1} \n", dr[0], dr[1]);

                conn.Close();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
            }
            
            

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
