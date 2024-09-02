using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary.Entities
{
    public class Lessons : BaseEntity
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public byte[] cover_picture { get; set; }
        public string content { get; set; }
        public string youtube_video { get; set; }
    }

}
