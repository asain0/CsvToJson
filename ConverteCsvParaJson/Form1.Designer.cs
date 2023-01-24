namespace ConverteCsvParaJson
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
            this.lblInformeArquivo = new System.Windows.Forms.Label();
            this.btnImportar = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblSelectedPath = new System.Windows.Forms.Label();
            this.btnConverterJson = new System.Windows.Forms.Button();
            this.txtOutputNameFile = new System.Windows.Forms.TextBox();
            this.lblOutputNameFile = new System.Windows.Forms.Label();
            this.lblExtensionOutputFile = new System.Windows.Forms.Label();
            this.btnGerarArquivo = new System.Windows.Forms.Button();
            this.txtPreviewJson = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblInformeArquivo
            // 
            this.lblInformeArquivo.AutoSize = true;
            this.lblInformeArquivo.Location = new System.Drawing.Point(9, 26);
            this.lblInformeArquivo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInformeArquivo.Name = "lblInformeArquivo";
            this.lblInformeArquivo.Size = new System.Drawing.Size(157, 13);
            this.lblInformeArquivo.TabIndex = 1;
            this.lblInformeArquivo.Text = "Informe o caminho dos arquivos";
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(13, 45);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(140, 19);
            this.btnImportar.TabIndex = 2;
            this.btnImportar.Text = "Selecionar caminho";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnInformarCaminho_Click);
            // 
            // lblSelectedPath
            // 
            this.lblSelectedPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedPath.AutoSize = true;
            this.lblSelectedPath.Location = new System.Drawing.Point(156, 47);
            this.lblSelectedPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedPath.Name = "lblSelectedPath";
            this.lblSelectedPath.Size = new System.Drawing.Size(22, 13);
            this.lblSelectedPath.TabIndex = 3;
            this.lblSelectedPath.Text = "C:\\";
            // 
            // btnConverterJson
            // 
            this.btnConverterJson.Location = new System.Drawing.Point(13, 68);
            this.btnConverterJson.Margin = new System.Windows.Forms.Padding(2);
            this.btnConverterJson.Name = "btnConverterJson";
            this.btnConverterJson.Size = new System.Drawing.Size(140, 19);
            this.btnConverterJson.TabIndex = 5;
            this.btnConverterJson.Text = "Converter para JSON";
            this.btnConverterJson.UseVisualStyleBackColor = true;
            this.btnConverterJson.Visible = false;
            this.btnConverterJson.Click += new System.EventHandler(this.btnConverterJson_Click);
            // 
            // txtOutputNameFile
            // 
            this.txtOutputNameFile.Location = new System.Drawing.Point(297, 90);
            this.txtOutputNameFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutputNameFile.Name = "txtOutputNameFile";
            this.txtOutputNameFile.Size = new System.Drawing.Size(147, 20);
            this.txtOutputNameFile.TabIndex = 6;
            this.txtOutputNameFile.Text = "OrdensDePagamento";
            this.txtOutputNameFile.Visible = false;
            // 
            // lblOutputNameFile
            // 
            this.lblOutputNameFile.AutoSize = true;
            this.lblOutputNameFile.Location = new System.Drawing.Point(157, 94);
            this.lblOutputNameFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutputNameFile.Name = "lblOutputNameFile";
            this.lblOutputNameFile.Size = new System.Drawing.Size(136, 13);
            this.lblOutputNameFile.TabIndex = 7;
            this.lblOutputNameFile.Text = "Nome do arquivo de saída:";
            this.lblOutputNameFile.Visible = false;
            // 
            // lblExtensionOutputFile
            // 
            this.lblExtensionOutputFile.AutoSize = true;
            this.lblExtensionOutputFile.Location = new System.Drawing.Point(448, 94);
            this.lblExtensionOutputFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExtensionOutputFile.Name = "lblExtensionOutputFile";
            this.lblExtensionOutputFile.Size = new System.Drawing.Size(38, 13);
            this.lblExtensionOutputFile.TabIndex = 8;
            this.lblExtensionOutputFile.Text = ".JSON";
            this.lblExtensionOutputFile.Visible = false;
            // 
            // btnGerarArquivo
            // 
            this.btnGerarArquivo.Location = new System.Drawing.Point(13, 91);
            this.btnGerarArquivo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGerarArquivo.Name = "btnGerarArquivo";
            this.btnGerarArquivo.Size = new System.Drawing.Size(140, 19);
            this.btnGerarArquivo.TabIndex = 9;
            this.btnGerarArquivo.Text = "GerarArquivo";
            this.btnGerarArquivo.UseVisualStyleBackColor = true;
            this.btnGerarArquivo.Visible = false;
            this.btnGerarArquivo.Click += new System.EventHandler(this.btnGerarArquivo_Click);
            // 
            // txtPreviewJson
            // 
            this.txtPreviewJson.Location = new System.Drawing.Point(13, 122);
            this.txtPreviewJson.Margin = new System.Windows.Forms.Padding(2);
            this.txtPreviewJson.Name = "txtPreviewJson";
            this.txtPreviewJson.ReadOnly = true;
            this.txtPreviewJson.Size = new System.Drawing.Size(717, 388);
            this.txtPreviewJson.TabIndex = 10;
            this.txtPreviewJson.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 521);
            this.Controls.Add(this.txtPreviewJson);
            this.Controls.Add(this.btnGerarArquivo);
            this.Controls.Add(this.lblExtensionOutputFile);
            this.Controls.Add(this.lblOutputNameFile);
            this.Controls.Add(this.txtOutputNameFile);
            this.Controls.Add(this.btnConverterJson);
            this.Controls.Add(this.lblSelectedPath);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.lblInformeArquivo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Ordem de Pagamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblInformeArquivo;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblSelectedPath;
        private System.Windows.Forms.Button btnConverterJson;
        private System.Windows.Forms.TextBox txtOutputNameFile;
        private System.Windows.Forms.Label lblOutputNameFile;
        private System.Windows.Forms.Label lblExtensionOutputFile;
        private System.Windows.Forms.Button btnGerarArquivo;
        private System.Windows.Forms.RichTextBox txtPreviewJson;
    }
}

