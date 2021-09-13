using Microsoft.EntityFrameworkCore;

namespace Tester.Models
{
    public class TestContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Common> Commons { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }
    }
}
