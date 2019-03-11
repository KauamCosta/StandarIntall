using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InstallStandard {
    public partial class MainForm : Form {
        private string regkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

        public MainForm() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            string MVS = "Microsoft Windows Vista Business";
            LblOs.Text = (OS());
            if (LblOs.Text != MVS)
            {
                LblOs.ForeColor = System.Drawing.Color.Red;
            }
        }
        

        public string HKLM_GetString(string path, string key) {
            try {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public string OS() {
            string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (ProductName != "") {
                return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                            (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "";
        }        

        private void BtnWG_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\01 - WatchGuard\WG.msi");
            btnWG.Enabled = false;
        }

        public AVdown avd = new AVdown();

        private void BtnAV_Click(object sender, EventArgs e) {            
            if (MessageBox.Show("Realmente deseja Instalar o AntiVirus ?", "Kaspersky", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                avd.Show();
                btnAV.Enabled = false;
            }
            
        }

        private void BtnPDF_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\04 - PDF Creator\PDFCreator.exe");
            BtnPDF.Enabled = false;
        }

        private void BtnRAR_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\05 - Compactador\Winrar 64 Bits 4.2\winrar.exe");
            BtnRAR.Enabled = false;
        }

        private void BtnChrome_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\08 - Google Chrome\ChromeStandaloneSetup64");
            BtnChrome.Enabled = false;
        }

        private void BtnJava_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\10 - Java\java.exe");
            BtnJava.Enabled = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (MessageBox.Show("Realmente deseja fechar?", "StandardInstall", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) {
                e.Cancel = true;
            }
        }

        private void BtnMozila_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\09 - Mozilla\Firefox.exe");
            BtnMozila.Enabled = false;
        }

        private void BtnVNC_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\13 - Ultra VNC\UltraVNC_X86.exe");
            BtnVNC.Enabled = false;
        }

        private void BtnIPM_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\16 - IPM Patrimonio\ipmservicoslocais_windows.exe");
            BtnIPM.Enabled = false;
        }

        private void BtnSpark_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\22 - Chat\spark_2_7_1.exe");
            BtnSpark.Enabled = false;
        }

        AdobeDown AD = new AdobeDown();

        private void BtnAdobes_Click(object sender, EventArgs e) {
            AD.Show();
            BtnAdobes.Enabled = false;
        }

        private void BtnMPC_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\13 - Media Player\MPC_X86.exe");
            BtnMPC.Enabled = false;
        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e){
            Clipboard.SetText("kauamcosta9@gmail.com");
        }

        private void BtnSP3Office_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\02 - Service Pack SO\Windows Vista - SP2\Windows6.0-KB948465-X86 VistaSP2.exe");
            BtnSP3Office.Enabled = false;
        }

        private void BtnOffice7s_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\06 - Microsoft Office\Microsoft Office 2007 Full\Portugues\setup.exe");
            BtnOffice7s.Enabled = false;
            Clipboard.SetText("KGFVY-7733B-8WCK9-KTG64-BC7D8");
        }

        private void BtnOffice7s7_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\06 - Microsoft Office\Microsoft Office 2007 Full\Portugues\setup.exe");
            BtnOffice7s.Enabled = false;
            Clipboard.SetText("KGFVY-7733B-8WCK9-KTG64-BC7D8");
        }

        private void BtnSP3Office7_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\06 - Microsoft Office\06.1 - Service Pack Office\Office 2007 - SP3\office2007sp3-kb2526086-fullfile-pt-br.exe");
            BtnSP3Office.Enabled = false;
        }        
    }
}