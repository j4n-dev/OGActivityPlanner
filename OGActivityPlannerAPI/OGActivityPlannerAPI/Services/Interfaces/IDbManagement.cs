using OGActivityPlannerAPI.Entities.Security;
using OGActivityPlannerAPI.StaticData;
using OGActivityPlannerAPI.Configuration;

namespace OGActivityPlannerAPI.Services.Interfaces

{
    /// <summary>
    /// interface for managing the database.
    /// </summary>
    public interface IDbManagement
    {
        /// <summary> 
        /// checks whether all <see cref="Role"/>s specified in <see cref="Constants.Roles"/> exist.
        /// </summary>
        /// <returns> 
        /// true if all <see cref="Role"/>s exists <br />
        /// false if one or more <see cref="Role"/>s does not exist
        /// </returns>
        Task<bool> RolesExist();

        /// <summary>
        /// checks whether the default <see cref="User"/> specified in <see cref="DefaultUser"/> exists. 
        /// </summary>
        /// <returns> 
        /// true if the default <see cref="User"/> exists <br />
        /// false if the defult <see cref="User"/> does not exist
        /// </returns>
        Task<bool> DefaultUserExists();

        /// <summary>
        /// checks if <see cref="PermissionsExist"/>, <see cref="RolesExist"/> and <see cref="DefaultUserExists"/> are true.
        /// </summary>
        /// <returns>
        /// true if all checks are true <br/>
        /// false if one or more checks are false
        /// </returns>
        Task<bool> CheckDatabase();
    }
}
