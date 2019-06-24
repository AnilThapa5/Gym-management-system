using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using GymManagementSystem.Model;
using GymManagementSystem.View;

namespace GymManagementSystem.Controller
{
    public class TrainerController
    {
        public void trainercont(string name,string email,string phone,string add,int id,Trainer tt)
        {
            try
            {
                if (name == "")
                {
                    MessageBox.Show("please insert the name");
                }
                else if (add == "")
                {
                    MessageBox.Show("plesae insert the address");
                }
                else if (phone == "")
                {
                    MessageBox.Show("plesae insert the phone number");
                }
                else if(GYMValidations.checkphonelength(phone))
                {
                    MessageBox.Show("Phone Number must be  10 Digits");
                }
                else if(GYMValidations.checkduplicatephone(phone) && tt==null)
                {
                    MessageBox.Show("Phone number already Exist");
                }
                //else if(!GYMValidations.checkcharacter(phone))
                //{
                //    MessageBox.Show("Character Not Allowed");
                //}
                else if (email == "")
                {
                    MessageBox.Show("please insert the email");
                }

                else if(tt!=null)
                {
                    string quer = "update [tbl_trainer] set trainer_name='" + name + "',trainer_address='" + add
                        + "',trainer_phone='" + phone + "',trainer_email='" + email + "',user_id='" + 
                        id + "' where trainer_id='" + tt.trainer_id + "' ";
                    SQLConnection con = new SQLConnection();
                    con.Executequery(quer);
                   
                    MessageBox.Show("updated successfully");
                   
               
                  

                }
                else
                {
                    string query = "insert into [tbl_trainer] values('" + name + "','" + add + "','" + phone + "','" 
                        + id + "','" + email + "')";
                    SQLConnection db = new SQLConnection();
                    db.Executequery(query);
                    MessageBox.Show("Successfully Added Trainer");
                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


      public void viewtrainer(DataGridView dgv)
        {
            try
            {
                string query = "select * from [tbl_trainer]";
                SQLConnection con = new SQLConnection();
                DataTable dt = con.GetData(query);
                dgv.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
