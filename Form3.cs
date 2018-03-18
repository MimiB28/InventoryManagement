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
    public partial class Form3 : Form
    {
        private OleDbConnection mycon;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Mimi\Desktop\Sklad.accdb");
            try
            {
                mycon.Open();
                string code = tb_id.Text.ToString();
                string name = tb_product.Text.ToString();
                string price = this.tb_price.Text.ToString();
                string stock = tb_qnt.Text.ToString();

                //string my_query = "UPDATE Products SET product_name= '" + name + "', product_price= '" + price + "' , product_stock= '" + stock + "' WHERE ID =" + code + " ";
                string my_query1 = "UPDATE Products SET product_name= '" + name + "' WHERE ID =" + code + " ";
                string my_query2 = "UPDATE Products SET product_price= '" + price + "' WHERE ID =" + code + " ";
                string my_query3 = "UPDATE Products SET product_stock= '" + stock + "' WHERE ID =" + code + " ";

                //OleDbCommand cmd = new OleDbCommand(my_query, mycon);
                //cmd.CommandText = my_query;
                //cmd.ExecuteNonQuery();
                OleDbCommand cmd1 = new OleDbCommand(my_query1, mycon);
                cmd1.CommandText = my_query1;
                cmd1.ExecuteNonQuery();
                OleDbCommand cmd2 = new OleDbCommand(my_query2, mycon);
                cmd2.CommandText = my_query2;
                cmd2.ExecuteNonQuery();
                OleDbCommand cmd3 = new OleDbCommand(my_query3, mycon);
                cmd3.CommandText = my_query3;
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Продуктът е актуализиран!", "CONFIRMATION");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to " + ex.Message);
            }
            finally
            {
                mycon.Close();
            }
            this.productsTableAdapter.Fill(this.skladDataSet.Products);

            tb_id.Clear();
            tb_price.Clear();
            tb_product.Clear();
            tb_qnt.Clear();
        }

        public Form3()
        {
            mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Mimi\Desktop\Sklad.accdb");
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            date.Text = DateTime.Now.ToLongDateString();
            time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Mimi\Desktop\Sklad.accdb");
            try
            {
                mycon.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = mycon;
                string code = tb_id.Text.ToString();
                string cmdstr = "DELETE * FROM Products WHERE ID = " + code + "";
                cmd.CommandText = cmdstr;
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Продуктът е изтрит!", "CONFIRMATION");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message);
            }
            finally
            {
                mycon.Close();
            }
            this.productsTableAdapter.Fill(this.skladDataSet.Products);
            tb_id.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form back = new Form2();
            back.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Mimi\Desktop\Sklad.accdb");
            try
            {
                mycon.Open();
                string code = tb_id.Text.ToString();
                string name = tb_product.Text.ToString();
                string price = this.tb_price.Text.ToString();
                string stock = tb_qnt.Text.ToString();
                string my_querry = "INSERT INTO products([ID],[product_name],[product_price],[product_stock]) VALUES (" + code + ",'" + name + "','" + price + "'," + stock + ")";
                OleDbCommand cmd = new OleDbCommand(my_querry, mycon);
                cmd.ExecuteNonQuery();
                OleDbDataReader dr = cmd.ExecuteReader();
                MessageBox.Show("Продуктът е добавен!", "CONFIRMATION");

                tb_id.Clear();
                tb_price.Clear();
                tb_product.Clear();
                tb_qnt.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to " + ex.Message);
            }
            finally
            {
                mycon.Close();
            }
            this.productsTableAdapter.Fill(this.skladDataSet.Products);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
