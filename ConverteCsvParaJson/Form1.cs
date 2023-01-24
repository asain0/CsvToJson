using ConverteCsvParaJson.Model;
using ConverteCsvParaJson.Model.Csv;
using ConverteCsvParaJson.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConverteCsvParaJson
{
    public partial class Form1 : Form
    {
        string[] selectedFiles;
        string saidaJson = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInformarCaminho_Click(object sender, EventArgs e)
        {
            txtPreviewJson.Text = "";
            string caminhoSelecionado = lblSelectedPath.Text;

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                caminhoSelecionado = dialog.SelectedPath;
                btnConverterJson.Visible = true;
                btnImportar.Text = "Mudar Caminho";
                saidaJson = "";
            }

            //exibindo caminho no label
            lblSelectedPath.Text = caminhoSelecionado;

            //2 - Listar arquivos
            selectedFiles = Directory.GetFiles(caminhoSelecionado, "*.csv");
            txtPreviewJson.Lines = selectedFiles;

        }

        private void btnConverterJson_Click(object sender, EventArgs e)
        {
            List<WorkRegister> arquivosLidos = CsvHandler.ReadFilesList(selectedFiles);

            List<PaymentOrder> paymentOrderList = DataProcess.PaymentOrderProcess(arquivosLidos);
           
            saidaJson = JsonCreate.PrepareContent(paymentOrderList);

            txtPreviewJson.Text = saidaJson;

            btnGerarArquivo.Visible = true;
            lblInformeArquivo.Visible = true;
            lblOutputNameFile.Visible = true;
            txtOutputNameFile.Visible = true;
            lblExtensionOutputFile.Visible = true;
        }

        private void btnGerarArquivo_Click(object sender, EventArgs e)
        {
            if (saidaJson == "")
                MessageBox.Show("Nenhum arquivo convertido ainda!");
            else
            {
                if (txtOutputNameFile.Text.Trim() == "")
                {
                    MessageBox.Show("Nome de arquivo de saída, inválido");
                }
                else
                {
                    string exitPath = lblSelectedPath.Text + "//" + txtOutputNameFile.Text;
                    JsonCreate.SaveJsonFile(exitPath, saidaJson);
                }
            }
        }
    }
}
