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
    public partial class Genres : Form
    {
        public String ConnectionString = @"Data Source=.\;Database=LibraryDatabase;Integrated Security=True;trusted_connection=true;encrypt=false";
        public SqlConnection Connection;
        public SqlDataAdapter Adapt;
        public SqlCommand cmd;
        public SqlDataReader dataReader;
        public String sql, Output = "";
        public DataTable dataTable;
        public int indexRow;
        public int editingGenreID;
        public Genres()
        {
            InitializeComponent();
            Connection = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(sql, Connection);
        }

        private void RefreshGrid(object sender, EventArgs e)
        {
            {
                Connection.Open();
                sql = "SELECT GenreID AS ID, Genre FROM Genres";
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
            if (!string.IsNullOrEmpty(txtGenre.Text))
            {
                string genre = txtGenre.Text;
                using (SqlCommand insertGenresCmd = new SqlCommand("INSERT INTO Genres(Genre) VALUES (@Genre);", Connection))
                {
                    insertGenresCmd.Parameters.AddWithValue("@Genre", genre);
                    Connection.Open();
                    insertGenresCmd.ExecuteNonQuery();
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
            if (!string.IsNullOrEmpty(txtGenre.Text))
            {
                string genre = txtGenre.Text;
                using (SqlCommand setGenresCmd = new SqlCommand("UPDATE Genres SET Genre = @Genre WHERE GenreID = @GenreID", Connection))
                {
                    setGenresCmd.Parameters.AddWithValue("@GenreID", editingGenreID);
                    setGenresCmd.Parameters.AddWithValue("@Genre", genre);
                    Connection.Open();
                    setGenresCmd.ExecuteNonQuery();
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
            if (!string.IsNullOrEmpty(txtGenre.Text))
            {
                using (SqlCommand deleteGenresCmd = new SqlCommand("DELETE FROM Genres WHERE GenreID = @GenreID", Connection))
                {
                    deleteGenresCmd.Parameters.AddWithValue("@GenreID", editingGenreID);
                    Connection.Open();
                    deleteGenresCmd.ExecuteNonQuery();
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

        private void Genres_Load(object sender, EventArgs e)
        {
            {
                Connection.Open();
                sql = "SELECT GenreID AS ID, Genre FROM Genres";
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                if (int.TryParse(row.Cells["ID"].Value.ToString(), out editingGenreID))
                {
                }
                txtGenre.Text = row.Cells["Genre"].Value.ToString();
            }
        }

    }
}
