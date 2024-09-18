using CollegeChemistryLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary.Interfaces
{
    public interface Interface_Category
    {
        IEnumerable<Category> GetAllCategory();
        Category GetCategoryById(int categoryid);
        int AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);

        bool PublishCategory(int id, bool ispublish, DateTime? published_at);

        IEnumerable<Category> GetAllPublishCategory();
    }
}
