namespace LibraryProject
{
    partial class MainForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.libraryDatabaseDataSet = new LibraryProject.LibraryDatabaseDataSet();
            this.booksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.booksTableAdapter = new LibraryProject.LibraryDatabaseDataSetTableAdapters.BooksTableAdapter();
            this.libraryDatabaseDataSet1 = new LibraryProject.LibraryDatabaseDataSet();
            this.libraryDatabaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.libraryDatabaseDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.staffTableAdapter1 = new LibraryProject.LibraryDatabaseDataSetTableAdapters.StaffTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.booksBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.membersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.membersTableAdapter = new LibraryProject.LibraryDatabaseDataSetTableAdapters.MembersTableAdapter();
            this.shelfInformationTableAdapter1 = new LibraryProject.LibraryDatabaseDataSetTableAdapters.ShelfInformationTableAdapter();
            this.ConnectionTest = new System.Windows.Forms.Button();
            this.Navigate = new System.Windows.Forms.Button();
            this.membersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.BorrowBooks = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDatabaseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDatabaseDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDatabaseDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // libraryDatabaseDataSet
            // 
            this.libraryDatabaseDataSet.DataSetName = "LibraryDatabaseDataSet";
            this.libraryDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // booksBindingSource
            // 
            this.booksBindingSource.DataMember = "Books";
            this.booksBindingSource.DataSource = this.libraryDatabaseDataSet;
            // 
            // booksTableAdapter
            // 
            this.booksTableAdapter.ClearBeforeFill = true;
            // 
            // libraryDatabaseDataSet1
            // 
            this.libraryDatabaseDataSet1.DataSetName = "LibraryDatabaseDataSet";
            this.libraryDatabaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // libraryDatabaseDataSetBindingSource
            // 
            this.libraryDatabaseDataSetBindingSource.DataSource = this.libraryDatabaseDataSet;
            this.libraryDatabaseDataSetBindingSource.Position = 0;
            // 
            // libraryDatabaseDataSetBindingSource1
            // 
            this.libraryDatabaseDataSetBindingSource1.DataSource = this.libraryDatabaseDataSet;
            this.libraryDatabaseDataSetBindingSource1.Position = 0;
            // 
            // staffTableAdapter1
            // 
            this.staffTableAdapter1.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(840, 489);
            this.dataGridView1.TabIndex = 1;
            // 
            // booksBindingSource1
            // 
            this.booksBindingSource1.DataMember = "Books";
            this.booksBindingSource1.DataSource = this.libraryDatabaseDataSet;
            // 
            // membersBindingSource
            // 
            this.membersBindingSource.DataMember = "Members";
            this.membersBindingSource.DataSource = this.libraryDatabaseDataSet;
            // 
            // membersTableAdapter
            // 
            this.membersTableAdapter.ClearBeforeFill = true;
            // 
            // shelfInformationTableAdapter1
            // 
            this.shelfInformationTableAdapter1.ClearBeforeFill = true;
            // 
            // ConnectionTest
            // 
            this.ConnectionTest.Location = new System.Drawing.Point(638, 507);
            this.ConnectionTest.Name = "ConnectionTest";
            this.ConnectionTest.Size = new System.Drawing.Size(214, 44);
            this.ConnectionTest.TabIndex = 2;
            this.ConnectionTest.Text = "Connection Test";
            this.ConnectionTest.UseVisualStyleBackColor = true;
            this.ConnectionTest.Click += new System.EventHandler(this.ConnectionTest_Click);
            // 
            // Navigate
            // 
            this.Navigate.Location = new System.Drawing.Point(12, 507);
            this.Navigate.Name = "Navigate";
            this.Navigate.Size = new System.Drawing.Size(197, 44);
            this.Navigate.TabIndex = 3;
            this.Navigate.Text = "Navigate";
            this.Navigate.UseVisualStyleBackColor = true;
            this.Navigate.Click += new System.EventHandler(this.Navigate_Click);
            // 
            // membersBindingSource1
            // 
            this.membersBindingSource1.DataMember = "Members";
            this.membersBindingSource1.DataSource = this.libraryDatabaseDataSet;
            // 
            // BorrowBooks
            // 
            this.BorrowBooks.Location = new System.Drawing.Point(215, 507);
            this.BorrowBooks.Name = "BorrowBooks";
            this.BorrowBooks.Size = new System.Drawing.Size(212, 44);
            this.BorrowBooks.TabIndex = 4;
            this.BorrowBooks.Text = "Borrow Books";
            this.BorrowBooks.UseVisualStyleBackColor = true;
            this.BorrowBooks.Click += new System.EventHandler(this.BorrowBooks_Click);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(433, 507);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(199, 44);
            this.Refresh.TabIndex = 5;
            this.Refresh.Text = "Refresh Table";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 563);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.BorrowBooks);
            this.Controls.Add(this.Navigate);
            this.Controls.Add(this.ConnectionTest);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDatabaseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDatabaseDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDatabaseDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.BindingSource bindingSource3;
        private System.Windows.Forms.BindingSource bindingSource4;
        private System.Windows.Forms.BindingSource bindingSource5;
        private LibraryDatabaseDataSet libraryDatabaseDataSet;
        private System.Windows.Forms.BindingSource booksBindingSource;
        private LibraryDatabaseDataSetTableAdapters.BooksTableAdapter booksTableAdapter;
        private LibraryDatabaseDataSet libraryDatabaseDataSet1;
        private System.Windows.Forms.BindingSource libraryDatabaseDataSetBindingSource;
        private System.Windows.Forms.BindingSource libraryDatabaseDataSetBindingSource1;
        private LibraryDatabaseDataSetTableAdapters.StaffTableAdapter staffTableAdapter1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource membersBindingSource;
        private LibraryDatabaseDataSetTableAdapters.MembersTableAdapter membersTableAdapter;
        private LibraryDatabaseDataSetTableAdapters.ShelfInformationTableAdapter shelfInformationTableAdapter1;
        private System.Windows.Forms.BindingSource booksBindingSource1;
        private System.Windows.Forms.Button ConnectionTest;
        private System.Windows.Forms.Button Navigate;
        private System.Windows.Forms.BindingSource membersBindingSource1;
        private System.Windows.Forms.Button BorrowBooks;
        private System.Windows.Forms.Button Refresh;
    }
}

