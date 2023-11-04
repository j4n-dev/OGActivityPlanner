using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OGActivityPlannerAPI.Configuration;
using OGActivityPlannerAPI.Entities.Security;
using OGActivityPlannerAPI.Services.Interfaces;
using OGActivityPlannerAPI.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGActivityPlannerAPI.Services
{
    /// <summary>
    /// service for managing database operations.
    /// </summary>
    public class DbManagement : IDbManagement
    {
        private readonly OGAPContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly DefaultUser _cfgDefaultUser;

        /// <summary>
        /// initializes a new instance of the <see cref="DbManagement"/> class.
        /// </summary>
        /// <param name="ctx">the database context.</param>
        /// <param name="userManager">the user manager.</param>
        /// <param name="roleManager">the role manager.</param>
        /// <param name="roleManager">the <see cref="DefaultUser"/> configuation.</param>
        public DbManagement(OGAPContext ctx, UserManager<User> userManager, RoleManager<Role> roleManager, IOptions<DefaultUser> cfgDefaultUser)
        {
            _context = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _cfgDefaultUser = cfgDefaultUser.Value ?? throw new ArgumentNullException(nameof(cfgDefaultUser));
        }

        /// <inheritdoc />
        public Task<bool> CheckDatabase()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<bool> DefaultUserExists()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<bool> RolesExist()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// creates the roles if they do not exist in the database.
        /// </summary>
        /// <returns>
        /// null if the roles already exist <br/>
        /// true if the roles are created successfully <br/>
        /// </returns>
        /// <exception cref="Exception">thrown when one of the roles could not be created or assigned permissions.</exception>
        /// <remarks>
        /// this method creates the default roles and assigns the permissions to them.
        /// </remarks>
        private async Task<bool?> CreateRoles()
        {
            // check if one of the default roles does not exist in the database
            if (!await RolesExist())
            {
                foreach (var roleName in Constants.RoleNames)
                {
                    if (!await _roleManager.RoleExistsAsync(roleName))
                    {
                        // define role
                        Role roleToCreate = new Role
                        {
                            Id = Constants.Role_AdminId,
                            Name = roleName,
                            NormalizedName = roleName.ToUpper(),
                        };

                        // create role
                        IdentityResult roleCreatedResult = await _roleManager.CreateAsync(roleToCreate);

                        if (!roleCreatedResult.Succeeded)
                            throw new Exception("one of the roles could not be created: " + string.Join(", ", roleCreatedResult.Errors.Select(x => x.Description)));

                        // assign permissions to the role
                        List<string> specificRolePermissions = Constants.RolePermissions[roleName];

                        foreach (var permissionToAssign in specificRolePermissions)
                        {
                            IdentityResult rolePermissionResult = await _roleManager.AddClaimAsync(roleToCreate, new System.Security.Claims.Claim(Constants.ClaimType_Permission, permissionToAssign));

                            if (!rolePermissionResult.Succeeded)
                                throw new Exception("one of the permissions could not be assigned to the role: " + string.Join(", ", rolePermissionResult.Errors.Select(x => x.Description)));
                        }
                    }
                }
                return true;
            }
            return null;
        }

        /// <summary>
        /// creates the default user if it does not exist in the database.
        /// </summary>
        /// <returns>
        /// null if the default user already exists <br/>
        /// true if the default user is created successfully <br/>
        /// </returns>
        /// <exception cref="Exception">thrown when the default user could not be created or assigned the 'iamroot' role and all permissions.</exception>
        private async Task<bool?> CreateDefaultUser()
        {
            User user = await _userManager.FindByNameAsync(_cfgDefaultUser.UserName);

            if (user is not null)
                return null;

            // create a user with appsettings properties
            User defaultUser = new User
            {
                UserName = _cfgDefaultUser.UserName,
                DisplayName = _cfgDefaultUser.DisplayName,
                DateOfBirth = _cfgDefaultUser.DateOfBirth ?? DateOnly.FromDayNumber(1),
                AccessCode = _cfgDefaultUser.AccessCode
            };

            // attempt to create the default user
            IdentityResult defaultUserCreateResult = await _userManager.CreateAsync(defaultUser, "");

            // if the user is created successfully, assign the 'iamroot' role to the user and grant all permissions
            if (defaultUserCreateResult.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(Constants.Role_iamrootName))
                    throw new Exception("could not find the iamroot role");

                // create default user
                User createdUser = await _userManager.FindByNameAsync(_cfgDefaultUser.UserName);

                if (createdUser is null)
                    throw new Exception("could not find default user to assign admin role");

                // assign 'iamroot' role
                IdentityResult roleAssignResult = await _userManager.AddToRoleAsync(createdUser, Constants.Role_iamrootName);

                // assign all permissions to the default user if the roleAssignResult is succeeded
                if (roleAssignResult.Succeeded)
                {
                    // assign all permissions
                    foreach (var permission in Constants.Permissions)
                    {
                        IdentityResult permissionAssignResult = await _userManager.AddClaimAsync(createdUser, new System.Security.Claims.Claim(Constants.ClaimType_Permission, permission));

                        if (!permissionAssignResult.Succeeded)
                            throw new Exception("one of the permissions could not be assigned to the default user: " + string.Join(", ", permissionAssignResult.Errors.Select(x => x.Description)));
                    }

                    return true;

                }
                else
                {
                    throw new Exception("the permissions could not be assigned to the default user: " + string.Join(", ", roleAssignResult.Errors.Select(x => x.Description)));
                }
            }
            else
            {
                throw new Exception("the default user could not be created: " + string.Join(", ", defaultUserCreateResult.Errors.Select(x => x.Description)));
            }
        }
    }
}
