using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace LibraryProject
{
    public partial class MainForm : Form
    {
        public String ConnectionString = @"Data Source=.\;Database=LibraryDatabase;Integrated Security=True;trusted_connection=true;encrypt=false";
        public SqlConnection Connection;
        public SqlDataAdapter Adapt;
        public SqlCommand cmd;
        public SqlDataReader dataReader;
        public String sql, Output = "";
        public DataTable dataTable;
        public MainForm()
        {
            InitializeComponent();
            Connection = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(sql, Connection);
            DisplayData();
        }
        private void DisplayData()
        {
            Connection.Open();
            DataTable dt = new DataTable();
            Adapt = new SqlDataAdapter("select * from Books", Connection);
            Adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            Connection.Close();
        }

        private void ConnectionTest_Click(object sender, EventArgs e)
        {
            Connection.Open();
            MessageBox.Show("Connection Succesfull !");
            Connection.Close();
        }

        private void Navigate_Click(object sender, EventArgs e)
        {
            Navigate navigate = new Navigate();
            navigate.Show();
        }

        private void BorrowBooks_Click(object sender, EventArgs e)
        {
            BorrowBooks borrowBooks = new BorrowBooks();
            borrowBooks.Show();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Connection.Open();
            sql = "SELECT B.BookID, B.BookName, B.Stock, A.AuthorName, P.PublisherName, G.Genre, SI.ShelfNumber, SI.FloorNumber " +
                "FROM Books AS B " +
                "INNER JOIN Authors AS A ON B.AuthorID = A.AuthorID " +
                "LEFT JOIN Publishers AS P ON B.PublisherID = P.PublisherID " +
                "INNER JOIN Genres AS G ON B.GenreID = G.GenreID " +
                "INNER JOIN ShelfInformation AS SI ON B.ShelfNumber = SI.ShelfNumber ";
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            Refresh_Click(sender, e);
        }
    }
}
