namespace LibraryProject
{
    partial class Books
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
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.Delete = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Insert = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxShelf = new System.Windows.Forms.ComboBox();
            this.listBoxGenre = new System.Windows.Forms.ComboBox();
            this.listBoxAuthor = new System.Windows.Forms.ComboBox();
            this.listBoxPublisher = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-100, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-133, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Phone Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-85, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Genre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Stock";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Publisher";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Author";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Name";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(91, 61);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(113, 20);
            this.txtStock.TabIndex = 1;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(91, 307);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(121, 50);
            this.Delete.TabIndex = 8;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(91, 251);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(121, 50);
            this.Update.TabIndex = 7;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Insert
            // 
            this.Insert.Location = new System.Drawing.Point(91, 195);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(121, 50);
            this.Insert.TabIndex = 6;
            this.Insert.Text = "Insert";
            this.Insert.UseVisualStyleBackColor = true;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(113, 20);
            this.txtName.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(330, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(903, 459);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 52;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Shelf Number";
            // 
            // listBoxShelf
            // 
            this.listBoxShelf.FormattingEnabled = true;
            this.listBoxShelf.Location = new System.Drawing.Point(91, 168);
            this.listBoxShelf.Name = "listBoxShelf";
            this.listBoxShelf.Size = new System.Drawing.Size(121, 21);
            this.listBoxShelf.TabIndex = 5;
            // 
            // listBoxGenre
            // 
            this.listBoxGenre.FormattingEnabled = true;
            this.listBoxGenre.Location = new System.Drawing.Point(91, 141);
            this.listBoxGenre.Name = "listBoxGenre";
            this.listBoxGenre.Size = new System.Drawing.Size(121, 21);
            this.listBoxGenre.TabIndex = 4;
            // 
            // listBoxAuthor
            // 
            this.listBoxAuthor.FormattingEnabled = true;
            this.listBoxAuthor.Location = new System.Drawing.Point(91, 87);
            this.listBoxAuthor.Name = "listBoxAuthor";
            this.listBoxAuthor.Size = new System.Drawing.Size(121, 21);
            this.listBoxAuthor.TabIndex = 2;
            // 
            // listBoxPublisher
            // 
            this.listBoxPublisher.FormattingEnabled = true;
            this.listBoxPublisher.Location = new System.Drawing.Point(91, 114);
            this.listBoxPublisher.Name = "listBoxPublisher";
            this.listBoxPublisher.Size = new System.Drawing.Size(121, 21);
            this.listBoxPublisher.TabIndex = 3;
            // 
            // Books
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 483);
            this.Controls.Add(this.listBoxPublisher);
            this.Controls.Add(this.listBoxAuthor);
            this.Controls.Add(this.listBoxGenre);
            this.Controls.Add(this.listBoxShelf);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Insert);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Books";
            this.Text = "Books";
            this.Load += new System.EventHandler(this.Books_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox listBoxShelf;
        private System.Windows.Forms.ComboBox listBoxGenre;
        private System.Windows.Forms.ComboBox listBoxAuthor;
        private System.Windows.Forms.ComboBox listBoxPublisher;
    }
}