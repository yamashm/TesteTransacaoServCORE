namespace TesteTransacaoServCORE
{
    partial class FormEditar
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbb_category = new System.Windows.Forms.ComboBox();
            this.cbb_trn_group = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ckbUpdate = new System.Windows.Forms.CheckBox();
            this.cbb_id_process = new System.Windows.Forms.ComboBox();
            this.cbb_seq_flow = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaidas = new System.Windows.Forms.Button();
            this.btnEntradas = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_shortdescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_description = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_id_channel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_id_if_input_output = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_id_if_permissoes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_nu_transacao = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbb_category);
            this.groupBox1.Controls.Add(this.cbb_trn_group);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.ckbUpdate);
            this.groupBox1.Controls.Add(this.cbb_id_process);
            this.groupBox1.Controls.Add(this.cbb_seq_flow);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnSaidas);
            this.groupBox1.Controls.Add(this.btnEntradas);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txb_shortdescription);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txb_description);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txb_id_channel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txb_id_if_input_output);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txb_id_if_permissoes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txb_nu_transacao);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados nova transação";
            // 
            // cbb_category
            // 
            this.cbb_category.FormattingEnabled = true;
            this.cbb_category.Items.AddRange(new object[] {
            "S",
            "T"});
            this.cbb_category.Location = new System.Drawing.Point(267, 207);
            this.cbb_category.Name = "cbb_category";
            this.cbb_category.Size = new System.Drawing.Size(100, 21);
            this.cbb_category.TabIndex = 23;
            // 
            // cbb_trn_group
            // 
            this.cbb_trn_group.FormattingEnabled = true;
            this.cbb_trn_group.Location = new System.Drawing.Point(92, 208);
            this.cbb_trn_group.Name = "cbb_trn_group";
            this.cbb_trn_group.Size = new System.Drawing.Size(100, 21);
            this.cbb_trn_group.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "trn_group";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(213, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "category";
            // 
            // ckbUpdate
            // 
            this.ckbUpdate.AutoSize = true;
            this.ckbUpdate.Location = new System.Drawing.Point(234, 26);
            this.ckbUpdate.Name = "ckbUpdate";
            this.ckbUpdate.Size = new System.Drawing.Size(151, 17);
            this.ckbUpdate.TabIndex = 19;
            this.ckbUpdate.Text = "Update Logical Evaluation";
            this.ckbUpdate.UseVisualStyleBackColor = true;
            // 
            // cbb_id_process
            // 
            this.cbb_id_process.FormattingEnabled = true;
            this.cbb_id_process.Location = new System.Drawing.Point(267, 128);
            this.cbb_id_process.Name = "cbb_id_process";
            this.cbb_id_process.Size = new System.Drawing.Size(100, 21);
            this.cbb_id_process.TabIndex = 18;
            this.cbb_id_process.SelectedIndexChanged += new System.EventHandler(this.cbb_id_process_SelectedIndexChanged);
            // 
            // cbb_seq_flow
            // 
            this.cbb_seq_flow.FormattingEnabled = true;
            this.cbb_seq_flow.Location = new System.Drawing.Point(92, 129);
            this.cbb_seq_flow.Name = "cbb_seq_flow";
            this.cbb_seq_flow.Size = new System.Drawing.Size(100, 21);
            this.cbb_seq_flow.TabIndex = 17;
            this.cbb_seq_flow.SelectedIndexChanged += new System.EventHandler(this.cbb_seq_flow_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "seq_flow";
            // 
            // btnSaidas
            // 
            this.btnSaidas.Location = new System.Drawing.Point(199, 260);
            this.btnSaidas.Name = "btnSaidas";
            this.btnSaidas.Size = new System.Drawing.Size(186, 23);
            this.btnSaidas.TabIndex = 15;
            this.btnSaidas.Text = "Saidas";
            this.btnSaidas.UseVisualStyleBackColor = true;
            this.btnSaidas.Click += new System.EventHandler(this.btnSaidas_Click);
            // 
            // btnEntradas
            // 
            this.btnEntradas.Location = new System.Drawing.Point(7, 260);
            this.btnEntradas.Name = "btnEntradas";
            this.btnEntradas.Size = new System.Drawing.Size(186, 23);
            this.btnEntradas.TabIndex = 14;
            this.btnEntradas.Text = "Entradas";
            this.btnEntradas.UseVisualStyleBackColor = true;
            this.btnEntradas.Click += new System.EventHandler(this.btnEntradas_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "shortdescription";
            // 
            // txb_shortdescription
            // 
            this.txb_shortdescription.Location = new System.Drawing.Point(92, 181);
            this.txb_shortdescription.Name = "txb_shortdescription";
            this.txb_shortdescription.Size = new System.Drawing.Size(275, 20);
            this.txb_shortdescription.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "description";
            // 
            // txb_description
            // 
            this.txb_description.Location = new System.Drawing.Point(92, 155);
            this.txb_description.Name = "txb_description";
            this.txb_description.Size = new System.Drawing.Size(275, 20);
            this.txb_description.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "id_process";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "id_channel";
            // 
            // txb_id_channel
            // 
            this.txb_id_channel.Location = new System.Drawing.Point(92, 103);
            this.txb_id_channel.Name = "txb_id_channel";
            this.txb_id_channel.Size = new System.Drawing.Size(100, 20);
            this.txb_id_channel.TabIndex = 6;
            this.txb_id_channel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "id_if_in_out";
            // 
            // txb_id_if_input_output
            // 
            this.txb_id_if_input_output.Location = new System.Drawing.Point(92, 77);
            this.txb_id_if_input_output.Name = "txb_id_if_input_output";
            this.txb_id_if_input_output.Size = new System.Drawing.Size(100, 20);
            this.txb_id_if_input_output.TabIndex = 4;
            this.txb_id_if_input_output.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "id_if_perm";
            // 
            // txb_id_if_permissoes
            // 
            this.txb_id_if_permissoes.Location = new System.Drawing.Point(92, 51);
            this.txb_id_if_permissoes.Name = "txb_id_if_permissoes";
            this.txb_id_if_permissoes.Size = new System.Drawing.Size(100, 20);
            this.txb_id_if_permissoes.TabIndex = 2;
            this.txb_id_if_permissoes.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "nu_transacao";
            // 
            // txb_nu_transacao
            // 
            this.txb_nu_transacao.Location = new System.Drawing.Point(92, 23);
            this.txb_nu_transacao.Name = "txb_nu_transacao";
            this.txb_nu_transacao.Size = new System.Drawing.Size(100, 20);
            this.txb_nu_transacao.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(337, 307);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(256, 307);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FormEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 342);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_shortdescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_description;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_id_channel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_id_if_input_output;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_id_if_permissoes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_nu_transacao;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnSaidas;
        private System.Windows.Forms.Button btnEntradas;
        private System.Windows.Forms.ComboBox cbb_seq_flow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbb_id_process;
        private System.Windows.Forms.CheckBox ckbUpdate;
        private System.Windows.Forms.ComboBox cbb_category;
        private System.Windows.Forms.ComboBox cbb_trn_group;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}