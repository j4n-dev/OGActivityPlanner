using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OGActivityPlannerAPI.Entities.Security;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OGActivityPlannerAPI.Helpers
{
    /// <summary> Extension methods for the UserManager class. </summary>
    public static class UserManagerExtensions
    {
        /// <summary> Finds a user by their access code asynchronously. </summary>
        /// <param name="userManager"> The UserManager instance. </param>
        /// <param name="accessCode"> The access code to search for. </param>
        /// <returns> A User object if a user with the specified access code is found; otherwise, a new User object. </returns>
        /// <exception cref="ArgumentNullException">Thrown if userManager is null.</exception>
        public static async Task<User> FindByAccessCodeAsync(this UserManager<User> userManager, string accessCode)
        {
            if (userManager is null) throw new ArgumentNullException(nameof(userManager));

            // Use FirstOrDefaultAsync to asynchronously find a user by access code.
            return await userManager.Users.FirstOrDefaultAsync(u => u.AccessCode.ToString() == accessCode) ?? new User();
        }
    }
}
