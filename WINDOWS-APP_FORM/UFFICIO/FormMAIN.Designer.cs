
namespace UFFICIO
{
    partial class FormMAIN
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMAIN));
            this.btnTEST = new System.Windows.Forms.Button();
            this.btnAddAttiva = new System.Windows.Forms.Button();
            this.btnInfoCommessa = new System.Windows.Forms.Button();
            this.btnCrea = new System.Windows.Forms.Button();
            this.btnStorico = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtMessaggioOperatore = new System.Windows.Forms.RichTextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMessaggioOperatore = new System.Windows.Forms.RichTextBox();
            this.btnAggiungiCommessa = new System.Windows.Forms.Button();
            this.BtnResetta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTEST
            // 
            this.btnTEST.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTEST.BackgroundImage")));
            this.btnTEST.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTEST.Location = new System.Drawing.Point(632, 37);
            this.btnTEST.Margin = new System.Windows.Forms.Padding(2);
            this.btnTEST.Name = "btnTEST";
            this.btnTEST.Size = new System.Drawing.Size(129, 115);
            this.btnTEST.TabIndex = 0;
            this.btnTEST.UseVisualStyleBackColor = true;
            this.btnTEST.Click += new System.EventHandler(this.btnTEST_Click);
            // 
            // btnAddAttiva
            // 
            this.btnAddAttiva.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddAttiva.BackgroundImage")));
            this.btnAddAttiva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddAttiva.Location = new System.Drawing.Point(493, 37);
            this.btnAddAttiva.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddAttiva.Name = "btnAddAttiva";
            this.btnAddAttiva.Size = new System.Drawing.Size(131, 116);
            this.btnAddAttiva.TabIndex = 1;
            this.btnAddAttiva.UseVisualStyleBackColor = true;
            this.btnAddAttiva.Click += new System.EventHandler(this.btnAddAttiva_Click);
            // 
            // btnInfoCommessa
            // 
            this.btnInfoCommessa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInfoCommessa.BackgroundImage")));
            this.btnInfoCommessa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnInfoCommessa.Location = new System.Drawing.Point(493, 175);
            this.btnInfoCommessa.Margin = new System.Windows.Forms.Padding(2);
            this.btnInfoCommessa.Name = "btnInfoCommessa";
            this.btnInfoCommessa.Size = new System.Drawing.Size(267, 70);
            this.btnInfoCommessa.TabIndex = 2;
            this.btnInfoCommessa.UseVisualStyleBackColor = true;
            this.btnInfoCommessa.Click += new System.EventHandler(this.btnInfoCommessa_Click);
            // 
            // btnCrea
            // 
            this.btnCrea.Image = ((System.Drawing.Image)(resources.GetObject("btnCrea.Image")));
            this.btnCrea.Location = new System.Drawing.Point(490, 381);
            this.btnCrea.Margin = new System.Windows.Forms.Padding(2);
            this.btnCrea.Name = "btnCrea";
            this.btnCrea.Size = new System.Drawing.Size(129, 115);
            this.btnCrea.TabIndex = 4;
            this.btnCrea.UseVisualStyleBackColor = true;
            this.btnCrea.Click += new System.EventHandler(this.btnCrea_Click);
            // 
            // btnStorico
            // 
            this.btnStorico.Image = ((System.Drawing.Image)(resources.GetObject("btnStorico.Image")));
            this.btnStorico.Location = new System.Drawing.Point(632, 381);
            this.btnStorico.Margin = new System.Windows.Forms.Padding(2);
            this.btnStorico.Name = "btnStorico";
            this.btnStorico.Size = new System.Drawing.Size(132, 115);
            this.btnStorico.TabIndex = 9;
            this.btnStorico.UseVisualStyleBackColor = true;
            this.btnStorico.Click += new System.EventHandler(this.btnStorico_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 294);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(451, 202);
            this.dataGridView1.TabIndex = 10;
            // 
            // txtMessaggioOperatore
            // 
            this.txtMessaggioOperatore.Location = new System.Drawing.Point(15, 149);
            this.txtMessaggioOperatore.Name = "txtMessaggioOperatore";
            this.txtMessaggioOperatore.Size = new System.Drawing.Size(448, 96);
            this.txtMessaggioOperatore.TabIndex = 11;
            this.txtMessaggioOperatore.Text = "";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 29);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(451, 74);
            this.dataGridView2.TabIndex = 12;
            this.dataGridView2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Dati Commessa Attiva";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Inserisci messaggio per operatore";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Dati Commesse In Attesa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(629, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Modifica la commessa Attiva";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(487, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Avvia la Commessa Attiva";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(493, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Messaggio dell\'operatore";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(487, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Aggiungi Nuova Commessa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(629, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Commesse Completate";
            // 
            // lblMessaggioOperatore
            // 
            this.lblMessaggioOperatore.Location = new System.Drawing.Point(490, 272);
            this.lblMessaggioOperatore.Name = "lblMessaggioOperatore";
            this.lblMessaggioOperatore.ReadOnly = true;
            this.lblMessaggioOperatore.Size = new System.Drawing.Size(271, 91);
            this.lblMessaggioOperatore.TabIndex = 21;
            this.lblMessaggioOperatore.Text = "";
            // 
            // btnAggiungiCommessa
            // 
            this.btnAggiungiCommessa.Location = new System.Drawing.Point(312, 251);
            this.btnAggiungiCommessa.Name = "btnAggiungiCommessa";
            this.btnAggiungiCommessa.Size = new System.Drawing.Size(151, 36);
            this.btnAggiungiCommessa.TabIndex = 22;
            this.btnAggiungiCommessa.Text = "Aggiungi la commessa in coda";
            this.btnAggiungiCommessa.UseVisualStyleBackColor = true;
            this.btnAggiungiCommessa.Click += new System.EventHandler(this.btnAggiungiCommessa_Click);
            // 
            // BtnResetta
            // 
            this.BtnResetta.Location = new System.Drawing.Point(312, 109);
            this.BtnResetta.Name = "BtnResetta";
            this.BtnResetta.Size = new System.Drawing.Size(151, 34);
            this.BtnResetta.TabIndex = 23;
            this.BtnResetta.Text = "Disattiva Commessa";
            this.BtnResetta.UseVisualStyleBackColor = true;
            this.BtnResetta.Click += new System.EventHandler(this.BtnResetta_Click);
            // 
            // FormMAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 508);
            this.Controls.Add(this.BtnResetta);
            this.Controls.Add(this.btnAggiungiCommessa);
            this.Controls.Add(this.lblMessaggioOperatore);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.txtMessaggioOperatore);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnStorico);
            this.Controls.Add(this.btnCrea);
            this.Controls.Add(this.btnInfoCommessa);
            this.Controls.Add(this.btnAddAttiva);
            this.Controls.Add(this.btnTEST);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMAIN";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.FormMAIN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTEST;
        private System.Windows.Forms.Button btnAddAttiva;
        private System.Windows.Forms.Button btnInfoCommessa;
        private System.Windows.Forms.Button btnCrea;
        private System.Windows.Forms.Button btnStorico;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox txtMessaggioOperatore;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox lblMessaggioOperatore;
        private System.Windows.Forms.Button btnAggiungiCommessa;
        private System.Windows.Forms.Button BtnResetta;
    }
}

