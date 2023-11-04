using OGActivityPlannerAPI.Entities.Relationships;
using OGActivityPlannerAPI.Entities.Security;
using System.Collections.ObjectModel;
using System.Data;
using static OGActivityPlannerAPI.StaticData.Constants;

namespace OGActivityPlannerAPI.StaticData
{
    public class Constants
    {
        #region Claim types
        public const string ClaimType_Permission = "Permission";
        #endregion

        #region Role constants
        public static readonly List<string> RoleNames = new() {
            Role_iamrootName, Role_AdminName, Role_WeekPlannerName,
            Role_OriginalName, Role_FriendName, Role_GuestName, 
        };

        // iamroot
        public const string Role_iamrootId = "ROLE_IAMROOT";
        public const string Role_iamrootName = "iamroot";
        // Admin
        public const string Role_AdminId = "ROLE_ADMIN";
        public const string Role_AdminName = "Admin";
        // Weekplanner
        public const string Role_WeekPlannerId = "ROLE_WEEKPLANNER";
        public const string Role_WeekPlannerName = "WeekPlanner";
        // Orignal
        public const string Role_OriginalId = "ROLE_ORIGINAL";
        public const string Role_OriginalName = "Original";
        // Friend
        public const string Role_FriendId = "ROLE_FRIEND";
        public const string Role_FriendName = "Friend";
        // Guest
        public const string Role_GuestId = "ROLE_GUEST";
        public const string Role_GuestName = "Guest";
        #endregion

        #region Permission constants
        public static readonly List<string> Permissions = new() {
            Permission_UserManagementRead, Permission_UserManagementWrite , Permission_SuggestionsRead,
            Permission_SuggestionsWrite, Permission_SuggestionsWriteOthers, Permission_SuggestionsVoteRead,
            Permission_SuggestionsVoteWrite, Permission_HistoryRead, Permission_TimelineRead, 
            Permission_TimelineWrite, Permission_HistoryCommentRead, Permission_HistoryCommentWrite,
            Permission_HistoryLikesRead, Permission_HistoryLikesWrite
        };

        // User management
        public const string Permission_UserManagementRead = "USER_MANAGEMENT_READ";
        public const string Permission_UserManagementWrite = "USER_MANAGEMENT_WRITE";
        // Suggenstions
        public const string Permission_SuggestionsRead = "SUGGESTIONS_READ";
        public const string Permission_SuggestionsWrite = "SUGGESTIONS_WRITE";
        public const string Permission_SuggestionsWriteOthers = "SUGGESTIONS_WRITE_OTHERS";
        public const string Permission_SuggestionsVoteRead = "SUGGESTIONS_VOTE_READ";
        public const string Permission_SuggestionsVoteWrite = "SUGGESTIONS_VOTE_WRITE";
        // Timeline
        public const string Permission_TimelineRead = "TIMELIME_READ";
        public const string Permission_TimelineWrite = "TIMELIME_WRITE";
        // History
        public const string Permission_HistoryRead = "HISTORY_READ";

        public const string Permission_HistoryCommentRead = "HISTORY_COMMENT_READ";
        public const string Permission_HistoryCommentWrite = "HISTORY_COMMENT_WRITE";

        public const string Permission_HistoryLikesRead = "HISTORY_LIKES_READ";
        public const string Permission_HistoryLikesWrite = "HISTORY_LIKES_WRITE";

        public const string Permission_HistoryVoteRepeat = "HISTORY_VOTE_REPEAT";

        public const string Permission_HistoryImagesRead = "HISTORY_IMAGES_READ";
        public const string Permission_HistoryImagesWrite = "HISTORY_IMAGES_WRITE";

        #endregion

        #region Rolepermission constants

        public static readonly List<string> IAmRootPermissions = Permissions;

        public static readonly List<string> AdminPermissions = new()
        {
            Permission_HistoryRead, Permission_HistoryCommentRead, Permission_HistoryLikesRead, Permission_HistoryImagesRead,
            Permission_HistoryImagesWrite, Permission_HistoryVoteRepeat, Permission_HistoryLikesWrite, Permission_TimelineRead,
            Permission_SuggestionsRead, Permission_SuggestionsVoteRead, Permission_HistoryCommentWrite, Permission_SuggestionsVoteWrite,
            Permission_SuggestionsWrite, Permission_UserManagementRead, Permission_TimelineWrite, Permission_SuggestionsWriteOthers,
            Permission_UserManagementWrite
        };

        public static readonly List<string> WeekplanerPermissions = new()
        {
            Permission_HistoryRead, Permission_HistoryCommentRead, Permission_HistoryLikesRead, Permission_HistoryImagesRead,
            Permission_HistoryImagesWrite, Permission_HistoryVoteRepeat, Permission_HistoryLikesWrite, Permission_TimelineRead,
            Permission_SuggestionsRead, Permission_SuggestionsVoteRead, Permission_HistoryCommentWrite, Permission_SuggestionsVoteWrite,
            Permission_SuggestionsWrite, Permission_UserManagementRead, Permission_TimelineWrite
        };

        public static readonly List<string> OriginalPermissions = new()
        {
            Permission_HistoryRead, Permission_HistoryCommentRead, Permission_HistoryLikesRead, Permission_HistoryImagesRead,
            Permission_HistoryImagesWrite, Permission_HistoryVoteRepeat, Permission_HistoryLikesWrite, Permission_TimelineRead,
            Permission_SuggestionsRead, Permission_SuggestionsVoteRead, Permission_HistoryCommentWrite, Permission_SuggestionsVoteWrite,
            Permission_SuggestionsWrite, Permission_UserManagementRead

        };

        public static readonly List<string> FriendPermissions = new()
        {
            Permission_HistoryRead, Permission_HistoryCommentRead, Permission_HistoryLikesRead, Permission_HistoryImagesRead,
            Permission_HistoryImagesWrite, Permission_HistoryVoteRepeat, Permission_HistoryLikesWrite, Permission_TimelineRead,
            Permission_SuggestionsRead, Permission_SuggestionsVoteRead, Permission_HistoryCommentWrite
        };

        public static readonly List<string> GuestPermissions = new() {
            Permission_HistoryRead, Permission_HistoryCommentRead, Permission_HistoryLikesRead, Permission_HistoryImagesRead
        };

        public static readonly Dictionary<string, List<string>> RolePermissions = new()
        {
            { Role_iamrootName, IAmRootPermissions },
            { Role_AdminName, AdminPermissions },
            { Role_WeekPlannerName, WeekplanerPermissions },
            { Role_OriginalName, OriginalPermissions },
            { Role_FriendName, FriendPermissions },
            { Role_GuestName, GuestPermissions }
        };
        #endregion
    }
}
