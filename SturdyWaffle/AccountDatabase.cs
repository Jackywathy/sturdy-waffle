using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

public enum DatabaseTables
{
    Credentials,
    Cards
}

namespace SturdyWaffle
{
    internal class 

    internal class DebugDataRetriever
    {
        private SqlConnection _dbConnection;
        private SqlDataAdapter _dbAdapter;

        private IList<Tuple<string, OleDbCommand>> _refreshCommands = new List<Tuple<string, OleDbCommand>>();

        public DataSet CurrentDataSet { get; set; } = new DataSet();

        public void Refresh()
        {
            _dbConnection.Open();
            CurrentDataSet.Clear();
            foreach (var element in _refreshCommands)
            {
                _dbAdapter.SelectCommand = element.Item2;
                _dbAdapter.Fill(CurrentDataSet, element.Item1);
            }
            _dbConnection.Close();

        }

        public DebugDataRetriever(OleDbConnection connection)
        {
            _dbConnection = connection;

            _refreshCommands.Add(new Tuple<string, OleDbCommand>("Clients",
                new OleDbCommand("SELECT * FROM Clients;", _dbConnection)));
            _refreshCommands.Add(new Tuple<string, OleDbCommand>("Accounts",
                new OleDbCommand("SELECT * FROM Accounts;", _dbConnection)));
            _refreshCommands.Add(new Tuple<string, OleDbCommand>("Cards",
                new OleDbCommand("SELECT * FROM Cards;", _dbConnection)));

            _dbAdapter = new OleDbDataAdapter(); // SELECT * FROM Accounts; SELECT * FROM Cards;", _dbConnection);
            Refresh();
        }

        public DebugDataRetriever(string path) : this(AccountDatabase.GetConnection(path))
        {
            
        }

    }

    internal class AccountDatabase
    {
        private OleDbConnection _dbConnection;
        

        public static string ConnectionString { get; } = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}";

        public static OleDbConnection GetConnection(string path)
        {
            return new OleDbConnection(String.Format(ConnectionString, path));
        }

        /// <summary>
        /// Creates a new database file
        /// returns a AccountDatabase, connected to the new database
        /// </summary>
        /// <param name="path">File path of the new database</param>
        public static AccountDatabase CreateEmptyDatabase(string path, bool overwrite = false)
        {
            // check if the file exists
            if (File.Exists(path) && !overwrite)
            {
                throw new IOException("File already exists");
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                var resource = (byte[])Properties.Resources.EmptyDatabase;
                if (resource == null)
                {
                    throw new Exception();
                }
                writer.Write(resource);
            }

            var dbConnection = GetConnection(path);
            Execute("CREATE TABLE Clients (" +
                               "[CLIENTNUMBER] COUNTER PRIMARY KEY," +
                               "FIRSTNAME TEXT NOT NULL," +
                               "MIDDLENAME TEXT," +
                               "LASTNAME TEXT NOT NULL," +
                               "DATEOFBIRTH DATETIME NOT NULL )",
                dbConnection
            );
            Execute("CREATE TABLE Accounts (" +
                               "ACCOUNTNUMBER INTEGER PRIMARY KEY," +
                               "CLIENTNUMBER INTEGER NOT NULL UNIQUE," +
                               "ACCOUNTTYPE TEXT NOT NULL," +
                               "CONSTRAINT FKEY_Accounts_CLIENTNUMBER FOREIGN KEY (CLIENTNUMBER) REFERENCES Clients ON UPDATE CASCADE ON DELETE CASCADE );",
                dbConnection
                );
            Execute("CREATE TABLE Cards (" +
                               "CARDNUMBER INTEGER PRIMARY KEY," +
                               "ACCOUNTNUMBER INTEGER NOT NULL UNIQUE," +
                               "CVV TEXT NOT NULL," +
                               "PIN TEXT NOT NULL," +
                               "EXPIRY DATETIME NOT NULL," +
                               "ISSUEDATE DATETIME NOT NULL," +
                               "CONSTRAINT FKEY_Cards_ACCOUNTNUMBER FOREIGN KEY (ACCOUNTNUMBER) REFERENCES Accounts ON UPDATE CASCADE ON DELETE CASCADE );",
                dbConnection
                               );

            var database = new AccountDatabase(dbConnection);

            //connection.Execute("CREATE table Transactions (" +
            //                   "TRANSACTIONID INTEGER PRIMARY KEY" +
            //                   "ACCOUNTNUMBER INTEGER," +
            //                   "");


            return database;
        }

        

        public void Execute(string sql)
        {
            Execute(sql, _dbConnection);
        }

        public static void Execute(string sql, OleDbConnection connection)
        {
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private int GetUniqueClientId()
        {
            var ret = -1;
            using (OleDbCommand command = new OleDbCommand("SELECT (COUNT(*) + 1) FROM Clients", _dbConnection))
            {
                _dbConnection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                ret = (int)reader[0];
                _dbConnection.Close();
            }
            return ret;
        }

        /// <summary>
        /// Cuts the milliseconds / microseconds off so that it can fit in the database
        /// MUST BE USED on DATETIME objects going into the database, or else the program will crash
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetProcessedDateTime(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
        }    

        public void AddClient(string firstname, string lastname, DateTime dateOfBirth, string middlename = null)
        {
            var insertCommand = new OleDbCommand("INSERT INTO Clients(FIRSTNAME, MIDDLENAME, LASTNAME, DATEOFBIRTH) VALUES (" +
                                           "@FIRSTNAME, @MIDDLENAME, @LASTNAME, @DATEOFBIRTH);", _dbConnection);

            insertCommand.Parameters.AddWithValue("@FIRSTNAME", firstname);
            insertCommand.Parameters.AddWithValue("@MIDDLENAME", middlename);
            insertCommand.Parameters.AddWithValue("@LASTNAME", lastname);
            insertCommand.Parameters.AddWithValue("@DATEOFBIRTH", GetProcessedDateTime(dateOfBirth));
            
            _dbConnection.Open();
            insertCommand.ExecuteNonQuery();
            _dbConnection.Close();
        }
        public void AddClient(ClientData data)
        {
            AddClient(data.FirstName, data.LastName, data.DateOfBirth, data.MiddleName);
        }

        public AccountDatabase(OleDbConnection connection)
        {
            _dbConnection = connection;
            // integrated SELECTED COMMMAND into the constructor
          
        }

        public AccountDatabase(string path) : this(GetConnection(path))
        {

        }

    }
}

