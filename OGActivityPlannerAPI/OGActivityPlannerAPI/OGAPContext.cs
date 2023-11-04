using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OGActivityPlannerAPI.Entities;
using OGActivityPlannerAPI.Entities.Security;

namespace OGActivityPlannerAPI
{
    /// <summary> Represents the database context for OGActivityPlannerAPI. </summary>
    public class OGAPContext : IdentityDbContext<User>
    {
        /// <summary> Gets or sets the DbSet for <see cref="UserStats"/> entities. </summary>
        public DbSet<UserStats>? UserStats { get; set; }

        /// <summary> Gets or sets the DbSet for <see cref="ActivitySuggestion"/> entities. </summary>
        public DbSet<ActivitySuggestion>? ActivitySuggestions { get; set; }

        /// <summary> Gets or sets the DbSet for <see cref="Permission"/> entities. </summary>
        public DbSet<Permission>? Permissions { get; set; }

        /// <summary> Initializes a new instance of the <see cref="OGAPContext"/> class. </summary>
        /// <param name="options">The DbContext options.</param>
        public OGAPContext(DbContextOptions<OGAPContext> options) : base(options)
        {
            // Constructor for initializing the database context.
        }
    }
}
