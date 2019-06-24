using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.Model
{
   public class PaymentC
    {
        public int id { get; set; }
        public float price { get; set; }
        public string duration { get; set; }
        public string dueamt { get; set; }
        public DateTime payment_date { get; set; }
        public int cust_id { get; set; }
        public string email{ get; set; }
    }
}
