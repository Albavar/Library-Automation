namespace LibraryProject
{
    partial class Navigate
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
            this.Members = new System.Windows.Forms.Button();
            this.Publishers = new System.Windows.Forms.Button();
            this.Books = new System.Windows.Forms.Button();
            this.Authors = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Shelfs = new System.Windows.Forms.Button();
            this.Genres = new System.Windows.Forms.Button();
            this.Staff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Members
            // 
            this.Members.Location = new System.Drawing.Point(12, 48);
            this.Members.Name = "Members";
            this.Members.Size = new System.Drawing.Size(128, 57);
            this.Members.TabIndex = 0;
            this.Members.Text = "Members";
            this.Members.UseVisualStyleBackColor = true;
            this.Members.Click += new System.EventHandler(this.Members_Click);
            // 
            // Publishers
            // 
            this.Publishers.Location = new System.Drawing.Point(146, 48);
            this.Publishers.Name = "Publishers";
            this.Publishers.Size = new System.Drawing.Size(128, 57);
            this.Publishers.TabIndex = 1;
            this.Publishers.Text = "Publishers";
            this.Publishers.UseVisualStyleBackColor = true;
            this.Publishers.Click += new System.EventHandler(this.Publishers_Click);
            // 
            // Books
            // 
            this.Books.Location = new System.Drawing.Point(280, 48);
            this.Books.Name = "Books";
            this.Books.Size = new System.Drawing.Size(128, 57);
            this.Books.TabIndex = 2;
            this.Books.Text = "Books";
            this.Books.UseVisualStyleBackColor = true;
            this.Books.Click += new System.EventHandler(this.Books_Click);
            // 
            // Authors
            // 
            this.Authors.Location = new System.Drawing.Point(414, 48);
            this.Authors.Name = "Authors";
            this.Authors.Size = new System.Drawing.Size(128, 57);
            this.Authors.TabIndex = 3;
            this.Authors.Text = "Authors";
            this.Authors.UseVisualStyleBackColor = true;
            this.Authors.Click += new System.EventHandler(this.Authors_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 30);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "For Information";
            // 
            // Shelfs
            // 
            this.Shelfs.Location = new System.Drawing.Point(548, 48);
            this.Shelfs.Name = "Shelfs";
            this.Shelfs.Size = new System.Drawing.Size(128, 57);
            this.Shelfs.TabIndex = 6;
            this.Shelfs.Text = "Shelfs";
            this.Shelfs.UseVisualStyleBackColor = true;
            this.Shelfs.Click += new System.EventHandler(this.Shelfs_Click);
            // 
            // Genres
            // 
            this.Genres.Location = new System.Drawing.Point(682, 48);
            this.Genres.Name = "Genres";
            this.Genres.Size = new System.Drawing.Size(128, 57);
            this.Genres.TabIndex = 7;
            this.Genres.Text = "Genres";
            this.Genres.UseVisualStyleBackColor = true;
            this.Genres.Click += new System.EventHandler(this.Genres_Click);
            // 
            // Staff
            // 
            this.Staff.Location = new System.Drawing.Point(12, 111);
            this.Staff.Name = "Staff";
            this.Staff.Size = new System.Drawing.Size(128, 57);
            this.Staff.TabIndex = 8;
            this.Staff.Text = "Staff";
            this.Staff.UseVisualStyleBackColor = true;
            this.Staff.Click += new System.EventHandler(this.Staff_Click);
            // 
            // Navigate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 483);
            this.Controls.Add(this.Staff);
            this.Controls.Add(this.Genres);
            this.Controls.Add(this.Shelfs);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Authors);
            this.Controls.Add(this.Books);
            this.Controls.Add(this.Publishers);
            this.Controls.Add(this.Members);
            this.Name = "Navigate";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Navigate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Members;
        private System.Windows.Forms.Button Publishers;
        private System.Windows.Forms.Button Books;
        private System.Windows.Forms.Button Authors;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Shelfs;
        private System.Windows.Forms.Button Genres;
        private System.Windows.Forms.Button Staff;
    }
}