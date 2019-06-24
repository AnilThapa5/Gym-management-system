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
    public partial class ViewTrainerDetails : Form
    {
        public int id = 0;
        public ViewTrainerDetails()
        {
            InitializeComponent();
        }

        private void ViewTrainerDetails_Load(object sender, EventArgs e)
        {
            TrainerController tc = new TrainerController();
            tc.viewtrainer(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string command = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (command.ToLower() == "delete")
            {
                try
                {

                    string query = "delete from [tbl_trainer] where trainer_id='" + id + "'";
                    SQLConnection con = new SQLConnection();
                    con.Executequery(query);
                    MessageBox.Show("successfully Deleted");
                    TrainerController tc = new TrainerController();
                    tc.viewtrainer(dataGridView1);
                 
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
                    string query = "select * from[tbl_trainer] where trainer_id=" + id;
                    SQLConnection con = new SQLConnection();
                    DataTable dt = con.GetData(query);
                    if (dt.Rows.Count > 0)
                    {
                        Trainer t = new Trainer();
                        t.trainer_id = (int)(dt.Rows[0]["trainer_id"]);
                        t.trainer_name = (string)dt.Rows[0]["trainer_name"];
                        t.trainer_address = (string)dt.Rows[0]["trainer_address"];
                        t.trainer_phone = (string)dt.Rows[0]["trainer_phone"];
                        t.trainer_email = (string)dt.Rows[0]["trainer_email"];
                        AddTrainer at = new AddTrainer(t);
                        at.id = this.id;
                        at.Show();
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
