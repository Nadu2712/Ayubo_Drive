
namespace Ayubo_Drive
{
    partial class HireVehicle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HireVehicle));
            this.btnBack = new System.Windows.Forms.Button();
            this.btnHirePackages = new System.Windows.Forms.Button();
            this.btnDayTours = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnHirePackages
            // 
            this.btnHirePackages.BackColor = System.Drawing.Color.Transparent;
            this.btnHirePackages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHirePackages.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHirePackages.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnHirePackages.Location = new System.Drawing.Point(596, 12);
            this.btnHirePackages.Name = "btnHirePackages";
            this.btnHirePackages.Size = new System.Drawing.Size(574, 529);
            this.btnHirePackages.TabIndex = 7;
            this.btnHirePackages.Text = "LONG TOURS";
            this.btnHirePackages.UseVisualStyleBackColor = false;
            this.btnHirePackages.Click += new System.EventHandler(this.btnHirePackages_Click);
            // 
            // btnDayTours
            // 
            this.btnDayTours.BackColor = System.Drawing.Color.Transparent;
            this.btnDayTours.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDayTours.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDayTours.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnDayTours.Location = new System.Drawing.Point(12, 12);
            this.btnDayTours.Name = "btnDayTours";
            this.btnDayTours.Size = new System.Drawing.Size(574, 529);
            this.btnDayTours.TabIndex = 6;
            this.btnDayTours.Text = "DAY TOURS";
            this.btnDayTours.UseVisualStyleBackColor = false;
            this.btnDayTours.Click += new System.EventHandler(this.btnDayTours_Click);
            // 
            // HireVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHirePackages);
            this.Controls.Add(this.btnDayTours);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "HireVehicle";
            this.Text = "HireVehicle";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnHirePackages;
        private System.Windows.Forms.Button btnDayTours;
    }
}