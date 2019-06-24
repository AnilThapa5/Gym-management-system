using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymManagementSystem.Controller;

namespace GymManagementSystem.View
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter the Customer Email to search");
            }
            else
            {
                try
                {
                    string searchqur = "select c.c_name,c.c_email,c.c_address,c.c_phone,c.assigned_trainer,p.email,p.price " +
                    " from [tbl_customer] as c inner join [tbl_payment] as p on c.cust_id = p.cust_id " +
                    " where c.c_email like'%" + textBox1.Text + "%'";
                    SQLConnection con = new SQLConnection();
                    DataTable dt = con.GetData(searchqur);
                    dataGridView1.DataSource = dt;
                    this.dataGridView1.Visible = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
             }
           }

     

        private void SearchForm_Load(object sender, EventArgs e)
        {
           

        }
    }
}
