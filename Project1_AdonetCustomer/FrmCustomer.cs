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

namespace Project1_AdonetCustomer
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            
            SqlCommand command = new SqlCommand("Select * From TblCity", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cmdCity.ValueMember = "CityId";
            cmdCity.DisplayMember = "CityName";
            cmdCity.DataSource = dataTable;
            
        }
        SqlConnection sqlConnection = new SqlConnection("Server=ELIFARI\\SQLEXPRESS; initial catalog = DbCustomer;  integrated security= true");
        private void btnListele_Click(object sender, EventArgs e)
        {

            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select CustomerId, CustomerName, CustomerSurname ,CustomerBalance , CustomerStatus , CityName from TblCustomer \r\nInner Join TblCity on TblCity.CityId = TblCustomer.CustomerCity", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            sqlConnection.Close();
        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {

            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Execute CustomerListWithCity", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            sqlConnection.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Insert Into TblCustomer (CustomerName, CustomerSurname, CustomerBalance, CustomerStatus, CustomerCity) Values (@customerName, @customerSurname, @customerBalance, @customerStatus, @customerCity)", sqlConnection);
            command.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            command.Parameters.AddWithValue("@customerSurname", txtCustomerSurname.Text);
            command.Parameters.AddWithValue("@customerBalance", txtBalance.Text);
            command.Parameters.AddWithValue("@customerCity", cmdCity.SelectedValue);
            if (rdbActive.Checked)
            {
                command.Parameters.AddWithValue("@customerStatus", 1);
            }
            if (rdbPassive.Checked)
            {
                command.Parameters.AddWithValue("@customerStatus", 0);
            }
            command.ExecuteNonQuery();  
            sqlConnection.Close();
            MessageBox.Show("Müşteri eklendi");
        }
        private void rdbActive_CheckedChanged(object sender, EventArgs e)
        {
            // Örneğin:
            // MessageBox.Show("Aktiflik durumu değişti!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM TblCustomer WHERE CustomerId = @customerId", sqlConnection);
            command.Parameters.AddWithValue("@customerId", txtCustomerId.Text);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Müşteri silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Update TblCustomer set CustomerName =@customerName , CustomerSurname =@customerSurname, CustomerBalance =  @customerBalance ,CustomerStatus = @customerStatus, CustomerCity = @customerCity) " +
                "where CustomerId= @customerId", sqlConnection);
            command.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            command.Parameters.AddWithValue("@customerSurname", txtCustomerSurname.Text);
            command.Parameters.AddWithValue("@customerBalance", txtBalance.Text);
            command.Parameters.AddWithValue("@customerCity", cmdCity.SelectedValue);
            command.Parameters.AddWithValue("@customerId", txtCustomerId.Text);
            if (rdbActive.Checked)
            {
                command.Parameters.AddWithValue("@customerStatus", 1);
            }
            if (rdbPassive.Checked)
            {
                command.Parameters.AddWithValue("@customerStatus", 0);
            }
            command.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Müşteri güncellendi");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select CustomerId, CustomerName, CustomerSurname ,CustomerBalance , CustomerStatus , CityName from TblCustomer \r\nInner Join TblCity on TblCity.CityId = TblCustomer.CustomerCity where CustomerName =@customerName  ", sqlConnection);
            command.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            sqlConnection.Close();
        }
    }

    }
