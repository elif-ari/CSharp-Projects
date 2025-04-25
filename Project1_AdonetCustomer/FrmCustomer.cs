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

        }
        SqlConnection sqlConnection = new SqlConnection("Server=ELIFARI\\SQLEXPRESS; initial catalog = DbCustomer;  integrated security= true");
        private void btnListele_Click(object sender, EventArgs e)
        {

            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select * From TblCustomer", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            sqlConnection.Close();
        }
    }
}
