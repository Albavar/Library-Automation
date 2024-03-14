using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class Books : Form
    {
        public String ConnectionString = @"Data Source=.\;Database=LibraryDatabase;Integrated Security=True;trusted_connection=true;encrypt=false";
        public SqlConnection Connection;
        public SqlDataAdapter Adapt;
        public SqlCommand cmd;
        public SqlDataReader dataReader;
        public String sql, Output = "";
        public DataTable dataTable;
        public int indexRow;
        public int editingBookID;
        public Books()
        {
            InitializeComponent();
            Connection = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(sql, Connection);
        }
        private void RefreshGrid(object sender, EventArgs e)
        {
            listBoxAuthor.Items.Clear();
            listBoxGenre.Items.Clear();
            listBoxPublisher.Items.Clear();
            listBoxShelf.Items.Clear();
            FilllistBoxShelf(sender, e);
            FilllistBoxGenre(sender, e);
            FilllistBoxPublisher(sender, e);
            FilllistBoxAuthor(sender, e);
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
        private void Books_Load(object sender, EventArgs e)
        {
            listBoxAuthor.Items.Clear();
            listBoxGenre.Items.Clear();
            listBoxPublisher.Items.Clear();
            listBoxShelf.Items.Clear();
            FilllistBoxShelf(sender, e);
            FilllistBoxGenre(sender, e);
            FilllistBoxPublisher(sender, e);
            FilllistBoxAuthor(sender, e);
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
        private void FilllistBoxGenre(object sender, EventArgs e)
        {
            Connection.Open();
            string sql = "SELECT Genre FROM Genres";
            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string genre = dataReader["Genre"].ToString();
                        listBoxGenre.Items.Add(genre);
                    }
                }
            }
            Connection.Close();
        }
        private void FilllistBoxShelf(object sender, EventArgs e)
        {
            Connection.Open();
            string sql = "SELECT ShelfNumber FROM ShelfInformation";
            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string ShelfNumber = dataReader["ShelfNumber"].ToString();
                        listBoxShelf.Items.Add(ShelfNumber);
                    }
                }
            }
            Connection.Close();
        }
        private void FilllistBoxAuthor(object sender, EventArgs e)
        {
            Connection.Open();
            string sql = "SELECT AuthorName FROM Authors";
            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string Authors = dataReader["AuthorName"].ToString();
                        listBoxAuthor.Items.Add(Authors);
                    }
                }
            }
            Connection.Close();
        }
        private void FilllistBoxPublisher(object sender, EventArgs e)
        {
            Connection.Open();
            string sql = "SELECT PublisherName FROM Publishers";
            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string Publisher = dataReader["PublisherName"].ToString();
                        listBoxPublisher.Items.Add(Publisher);
                    }
                }
            }
            Connection.Close();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtStock.Text) &&
                !string.IsNullOrEmpty(listBoxAuthor.Text) && !string.IsNullOrEmpty(listBoxPublisher.Text) &&
                !string.IsNullOrEmpty(listBoxShelf.Text) && !string.IsNullOrEmpty(listBoxGenre.Text))
            {
                if (listBoxAuthor.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Valid Author.");
                    return;
                }
                if (listBoxGenre.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Valid Genre.");
                    return;
                }
                if (listBoxPublisher.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Valid Publisher.");
                    return;
                }
                if (listBoxShelf.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Valid Shelf.");
                    return;
                }
                string selectedAuthor = listBoxAuthor.SelectedItem.ToString();
                string selectedPublisher = listBoxPublisher.SelectedItem.ToString();
                string selectedGenre = listBoxGenre.SelectedItem.ToString();
                string selectedShelf = listBoxShelf.SelectedItem.ToString();
                int authorID;
                using (SqlCommand getAuthorIDCmd = new SqlCommand("SELECT AuthorID FROM Authors WHERE AuthorName = @AuthorName", Connection))
                {
                    getAuthorIDCmd.Parameters.AddWithValue("@AuthorName", selectedAuthor);
                    Connection.Open();
                    authorID = (int)getAuthorIDCmd.ExecuteScalar();
                    Connection.Close();
                }
                int publisherID;
                using (SqlCommand getPublisherIDCmd = new SqlCommand("SELECT PublisherID FROM Publishers WHERE PublisherName = @PublisherName", Connection))
                {
                    getPublisherIDCmd.Parameters.AddWithValue("@PublisherName", selectedPublisher);
                    Connection.Open();
                    publisherID = (int)getPublisherIDCmd.ExecuteScalar();
                    Connection.Close();
                }
                int genreID;
                using (SqlCommand getGenreIDCmd = new SqlCommand("SELECT GenreID FROM Genres WHERE Genre = @Genre", Connection))
                {
                    getGenreIDCmd.Parameters.AddWithValue("@Genre", selectedGenre);
                    Connection.Open();
                    genreID = (int)getGenreIDCmd.ExecuteScalar();
                    Connection.Close();
                }
                int shelfNumber;
                if (!int.TryParse(selectedShelf, out shelfNumber))
                {
                    MessageBox.Show("Invalid Shelf Number. Please enter a valid integer value for Shelf Number.");
                    return;
                }
                string name = txtName.Text;

                // Kontrol için SQL sorgusu
                string checkIfExistsQuery = "SELECT COUNT(*) FROM Books WHERE BookName = @BookName AND BookID != @BookID";

                using (SqlCommand checkIfExistsCmd = new SqlCommand(checkIfExistsQuery, Connection))
                {
                    checkIfExistsCmd.Parameters.AddWithValue("@BookName", name);
                    checkIfExistsCmd.Parameters.AddWithValue("@BookID", editingBookID);
                    Connection.Open();

                    int existingBookCount = (int)checkIfExistsCmd.ExecuteScalar();

                    Connection.Close();

                    if (existingBookCount > 0)
                    {
                        MessageBox.Show("Another book with the same name already exists. Please choose a different name.");
                        return;
                    }
                }

                if (!int.TryParse(txtStock.Text, out int stock))
                {
                    MessageBox.Show("Invalid Stock. Please enter a valid integer value for Stock. Stock cannot be NEGATIVE");
                    return;
                }

                using (SqlCommand updateBooksCmd = new SqlCommand("UPDATE Books SET BookName = @Name, Stock = @Stock, AuthorID = @AuthorID, PublisherID = @PublisherID, GenreID = @GenreID, ShelfNumber = @ShelfNumber WHERE BookID = @BookID;", Connection))
                {
                    updateBooksCmd.Parameters.AddWithValue("@BookID", editingBookID);
                    updateBooksCmd.Parameters.AddWithValue("@Name", name);
                    updateBooksCmd.Parameters.AddWithValue("@Stock", stock);
                    updateBooksCmd.Parameters.AddWithValue("@AuthorID", authorID);
                    updateBooksCmd.Parameters.AddWithValue("@PublisherID", publisherID);
                    updateBooksCmd.Parameters.AddWithValue("@GenreID", genreID);
                    updateBooksCmd.Parameters.AddWithValue("@ShelfNumber", shelfNumber);

                    Connection.Open();
                    updateBooksCmd.ExecuteNonQuery();
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

        private void Insert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtStock.Text) && !string.IsNullOrEmpty(listBoxAuthor.Text) && !string.IsNullOrEmpty(listBoxPublisher.Text) && !string.IsNullOrEmpty(listBoxShelf.Text) && !string.IsNullOrEmpty(listBoxGenre.Text))
            {
                string selectedAuthor = listBoxAuthor.SelectedItem.ToString();
                string selectedPublisher = listBoxPublisher.SelectedItem.ToString();
                string selectedGenre = listBoxGenre.SelectedItem.ToString();
                string selectedShelf = listBoxShelf.SelectedItem.ToString();
                if (listBoxGenre.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Valid Genre.");
                    return;
                }
                if (listBoxShelf.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Valid Shelf Number.");
                    return;
                }
                if (listBoxPublisher.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Valid Publisher Name.");
                    return;
                }
                if (listBoxAuthor.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Valid Author Number.");
                    return;
                }
                int authorID;
                using (SqlCommand getAuthorIDCmd = new SqlCommand("SELECT AuthorID FROM Authors WHERE AuthorName = @AuthorName", Connection))
                {
                    getAuthorIDCmd.Parameters.AddWithValue("@AuthorName", selectedAuthor);
                    Connection.Open();
                    authorID = (int)getAuthorIDCmd.ExecuteScalar();
                    Connection.Close();
                }
                int publisherID;
                using (SqlCommand getPublisherIDCmd = new SqlCommand("SELECT PublisherID FROM Publishers WHERE PublisherName = @PublisherName", Connection))
                {
                    getPublisherIDCmd.Parameters.AddWithValue("@PublisherName", selectedPublisher);
                    Connection.Open();
                    publisherID = (int)getPublisherIDCmd.ExecuteScalar();
                    Connection.Close();
                }
                int genreID;
                using (SqlCommand getGenreIDCmd = new SqlCommand("SELECT GenreID FROM Genres WHERE Genre = @Genre", Connection))
                {
                    getGenreIDCmd.Parameters.AddWithValue("@Genre", selectedGenre);
                    Connection.Open();
                    genreID = (int)getGenreIDCmd.ExecuteScalar();
                    Connection.Close();
                }
                int shelfNumber;
                if (!int.TryParse(selectedShelf, out shelfNumber))
                {
                    MessageBox.Show("Invalid Shelf Number. Please enter a valid integer value for Shelf Number.");
                    return;
                }
                string name = txtName.Text;
                string checkIfExistsQuery = "SELECT COUNT(*) FROM Books WHERE BookName = @BookName";

                using (SqlCommand checkIfExistsCmd = new SqlCommand(checkIfExistsQuery, Connection))
                {
                    checkIfExistsCmd.Parameters.AddWithValue("@BookName", name);
                    Connection.Open();

                    int existingBookCount = (int)checkIfExistsCmd.ExecuteScalar();

                    Connection.Close();

                    if (existingBookCount > 0)
                    {
                        MessageBox.Show("This book already exists. Please update the stock.");
                        return;
                    }
                }
                if (!int.TryParse(txtStock.Text, out int stock))
                {
                    MessageBox.Show("Invalid Stock. Please enter a valid integer value for Stock. Stock cannot be NEGATIVE");
                    return;
                }
                using (SqlCommand insertBooksCmd = new SqlCommand("INSERT INTO Books(BookName, Stock, AuthorID, PublisherID, GenreID, ShelfNumber) VALUES (@Name, @Stock, @AuthorID, @PublisherID, @GenreID, @ShelfNumber);", Connection))
                {
                    insertBooksCmd.Parameters.AddWithValue("@Name", name);
                    insertBooksCmd.Parameters.AddWithValue("@Stock", stock);
                    insertBooksCmd.Parameters.AddWithValue("@AuthorID", authorID);
                    insertBooksCmd.Parameters.AddWithValue("@PublisherID", publisherID);
                    insertBooksCmd.Parameters.AddWithValue("@GenreID", genreID);
                    insertBooksCmd.Parameters.AddWithValue("@ShelfNumber", shelfNumber);

                    Connection.Open();
                    insertBooksCmd.ExecuteNonQuery();
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
        private void Delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtStock.Text) && !string.IsNullOrEmpty(listBoxAuthor.Text) && !string.IsNullOrEmpty(listBoxPublisher.Text) && !string.IsNullOrEmpty(listBoxShelf.Text) && !string.IsNullOrEmpty(listBoxGenre.Text))
            {
                using (SqlCommand deleteBooksCmd = new SqlCommand("DELETE FROM Books WHERE BookID = @BookID", Connection))
                {
                    deleteBooksCmd.Parameters.AddWithValue("@BookID", editingBookID);
                    Connection.Open();
                    deleteBooksCmd.ExecuteNonQuery();
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
                if (int.TryParse(row.Cells["BookID"].Value.ToString(), out editingBookID))
                {
                }
                txtName.Text = row.Cells["BookName"].Value.ToString();
                if (int.TryParse(row.Cells["Stock"].Value.ToString(), out int stock))
                {
                    txtStock.Text = stock.ToString();
                }
                listBoxAuthor.Text = row.Cells["AuthorName"].Value.ToString();
                listBoxGenre.Text = row.Cells["Genre"].Value.ToString();
                listBoxPublisher.Text = row.Cells["PublisherName"].Value.ToString();
                if (int.TryParse(row.Cells["ShelfNumber"].Value.ToString(), out int shelfNumber))
                {
                    listBoxShelf.Text = shelfNumber.ToString();
                }
            }

        }
    }
}
