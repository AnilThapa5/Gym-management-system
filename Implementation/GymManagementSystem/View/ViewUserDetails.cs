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
using GymManagementSystem.Model;

namespace GymManagementSystem.View
{
    public partial class ViewUserDetails : Form
    {
        public int id = 0;
        
        public ViewUserDetails()
        {
            InitializeComponent();
        }

        public void ViewUserDetails_Load(object sender, EventArgs e)
        {
            RegisterControll rc = new RegisterControll();
            rc.viewuserdetails(dataGridView1,id);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string command = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (command.ToLower() == "delete")
            {
                try
                {

                    string query = "delete from [tbl_user] where user_id='" + id + "'";
                    SQLConnection con = new SQLConnection();
                    con.Executequery(query);
                    MessageBox.Show("successfully Deleted");
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (command.ToLower() == "edit")
                    {

                try
                {
                    string query = "select * from[tbl_user] where user_id=" + id;
                    SQLConnection con = new SQLConnection();
                    DataTable dt = con.GetData(query);
                    if (dt.Rows.Count > 0)
                    {
                        User u = new User();
                        u.id =(int)(dt.Rows[0]["user_id"]);
                        u.firstname = (string)dt.Rows[0]["name"];
                        u.email = (string)dt.Rows[0]["email"];
                        u.username = (string)dt.Rows[0]["username"];
                        u.password = (string)dt.Rows[0]["password"];
                        u.lastname = (string)dt.Rows[0]["last_name"];
                        UserRegistrationForm urf = new UserRegistrationForm(u);
                        urf.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
