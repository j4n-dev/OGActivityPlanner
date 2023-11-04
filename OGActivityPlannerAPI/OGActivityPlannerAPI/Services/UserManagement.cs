using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OGActivityPlannerAPI.Entities.Security;
using OGActivityPlannerAPI.Helpers;
using OGActivityPlannerAPI.Services.Interfaces;
using OGActivityPlannerAPI.StaticData;
using System.Linq;

namespace OGActivityPlannerAPI.Services
{
    public class UserManagement : IUserManagement
    {
        private readonly OGAPContext _context;

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserManagement(OGAPContext ctx, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _context = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public async Task Login(string accessCode, DateOnly birthdate)
        {
            var user = await _userManager.FindByAccessCodeAsync(accessCode);

            if (user != null && user.DateOfBirth == birthdate)
            {

            }
        }
    }
}
