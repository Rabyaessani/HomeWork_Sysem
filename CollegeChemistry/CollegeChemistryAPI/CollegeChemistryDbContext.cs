using Microsoft.EntityFrameworkCore;

namespace CollegeChemistryAPI
{
    public class CollegeChemistryDbContext : DbContext
    {
        public CollegeChemistryDbContext(DbContextOptions<CollegeChemistryDbContext> options) : base(options)
        {

        }
    }
}
