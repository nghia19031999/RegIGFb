namespace regbmig
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2FA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cStt,
            this.cUsername,
            this.cPass,
            this.c2FA,
            this.cStatus});
            this.dgv.Location = new System.Drawing.Point(12, 116);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.Size = new System.Drawing.Size(761, 150);
            this.dgv.TabIndex = 1;
            // 
            // cStt
            // 
            this.cStt.HeaderText = "STT";
            this.cStt.Name = "cStt";
            // 
            // cUsername
            // 
            this.cUsername.HeaderText = "USERNAME";
            this.cUsername.Name = "cUsername";
            // 
            // cPass
            // 
            this.cPass.HeaderText = "PASS";
            this.cPass.Name = "cPass";
            // 
            // c2FA
            // 
            this.c2FA.HeaderText = "2FA";
            this.c2FA.Name = "c2FA";
            // 
            // cStatus
            // 
            this.cStatus.HeaderText = "STATUS";
            this.cStatus.Name = "cStatus";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStt;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2FA;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
    }
}

