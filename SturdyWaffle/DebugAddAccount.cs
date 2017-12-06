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
    public partial class DebugAddAccount : Form
    {

        public bool Cancelled = true;

        public DebugAddAccount()
        {
            InitializeComponent();
        }

        private void DebugAddAccount_Load(object sender, EventArgs e)
        {
            cbox_type.SelectedIndex = 0;
        }

        public static AccountData GetAccountDataFromUser(int clientNum = -1)
        {
            var form = new DebugAddAccount();
            if (clientNum != -1)
            {
                form.tbox_clientNum.Text = clientNum.ToString();
            }
            form.ShowDialog();
            if (!form.Cancelled)
            {
                try
                {
                    return new AccountData(-1, int.Parse(form.tbox_clientNum.Text),
                        AccountTypeExtension.FromString((string) form.cbox_type.SelectedItem));
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Exception: probably cannot convert text to integer {e}");
                }
            }

            return null;

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
