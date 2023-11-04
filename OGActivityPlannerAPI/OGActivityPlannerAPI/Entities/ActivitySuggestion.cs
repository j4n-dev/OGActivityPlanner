using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OGActivityPlannerAPI.Entities.Security;

namespace OGActivityPlannerAPI.Entities
{
    public class ActivitySuggestion
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? SuggestionId { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }

        [Required]
        [StringLength(255)]

        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        public int MaxParticipants { get; set; }

        public int MinParticipants { get; set; }

        public decimal EstimatedPrice { get; set; }

        public int EstimatedDuration { get; set; }

        #endregion



        #region Navigation Properties
        public User? User { get; set; }
        #endregion
    }
}
