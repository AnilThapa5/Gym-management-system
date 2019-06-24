using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.Model
{
   public  class Customer
    {
        public int cust_id { get; set; }
        public string cname { get; set; }
        public string cemail { get; set; }
        public string cphone { get; set; }
        public DateTime dob { get; set; }
        public string address { get; set; }
        public int user_id { get; set; }
       public string assigned_trainer { get; set; }
    }
}
