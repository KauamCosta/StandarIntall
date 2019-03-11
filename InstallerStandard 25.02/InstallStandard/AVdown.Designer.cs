namespace InstallStandard {
    partial class AVdown {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AVdown));
            this.pgbAV = new System.Windows.Forms.ProgressBar();
            this.lblDown = new System.Windows.Forms.Label();
            this.lblAVaux = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pgbAV
            // 
            this.pgbAV.Location = new System.Drawing.Point(12, 57);
            this.pgbAV.Name = "pgbAV";
            this.pgbAV.Size = new System.Drawing.Size(277, 23);
            this.pgbAV.TabIndex = 0;
            // 
            // lblDown
            // 
            this.lblDown.AutoSize = true;
            this.lblDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblDown.Location = new System.Drawing.Point(79, 9);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(140, 25);
            this.lblDown.TabIndex = 1;
            this.lblDown.Text = "Downloading...";
            this.lblDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAVaux
            // 
            this.lblAVaux.AutoSize = true;
            this.lblAVaux.Location = new System.Drawing.Point(81, 41);
            this.lblAVaux.Name = "lblAVaux";
            this.lblAVaux.Size = new System.Drawing.Size(0, 13);
            this.lblAVaux.TabIndex = 2;
            this.lblAVaux.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AVdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 92);
            this.Controls.Add(this.lblAVaux);
            this.Controls.Add(this.lblDown);
            this.Controls.Add(this.pgbAV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AVdown";
            this.Text = "Kaspersky";
            this.Load += new System.EventHandler(this.AVdown_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbAV;
        private System.Windows.Forms.Label lblDown;
        private System.Windows.Forms.Label lblAVaux;
    }
}