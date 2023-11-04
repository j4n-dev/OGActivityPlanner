using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OGActivityPlannerAPI.Entities.Security;

namespace OGActivityPlannerAPI.Entities
{
    public class UserStats
    {
        #region Properties
        [Key]
        [ForeignKey("User")]
        public string? UserId { get; set; }

        public int ParticipatedInEvents { get; set; }

        public int ReviewsSubmitted { get; set; }

        public int CommentsPosted { get; set; }

        public int UploadedImages { get; set; }

        public int BeenWeekPlanner { get; set; }
        #endregion



        #region Navigation Properties
        public User? User { get; set; }
        #endregion
    }
}
