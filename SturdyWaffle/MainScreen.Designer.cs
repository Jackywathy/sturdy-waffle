﻿namespace SturdyWaffle
{
    partial class MainScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridClients = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_addClient = new System.Windows.Forms.Button();
            this.btn_addAccount = new System.Windows.Forms.Button();
            this.btn_addCard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Insert card";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 83);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridClients
            // 
            this.dataGridClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridClients.Location = new System.Drawing.Point(466, 3);
            this.dataGridClients.Name = "dataGridClients";
            this.dataGridClients.Size = new System.Drawing.Size(385, 199);
            this.dataGridClients.TabIndex = 2;
            this.dataGridClients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridClients_CellContentClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(466, 217);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(385, 176);
            this.dataGridView2.TabIndex = 3;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(466, 424);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(385, 176);
            this.dataGridView3.TabIndex = 4;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(362, 28);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_refresh.TabIndex = 5;
            this.btn_refresh.Text = "refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_addClient
            // 
            this.btn_addClient.Location = new System.Drawing.Point(362, 70);
            this.btn_addClient.Name = "btn_addClient";
            this.btn_addClient.Size = new System.Drawing.Size(75, 23);
            this.btn_addClient.TabIndex = 6;
            this.btn_addClient.Text = "Add cl;ient";
            this.btn_addClient.UseVisualStyleBackColor = true;
            this.btn_addClient.Click += new System.EventHandler(this.btn_addClient_Click);
            // 
            // btn_addAccount
            // 
            this.btn_addAccount.Location = new System.Drawing.Point(332, 109);
            this.btn_addAccount.Name = "btn_addAccount";
            this.btn_addAccount.Size = new System.Drawing.Size(105, 39);
            this.btn_addAccount.TabIndex = 7;
            this.btn_addAccount.Text = "Add account";
            this.btn_addAccount.UseVisualStyleBackColor = true;
            this.btn_addAccount.Click += new System.EventHandler(this.btn_addAccount_Click);
            // 
            // btn_addCard
            // 
            this.btn_addCard.Location = new System.Drawing.Point(318, 173);
            this.btn_addCard.Name = "btn_addCard";
            this.btn_addCard.Size = new System.Drawing.Size(105, 39);
            this.btn_addCard.TabIndex = 8;
            this.btn_addCard.Text = "Add Card";
            this.btn_addCard.UseVisualStyleBackColor = true;
            this.btn_addCard.Click += new System.EventHandler(this.btn_addCard_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 592);
            this.Controls.Add(this.btn_addCard);
            this.Controls.Add(this.btn_addAccount);
            this.Controls.Add(this.btn_addClient);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridClients);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainScreen";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridClients;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_addClient;
        private System.Windows.Forms.Button btn_addAccount;
        private System.Windows.Forms.Button btn_addCard;
    }
}

