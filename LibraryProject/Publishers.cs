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

namespace LibraryProject
{
    public partial class Publishers : Form
    {
        public String ConnectionString = @"Data Source=.\;Database=LibraryDatabase;Integrated Security=True;trusted_connection=true;encrypt=false";
        public SqlConnection Connection;
        public SqlDataAdapter Adapt;
        public SqlCommand cmd;
        public SqlDataReader dataReader;
        public String sql, Output = "";
        public DataTable dataTable;
        public int indexRow;
        public int editingPublisherID;
        public Publishers()
        {
            InitializeComponent();
            Connection = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(sql, Connection);
        }
        private void RefreshGrid(object sender, EventArgs e)
        {
            Connection.Open();
            sql = "SELECT PublisherID AS ID, PublisherName AS Publisher, Email, PublisherAddress AS Address FROM Publishers";
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
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(labelAddress.Text))
            {
                string name = txtName.Text;
                string email = txtEmail.Text;
                string address = txtAddress.Text;
                using (SqlCommand insertMembersCmd = new SqlCommand("INSERT INTO Publishers(PublisherName, Email, PublisherAddress) VALUES (@Name, @Email, @Address);", Connection))
                {
                    insertMembersCmd.Parameters.AddWithValue("@Name", name);
                    insertMembersCmd.Parameters.AddWithValue("@Email", email);
                    insertMembersCmd.Parameters.AddWithValue("@Address", address);


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

        private void Publishers_Load(object sender, EventArgs e)
        {
            {
                Connection.Open();
                sql = "SELECT PublisherID AS ID, PublisherName AS Publisher, Email, PublisherAddress AS Address FROM Publishers";
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
        }

        private void Update_Click(object sender, EventArgs e)
        {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(labelAddress.Text))
                {
                string name = txtName.Text;
                string email = txtEmail.Text;
                string address = txtAddress.Text;
                using (SqlCommand setPublisherCmd = new SqlCommand("UPDATE Publishers SET PublisherName = @Name , Email = @Email, PublisherAddress = @Address WHERE PublisherID = @PublisherID", Connection))
                    {
                        setPublisherCmd.Parameters.AddWithValue("@PublisherID", editingPublisherID);
                        setPublisherCmd.Parameters.AddWithValue("@Name", name);
                        setPublisherCmd.Parameters.AddWithValue("@Email", email);
                        setPublisherCmd.Parameters.AddWithValue("@Address", address);
                        Connection.Open();
                        setPublisherCmd.ExecuteNonQuery();
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
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(labelAddress.Text))
            {
                using (SqlCommand deletePublishersCmd = new SqlCommand("DELETE FROM Publishers WHERE PublisherID = @PublisherID", Connection))
                {
                    deletePublishersCmd.Parameters.AddWithValue("@PublisherID", editingPublisherID);
                    Connection.Open();
                    deletePublishersCmd.ExecuteNonQuery();
                    Connection.Close();
                    MessageBox.Show("Record Deleted Successfully");
                }
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            RefreshGrid(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) 
            { 
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            if (int.TryParse(row.Cells["ID"].Value.ToString(), out editingPublisherID))
            {
            }
            txtName.Text = row.Cells["Publisher"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtAddress.Text = row.Cells["Address"].Value.ToString();
            }
        }

    }
}
