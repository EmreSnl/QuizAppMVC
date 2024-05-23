using QuizApp.Business.Dtos;
using QuizApp.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Services
{
    public interface IUserService
    {
        ServiceMessage AddUser(AddUserDto addUserDto);

        UserInfoDto LoginUser(LoginUserDto loginUserDto);
        UserInfoDto GetUserInfoById(int userId);

    }
}
