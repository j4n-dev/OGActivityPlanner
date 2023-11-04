using Microsoft.AspNetCore.Http.Features;
using OGActivityPlannerAPI.Services.Interfaces;

namespace OGActivityPlannerAPI.Services
{
    public class PermissionManagement : IPermissionManagement
    {
        #region Fields
        private readonly IDbManagement _dbManagement;
        #endregion

        public PermissionManagement(IDbManagement dbManagement) { 
            this._dbManagement = dbManagement ?? throw new ArgumentNullException(nameof(dbManagement));
        }



    }
}
