using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Net;
using System.IO;

namespace InstallStandard {
    public partial class MainForm : Form {
        private string regkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

        public MainForm() {
            InitializeComponent();
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (MessageBox.Show("Do you want to save changes to your text?", "My Application",
                MessageBoxButtons.YesNo) == DialogResult.Yes) {
                e.Cancel = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e) {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            return Form1_Closing();
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

        private void BtnCheck_Click(object sender, EventArgs e) {
            lstInstall.Items.Clear();
            int contador = 0;

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(regkey)) {
                var query = from a in
                                 key.GetSubKeyNames()
                            let r = key.OpenSubKey(a)
                            select new {
                                Application = r.GetValue("DisplayName")
                            };
                foreach (var item in query) {
                    if (item.Application != null)
                        lstInstall.Items.Add(item.Application);
                    contador++;
                }
            }
            lblCount.Text = contador + " Aplicações instaladas ";
        }

        private void BtnWG_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\01 - WatchGuard\WG.msi");
            if (!Directory.Exists(@"C:/CCleaner"))
                Directory.CreateDirectory(@"C:/CCleaner");
            System.IO.File.Copy(@"Y:/Software/Instalacao Padrao/27 - Ccleaner", @"C:/CCleaner");

        }

        public AVdown avd = new AVdown();

        private void btnAV_Click(object sender, EventArgs e) {            
            if (MessageBox.Show("Realmente deseja Instalar o AntiVirus ?", "Kaspersky", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                avd.Show();                
            }
            btnAV.Enabled = (false);
        }

        private void BtnPDF_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\04 - PDF Creator\PDFCreator - 3_0_1 - Setup.exe");
            BtnPDF.Enabled = (false);
        }

        private void BtnRAR_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\05 - Compactador\Winrar 64 Bits 4.2\winrar-x64-420br.exe");
            BtnRAR.Enabled = (false);
        }

        private void BtnChrome_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\08 - Google Chrome\ChromeStandaloneSetup64_v66.exe");
            BtnChrome.Enabled = (false);
        }

        private void BtnJava_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\10 - Java\java.exe");
            BtnJava.Enabled = (false);
        }
    }
}