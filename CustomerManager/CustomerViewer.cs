using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using CodeFirst;

namespace CustomerManager
{
    public partial class frmCustomerViewer : Form
    {
        SampleContext context = new SampleContext();
        byte[] Ph;
        public frmCustomerViewer()
        {
            InitializeComponent();
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer
                {
                    Name = this.textBoxName.Text,
                    LastName = this.textBoxLastName.Text,
                    Email = this.textBoxAddress.Text,
                    Age = Int32.Parse(this.textBoxAge.Text),
                    Photo = Ph
                };
                context.Customers.Add(customer);
                context.SaveChanges();
                textBoxName.Text = String.Empty;
                textBoxLastName.Text = String.Empty;
                textBoxAddress.Text = String.Empty;
                textBoxAge.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                Image bm = new Bitmap(dialog.OpenFile());
                ImageConverter converter = new ImageConverter();
                Ph = (byte[])converter.ConvertTo(bm, typeof(byte[]));
            }
        }
    }
}
