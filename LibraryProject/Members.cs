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
using System.Xml;
using System.Data.Common;

namespace LibraryProject
{
    public partial class Members : Form
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
        public Members()
        {
            InitializeComponent();
            Connection = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(sql, Connection);
        }
        private void RefreshGrid(object sender, EventArgs e)
        {
                Connection.Open();
                sql = "SELECT MemberID AS ID, MemberName AS Name, MemberSurname AS Surname, Email, RegisterDate , MemberAddress AS Address, MemberPhoneNumber AS Phone FROM Members";
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
        private void Members_Load(object sender, EventArgs e)
        {
            Connection.Open();
            sql = "SELECT MemberID AS ID, MemberName AS Name, MemberSurname AS Surname, Email, RegisterDate , MemberAddress AS Address, MemberPhoneNumber AS Phone FROM Members";
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
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtDate.Text) && !string.IsNullOrEmpty(txtAddress.Text) && !string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string email = txtEmail.Text;
                string address = txtAddress.Text;
                string phoneNumber = txtPhoneNumber.Text;
                DateTime date;
                if (!DateTime.TryParse(txtDate.Text, out date))
                {
                    MessageBox.Show("Gecersiz tarih formati");
                    return;
                }
                using (SqlCommand insertMembersCmd = new SqlCommand("INSERT INTO Members(MemberName, MemberSurname, Email, RegisterDate, MemberPhoneNumber, MemberAddress) VALUES (@Name, @Surname, @Email, @Date, @PhoneNumber, @Address);", Connection))
                {
                    insertMembersCmd.Parameters.AddWithValue("@Name", name);
                    insertMembersCmd.Parameters.AddWithValue("@Surname", surname);
                    insertMembersCmd.Parameters.AddWithValue("@Email", email);
                    insertMembersCmd.Parameters.AddWithValue("@Date", date);
                    insertMembersCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
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
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                DateTime dateValue;
                if (DateTime.TryParse(row.Cells["RegisterDate"].Value.ToString(), out dateValue))
                {
                    txtDate.Text = dateValue.ToString("dd-MM-yyyy");
                }
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtPhoneNumber.Text = row.Cells["Phone"].Value.ToString();
            }
            
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtDate.Text) && !string.IsNullOrEmpty(txtAddress.Text) && !string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                using (SqlCommand deleteMembersCmd = new SqlCommand("DELETE FROM Members WHERE MemberID = @MemberID", Connection))
                {
                    deleteMembersCmd.Parameters.AddWithValue("@MemberID", editingMemberID);
                    Connection.Open();
                    deleteMembersCmd.ExecuteNonQuery();
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
        private void Update_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtDate.Text) && !string.IsNullOrEmpty(txtAddress.Text) && !string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string email = txtEmail.Text;
                string address = txtAddress.Text;
                string phoneNumber = txtPhoneNumber.Text;
                DateTime date;
                if (!DateTime.TryParse(txtDate.Text, out date))
                {
                    MessageBox.Show("Gecersiz tarih formati");
                    return;
                }
                using (SqlCommand setMembersCmd = new SqlCommand("UPDATE Members SET MemberName = @Name , MemberSurname = @Surname, Email = @Email, RegisterDate = @Date, MemberPhoneNumber = @PhoneNumber, MemberAddress = @Address WHERE MemberID = @MemberID", Connection))
                {
                setMembersCmd.Parameters.AddWithValue("@MemberID", editingMemberID);
                setMembersCmd.Parameters.AddWithValue("@Name", name);
                setMembersCmd.Parameters.AddWithValue("@Surname", surname);
                setMembersCmd.Parameters.AddWithValue("@Email", email);
                setMembersCmd.Parameters.AddWithValue("@Date", date);
                setMembersCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                setMembersCmd.Parameters.AddWithValue("@Address", address);
                Connection.Open();
                setMembersCmd.ExecuteNonQuery();
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
        private void Penalty_Click(object sender, EventArgs e)
        {
            MemberPenalties memberPenalties = new MemberPenalties();
            memberPenalties.Show();
        }
    }
}
