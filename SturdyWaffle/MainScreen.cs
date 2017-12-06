using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SturdyWaffle
{
    public partial class MainScreen : Form
    {

        public MainScreen()
        {
            InitializeComponent();
        }

        private DebugDataRetriever _debug;
        private CompleteDatabase _database;
        private void Form1_Load(object sender, EventArgs e)
        {

            //try
            //{
            //    System.IO.File.Delete("database.mdb");
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception);
            //    throw;
            //}
            // DELETES THE DATABASE if needed for some reason

            _database = System.IO.File.Exists("database.mdb") ? new CompleteDatabase("database.mdb") : CompleteDatabase.CreateEmptyDatabase("database.mdb");
     
            _debug = new DebugDataRetriever("database.mdb");

            dataGridClients.DataSource = _debug.CurrentDataSet;
            dataGridClients.DataMember = "Clients";

            dataGridView2.DataSource = _debug.CurrentDataSet;
            dataGridView2.DataMember = "Accounts";

            dataGridView3.DataSource = _debug.CurrentDataSet;
            dataGridView3.DataMember = "Cards";
        }



        private void btn_refresh_Click(object sender, EventArgs e)
        {
            _debug.Refresh();
        }

        private void btn_addClient_Click(object sender, EventArgs e)
        {
            ClientData data = DebugAddClient.GetClientDataFromUser();
            if (data != null)
            {
                _database.AddClient(data.FirstName, data.MiddleName, data.LastName, data.DateOfBirth);
                _debug.Refresh();
            } 
        }

        private void btn_addAccount_Click(object sender, EventArgs e)
        {
            // check if a client is already selected
            var clientNum = -1;
            var selectedCells = dataGridClients.SelectedCells;
            if (selectedCells.Count == 1)
            {
                var currentRow = dataGridClients.Rows[selectedCells[0].RowIndex];
                clientNum = (int) currentRow.Cells[0].Value; // get the clientNumber if any cells are selected
            }

            AccountData data = DebugAddAccount.GetAccountDataFromUser(clientNum);
            if (data != null) 
            {
                _database.AddAccount(data.ClientNumber, data.AccountType);
                _debug.Refresh();
            }
        }

        private void dataGridClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
