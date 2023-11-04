using Microsoft.AspNetCore.Identity;
using OGActivityPlannerAPI.Entities.Security;
using OGActivityPlannerAPI.Services.Interfaces;
using OGActivityPlannerAPI.StaticData;

namespace OGActivityPlannerAPI.Services
{
    public class RoleManagement : IRoleManagement
    {
        private readonly OGAPContext _context;

        private readonly RoleManager<Role> _roleManager;

        public RoleManagement(OGAPContext ctx, RoleManager<Role> roleManager)
        {
            _context = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }
    }
}
