using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryProject
{
    public partial class Shelfs : Form
    {
        public String ConnectionString = @"Data Source=.\;Database=LibraryDatabase;Integrated Security=True;trusted_connection=true;encrypt=false";
        public SqlConnection Connection;
        public SqlDataAdapter Adapt;
        public SqlCommand cmd;
        public SqlDataReader dataReader;
        public String sql, Output = "";
        public DataTable dataTable;
        public int indexRow;
        public int editingShelfNumber;
        public Shelfs()
        {
            InitializeComponent();
            Connection = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(sql, Connection);
        }


        private void RefreshGrid(object sender, EventArgs e)
        {
            Connection.Open();
            sql = "SELECT ShelfNumber AS [Shelf Number], FloorNumber AS [Floor Number] FROM ShelfInformation";
            cmd = new SqlCommand(sql, Connection);
            dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                DataColumn column = new DataColumn(dataReader.GetName(i), dataReader.GetFieldType(i));
                dt.Columns.Add(column);
            }
            while (dataReader.Read())
            {
                DataRow row = dt.NewRow();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    row[i] = dataReader[i];
                }
                dt.Rows.Add(row);
            }
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;
            Connection.Close();
        }
        private void Insert_Click(object sender, EventArgs e)
        {
            string ShelfNumber = txtShelfNumber.Text;
            string FloorNumber = txtFloorNumber.Text;
            using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM ShelfInformation WHERE ShelfNumber = @ShelfNumber", Connection))
            {
                checkCmd.Parameters.AddWithValue("@ShelfNumber", ShelfNumber);

                Connection.Open();
                int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                Connection.Close();

                if (existingCount > 0)
                {
                    MessageBox.Show("This Shelf Is Already Attached");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(txtShelfNumber.Text) && !string.IsNullOrEmpty(txtFloorNumber.Text))
            {
                using (SqlCommand insertMembersCmd = new SqlCommand("INSERT INTO ShelfInformation(ShelfNumber, FloorNumber) VALUES (@ShelfNumber, @FloorNumber);", Connection))
                {
                    insertMembersCmd.Parameters.AddWithValue("@ShelfNumber", ShelfNumber);
                    insertMembersCmd.Parameters.AddWithValue("@FloorNumber", FloorNumber);


                    Connection.Open();
                    insertMembersCmd.ExecuteNonQuery();
                    Connection.Close();
                    MessageBox.Show("Record Inserted Successfully");
                }
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            RefreshGrid(sender, e);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtShelfNumber.Text) && !string.IsNullOrEmpty(txtFloorNumber.Text))
            {
                string ShelfNumber = txtShelfNumber.Text;
                string FloorNumber = txtFloorNumber.Text;
                using (SqlCommand setShelfsCmd = new SqlCommand("UPDATE ShelfInformation SET ShelfNumber = @ShelfNumber , FloorNumber = @FloorNumber WHERE ShelfNumber = @ShelfNumber", Connection))
                {
                    setShelfsCmd.Parameters.AddWithValue("@ShelfNumber", ShelfNumber);
                    setShelfsCmd.Parameters.AddWithValue("@FloorNumber", FloorNumber);
                    Connection.Open();
                    setShelfsCmd.ExecuteNonQuery();
                    Connection.Close();
                    MessageBox.Show("Record Updated Successfully");
                }
            }

            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            RefreshGrid(sender, e);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtShelfNumber.Text) && !string.IsNullOrEmpty(txtFloorNumber.Text))
            {
                string ShelfNumber = txtShelfNumber.Text;
                using (SqlCommand deleteShelfsCmd = new SqlCommand("DELETE FROM ShelfInformation WHERE ShelfNumber = @ShelfNumber", Connection))
                {
                    deleteShelfsCmd.Parameters.AddWithValue("@ShelfNumber", ShelfNumber);
                    Connection.Open();
                    deleteShelfsCmd.ExecuteNonQuery();
                    Connection.Close();
                    RefreshGrid(sender, e);
                    MessageBox.Show("Record Deleted Successfully");
                }
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            RefreshGrid(sender, e);
        }

        private void Shelfs_Load(object sender, EventArgs e)
        {
            Connection.Open();
            sql = "SELECT ShelfNumber AS [Shelf Number], FloorNumber AS [Floor Number] FROM ShelfInformation";
            cmd = new SqlCommand(sql, Connection);
            dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                DataColumn column = new DataColumn(dataReader.GetName(i), dataReader.GetFieldType(i));
                dt.Columns.Add(column);
            }
            while (dataReader.Read())
            {
                DataRow row = dt.NewRow();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    row[i] = dataReader[i];
                }
                dt.Rows.Add(row);
            }
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;
            Connection.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                txtShelfNumber.Text = row.Cells["Shelf Number"].Value.ToString();
                txtFloorNumber.Text = row.Cells["Floor Number"].Value.ToString();
            }

        }

    }
}
