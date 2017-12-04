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

      

       
 
    }

    
}
