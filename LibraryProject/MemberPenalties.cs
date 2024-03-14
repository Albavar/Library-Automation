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
    public partial class MemberPenalties : Form
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

        public MemberPenalties()
        {
            InitializeComponent();
            Connection = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(sql, Connection);
        }
        private void RefreshGrid(object sender, EventArgs e)
        {
            Connection.Open();
            sql = "SELECT M.MemberID AS ID, M.MemberName AS Name , M.MemberSurname AS Surname, M.MemberPhoneNumber AS Phone, M.Email AS Email, MP.PenaltyDate AS [Penalty Date], MP.PenaltyUpdateDate AS [Update Date], MP.PenaltyCause AS [Penalty Reason]" +
                  "FROM Members M " +
                  "LEFT JOIN MemberPenalties MP ON M.MemberID = MP.MemberID ORDER BY M.MemberID";
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
        private void MemberPenalties_Load(object sender, EventArgs e)
        {
            Connection.Open();
            sql = "SELECT M.MemberID AS ID, M.MemberName AS Name , M.MemberSurname AS Surname, M.MemberPhoneNumber AS Phone, M.Email AS Email, MP.PenaltyDate AS [Penalty Date], MP.PenaltyUpdateDate AS [Update Date], MP.PenaltyCause AS [Penalty Reason]" +
                  "FROM Members M " +
                  "LEFT JOIN MemberPenalties MP ON M.MemberID = MP.MemberID ORDER BY M.MemberID";
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
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtpenaltyReason.Text))
            {
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string penaltyReason = txtpenaltyReason.Text;
                DateTime currentDate = DateTime.Now;
                string Date = currentDate.ToString("dd-MM-yyyy");
                using (SqlCommand checkExistingCmd = new SqlCommand("SELECT COUNT(*) FROM MemberPenalties WHERE MemberID = @MemberID AND PenaltyCause IS NOT NULL", Connection))
                {
                    checkExistingCmd.Parameters.AddWithValue("@MemberID", editingMemberID);
                    Connection.Open();
                    int existingCount = (int)checkExistingCmd.ExecuteScalar();
                    Connection.Close();
                    if (existingCount > 0)
                    {
                        MessageBox.Show("This Member Already Has a Penalty. Update or Delete it.");
                    }
                    else
                    {
                        using (SqlCommand insertMemberPenaltyCmd = new SqlCommand("INSERT INTO MemberPenalties(MemberID, PenaltyDate, PenaltyCause) VALUES (@MemberID, @PenaltyDate, @PenaltyCause);", Connection))
                        {
                            insertMemberPenaltyCmd.Parameters.AddWithValue("@MemberID", editingMemberID);
                            insertMemberPenaltyCmd.Parameters.AddWithValue("@Name", name);
                            insertMemberPenaltyCmd.Parameters.AddWithValue("@Surname", surname);
                            insertMemberPenaltyCmd.Parameters.AddWithValue("@PenaltyCause", penaltyReason);
                            insertMemberPenaltyCmd.Parameters.AddWithValue("@PenaltyDate", Date);
                            Connection.Open();
                            insertMemberPenaltyCmd.ExecuteNonQuery();
                            Connection.Close();
                            MessageBox.Show("Record Inserted Successfully");
                        }
                    }
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
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtpenaltyReason.Text))
            {
                using (SqlCommand deleteMemberPenaltyCmd = new SqlCommand("DELETE FROM MemberPenalties WHERE MemberID = @MemberID", Connection))
                    {
                    deleteMemberPenaltyCmd.Parameters.AddWithValue("@MemberID", editingMemberID);
                    Connection.Open();
                    deleteMemberPenaltyCmd.ExecuteNonQuery();
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
        private void Update_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtpenaltyReason.Text))
            {
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string penaltyReason = txtpenaltyReason.Text;
                DateTime currentDate = DateTime.Now;
                string Date = currentDate.ToString("dd-MM-yyyy");
                using (SqlCommand setMemberPenaltyCmd = new SqlCommand("UPDATE MemberPenalties SET PenaltyCause = @PenaltyCause , PenaltyUpdateDate = @PenaltyUpdateDate WHERE MemberID = @MemberID", Connection))
                {
                    setMemberPenaltyCmd.Parameters.AddWithValue("@MemberID", editingMemberID);
                    setMemberPenaltyCmd.Parameters.AddWithValue("@Name", name);
                    setMemberPenaltyCmd.Parameters.AddWithValue("@Surname", surname);
                    setMemberPenaltyCmd.Parameters.AddWithValue("@PenaltyCause", penaltyReason);
                    setMemberPenaltyCmd.Parameters.AddWithValue("@PenaltyUpdateDate", Date);
                    Connection.Open();
                    setMemberPenaltyCmd.ExecuteNonQuery();
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                if (int.TryParse(row.Cells["ID"].Value.ToString(), out editingMemberID))
                {
                }
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSurname.Text = row.Cells["Surname"].Value.ToString();
                txtpenaltyReason.Text = row.Cells["Penalty Reason"].Value.ToString();
            }
        }
    }
}
