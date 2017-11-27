using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private AccountDatabase _database;
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

            _database = System.IO.File.Exists("database.mdb") ? new AccountDatabase("database.mdb") : AccountDatabase.CreateEmptyDatabase("database.mdb");
     
            _debug = new DebugDataRetriever("database.mdb");

            dataGridView1.DataSource = _debug.CurrentDataSet;
            dataGridView1.DataMember = "Clients";

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
            ClientData data = DebugAddItem.GetClientDataFromUser();
            _database.AddClient(data);
            _debug.Refresh();
        }
    }
}
