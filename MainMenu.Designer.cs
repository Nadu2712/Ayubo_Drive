
namespace Ayubo_Drive
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.btnRent = new System.Windows.Forms.Button();
            this.btnHire = new System.Windows.Forms.Button();
            this.btnPackage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(426, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 58);
            this.label1.TabIndex = 1;
            this.label1.Text = "MAIN MENU";
            // 
            // btnRent
            // 
            this.btnRent.BackColor = System.Drawing.Color.Transparent;
            this.btnRent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRent.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRent.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnRent.Location = new System.Drawing.Point(50, 203);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(523, 209);
            this.btnRent.TabIndex = 2;
            this.btnRent.Text = "RENT A VEHICLE";
            this.btnRent.UseVisualStyleBackColor = false;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // btnHire
            // 
            this.btnHire.BackColor = System.Drawing.Color.Transparent;
            this.btnHire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHire.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHire.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnHire.Location = new System.Drawing.Point(599, 203);
            this.btnHire.Name = "btnHire";
            this.btnHire.Size = new System.Drawing.Size(523, 209);
            this.btnHire.TabIndex = 3;
            this.btnHire.Text = "HIRE A VEHICLE";
            this.btnHire.UseVisualStyleBackColor = false;
            this.btnHire.Click += new System.EventHandler(this.btnHire_Click);
            // 
            // btnPackage
            // 
            this.btnPackage.BackColor = System.Drawing.Color.Transparent;
            this.btnPackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPackage.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPackage.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnPackage.Location = new System.Drawing.Point(50, 427);
            this.btnPackage.Name = "btnPackage";
            this.btnPackage.Size = new System.Drawing.Size(523, 199);
            this.btnPackage.TabIndex = 4;
            this.btnPackage.Text = "PACKAGE DETAILS";
            this.btnPackage.UseVisualStyleBackColor = false;
            this.btnPackage.Click += new System.EventHandler(this.btnPackage_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.button1.Location = new System.Drawing.Point(599, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(523, 199);
            this.button1.TabIndex = 5;
            this.button1.Text = "LOGOUT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPackage);
            this.Controls.Add(this.btnHire);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Button btnHire;
        private System.Windows.Forms.Button btnPackage;
        private System.Windows.Forms.Button button1;
    }
}