using Microsoft.EntityFrameworkCore;

namespace BloodDonationDetails.Models
{
    public class DonationDbContext : DbContext
    {
        public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options)
        {
             
        }

        public DbSet<DonationCandidateDetails> candidateDetails { get; set; }
    }
}
