using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;

public enum DatabaseTables
{
    Credentials,
    Cards,
    Accounts
}

public enum AccountType
{
    Savings,
    Cheque,
    Credit
}

public static class AccountTypeExtension
{
    public static string ToDatabaseString(this AccountType accountEnum)
    {
        switch (accountEnum)
        {
            case AccountType.Savings:
                return "Savings";
            case AccountType.Cheque:
                return "Cheque";
            case AccountType.Credit:
                return "Credit";
            default:
                throw new InvalidCastException($"Cannot convert AccountType [{accountEnum}] to AccountType");
        }
    }

    public static AccountType FromString(this AccountType accoutEnum, string accountString)
    {
        switch (accountString)
        {
            case "Savings":
                return AccountType.Savings;
            case "Cheque":
                return AccountType.Cheque;
            case "Credit":
                return AccountType.Savings;
            default:
                throw new InvalidCastException($"Cannot convert '{accountString}' to AccountType");
        }
    }
}

namespace SturdyWaffle
{
    internal class DebugDataRetriever
    {
        private OleDbConnection _dbConnection;
        private OleDbDataAdapter _dbAdapter;

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

        public DebugDataRetriever(string path) : this(CompleteDatabase.GetConnection(path))
        {
        }

    }

    internal class CompleteDatabase
    {
        private OleDbConnection _dbConnection;
        

        public static string ConnectionString { get; } = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}";

        public static OleDbConnection GetConnection(string path)
        {
            return new OleDbConnection(String.Format(ConnectionString, path));
        }

        /// <summary>
        /// Creates a new database file
        /// returns a CompleteDatabase, connected to the new database
        /// </summary>
        /// <param name="path">File path of the new database</param>
        public static CompleteDatabase CreateEmptyDatabase(string path, bool overwrite = false)
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

            var database = new CompleteDatabase(dbConnection);

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
                ret = (int) command.ExecuteScalar();
                _dbConnection.Close();
            }
            return ret;
        }

        /// <summary>
        /// Cuts datetime to just days
        /// MUST BE USED on DATETIME objects going into the database, or else the program will crash
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetProcessedDateTime(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }    

        public ClientData AddClient(string firstname, string lastname, DateTime dateOfBirth, string middlename = null)
        {
            var insertCommand = new OleDbCommand("INSERT INTO Clients(CLIENTNUMBER, FIRSTNAME, MIDDLENAME, LASTNAME, DATEOFBIRTH) VALUES (" +
                                           "@CLIENTNUMBER, @FIRSTNAME, @MIDDLENAME, @LASTNAME, @DATEOFBIRTH);", _dbConnection);
            var num = GetUniqueClientId();
            insertCommand.Parameters.AddWithValue("@CLIENTNUMBER", num);
            insertCommand.Parameters.AddWithValue("@FIRSTNAME", firstname);
            insertCommand.Parameters.AddWithValue("@MIDDLENAME", middlename);
            insertCommand.Parameters.AddWithValue("@LASTNAME", lastname);
            insertCommand.Parameters.AddWithValue("@DATEOFBIRTH", GetProcessedDateTime(dateOfBirth));
            
            _dbConnection.Open();
            insertCommand.ExecuteNonQuery();            
            _dbConnection.Close();
            return new ClientData(firstname, lastname, dateOfBirth, middlename, num);
        }

        public ClientData AddClient(ClientData data)
        {
            return AddClient(data.FirstName, data.LastName, data.DateOfBirth, data.MiddleName);
        }

        public AccountData AddAccount(AccountData data)
        {
            return AddAccount(data.ClientNumber, data.AccountType);
        }


        public AccountData AddAccount(int clientData, AccountType accountType)
        {
            var insertCommand = new OleDbCommand("INSERT INTO Clients(CLIENTNUMBER, FIRSTNAME, MIDDLENAME, LASTNAME, DATEOFBIRTH) VALUES (" +
                                                 "@CLIENTNUMBER, @FIRSTNAME, @MIDDLENAME, @LASTNAME, @DATEOFBIRTH);", _dbConnection);
            return null;
        }
        



        public CompleteDatabase(OleDbConnection connection)
        {
            _dbConnection = connection;
            // integrated SELECTED COMMMAND into the constructor
          
        }

        public CompleteDatabase(string path) : this(GetConnection(path))
        {

        }

    }
}


public class ClientData
{
    public readonly string FirstName;
    public readonly string MiddleName;
    public readonly string LastName;

    public readonly DateTime DateOfBirth;
    public readonly int ClientNumber;

    public ClientData(string firstName, string lastName, DateTime dateOfBirth, string middleName = null, int clientNumber = -1)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.DateOfBirth = dateOfBirth;
        this.ClientNumber = clientNumber;
    }

    public override string ToString()
    {
        return $"number {ClientNumber}, name: {FirstName} {MiddleName} {LastName}, DOB: {DateOfBirth}";
    }
}

public class AccountData
{
    public readonly int ClientNumber;
    public readonly AccountType AccountType;
    public readonly int AccountNumber;



    public AccountData(int clientNumber, AccountType accountType, int accountNumber = -1)
    {
        this.ClientNumber = clientNumber;
        this.AccountType = accountType;
        this.AccountNumber = accountNumber;
    }

    public override string ToString()
    {
        return $"Account Number: {AccountNumber}, ClientNumber: {ClientNumber}, AccountType: {AccountType.ToDatabaseString()}";
    }
}