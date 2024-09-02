using CollegeChemistryLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CollegeChemistryAPI
{
    public class CollegeChemistryDbContext : DbContext
    {
        public CollegeChemistryDbContext(DbContextOptions<CollegeChemistryDbContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<MCQs> MCQs { get; set; }
        public DbSet<MCQ_Questions> MCQ_Questions { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
    }
}
