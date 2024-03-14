using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryProject
{
    public partial class BorrowBooks : Form
    {
        public String ConnectionString = @"Data Source=.\;Database=LibraryDatabase;Integrated Security=True;trusted_connection=true;encrypt=false";
        public SqlConnection Connection;
        public SqlDataAdapter Adapt;
        public SqlCommand cmd;
        public SqlDataReader dataReader;
        public String sql, Output = "";
        public DataTable dataTable;
        public int indexRow;
        public int editingMemberID;
        public int editingBookID;
        public int editingBorrowID;

        public BorrowBooks()
        {
            InitializeComponent();
            Connection = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(sql, Connection);
        }
        private void RefreshGrid(object sender, EventArgs e)
        {
            Connection.Open();
            sql = "SELECT BookID, BookName FROM Books";
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

            sql = "SELECT MemberID, MemberName FROM Members";
            cmd = new SqlCommand(sql, Connection);
            dataReader = cmd.ExecuteReader();
            DataTable dt2 = new DataTable();
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                DataColumn column = new DataColumn(dataReader.GetName(i), dataReader.GetFieldType(i));
                dt2.Columns.Add(column);
            }
            while (dataReader.Read())
            {
                DataRow row = dt2.NewRow();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    row[i] = dataReader[i];
                }
                dt2.Rows.Add(row);
            }
            dt2.Load(dataReader);
            dataGridView2.DataSource = dt2;

            sql = "SELECT BB.BorrowID, B.BookName, M.MemberName, BB.BorrowDate " +
             "FROM BorrowedBooks AS BB " +
             "LEFT JOIN Books AS B ON BB.BookID = B.BookID " +
             "LEFT JOIN Members AS M ON BB.MemberID = M.MemberID " +
             "WHERE BB.BorrowID IS NOT NULL";
            cmd = new SqlCommand(sql, Connection);
            dataReader = cmd.ExecuteReader();
            DataTable dt3 = new DataTable();
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                DataColumn column = new DataColumn(dataReader.GetName(i), dataReader.GetFieldType(i));
                dt3.Columns.Add(column);
            }
            while (dataReader.Read())
            {
                DataRow row = dt3.NewRow();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    row[i] = dataReader[i];
                }
                dt3.Rows.Add(row);
            }
            dt3.Load(dataReader);
            dataGridView3.DataSource = dt3;

            Connection.Close();
        }

        private void Borrow_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMemberID.Text) && !string.IsNullOrEmpty(txtBookID.Text))
            {
                string MemberID = txtMemberID.Text;
                string BookID = txtBookID.Text;
                DateTime currentDate = DateTime.Now;
                string Date = currentDate.ToString("dd-MM-yyyy");
                using (SqlCommand insertBorrowedBooksCmd = new SqlCommand("INSERT INTO BorrowedBooks (MemberID, BookID, BorrowDate) VALUES (@MemberID, @BookID, @Date); SELECT SCOPE_IDENTITY();", Connection))
                {
                    insertBorrowedBooksCmd.Parameters.AddWithValue("@MemberID", MemberID);
                    insertBorrowedBooksCmd.Parameters.AddWithValue("@BookID", BookID);
                    insertBorrowedBooksCmd.Parameters.AddWithValue("@Date", Date);
                    Connection.Open();
                    int borrowedBookID = Convert.ToInt32(insertBorrowedBooksCmd.ExecuteScalar());
                    Connection.Close();
                    MessageBox.Show("Book Borrowed Successfully");
                    using (SqlCommand insertBorrowingHistoryCmd = new SqlCommand("INSERT INTO BorrowingHistory(MemberID, BookID, BorrowID, BorrowDate) VALUES (@MemberID, @BookID, @BorrowID, @Date)", Connection))
                    {
                        insertBorrowingHistoryCmd.Parameters.AddWithValue("@MemberID", MemberID);
                        insertBorrowingHistoryCmd.Parameters.AddWithValue("@BookID", BookID);
                        insertBorrowingHistoryCmd.Parameters.AddWithValue("@BorrowID", borrowedBookID);
                        insertBorrowingHistoryCmd.Parameters.AddWithValue("@Date", Date);

                        Connection.Open();
                        insertBorrowingHistoryCmd.ExecuteNonQuery();
                        Connection.Close();
                    }
                    using (SqlCommand updateStockCmd = new SqlCommand("UPDATE Books SET Stock = Stock - 1 WHERE BookID = @BookID", Connection))
                    {
                        updateStockCmd.Parameters.AddWithValue("@BookID", BookID);

                        Connection.Open();
                        updateStockCmd.ExecuteNonQuery();
                        Connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            RefreshGrid(sender, e);
        }

        private void BorrowBooks_Load(object sender, EventArgs e)
        {
            RefreshGrid(sender, e);
            Connection.Open();
            sql = "SELECT BookID, BookName FROM Books";
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
            sql = "SELECT MemberID, MemberName FROM Members";
            cmd = new SqlCommand(sql, Connection);
            dataReader = cmd.ExecuteReader();
            DataTable dt2 = new DataTable();
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                DataColumn column = new DataColumn(dataReader.GetName(i), dataReader.GetFieldType(i));
                dt2.Columns.Add(column);
            }
            while (dataReader.Read())
            {
                DataRow row = dt2.NewRow();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    row[i] = dataReader[i];
                }
                dt2.Rows.Add(row);
            }
            dt2.Load(dataReader);
            dataGridView2.DataSource = dt2;
            Connection.Close();
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
                txtBookID.Text = row.Cells["BookID"].Value.ToString();
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView2.Rows[indexRow];
                if (int.TryParse(row.Cells["MemberID"].Value.ToString(), out editingMemberID))
                {
                }
                txtMemberID.Text = row.Cells["MemberID"].Value.ToString();
            }
        }
        private void Delete_Click_1(object sender, EventArgs e)
        {
            {
                Connection.Open();
                using (SqlCommand insertBorrowHistoryCmd = new SqlCommand("UPDATE BorrowingHistory SET ReturnDate = @Date WHERE BorrowID = @BorrowID", Connection))
                {
                    DateTime currentDate = DateTime.Now;
                    string Date = currentDate.ToString("dd-MM-yyyy");
                    insertBorrowHistoryCmd.Parameters.AddWithValue("@Date", Date);
                    insertBorrowHistoryCmd.Parameters.AddWithValue("@BorrowID", editingBorrowID);
                    insertBorrowHistoryCmd.ExecuteNonQuery();
                }
                using (SqlCommand updateBorrowingHistoryCmd = new SqlCommand("UPDATE BorrowingHistory SET BorrowID = NULL WHERE BorrowID = @BorrowID", Connection))
                {
                    updateBorrowingHistoryCmd.Parameters.AddWithValue("@BorrowID", editingBorrowID);
                    updateBorrowingHistoryCmd.ExecuteNonQuery();
                }
                using (SqlCommand deleteBorrowedBooksCmd = new SqlCommand("DELETE FROM BorrowedBooks WHERE BorrowID = @BorrowID", Connection))
                {
                    deleteBorrowedBooksCmd.Parameters.AddWithValue("@BorrowID", editingBorrowID);
                    deleteBorrowedBooksCmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Deleted Successfully");
                using (SqlCommand updateStockCmd = new SqlCommand("UPDATE Books SET Stock = Stock + 1 WHERE BookID = @BookID", Connection))
                {
                    string BookID = txtBookID.Text;
                    updateStockCmd.Parameters.AddWithValue("@BookID", BookID);
                    updateStockCmd.ExecuteNonQuery();
                }


                Connection.Close();
            }
            RefreshGrid(sender, e);
        }

        private void BorrowHistory_Click(object sender, EventArgs e)
        {
            BorrowingHistory borrowingHistory = new BorrowingHistory();
            borrowingHistory.Show();
        }
        private int GetBookIDByName(string bookName)
        {
            int bookID = -1;
            string query = "SELECT BookID FROM Books WHERE BookName = @BookName";

            using (SqlCommand cmd = new SqlCommand(query, Connection))
            {
                cmd.Parameters.AddWithValue("@BookName", bookName);

                Connection.Open();
                object result = cmd.ExecuteScalar();
                Connection.Close();

                if (result != null && int.TryParse(result.ToString(), out bookID))
                {
                }
            }

            return bookID;
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView3.Rows[indexRow];
                if (int.TryParse(row.Cells["BorrowID"].Value.ToString(), out editingBorrowID))
                {
                }
                string bookName = row.Cells["BookName"].Value.ToString();
                int bookID = GetBookIDByName(bookName);
                txtBookID.Text = bookID.ToString();
            }
        }
    }
}
