using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class Staff : Form
    {
        public String ConnectionString = @"Data Source=.\;Database=LibraryDatabase;Integrated Security=True;trusted_connection=true;encrypt=false";
        public SqlConnection Connection;
        public SqlDataAdapter Adapt;
        public SqlCommand cmd;
        public SqlDataReader dataReader;
        public String sql, Output = "";
        public DataTable dataTable;
        public int indexRow;
        public int editingStaffID;
        public Staff()
        {
            InitializeComponent();
            Connection = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(sql, Connection);
        }
        private void RefreshGrid(object sender, EventArgs e)
        {
            Connection.Open();
            sql = "SELECT StaffID AS ID, StaffName AS Name, StaffSurname AS Surname, Position, PhoneNumber AS Phone , Email, StartDate AS [Start Date], Salary FROM Staff";
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
        private void FillpositionBox(object sender, EventArgs e)
        {
            positionBox.Items.Clear();
            positionBox.Items.Add("Manager");
            positionBox.Items.Add("Team Leader");
            positionBox.Items.Add("IT Manager");
            positionBox.Items.Add("IT Worker");
            positionBox.Items.Add("Head Librarian");
            positionBox.Items.Add("Librarian");
            positionBox.Items.Add("Cleaner");
        }
        private void Insert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtDate.Text) && !string.IsNullOrEmpty(txtSalary.Text) && !string.IsNullOrEmpty(txtPhone.Text) && !string.IsNullOrEmpty(positionBox.Text))
            {
                if (positionBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Valid Position.");
                    return;
                }
                string selectedPosition = positionBox.SelectedItem.ToString();
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string email = txtEmail.Text;
                string phoneNumber = txtPhone.Text;
                if (!int.TryParse(txtSalary.Text, out int salary))
                {
                    MessageBox.Show("Invalid Salary. Please enter a valid integer value for Salary.");
                    return;
                }
                DateTime date;
                if (!DateTime.TryParse(txtDate.Text, out date))
                {
                    MessageBox.Show("Gecersiz tarih formati");
                    return;
                }
                using (SqlCommand insertStaffCmd = new SqlCommand("INSERT INTO Staff(StaffName, StaffSurname, Position, PhoneNumber, Email, StartDate, Salary) VALUES (@Name, @Surname, @Position, @PhoneNumber, @Email, @Date, @Salary);", Connection))
                {
                    insertStaffCmd.Parameters.AddWithValue("@Name", name);
                    insertStaffCmd.Parameters.AddWithValue("@Surname", surname);
                    insertStaffCmd.Parameters.AddWithValue("@Position", selectedPosition);
                    insertStaffCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    insertStaffCmd.Parameters.AddWithValue("@Email", email);
                    insertStaffCmd.Parameters.AddWithValue("@Date", date);
                    insertStaffCmd.Parameters.AddWithValue("@Salary", salary);


                    Connection.Open();
                    insertStaffCmd.ExecuteNonQuery();
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

        private void Staff_Load(object sender, EventArgs e)
        {
                Connection.Open();
                sql = "SELECT StaffID AS ID, StaffName AS Name, StaffSurname AS Surname, Position, PhoneNumber AS Phone , Email, StartDate AS [Start Date], Salary FROM Staff";
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
            FillpositionBox(sender, e);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtDate.Text) && !string.IsNullOrEmpty(txtSalary.Text) && !string.IsNullOrEmpty(txtPhone.Text) && !string.IsNullOrEmpty(positionBox.Text))
            {
                if (positionBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Valid Position.");
                    return;
                }
                string selectedPosition = positionBox.SelectedItem.ToString();
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string email = txtEmail.Text;
                string phoneNumber = txtPhone.Text;
                string salary = txtSalary.Text;
                DateTime date;
                if (!DateTime.TryParse(txtDate.Text, out date))
                {
                    MessageBox.Show("Gecersiz tarih formati");
                    return;
                }
                using (SqlCommand setStaffCmd = new SqlCommand("UPDATE Staff SET StaffName = @Name , StaffSurname = @Surname, Position = @Position, StartDate = @Date, PhoneNumber = @PhoneNumber, Email = @Email, Salary = @Salary WHERE StaffID = @StaffID", Connection))
                {
                    setStaffCmd.Parameters.AddWithValue("@StaffID", editingStaffID);
                    setStaffCmd.Parameters.AddWithValue("@Name", name);
                    setStaffCmd.Parameters.AddWithValue("@Surname", surname);
                    setStaffCmd.Parameters.AddWithValue("@Position", selectedPosition);
                    setStaffCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    setStaffCmd.Parameters.AddWithValue("@Email", email);
                    setStaffCmd.Parameters.AddWithValue("@Date", date);
                    setStaffCmd.Parameters.AddWithValue("@Salary", salary);
                    Connection.Open();
                    setStaffCmd.ExecuteNonQuery();
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
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtDate.Text) && !string.IsNullOrEmpty(txtSalary.Text) && !string.IsNullOrEmpty(txtPhone.Text) && !string.IsNullOrEmpty(positionBox.Text))
            {
                using (SqlCommand deleteStaffCmd = new SqlCommand("DELETE FROM Staff WHERE StaffID = @StaffID", Connection))
                {
                    deleteStaffCmd.Parameters.AddWithValue("@StaffID", editingStaffID);
                    Connection.Open();
                    deleteStaffCmd.ExecuteNonQuery();
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
                if (int.TryParse(row.Cells["ID"].Value.ToString(), out editingStaffID))
                {
                }
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSurname.Text = row.Cells["Surname"].Value.ToString();
                string positionValue = row.Cells["Position"].Value.ToString();
                int positionIndex = -1;

                for (int i = 0; i < positionBox.Items.Count; i++)
                {
                    if (string.Equals(positionBox.Items[i].ToString(), positionValue, StringComparison.OrdinalIgnoreCase))
                    {
                        positionIndex = i;
                        break;
                    }
                }

                if (positionIndex != -1)
                {
                    positionBox.SelectedIndex = positionIndex;
                }
                else
                {
                    MessageBox.Show("Invalid Position in the Positions: " + positionValue);
                }
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                DateTime dateValue;
                if (DateTime.TryParse(row.Cells["Start Date"].Value.ToString(), out dateValue))
                {
                    txtDate.Text = dateValue.ToString("dd-MM-yyyy");
                }
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSalary.Text = row.Cells["Salary"].Value.ToString();
            }
        }

    }
}
