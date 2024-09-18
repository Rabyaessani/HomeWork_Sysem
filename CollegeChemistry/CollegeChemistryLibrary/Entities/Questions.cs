using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary.Entities
{
    public class Questions : BaseEntity
    {
        public int id { get; set; }
        public string question { get; set; }
        public string option_a { get; set; }
        public string option_b { get; set; }
        public string option_c { get; set; }
        public string option_d { get; set; }
        public char correct_option { get; set; }

        public int mcq_id { get; set; }
    }

}
