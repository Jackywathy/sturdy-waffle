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
    public partial class DebugAddItem : Form
    {

        public bool Cancelled = false;

        public DebugAddItem()
        {
            InitializeComponent();
        }

        private void DebugAddItem_Load(object sender, EventArgs e)
        {

        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Cancelled = true;
            this.Close();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            Cancelled = false;
            this.Close();
            
        }

        public static ClientData GetClientDataFromUser()
        {
            var form = new DebugAddItem();
            form.ShowDialog();
            if (!form.Cancelled)
            {
                return new ClientData(form.textBox1.Text, form.textBox3.Text, form.dateTimePicker1.Value,
                    form.textBox2.Text);
            }

            return null;


        }

        private void DebugAddItem_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }

    public class ClientData
    {
        public readonly string FirstName;
        public readonly string MiddleName;
        public readonly string LastName;

        public readonly DateTime DateOfBirth;

        public ClientData(string firstName, string lastName, DateTime dateOfBirth, string middleName = null)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
        }

        public override string ToString()
        {
            return $"name: {FirstName} {MiddleName} {LastName}, DOB: {DateOfBirth}";
        }
    }
}
