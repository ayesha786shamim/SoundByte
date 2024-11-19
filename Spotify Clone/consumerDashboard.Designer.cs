namespace Spotify_Clone
{
    partial class consumerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(consumerDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewPlaylistBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.createPlaylistBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.addCommentBtn = new System.Windows.Forms.Button();
            this.commentTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.playBtn = new System.Windows.Forms.Button();
            this.addToPlaylistbtn = new System.Windows.Forms.Button();
            this.likeBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCoral;
            this.panel1.Controls.Add(this.viewPlaylistBtn);
            this.panel1.Controls.Add(this.logoutBtn);
            this.panel1.Controls.Add(this.createPlaylistBtn);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 685);
            this.panel1.TabIndex = 0;
            // 
            // viewPlaylistBtn
            // 
            this.viewPlaylistBtn.BackColor = System.Drawing.Color.Firebrick;
            this.viewPlaylistBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewPlaylistBtn.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewPlaylistBtn.ForeColor = System.Drawing.Color.White;
            this.viewPlaylistBtn.Location = new System.Drawing.Point(0, 231);
            this.viewPlaylistBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.viewPlaylistBtn.Name = "viewPlaylistBtn";
            this.viewPlaylistBtn.Size = new System.Drawing.Size(315, 48);
            this.viewPlaylistBtn.TabIndex = 4;
            this.viewPlaylistBtn.Text = "View Playlist";
            this.viewPlaylistBtn.UseVisualStyleBackColor = false;
            this.viewPlaylistBtn.Click += new System.EventHandler(this.viewPlaylistBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.Turquoise;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.White;
            this.logoutBtn.Location = new System.Drawing.Point(0, 314);
            this.logoutBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(315, 48);
            this.logoutBtn.TabIndex = 3;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // createPlaylistBtn
            // 
            this.createPlaylistBtn.BackColor = System.Drawing.Color.DarkTurquoise;
            this.createPlaylistBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createPlaylistBtn.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPlaylistBtn.ForeColor = System.Drawing.Color.White;
            this.createPlaylistBtn.Location = new System.Drawing.Point(0, 148);
            this.createPlaylistBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.createPlaylistBtn.Name = "createPlaylistBtn";
            this.createPlaylistBtn.Size = new System.Drawing.Size(315, 48);
            this.createPlaylistBtn.TabIndex = 1;
            this.createPlaylistBtn.Text = "Create Playlist";
            this.createPlaylistBtn.UseVisualStyleBackColor = false;
            this.createPlaylistBtn.Click += new System.EventHandler(this.createPlaylistBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Firebrick;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 82);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(318, 3);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(886, 685);
            this.panel3.TabIndex = 6;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.addCommentBtn);
            this.panel4.Controls.Add(this.commentTxtBox);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Controls.Add(this.playBtn);
            this.panel4.Controls.Add(this.addToPlaylistbtn);
            this.panel4.Controls.Add(this.likeBtn);
            this.panel4.Location = new System.Drawing.Point(158, 89);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(580, 538);
            this.panel4.TabIndex = 6;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // addCommentBtn
            // 
            this.addCommentBtn.BackColor = System.Drawing.Color.Firebrick;
            this.addCommentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCommentBtn.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCommentBtn.ForeColor = System.Drawing.Color.White;
            this.addCommentBtn.Location = new System.Drawing.Point(219, 492);
            this.addCommentBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addCommentBtn.Name = "addCommentBtn";
            this.addCommentBtn.Size = new System.Drawing.Size(150, 35);
            this.addCommentBtn.TabIndex = 6;
            this.addCommentBtn.Text = "Add Comment";
            this.addCommentBtn.UseVisualStyleBackColor = false;
            this.addCommentBtn.Click += new System.EventHandler(this.addCommentBtn_Click);
            // 
            // commentTxtBox
            // 
            this.commentTxtBox.Location = new System.Drawing.Point(98, 452);
            this.commentTxtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.commentTxtBox.Name = "commentTxtBox";
            this.commentTxtBox.Size = new System.Drawing.Size(374, 26);
            this.commentTxtBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(146, 420);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Add Your Comment";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 25);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(546, 331);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // playBtn
            // 
            this.playBtn.BackColor = System.Drawing.Color.Firebrick;
            this.playBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playBtn.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.ForeColor = System.Drawing.Color.White;
            this.playBtn.Location = new System.Drawing.Point(98, 365);
            this.playBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(112, 35);
            this.playBtn.TabIndex = 1;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = false;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // addToPlaylistbtn
            // 
            this.addToPlaylistbtn.BackColor = System.Drawing.Color.Firebrick;
            this.addToPlaylistbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addToPlaylistbtn.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToPlaylistbtn.ForeColor = System.Drawing.Color.White;
            this.addToPlaylistbtn.Location = new System.Drawing.Point(340, 365);
            this.addToPlaylistbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addToPlaylistbtn.Name = "addToPlaylistbtn";
            this.addToPlaylistbtn.Size = new System.Drawing.Size(134, 35);
            this.addToPlaylistbtn.TabIndex = 3;
            this.addToPlaylistbtn.Text = "Add To Playlist";
            this.addToPlaylistbtn.UseVisualStyleBackColor = false;
            this.addToPlaylistbtn.Click += new System.EventHandler(this.addToPlaylistbtn_Click);
            // 
            // likeBtn
            // 
            this.likeBtn.BackColor = System.Drawing.Color.Firebrick;
            this.likeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.likeBtn.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.likeBtn.ForeColor = System.Drawing.Color.White;
            this.likeBtn.Location = new System.Drawing.Point(219, 365);
            this.likeBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.likeBtn.Name = "likeBtn";
            this.likeBtn.Size = new System.Drawing.Size(112, 35);
            this.likeBtn.TabIndex = 2;
            this.likeBtn.Text = "Like";
            this.likeBtn.UseVisualStyleBackColor = false;
            this.likeBtn.Click += new System.EventHandler(this.likeBtn_Click);
            // 
            // consumerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1190, 691);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "consumerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "consumerDashboard";
            this.Load += new System.EventHandler(this.consumerDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button createPlaylistBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button viewPlaylistBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox commentTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addToPlaylistbtn;
        private System.Windows.Forms.Button likeBtn;
        private System.Windows.Forms.Button addCommentBtn;
    }
}