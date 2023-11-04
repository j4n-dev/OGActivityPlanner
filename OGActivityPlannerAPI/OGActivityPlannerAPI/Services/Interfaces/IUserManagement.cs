using Microsoft.AspNetCore.Mvc;

namespace OGActivityPlannerAPI.Services.Interfaces
{
    public interface IUserManagement
    {
        Task Login(string accessCode, DateOnly birthdate);
    }
}
