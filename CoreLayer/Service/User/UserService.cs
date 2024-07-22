using CoreLayer.Utilitiy.Security;
using CoreLayer.ViewModels.Auth;
using DataLayer.Context;
using DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Service.User
{
    public class UserService : BaseService, IUserService
    {
        public UserService(EchatDbContex context) : base(context)
        {

        }

        public async Task<bool> IsUserExist(string userName)
        {
           // return await _context.userEntities.AsNoTracking().AnyAsync(x=>x.UserName == userName.ToLower());
            return await Table<UserEntity>().AnyAsync(x => x.UserName == userName.ToLower());
        }

        public Task<bool> IsUserExist(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> LoginUser(LoginViewModel loginViewModel)
        {
            var user = await Table<UserEntity>().SingleOrDefaultAsync(u => u.UserName == loginViewModel.UserName.ToLower());
            if (user == null) { return null; }
             var password = loginViewModel.Password.EncodePasswordMd5();
            if(password != user.Password)
            {
                return null;
            }
            return user;
        }

        public async Task<bool> RegisterUser(RegisterViewModel registerModel)
        {

            if (await IsUserExist(registerModel.UserName))
                return false;

            if (registerModel.Password != registerModel.RePassword)
                return false;

            var password = registerModel.Password.EncodePasswordMd5();
            var user = new UserEntity()
            {
                Avatar = "Default.jpg",
                CreateDate = DateTime.Now,
                Password = password,
                UserName = registerModel.UserName.ToLower()
            };
            Insert(user);
            await Save();
            return true;
        }
    }
}
