using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace InstallStandard {
    public partial class AVdown : Form {
        public AVdown()/* Inicializa formulario */
        {
            InitializeComponent();
        }

        private void AVdown_Load(object sender, EventArgs e)/* Carrega formulario */
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            WebClient web = new WebClient();
            web.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Web_DownloadProgressChanged);
            web.DownloadFileCompleted += new AsyncCompletedEventHandler(Web_DownloadFileCompleted);
            if (!Directory.Exists(@"C:/Temp/StandarInstall/AV")) {
                Directory.CreateDirectory(@"C:/Temp/StandarInstall/AV");
            }
            web.DownloadFileAsync(new Uri("http://srvantivirus.pinhais.pr.gov.br:8060/dlpkg?id=17530603"), @"C:/Temp/StandarInstall/AV/kaspersky.exe");
        }

        private void Web_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)/* Faz o download automaticamente */
        {
            if (e.Error == null) {
                lblDown.Text = "Download Completo";
                lblAVaux.Text = ("Abrindo por favor espere");
                var processo = System.Diagnostics.Process.Start(@"C:/Temp/StandarInstall/AV/kaspersky.exe");
                processo.WaitForExit();
                Close();
            }
        }

        private void Web_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)/* Altera a barra de progresso de acordo com o download */
        {
            pgbAV.Maximum = (int)e.TotalBytesToReceive;
            pgbAV.Value = (int)e.BytesReceived;
        }
    }
}
