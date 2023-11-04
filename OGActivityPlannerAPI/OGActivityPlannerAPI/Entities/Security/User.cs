using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using OGActivityPlannerAPI.Entities.Relationships;
using OGActivityPlannerAPI.Entities.Security;

namespace OGActivityPlannerAPI.Entities.Security
{
    public class User : IdentityUser
    {
        #region Properties
        [Required]
        [StringLength(255)]
        public string? DisplayName { get; set; }

        [Required]
        [StringLength(4)]
        public Guid? AccessCode { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public DateTime? AccessCodeExpiry { get; set; }

        public string? Culture { get; set; } = "de-DE";
        #endregion



        #region Navigation Properties
        public UserStats? UserStats { get; set; }
        public ICollection<ActivitySuggestion>? ActivitySuggestions { get; set; }
        #endregion
    }
}
 