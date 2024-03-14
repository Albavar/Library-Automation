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
using System.Xml.Linq;

namespace LibraryProject
{
    public partial class BorrowingHistory : Form
    {
        public String ConnectionString = @"Data Source=.\;Database=LibraryDatabase;Integrated Security=True;trusted_connection=true;encrypt=false";
        public SqlConnection Connection;
        public SqlDataAdapter Adapt;
        public SqlCommand cmd;
        public SqlDataReader dataReader;
        public String sql, Output = "";
        public int indexRow;

        public BorrowingHistory()
        {
            InitializeComponent();
            Connection = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(sql, Connection);
        }

        private void BorrowingHistory_Load(object sender, EventArgs e)
        {
            Connection.Open();
            sql = "SELECT M.MemberID, M.MemberName, M.MemberSurname, B.BookName, BB.BorrowDate, BH.ReturnDate " +
                  "FROM BorrowingHistory AS BH " +
                  "LEFT JOIN Members AS M ON BH.MemberID = M.MemberID " +
                  "LEFT JOIN Books AS B ON BH.BookID = B.BookID " +
                  "LEFT JOIN BorrowedBooks AS BB ON BH.BorrowID = BB.BorrowID";
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
}
