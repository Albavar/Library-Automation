using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class Authors : Form
    {
        public String ConnectionString = @"Data Source=.\;Database=LibraryDatabase;Integrated Security=True;trusted_connection=true;encrypt=false";
        public SqlConnection Connection;
        public SqlDataAdapter Adapt;
        public SqlCommand cmd;
        public SqlDataReader dataReader;
        public String sql, Output = "";
        public DataTable dataTable;
        public int indexRow;
        public int editingAuthorID;

        public Authors()
        {
            InitializeComponent();
            Connection = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(sql, Connection);
        }

        private void RefreshGrid(object sender, EventArgs e)
        {
            {
                Connection.Open();
                sql = "SELECT AuthorID AS ID, AuthorName AS Name, AuthorNationality AS Nationality FROM Authors";
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
        private void Authors_Load(object sender, EventArgs e)
        {
            {
                Connection.Open();
                sql = "SELECT AuthorID AS ID, AuthorName AS Name, AuthorNationality AS Nationality FROM Authors";
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

        private void Insert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtNationality.Text))
            {
                string name = txtName.Text;
                string nationality = txtNationality.Text;
                using (SqlCommand insertAuthorsCmd = new SqlCommand("INSERT INTO Authors(AuthorName, AuthorNationality) VALUES (@Name, @Nationality);", Connection))
                {
                    insertAuthorsCmd.Parameters.AddWithValue("@Name", name);
                    insertAuthorsCmd.Parameters.AddWithValue("@Nationality", nationality);
                    Connection.Open();
                    insertAuthorsCmd.ExecuteNonQuery();
                    Connection.Close();
                    RefreshGrid(sender, e);
                    MessageBox.Show("Record Inserted Successfully");
                }
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtNationality.Text))
            {
                string name = txtName.Text;
                string nationality = txtNationality.Text;
                using (SqlCommand setAuthorsCmd = new SqlCommand("UPDATE Authors SET AuthorName = @Name , AuthorNationality = @Nationality WHERE AuthorID = @AuthorID", Connection))
                {
                    setAuthorsCmd.Parameters.AddWithValue("@AuthorID", editingAuthorID);
                    setAuthorsCmd.Parameters.AddWithValue("@Name", name);
                    setAuthorsCmd.Parameters.AddWithValue("@Nationality", nationality);
                    Connection.Open();
                    setAuthorsCmd.ExecuteNonQuery();
                    Connection.Close();
                    RefreshGrid(sender, e);
                    MessageBox.Show("Record Updated Successfully");
                }
            }

            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtNationality.Text))
            {
                using (SqlCommand deleteAuthorsCmd = new SqlCommand("DELETE FROM Authors WHERE AuthorID = @AuthorID", Connection))
                {
                    deleteAuthorsCmd.Parameters.AddWithValue("@AuthorID", editingAuthorID);
                    Connection.Open();
                    deleteAuthorsCmd.ExecuteNonQuery();
                    Connection.Close();
                    RefreshGrid(sender, e);
                    MessageBox.Show("Record Deleted Successfully");
                }
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                if (int.TryParse(row.Cells["ID"].Value.ToString(), out editingAuthorID))
                {
                }
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtNationality.Text = row.Cells["Nationality"].Value.ToString();
            }

        }



    }
}
