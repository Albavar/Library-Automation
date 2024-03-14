namespace LibraryProject
{
    partial class Shelfs
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
            this.txtFloorNumber = new System.Windows.Forms.TextBox();
            this.txtShelfNumber = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.Delete = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Insert = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFloorNumber
            // 
            this.txtFloorNumber.Location = new System.Drawing.Point(78, 38);
            this.txtFloorNumber.Multiline = true;
            this.txtFloorNumber.Name = "txtFloorNumber";
            this.txtFloorNumber.Size = new System.Drawing.Size(149, 20);
            this.txtFloorNumber.TabIndex = 1;
            // 
            // txtShelfNumber
            // 
            this.txtShelfNumber.Location = new System.Drawing.Point(78, 12);
            this.txtShelfNumber.Name = "txtShelfNumber";
            this.txtShelfNumber.Size = new System.Drawing.Size(149, 20);
            this.txtShelfNumber.TabIndex = 0;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(2, 41);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(70, 13);
            this.labelAddress.TabIndex = 17;
            this.labelAddress.Text = "Floor Number";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(1, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(71, 13);
            this.labelName.TabIndex = 15;
            this.labelName.Text = "Shelf Number";
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(78, 307);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(121, 50);
            this.Delete.TabIndex = 18;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(78, 251);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(121, 50);
            this.Update.TabIndex = 16;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Insert
            // 
            this.Insert.Location = new System.Drawing.Point(78, 195);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(121, 50);
            this.Insert.TabIndex = 14;
            this.Insert.Text = "Insert";
            this.Insert.UseVisualStyleBackColor = true;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(317, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(743, 459);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Shelfs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 483);
            this.Controls.Add(this.txtFloorNumber);
            this.Controls.Add(this.txtShelfNumber);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Insert);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Shelfs";
            this.Text = "Shelfs";
            this.Load += new System.EventHandler(this.Shelfs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFloorNumber;
        private System.Windows.Forms.TextBox txtShelfNumber;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}