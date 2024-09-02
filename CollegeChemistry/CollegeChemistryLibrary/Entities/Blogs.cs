using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary.Entities
{
    public class Blogs : BaseEntity
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public byte[] cover_picture { get; set; }
    }

}
