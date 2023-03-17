
namespace Ayubo_Drive
{
    partial class PackageDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageDetails));
            this.btnRentpackage = new System.Windows.Forms.Button();
            this.btnHirepackages = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRentpackage
            // 
            this.btnRentpackage.BackColor = System.Drawing.Color.Transparent;
            this.btnRentpackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRentpackage.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRentpackage.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnRentpackage.Location = new System.Drawing.Point(12, 12);
            this.btnRentpackage.Name = "btnRentpackage";
            this.btnRentpackage.Size = new System.Drawing.Size(574, 529);
            this.btnRentpackage.TabIndex = 3;
            this.btnRentpackage.Text = "RENT PACKAGES";
            this.btnRentpackage.UseVisualStyleBackColor = false;
            this.btnRentpackage.Click += new System.EventHandler(this.btnRentpackage_Click);
            // 
            // btnHirepackages
            // 
            this.btnHirepackages.BackColor = System.Drawing.Color.Transparent;
            this.btnHirepackages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHirepackages.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHirepackages.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnHirepackages.Location = new System.Drawing.Point(596, 12);
            this.btnHirepackages.Name = "btnHirepackages";
            this.btnHirepackages.Size = new System.Drawing.Size(574, 529);
            this.btnHirepackages.TabIndex = 4;
            this.btnHirepackages.Text = "HIRE PACKAGES";
            this.btnHirepackages.UseVisualStyleBackColor = false;
            this.btnHirepackages.Click += new System.EventHandler(this.btnHirepackages_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnBack.Location = new System.Drawing.Point(856, 582);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(314, 59);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // PackageDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHirepackages);
            this.Controls.Add(this.btnRentpackage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "PackageDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PackageDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRentpackage;
        private System.Windows.Forms.Button btnHirepackages;
        private System.Windows.Forms.Button btnBack;
    }
}