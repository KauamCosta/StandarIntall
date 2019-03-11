using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace InstallStandard {
    public partial class AdobeDown : Form {
        public AdobeDown()/* Inicializa formulario */{
            InitializeComponent();
        }

        WebClient web = new WebClient(); /* Obrigatorio quando existe download */
        int i; /* Variavel contadora */

        private void AdobeDown_Load(object sender, EventArgs e)/* Carregamento do formulario e analise dos programas ja baixados */
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            i = 0;
            web.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Web_DownloadProgressChanged);
            web.DownloadFileCompleted += new AsyncCompletedEventHandler(Web_DownloadFileCompleted);
            if (!Directory.Exists(@"C:/Temp/StandarInstall/ADB")) {
                Directory.CreateDirectory(@"C:/Temp/StandarInstall/ADB");
            }
            if (File.Exists(@"C:\Temp\StandarInstall\ADB\readerdc_br_xa_crd_install.exe")) {
                btnIReader.Enabled = true;
                btnReader.Enabled = false;
                PgbADB.Value = 0;
                lbldown.Text = "";
                i++;
            }
            if (File.Exists(@"C:\Temp\StandarInstall\ADB\shock.exe")) {
                btnIShock.Enabled = true;
                btnShock.Enabled = false;
                PgbADB.Value = 0;
                lbldown.Text = "";
                i++;
            }
            if (File.Exists(@"C:\Temp\StandarInstall\ADB\air.exe")) {
                btnIAir.Enabled = true;
                btnAir.Enabled = false;
                PgbADB.Value = 0;
                lbldown.Text = "";
                i++;
            }
            if (File.Exists(@"C:\Temp\StandarInstall\ADB\flashplayer32pp_xa_install.exe")) {
                btnIFlash.Enabled = true;
                btnFlash.Enabled = false;
                PgbADB.Value = 0;
                lbldown.Text = "";
                i++;
            }
            
            if (i == 6){
                lbldown.Text = "Já baixados";
            }
        }

        private int a = 0, /* Variaveis para analise de instalados */
                    b = 0,
                    c = 0,
                    d = 0,
                    ee = 0,
                    f = 0;

        private void Web_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)/* Metodo responsavel pelos downloads */{
            if (e.Error == null) {                
                if (File.Exists(@"C:\Temp\StandarInstall\ADB\readerdc_br_xa_crd_install.exe") && a == 0) {
                    btnIReader.Enabled = true;
                    btnReader.Enabled = false;
                    PgbADB.Value = 0;
                    lbldown.Text = "";
                }
                if (File.Exists(@"C:\Temp\StandarInstall\ADB\shock.exe") && b == 0) {
                    btnIShock.Enabled = true;
                    btnShock.Enabled = false;
                    PgbADB.Value = 0;
                    lbldown.Text = "";
                }
                if (File.Exists(@"C:\Temp\StandarInstall\ADB\air.exe") && c == 0) {
                    btnIAir.Enabled = true;
                    btnAir.Enabled = false;
                    PgbADB.Value = 0;
                    lbldown.Text = "";
                }
                if (File.Exists(@"C:\Temp\StandarInstall\ADB\flashplayer32pp_xa_install.exe") && d == 0) {
                    btnIFlash.Enabled = true;
                    btnFlash.Enabled = false;
                    PgbADB.Value = 0;
                    lbldown.Text = "";
                }
                if (File.Exists(@"C:/Temp/StandarInstall/ADB/flashplayer32_xa_install.exe") && ee == 0)
                {
                    button1.Enabled = true;
                    button4.Enabled = false;
                    PgbADB.Value = 0;
                    lbldown.Text = "";
                }
                if (File.Exists(@"C:\Temp\StandarInstall\ADB\flashplayer32ax_xa_install.exe") && f == 0)
                {
                    button2.Enabled = true;
                    button3.Enabled = false;
                    PgbADB.Value = 0;
                    lbldown.Text = "";
                }
            }
        }

        private void Web_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) /* Metodo responsavel pela barra de progresso */{
            PgbADB.Maximum = (int)e.TotalBytesToReceive;
            PgbADB.Value = (int)e.BytesReceived;
        }

        private void BtnReader_Click(object sender, EventArgs e)/* Metodo responsavel pelo donwload do reader */ {
            web.DownloadFileAsync(new Uri("https://admdownload.adobe.com/bin/live/readerdc_br_xa_crd_install.exe"), @"C:/Temp/StandarInstall/ADB/readerdc_br_xa_crd_install.exe");
            lbldown.Text = "Baixando";
        }

        private void BtnIReader_Click(object sender, EventArgs e)/* Metodo responsavel pela execução e deshabilitação do botao do reader */ {
            System.Diagnostics.Process.Start(@"C:/Temp/StandarInstall/ADB/readerdc_br_xa_crd_install.exe");
            btnIReader.Enabled = false;
            a = 1;
        }        

        private void BtnShock_Click(object sender, EventArgs e)/* Metodo responsavel pelo donwload do Shockwave */ {
            web.DownloadFileAsync(new Uri("https://fpdownload.macromedia.com/get/shockwave/default/english/win95nt/latest/Shockwave_Installer_Full.exe"), @"C:/Temp/StandarInstall/ADB/shock.exe");
            lbldown.Text = "Baixando";
            btnShock.Enabled = false;
        }

        private void BtnIShock_Click(object sender, EventArgs e)/* Metodo responsavel pela execução e deshabilitação do botao do Shockwave */ {
            System.Diagnostics.Process.Start(@"C:/Temp/StandarInstall/ADB/shock.exe");
            btnIShock.Enabled = false;
            b = 1;
        }

        private void BtnAir_Click(object sender, EventArgs e)/* Metodo responsavel pelo donwload do Air */ {
            web.DownloadFileAsync(new Uri("https://airdownload.adobe.com/air/win/download/30.0/AdobeAIRInstaller.exe"), @"C:/Temp/StandarInstall/ADB/air.exe");
            lbldown.Text = "Baixando";
        }

        private void BtnIAir_Click(object sender, EventArgs e)/* Metodo responsavel pela execução e deshabilitação do botao do air */  {
            System.Diagnostics.Process.Start(@"C:/Temp/StandarInstall/ADB/air.exe");
            btnIAir.Enabled = false;
            c = 1;

        }

        private void BtnFlash_Click(object sender, EventArgs e)/* Metodo responsavel pelo donwload do Flash (BTN 1,2,3 E 4 TBM FAZEM O MESMO) */ {
            web.DownloadFileAsync(new Uri("https://admdownload.adobe.com/bin/live/flashplayer31pp_xa_install.exe"), @"C:/Temp/StandarInstall/ADB/flashplayer32pp_xa_install.exe");
            lbldown.Text = "Baixando";
        }

        private void BtnIFlash_Click(object sender, EventArgs e)/* Metodo responsavel pela execução e deshabilitação do botao do Flash */ {
            System.Diagnostics.Process.Start(@"C:/Temp/StandarInstall/ADB/flashplayer32pp_xa_install.exe");
            btnIFlash.Enabled = false;
            d = 1;
        }

        private void button4_Click(object sender, EventArgs e) {
            web.DownloadFileAsync(new Uri("https://admdownload.adobe.com/bin/live/flashplayer31_xa_install.exe"), @"C:/Temp/StandarInstall/ADB/flashplayer32_xa_install.exe");
            lbldown.Text = "Baixando";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (OS().Contains("Windows 10"))
            {
                button2.Enabled = false;
                button3.Enabled = false;
                lbldown.Text = "Incompativel";
                label6.ForeColor = Color.Red;
            }
            else { 

            web.DownloadFileAsync(new Uri("https://admdownload.adobe.com/bin/live/flashplayer31ax_xa_install.exe"), @"C:/Temp/StandarInstall/ADB/flashplayer32ax_xa_install.exe");
            lbldown.Text = "Baixando";

            }
        }

        private void button1_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"C:/Temp/StandarInstall/ADB/flashplayer32_xa_install.exe");
            button1.Enabled = false;
            ee = 1;
        }

        private string regkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"; //Salva todos os programas instalados na variavel
        
        public string HKLM_GetString(string path, string key) /* Pega informções dos programas instalados */
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public string OS() /* Pega o sistema operacional acessivel metodo OS */
        {
            string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (ProductName != "")
            {
                return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                            (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "";
        }

        private void button2_Click(object sender, EventArgs e) {
            
            System.Diagnostics.Process.Start(@"C:/Temp/StandarInstall/ADB/flashplayer32ax_xa_install.exe");
            button2.Enabled = false;
            f = 1;
        }

        private void AdobeDown_FormClosing(object sender, FormClosingEventArgs e)/* Responsavel por pergunta ao usuario se realmente deseja fechar o formulario de download dos adobes */
        {
            if (MessageBox.Show("Realmente deseja fechar?", "Adobes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
