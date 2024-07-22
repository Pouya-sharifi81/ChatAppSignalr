using CoreLayer.ViewModels.Auth;
using DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Service.User
{
    public interface IUserService
    {
        Task<bool> IsUserExist(string userName);
        Task<bool> IsUserExist(long userId);
        Task<bool> RegisterUser(RegisterViewModel registerModel);
        Task<UserEntity> LoginUser(LoginViewModel loginViewModel);
    }
}
