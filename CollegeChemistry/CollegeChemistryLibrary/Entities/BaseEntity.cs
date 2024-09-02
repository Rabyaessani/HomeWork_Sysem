using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary.Entities
{
    public class BaseEntity
    {
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? published_at { get; set; }
        public int? created_by_id { get; set; }
        public int? updated_by_id { get; set; }
        public bool ispublish { get; set; }
    }

}
