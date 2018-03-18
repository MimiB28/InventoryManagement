using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sklad
{
    public partial class Form2 : Form
    {
        private OleDbConnection mycon;

        public Form2()
        {
            mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Mimi\Desktop\Sklad.accdb");
            InitializeComponent();
            date.Text = DateTime.Now.ToLongDateString();
            time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }



        private void Form2_Load(object sender, EventArgs e)
        {

            this.productsTableAdapter.Fill(this.skladDataSet.Products);
            this.dataGridView1.ReadOnly = true;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Form Sklad = new Form2();
            Sklad.Show();
            this.Hide();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form Edit = new Form3();
            Edit.Show();
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
