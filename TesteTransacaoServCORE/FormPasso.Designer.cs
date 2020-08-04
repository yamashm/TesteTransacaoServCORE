namespace TesteTransacaoServCORE
{
    partial class FormPasso
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_PROPAGATION_TRANSACTION = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_NEXT_STEP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_BEFORE_EXECUTE_EVAL = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_EXCEPTION_EVAL = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_RESULT_EVAL = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txb_CACHE_EVAL = new System.Windows.Forms.TextBox();
            this.cbb_ID_ACTIVITY = new System.Windows.Forms.ComboBox();
            this.cbb_ID_PROCESS_CHILD = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txb_STEP = new System.Windows.Forms.TextBox();
            this.cbb_CREATE_TRANSACTION = new System.Windows.Forms.ComboBox();
            this.cbb_FINISH_TRANSACTION = new System.Windows.Forms.ComboBox();
            this.txb_ACTIVITY_NAME = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(131, 330);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(212, 330);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "FINISH_TRANSACTION";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "PROPAGATION_TRANSACTION";
            // 
            // txb_PROPAGATION_TRANSACTION
            // 
            this.txb_PROPAGATION_TRANSACTION.Location = new System.Drawing.Point(187, 148);
            this.txb_PROPAGATION_TRANSACTION.Name = "txb_PROPAGATION_TRANSACTION";
            this.txb_PROPAGATION_TRANSACTION.Size = new System.Drawing.Size(100, 20);
            this.txb_PROPAGATION_TRANSACTION.TabIndex = 16;
            this.txb_PROPAGATION_TRANSACTION.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "CREATE_TRANSACTION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "ID_PROCESS_CHILD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ID_ACTIVITY";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "NEXT_STEP";
            // 
            // txb_NEXT_STEP
            // 
            this.txb_NEXT_STEP.Location = new System.Drawing.Point(187, 200);
            this.txb_NEXT_STEP.Name = "txb_NEXT_STEP";
            this.txb_NEXT_STEP.Size = new System.Drawing.Size(100, 20);
            this.txb_NEXT_STEP.TabIndex = 20;
            this.txb_NEXT_STEP.Text = "65";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "BEFORE_EXECUTE_EVAL";
            // 
            // txb_BEFORE_EXECUTE_EVAL
            // 
            this.txb_BEFORE_EXECUTE_EVAL.Location = new System.Drawing.Point(187, 278);
            this.txb_BEFORE_EXECUTE_EVAL.Name = "txb_BEFORE_EXECUTE_EVAL";
            this.txb_BEFORE_EXECUTE_EVAL.Size = new System.Drawing.Size(100, 20);
            this.txb_BEFORE_EXECUTE_EVAL.TabIndex = 26;
            this.txb_BEFORE_EXECUTE_EVAL.Text = "65";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "EXCEPTION_EVAL";
            // 
            // txb_EXCEPTION_EVAL
            // 
            this.txb_EXCEPTION_EVAL.Location = new System.Drawing.Point(187, 252);
            this.txb_EXCEPTION_EVAL.Name = "txb_EXCEPTION_EVAL";
            this.txb_EXCEPTION_EVAL.Size = new System.Drawing.Size(100, 20);
            this.txb_EXCEPTION_EVAL.TabIndex = 24;
            this.txb_EXCEPTION_EVAL.Text = "65";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "RESULT_EVAL";
            // 
            // txb_RESULT_EVAL
            // 
            this.txb_RESULT_EVAL.Location = new System.Drawing.Point(187, 226);
            this.txb_RESULT_EVAL.Name = "txb_RESULT_EVAL";
            this.txb_RESULT_EVAL.Size = new System.Drawing.Size(100, 20);
            this.txb_RESULT_EVAL.TabIndex = 22;
            this.txb_RESULT_EVAL.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 307);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "CACHE_EVAL";
            // 
            // txb_CACHE_EVAL
            // 
            this.txb_CACHE_EVAL.Location = new System.Drawing.Point(187, 304);
            this.txb_CACHE_EVAL.Name = "txb_CACHE_EVAL";
            this.txb_CACHE_EVAL.Size = new System.Drawing.Size(100, 20);
            this.txb_CACHE_EVAL.TabIndex = 28;
            this.txb_CACHE_EVAL.Text = "65";
            // 
            // cbb_ID_ACTIVITY
            // 
            this.cbb_ID_ACTIVITY.FormattingEnabled = true;
            this.cbb_ID_ACTIVITY.Location = new System.Drawing.Point(187, 42);
            this.cbb_ID_ACTIVITY.Name = "cbb_ID_ACTIVITY";
            this.cbb_ID_ACTIVITY.Size = new System.Drawing.Size(100, 21);
            this.cbb_ID_ACTIVITY.TabIndex = 30;
            this.cbb_ID_ACTIVITY.SelectedIndexChanged += new System.EventHandler(this.cbb_ID_ACTIVITY_SelectedIndexChanged);
            // 
            // cbb_ID_PROCESS_CHILD
            // 
            this.cbb_ID_PROCESS_CHILD.FormattingEnabled = true;
            this.cbb_ID_PROCESS_CHILD.Location = new System.Drawing.Point(187, 95);
            this.cbb_ID_PROCESS_CHILD.Name = "cbb_ID_PROCESS_CHILD";
            this.cbb_ID_PROCESS_CHILD.Size = new System.Drawing.Size(100, 21);
            this.cbb_ID_PROCESS_CHILD.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "STEP";
            // 
            // txb_STEP
            // 
            this.txb_STEP.Location = new System.Drawing.Point(187, 16);
            this.txb_STEP.Name = "txb_STEP";
            this.txb_STEP.Size = new System.Drawing.Size(100, 20);
            this.txb_STEP.TabIndex = 32;
            this.txb_STEP.Text = "1";
            // 
            // cbb_CREATE_TRANSACTION
            // 
            this.cbb_CREATE_TRANSACTION.FormattingEnabled = true;
            this.cbb_CREATE_TRANSACTION.Items.AddRange(new object[] {
            "N",
            "Y"});
            this.cbb_CREATE_TRANSACTION.Location = new System.Drawing.Point(187, 121);
            this.cbb_CREATE_TRANSACTION.Name = "cbb_CREATE_TRANSACTION";
            this.cbb_CREATE_TRANSACTION.Size = new System.Drawing.Size(100, 21);
            this.cbb_CREATE_TRANSACTION.TabIndex = 34;
            // 
            // cbb_FINISH_TRANSACTION
            // 
            this.cbb_FINISH_TRANSACTION.FormattingEnabled = true;
            this.cbb_FINISH_TRANSACTION.Items.AddRange(new object[] {
            "N",
            "Y"});
            this.cbb_FINISH_TRANSACTION.Location = new System.Drawing.Point(187, 174);
            this.cbb_FINISH_TRANSACTION.Name = "cbb_FINISH_TRANSACTION";
            this.cbb_FINISH_TRANSACTION.Size = new System.Drawing.Size(100, 21);
            this.cbb_FINISH_TRANSACTION.TabIndex = 35;
            // 
            // txb_ACTIVITY_NAME
            // 
            this.txb_ACTIVITY_NAME.Location = new System.Drawing.Point(15, 69);
            this.txb_ACTIVITY_NAME.Name = "txb_ACTIVITY_NAME";
            this.txb_ACTIVITY_NAME.Size = new System.Drawing.Size(272, 20);
            this.txb_ACTIVITY_NAME.TabIndex = 36;
            this.txb_ACTIVITY_NAME.Text = "1";
            // 
            // FormPasso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 373);
            this.Controls.Add(this.txb_ACTIVITY_NAME);
            this.Controls.Add(this.cbb_FINISH_TRANSACTION);
            this.Controls.Add(this.cbb_CREATE_TRANSACTION);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txb_STEP);
            this.Controls.Add(this.cbb_ID_PROCESS_CHILD);
            this.Controls.Add(this.cbb_ID_ACTIVITY);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txb_CACHE_EVAL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txb_BEFORE_EXECUTE_EVAL);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txb_EXCEPTION_EVAL);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txb_RESULT_EVAL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_NEXT_STEP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_PROPAGATION_TRANSACTION);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormPasso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Passo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_PROPAGATION_TRANSACTION;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_NEXT_STEP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_BEFORE_EXECUTE_EVAL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txb_EXCEPTION_EVAL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txb_RESULT_EVAL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txb_CACHE_EVAL;
        private System.Windows.Forms.ComboBox cbb_ID_ACTIVITY;
        private System.Windows.Forms.ComboBox cbb_ID_PROCESS_CHILD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txb_STEP;
        private System.Windows.Forms.ComboBox cbb_CREATE_TRANSACTION;
        private System.Windows.Forms.ComboBox cbb_FINISH_TRANSACTION;
        private System.Windows.Forms.TextBox txb_ACTIVITY_NAME;
    }
}