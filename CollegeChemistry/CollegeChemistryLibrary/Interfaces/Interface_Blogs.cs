using CollegeChemistryLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary.Interfaces
{
    public interface Interface_Blogs
    {
        IEnumerable<Blogs> GetAllBlogs();
        Blogs GetBlogById(int blogid);
        int AddBlog(Blogs blog);
        bool UpdateBlog(Blogs blog);
        bool DeleteBlog(Blogs blog);
    }
}
