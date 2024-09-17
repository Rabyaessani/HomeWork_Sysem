using CollegeChemistryLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary.Interfaces
{
    public interface MCQs_Interface
    {
        IEnumerable<MCQs> GetAllMCQs();
        MCQs GetMCQsById(int MCQid);
        int AddMCQ(MCQs mcq);
        bool UpdateMCQ(MCQs mcq);
        bool DeleteMCQ(MCQs mcq);

        bool PublishMCQ(int id, bool ispublish, DateTime? published_at);

        IEnumerable<MCQs> GetAllPublishMCQs();
    }
}
