using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.Model
{
   public  class Trainer
    {
        public int trainer_id { get; set; }
        public string trainer_name { get; set; }
        public string trainer_address { get; set; }
        public string trainer_phone { get; set; }
        public int user_id { get; set; }
        public string trainer_email { get; set; }
    }
}
