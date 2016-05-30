using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace BasicCrud
{
    public class Program
    {
        static void createDatabase()
        {
            // Initializing database
            SQLiteConnection.CreateFile("ModelRefDatabase.sqlite");
        }

        static void uuidAutoIncrementTrigger(SQLiteConnection conn)
        {
            try
            {
                // Creating UUID Auto Gen Trigger
                string sql = "CREATE TRIGGER AutoGenerateGUID" +
                "AFTER INSERT ON crud_table" +
                "FOR EACH ROW" +
                "WHEN (NEW.id IS NULL)" +
                "BEGIN" +
                "   UPDATE crud_table SET id = (select hex( randomblob(4)) || '-' || hex( randomblob(2))" +
                "             || '-' || '4' || substr( hex( randomblob(2)), 2) || '-'" +
                "             || substr('AB89', 1 + (abs(random()) % 4) , 1)  ||" +
                "             substr(hex(randomblob(2)), 2) || '-' || hex(randomblob(6)) ) WHERE rowid = NEW.rowid;" +
                "END;";

                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
            }

        }

        static void createTable(SQLiteConnection conn)
        {
            try
            {
                // Creating Table
                string sql = "CREATE TABLE crud_table (id INTEGER PRIMARY KEY AUTOINCREMENT,link varchar(1000));";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
            }

        }

        static void deleteTable(SQLiteConnection conn)
        {
            try
            {
                string sql = "DROP TABLE crud_table;";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
            }

        }

        static void insertModel(SQLiteConnection conn)
        {
            try
            {
                // Inserting into DB
                string sql = "insert into crud_table values (NULL, 'bob');";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
            }

        }

        static void getModels(SQLiteConnection conn)
        {
            try
            {
                // Reading from DB
                string sql = "SELECT * FROM crud_table;";
                SQLiteCommand command = new SQLiteCommand(sql, conn);

                SQLiteDataReader reader = command.ExecuteReader();

                printModels(reader);
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
            }
        }

        public static string getModel(string id)
        {
            try
            {
                SQLiteConnection conn;
                string model = "";

                conn = new SQLiteConnection("Data Source=ModelRefDatabase.sqlite;Version=3;");
                conn.Open();
                
                // Reading from DB
                string sql = "SELECT * FROM crud_table where id = @id;";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);

                SQLiteDataReader reader = command.ExecuteReader();

                printModels(reader);

                model = "Id: " + reader["id"] + "\t Link: " + reader["link"];

                conn.Close();

                return model;
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
                return msg.ToString();
            }
        }

        static void printModels(SQLiteDataReader reader)
        {
            while (reader.Read())
                Console.WriteLine("Id: " + reader["id"] + "\t Link: " + reader["link"]);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World.");

            try
            {
                SQLiteConnection m_dbConnection;

                m_dbConnection = new SQLiteConnection("Data Source=ModelRefDatabase.sqlite;Version=3;");
                m_dbConnection.Open();

                insertModel(m_dbConnection);

                getModels(m_dbConnection);
                getModel("1");
                m_dbConnection.Close();
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
