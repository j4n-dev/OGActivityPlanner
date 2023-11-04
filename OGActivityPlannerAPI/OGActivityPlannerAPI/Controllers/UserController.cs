using Microsoft.AspNetCore.Mvc;
using OGActivityPlannerAPI.Services;

namespace OGActivityPlannerAPI.Controllers
{
    /// <summary>
    /// Controller for managing users.
    /// </summary>
    [Controller]
    public class UserController : ControllerBase
    {
        #region Fields
        private readonly UserManagement _userManagement;
        #endregion


        public UserController(UserManagement userManagement)
        {
            this._userManagement = userManagement ?? throw new ArgumentNullException(nameof(userManagement)); 
        }
    }
}
