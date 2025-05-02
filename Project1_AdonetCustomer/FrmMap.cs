using System;
using System.Windows.Forms;
namespace Project1_AdonetCustomer
{
    public partial class FrmMap : Form
    {
        public FrmMap()
        {
            InitializeComponent();
        }

        // Şehir formunu aç
        private void button1_Click(object sender, EventArgs e)
        {
            // Form zaten açıksa tekrar açma
            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmCity)
                {
                    form.Focus();
                    return;
                }
            }

            FrmCity frmCity = new FrmCity();
            frmCity.Show();
        }

        // Müşteri formunu aç
        private void btnOpenCustomerForm_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmCustomer)
                {
                    form.Focus();
                    return;
                }
            }

            FrmCustomer frmCustomer = new FrmCustomer();
            frmCustomer.Show();
        }

        // Çıkış butonu
        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Uygulamadan çıkmak istiyor musunuz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
