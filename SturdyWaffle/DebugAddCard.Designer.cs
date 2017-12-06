namespace SturdyWaffle
{
    partial class DebugAddCard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbox_pin = new System.Windows.Forms.TextBox();
            this.tbox_accountNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbox_pin
            // 
            this.tbox_pin.Location = new System.Drawing.Point(50, 118);
            this.tbox_pin.Name = "tbox_pin";
            this.tbox_pin.Size = new System.Drawing.Size(265, 20);
            this.tbox_pin.TabIndex = 12;
            // 
            // tbox_accountNum
            // 
            this.tbox_accountNum.Location = new System.Drawing.Point(50, 66);
            this.tbox_accountNum.Name = "tbox_accountNum";
            this.tbox_accountNum.Size = new System.Drawing.Size(265, 20);
            this.tbox_accountNum.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "expiry";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "pin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Account Number";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(62, 178);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(397, 262);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 15;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(397, 205);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_confirm.TabIndex = 14;
            this.btn_confirm.Text = "Con-Furm";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // DebugAddCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 490);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tbox_pin);
            this.Controls.Add(this.tbox_accountNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DebugAddCard";
            this.Text = "DebugAddCard";
            this.Load += new System.EventHandler(this.DebugAddCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbox_pin;
        private System.Windows.Forms.TextBox tbox_accountNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_confirm;
    }
}