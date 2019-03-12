using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Principal;
using Newtonsoft.Json;

namespace InstallStandard {
    public partial class MainForm : Form {
        private string regkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"; //Salva todos os programas instalados na variavel

        public User UsuarioAtual = new User(); /* Declaração do Usuario*/
        public Computer Computador = new Computer(); /* Declaração do Computador*/        
        public AVdown avd = new AVdown(); /* Declaração do formulario de download do anti-virus */
        public AdobeDown AD = new AdobeDown();/* Declaração do formulario de download dos adobes */

        public MainForm() /* Inicializa formulario */ {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) /* Carrega formulario */{
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            UsuarioAtual.NomeUsuario = WindowsIdentity.GetCurrent().Name;
            UsuarioAtual.PrimeiroLogin = DateTime.Today;
            Computador.GravarNomeComputador = Environment.MachineName;
            Json();
        }
        

        public string HKLM_GetString(string path, string key) /* Pega informções dos programas instalados */
        {
            try {
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
            if (ProductName != "") {
                return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                            (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "";
        }

        private void BtnCheck_Click(object sender, EventArgs e)/* Carrega todos os programas instalados e verifica qual OS utilizado */
        {
            lstInstall.Items.Clear();
            int contador = 0;
            string MVS = "Microsoft Windows Vista Business";
            LblOS.Text = (OS());
            if (LblOS.Text != MVS){
                LblOS.ForeColor = System.Drawing.Color.Blue;
            }
            else{
                LblOS.ForeColor = System.Drawing.Color.Yellow;
            }

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

        private void ClickBTN(object sender, EventArgs e)/* Metodo responsavel pelas ações dos botões do win10 */
        {            
            if (OS().Contains("Windows 10")) { 
                switch ((sender as Button).Name)
                {
                    case "BtnWG":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\01 - WatchGuard\WG.msi");
                    BtnWG.Enabled = false;
                    Programas WG = new Programas {
                        Identificador = '1',
                        Instalado = true,
                        NomeDoPrograma = "WatchGuard"
                    };
                    Computador.UltimaInstalacao = DateTime.Now;
                    break;

                    case "btnAV":

                    if (MessageBox.Show("Realmente deseja Instalar o AntiVirus ?", "Kaspersky", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        avd.Show();
                        btnAV.Enabled = false;
                    }
                    break;

                    case "BtnPDF":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\04 - PDF Creator\PDFCreator.exe");
                    BtnPDF.Enabled = false;
                    Programas PDF = new Programas {
                        Identificador = '5',
                        Instalado = true,
                        NomeDoPrograma = "PDF"
                    };
                    Computador.UltimaInstalacao = DateTime.Now;
                    break;

                    case "BtnRAR":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\05 - Compactador\Winrar 64 Bits 4.2\winrar.exe");
                    BtnRAR.Enabled = false;
                    Programas RAR = new Programas {
                        Identificador = '6',
                        Instalado = true,
                        NomeDoPrograma = "RAR"
                    };
                    Computador.UltimaInstalacao = DateTime.Now;
                    break;

                    case "BtnChrome":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\08 - Google Chrome\ChromeStandaloneSetup64");
                    BtnChrome.Enabled = false;
                    Programas Chrome = new Programas {
                        Identificador = '7',
                        Instalado = true,
                        NomeDoPrograma = "Chrome"
                    };
                    Computador.UltimaInstalacao = DateTime.Now;
                    break;

                    case "BtnJava":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\10 - Java\java.exe");
                    BtnJava.Enabled = false;
                    Programas Java = new Programas {
                        Identificador = '2',
                        Instalado = true,
                        NomeDoPrograma = "Java"
                    };
                    Computador.UltimaInstalacao = DateTime.Now;
                    break;

                    case "BtnMozila":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\09 - Mozilla\Firefox.exe");
                    BtnMozila.Enabled = false;
                    Programas Mozilla = new Programas {
                        Identificador = '8',
                        Instalado = true,
                        NomeDoPrograma = "Mozilla"
                    };
                    Computador.UltimaInstalacao = DateTime.Now;
                    break;

                    case "BtnOffice10":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\06 - Microsoft Office\Microsoft Office 2010\setup.exe");
                    BtnOffice10.Enabled = false;
                    Programas Office10 = new Programas {
                        Identificador = '9',
                        Instalado = true,
                        NomeDoPrograma = "Office 10"
                    };
                    Computador.UltimaInstalacao = DateTime.Now;
                    break;

                    case "BtnKMS":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\06 - Microsoft Office\Ativador\Office 2010 Toolkit.7z");
                    BtnKMS.Enabled = false;
                    Programas KMS = new Programas {
                        Identificador = '0',
                        Instalado = true,
                        NomeDoPrograma = "KMS"
                    };
                    Computador.UltimaInstalacao = DateTime.Now;
                    break;

                    case "BtnVNC":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\13 - Ultra VNC\UltraVNC_X64.exe");
                    BtnVNC.Enabled = false;
                    break;

                    case "BtnIPM":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\16 - IPM Patrimonio\ipmservicoslocais_windows.exe");
                    BtnIPM.Enabled = false;
                    break;

                    case "BtnSpark":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\22 - Chat\spark_2_7_1.exe");
                    BtnSpark.Enabled = false;
                    break;

                    case "BtnAdobes":

                    AD.Show();
                    BtnAdobes.Enabled = false;
                    break;

                    case "BtnMPC":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\13 - Media Player\MPC_X64.exe");
                    BtnMPC.Enabled = false;
                    break;

                    case "BtnVLC":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\13 - Media Player\vlc_x86.exe");
                    BtnVLC.Enabled = false;
                    break;

                    case "BtnSP3Office":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\06 - Microsoft Office\06.1 - Service Pack Office\Office 2007 - SP3\office2007sp3-kb2526086-fullfile-pt-br.exe");
                    BtnSP3Office.Enabled = false;
                    break;

                    case "BtnOffice7s":
                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\06 - Microsoft Office\Microsoft Office 2007 Full\Portugues\setup.exe");
                    BtnOffice7s.Enabled = false;
                    Clipboard.SetText("KGFVY-7733B-8WCK9-KTG64-BC7D8");
                    break;

                    case "BtnWinSaude":

                    System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\25 - WinSaude\00-Oracle Client 11g r2\setup.exe");
                    BtnWinSaude.Enabled = false;
                    break;

                    case "BtnSaude":

                    if (MessageBox.Show("Tem certeza que deseja instalar como saúde?", "StandardInstall", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        BtnSaude.Enabled = false;
                        BtnSaude7.Enabled = false;
                        BtnMPC.Visible = false;
                        BtnMPC7.Visible = false;
                        BtnSpark.Visible = false;
                        BtnSpark7.Visible = false;
                        BtnOffice10.Visible = false;
                        BtnOffice10w7.Visible = false;
                        BtnKMS.Visible = false;
                        BtnKMS7.Visible = false;
                        BtnVLC.Visible = true;
                        BtnVLC7.Visible = true;
                        BtnOffice7s.Visible = true;
                        BtnSP3Office.Visible = true;
                        BtnOffice7s7.Visible = true;
                        BtnSP3Office7.Visible = true;
                        BtnWinSaude.Visible = true;
                        BtnWinSaude7.Visible = true;
                    }
                    break;
                }
            }
            else{
                BtnSaude.Enabled = false;
                BtnMPC.Enabled = false;
                BtnSpark.Enabled = false;
                BtnOffice10.Enabled = false;
                BtnKMS.Enabled = false;
                BtnAdobes.Enabled = false;
                BtnWG.Enabled = false;
                BtnVNC.Enabled = false;
                BtnJava.Enabled = false;
                BtnChrome.Enabled = false;
                BtnMozila.Enabled = false;
                BtnPDF.Enabled = false;
                BtnIPM.Enabled = false;
                BtnRAR.Enabled = false;
                BtnSpark.Enabled = false;
                btnAV.Enabled = false;
                lblwin10.ForeColor = Color.Red;
            }
        } 
        
        private void ClickBTNw7(object sender, EventArgs e)/* Metodo responsavel pelas ações dos botões do win7 e outros */
        {
            if (OS().Contains("Windows 7") || OS().Contains("Windows 8")) {
                switch ((sender as Button).Name)
                {
                    case "BtnWG7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\01 - WatchGuard\WG.msi");
                        BtnWG7.Enabled = false;
                        break;

                    case "BtnAV7":

                        if (MessageBox.Show("Realmente deseja Instalar o AntiVirus ?", "Kaspersky", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            avd.Show();
                            BtnAV7.Enabled = false;
                        }
                        break;

                    case "BtnPDF7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\04 - PDF Creator\PDFCreator.exe");
                        BtnPDF7.Enabled = false;
                        break;

                    case "BtnWinRar7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\05 - Compactador\Winrar 64 Bits 4.2\winrar.exe");
                        BtnWinRar7.Enabled = false;
                        break;

                    case "BtnChrome7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\08 - Google Chrome\ChromeStandaloneSetup64");
                        BtnChrome7.Enabled = false;
                        break;

                    case "BtnJava7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\10 - Java\java.exe");
                        BtnJava7.Enabled = false;
                        break;

                    case "BtnMozila7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\09 - Mozilla\Firefox.exe");
                        BtnMozila7.Enabled = false;
                        break;

                    case "BtnOffice10w7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\06 - Microsoft Office\Microsoft Office 2010\setup.exe");
                        BtnOffice10w7.Enabled = false;
                        break;

                    case "BtnKMS7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\06 - Microsoft Office\Ativador\Office 2010 Toolkit.7z");
                        BtnKMS7.Enabled = false;
                        break;

                    case "BtnVNC7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\13 - Ultra VNC\UltraVNC_X64.exe");
                        BtnVNC7.Enabled = false;
                        break;

                    case "BtnIPM7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\16 - IPM Patrimonio\ipmservicoslocais_windows.exe");
                        BtnIPM7.Enabled = false;
                        break;

                    case "BtnSpark7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\22 - Chat\spark_2_7_1.exe");
                        BtnSpark7.Enabled = false;
                        break;

                    case "BtnAdobes7":

                        AD.Show();
                        BtnAdobes7.Enabled = false;
                        break;

                    case "BtnMPC7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\13 - Media Player\MPC_X64.exe");
                        BtnMPC7.Enabled = false;
                        break;

                    case "BtnVLC7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\13 - Media Player\vlc_x86.exe");
                        BtnVLC7.Enabled = false;
                        break;

                    case "BtnSP3Office7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\06 - Microsoft Office\06.1 - Service Pack Office\Office 2007 - SP3\office2007sp3-kb2526086-fullfile-pt-br.exe");
                        BtnSP3Office7.Enabled = false;
                        break;

                    case "BtnWinSaude7":

                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\25 - WinSaude\00-Oracle Client 11g r2\setup.exe");
                        BtnWinSaude7.Enabled = false;
                        break;

                    case "BtnOffice7s7":
                        System.Diagnostics.Process.Start(@"Y:\Software\Instalacao Padrao\06 - Microsoft Office\Microsoft Office 2007 Full\Portugues\setup.exe");
                        BtnOffice7s7.Enabled = false;
                        Clipboard.SetText("KGFVY-7733B-8WCK9-KTG64-BC7D8");
                        break;

                    case "BtnSaude7":

                        if (MessageBox.Show("Tem certeza que deseja instalar como saúde?", "StandardInstall", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            BtnSaude.Enabled = false;
                            BtnSaude7.Enabled = false;
                            BtnMPC.Visible = false;
                            BtnMPC7.Visible = false;
                            BtnSpark.Visible = false;
                            BtnSpark7.Visible = false;
                            BtnOffice10.Visible = false;
                            BtnOffice10w7.Visible = false;
                            BtnKMS.Visible = false;
                            BtnKMS7.Visible = false;
                            BtnVLC.Visible = true;
                            BtnVLC7.Visible = true;
                            BtnOffice7s.Visible = true;
                            BtnSP3Office.Visible = true;
                            BtnOffice7s7.Visible = true;
                            BtnSP3Office7.Visible = true;
                            BtnWinSaude.Visible = true;
                            BtnWinSaude7.Visible = true;
                        }
                        break;
                }
            }
            else{
                BtnSaude7.Enabled = false;
                BtnMPC7.Enabled = false;
                BtnSpark7.Enabled = false;
                BtnOffice10w7.Enabled = false;
                BtnKMS7.Enabled = false;
                BtnAdobes7.Enabled = false;
                BtnWG7.Enabled = false;
                BtnVNC7.Enabled = false;
                BtnJava7.Enabled = false;
                BtnChrome7.Enabled = false;
                BtnMozila7.Enabled = false;
                BtnPDF7.Enabled = false;
                BtnIPM7.Enabled = false;
                BtnWinRar7.Enabled = false;
                BtnSpark7.Enabled = false;
                BtnAV7.Enabled = false;
                label1.ForeColor = Color.Red;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)/* Responsavel por perguntar se o usuario deseja realmente fechar o IntallStandard */
        {
            if (MessageBox.Show("Realmente deseja fechar?", "StandardInstall", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)/* Não mexer */
        {
            Clipboard.SetText("kauamcosta9@gmail.com");
        }

        private void Json() {

            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(@"C:\Temp\StandarInstall\json.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw)) {
                serializer.Serialize(writer, UsuarioAtual);
                serializer.Serialize(writer, Computador);
            }
        }
    }    
}