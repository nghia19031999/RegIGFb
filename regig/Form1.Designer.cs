namespace regig
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.cStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2FA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPassMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMailKP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numThreads = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cStt,
            this.cUid,
            this.cPass,
            this.c2FA,
            this.cMail,
            this.cPassMail,
            this.cMailKP,
            this.cStatus});
            this.dgv1.Location = new System.Drawing.Point(7, 107);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv1.Size = new System.Drawing.Size(781, 298);
            this.dgv1.TabIndex = 1;
            // 
            // cStt
            // 
            this.cStt.HeaderText = "STT";
            this.cStt.Name = "cStt";
            // 
            // cUid
            // 
            this.cUid.HeaderText = "UID";
            this.cUid.Name = "cUid";
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
            // cMail
            // 
            this.cMail.HeaderText = "MAIL";
            this.cMail.Name = "cMail";
            // 
            // cPassMail
            // 
            this.cPassMail.HeaderText = "PASSMAIL";
            this.cPassMail.Name = "cPassMail";
            // 
            // cMailKP
            // 
            this.cMailKP.HeaderText = "MAILKP";
            this.cMailKP.Name = "cMailKP";
            // 
            // cStatus
            // 
            this.cStatus.HeaderText = "STATUS";
            this.cStatus.Name = "cStatus";
            // 
            // numThreads
            // 
            this.numThreads.Location = new System.Drawing.Point(262, 43);
            this.numThreads.Name = "numThreads";
            this.numThreads.Size = new System.Drawing.Size(120, 20);
            this.numThreads.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "số luồng :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numThreads);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStt;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2FA;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPassMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMailKP;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
        private System.Windows.Forms.NumericUpDown numThreads;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
    }
}

