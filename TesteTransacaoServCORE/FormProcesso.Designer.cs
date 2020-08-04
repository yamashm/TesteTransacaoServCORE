namespace TesteTransacaoServCORE
{
    partial class FormProcesso
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
            this.label11 = new System.Windows.Forms.Label();
            this.txb_ID_PROCESS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_NAME = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_DESCRIPTION = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_FULL_PATH = new System.Windows.Forms.TextBox();
            this.cbb_STATUS = new System.Windows.Forms.ComboBox();
            this.cbb_PROCESS_TYPE = new System.Windows.Forms.ComboBox();
            this.cbb_CREATE_TRANSACTION = new System.Windows.Forms.ComboBox();
            this.txb_PROPAGATION_TRANSACTION = new System.Windows.Forms.TextBox();
            this.cbb_FINISH_TRANSACTION = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "ID_PROCESS";
            // 
            // txb_ID_PROCESS
            // 
            this.txb_ID_PROCESS.Location = new System.Drawing.Point(117, 12);
            this.txb_ID_PROCESS.Name = "txb_ID_PROCESS";
            this.txb_ID_PROCESS.Size = new System.Drawing.Size(175, 20);
            this.txb_ID_PROCESS.TabIndex = 34;
            this.txb_ID_PROCESS.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "NAME";
            // 
            // txb_NAME
            // 
            this.txb_NAME.Location = new System.Drawing.Point(117, 38);
            this.txb_NAME.Name = "txb_NAME";
            this.txb_NAME.Size = new System.Drawing.Size(175, 20);
            this.txb_NAME.TabIndex = 36;
            this.txb_NAME.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "DESCRIPTION";
            // 
            // txb_DESCRIPTION
            // 
            this.txb_DESCRIPTION.Location = new System.Drawing.Point(117, 64);
            this.txb_DESCRIPTION.Name = "txb_DESCRIPTION";
            this.txb_DESCRIPTION.Size = new System.Drawing.Size(175, 20);
            this.txb_DESCRIPTION.TabIndex = 38;
            this.txb_DESCRIPTION.Text = "1";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(136, 259);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 41;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(217, 259);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "FULL_PATH";
            // 
            // txb_FULL_PATH
            // 
            this.txb_FULL_PATH.Location = new System.Drawing.Point(117, 223);
            this.txb_FULL_PATH.Name = "txb_FULL_PATH";
            this.txb_FULL_PATH.Size = new System.Drawing.Size(175, 20);
            this.txb_FULL_PATH.TabIndex = 48;
            this.txb_FULL_PATH.Text = "1";
            // 
            // cbb_STATUS
            // 
            this.cbb_STATUS.FormattingEnabled = true;
            this.cbb_STATUS.Items.AddRange(new object[] {
            "N",
            "Y"});
            this.cbb_STATUS.Location = new System.Drawing.Point(192, 90);
            this.cbb_STATUS.Name = "cbb_STATUS";
            this.cbb_STATUS.Size = new System.Drawing.Size(100, 21);
            this.cbb_STATUS.TabIndex = 53;
            // 
            // cbb_PROCESS_TYPE
            // 
            this.cbb_PROCESS_TYPE.FormattingEnabled = true;
            this.cbb_PROCESS_TYPE.Items.AddRange(new object[] {
            "G",
            "I"});
            this.cbb_PROCESS_TYPE.Location = new System.Drawing.Point(192, 117);
            this.cbb_PROCESS_TYPE.Name = "cbb_PROCESS_TYPE";
            this.cbb_PROCESS_TYPE.Size = new System.Drawing.Size(100, 21);
            this.cbb_PROCESS_TYPE.TabIndex = 54;
            // 
            // cbb_CREATE_TRANSACTION
            // 
            this.cbb_CREATE_TRANSACTION.FormattingEnabled = true;
            this.cbb_CREATE_TRANSACTION.Items.AddRange(new object[] {
            "N",
            "Y"});
            this.cbb_CREATE_TRANSACTION.Location = new System.Drawing.Point(192, 143);
            this.cbb_CREATE_TRANSACTION.Name = "cbb_CREATE_TRANSACTION";
            this.cbb_CREATE_TRANSACTION.Size = new System.Drawing.Size(100, 21);
            this.cbb_CREATE_TRANSACTION.TabIndex = 46;
            // 
            // txb_PROPAGATION_TRANSACTION
            // 
            this.txb_PROPAGATION_TRANSACTION.Location = new System.Drawing.Point(192, 170);
            this.txb_PROPAGATION_TRANSACTION.Name = "txb_PROPAGATION_TRANSACTION";
            this.txb_PROPAGATION_TRANSACTION.Size = new System.Drawing.Size(100, 20);
            this.txb_PROPAGATION_TRANSACTION.TabIndex = 43;
            this.txb_PROPAGATION_TRANSACTION.Text = "0";
            // 
            // cbb_FINISH_TRANSACTION
            // 
            this.cbb_FINISH_TRANSACTION.FormattingEnabled = true;
            this.cbb_FINISH_TRANSACTION.Items.AddRange(new object[] {
            "N",
            "Y"});
            this.cbb_FINISH_TRANSACTION.Location = new System.Drawing.Point(192, 196);
            this.cbb_FINISH_TRANSACTION.Name = "cbb_FINISH_TRANSACTION";
            this.cbb_FINISH_TRANSACTION.Size = new System.Drawing.Size(100, 21);
            this.cbb_FINISH_TRANSACTION.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "FINISH_TRANSACTION";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "PROPAGATION_TRANSACTION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "CREATE_TRANSACTION";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "PROCESS_TYPE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "STATUS";
            // 
            // FormProcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 297);
            this.Controls.Add(this.cbb_PROCESS_TYPE);
            this.Controls.Add(this.cbb_STATUS);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_FULL_PATH);
            this.Controls.Add(this.cbb_FINISH_TRANSACTION);
            this.Controls.Add(this.cbb_CREATE_TRANSACTION);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_PROPAGATION_TRANSACTION);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_DESCRIPTION);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txb_NAME);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txb_ID_PROCESS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormProcesso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processo";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txb_ID_PROCESS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_NAME;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_DESCRIPTION;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_FULL_PATH;
        private System.Windows.Forms.ComboBox cbb_STATUS;
        private System.Windows.Forms.ComboBox cbb_PROCESS_TYPE;
        private System.Windows.Forms.ComboBox cbb_CREATE_TRANSACTION;
        private System.Windows.Forms.TextBox txb_PROPAGATION_TRANSACTION;
        private System.Windows.Forms.ComboBox cbb_FINISH_TRANSACTION;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}