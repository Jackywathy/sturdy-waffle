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
    public partial class DebugAddCard : Form
    {
        public DebugAddCard()
        {
            InitializeComponent();
        }

        private void DebugAddCard_Load(object sender, EventArgs e)
        {

        }

        public bool Cancelled = false;

        public static CardData GetAccountDataFromUser(int accountNumber = -1)
        {
            var form = new DebugAddCard();
            if (accountNumber != -1)
            {
                form.tbox_accountNum.Text = accountNumber.ToString();
            }
            form.ShowDialog();
            if (!form.Cancelled)
            {
                try
                {
                    return new CardData(-1, int.Parse(form.tbox_accountNum.Text), "", form.tbox_pin.Text, form.dateTimePicker1.Value, DateTime.Today);
               
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Exception: probably cannot convert text to integer {e}");
                }
            }

            return null;
        }

        private void label1_Click(object sender, EventArgs e)
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
    }
}
