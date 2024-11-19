namespace Spotify_Clone
{
    partial class ProducerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProducerDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.logOutButton = new System.Windows.Forms.Button();
            this.addMusicButton = new System.Windows.Forms.Button();
            this.viewAlbumButton = new System.Windows.Forms.Button();
            this.createAlbumButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dashBoardLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.logOutButton);
            this.panel1.Controls.Add(this.addMusicButton);
            this.panel1.Controls.Add(this.viewAlbumButton);
            this.panel1.Controls.Add(this.createAlbumButton);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 452);
            this.panel1.TabIndex = 0;
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.SteelBlue;
            this.logOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.logOutButton.Location = new System.Drawing.Point(0, 204);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(239, 34);
            this.logOutButton.TabIndex = 4;
            this.logOutButton.Text = "Logout";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // addMusicButton
            // 
            this.addMusicButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.addMusicButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addMusicButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addMusicButton.Location = new System.Drawing.Point(0, 164);
            this.addMusicButton.Name = "addMusicButton";
            this.addMusicButton.Size = new System.Drawing.Size(239, 34);
            this.addMusicButton.TabIndex = 3;
            this.addMusicButton.Text = "Add Music To Album";
            this.addMusicButton.UseVisualStyleBackColor = false;
            this.addMusicButton.Click += new System.EventHandler(this.addMusicButton_Click);
            // 
            // viewAlbumButton
            // 
            this.viewAlbumButton.BackColor = System.Drawing.Color.SteelBlue;
            this.viewAlbumButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewAlbumButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.viewAlbumButton.Location = new System.Drawing.Point(0, 124);
            this.viewAlbumButton.Name = "viewAlbumButton";
            this.viewAlbumButton.Size = new System.Drawing.Size(239, 34);
            this.viewAlbumButton.TabIndex = 2;
            this.viewAlbumButton.Text = "View Albums";
            this.viewAlbumButton.UseVisualStyleBackColor = false;
            this.viewAlbumButton.Click += new System.EventHandler(this.viewAlbumButton_Click);
            // 
            // createAlbumButton
            // 
            this.createAlbumButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.createAlbumButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createAlbumButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.createAlbumButton.Location = new System.Drawing.Point(0, 84);
            this.createAlbumButton.Name = "createAlbumButton";
            this.createAlbumButton.Size = new System.Drawing.Size(239, 34);
            this.createAlbumButton.TabIndex = 1;
            this.createAlbumButton.Text = "Create Album";
            this.createAlbumButton.UseVisualStyleBackColor = false;
            this.createAlbumButton.Click += new System.EventHandler(this.createAlbumButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.dashBoardLabel);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(239, 64);
            this.panel3.TabIndex = 0;
            // 
            // dashBoardLabel
            // 
            this.dashBoardLabel.AutoSize = true;
            this.dashBoardLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashBoardLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dashBoardLabel.Location = new System.Drawing.Point(37, 17);
            this.dashBoardLabel.Name = "dashBoardLabel";
            this.dashBoardLabel.Size = new System.Drawing.Size(156, 31);
            this.dashBoardLabel.TabIndex = 0;
            this.dashBoardLabel.Text = "Dashboard";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(235, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 452);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(204, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sound Byte";
            // 
            // ProducerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 449);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProducerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProducerDashboard";
            this.Load += new System.EventHandler(this.ProducerDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label dashBoardLabel;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button addMusicButton;
        private System.Windows.Forms.Button viewAlbumButton;
        private System.Windows.Forms.Button createAlbumButton;
        private System.Windows.Forms.Label label1;
    }
}