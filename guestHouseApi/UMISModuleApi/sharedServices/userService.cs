using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Dapper;
using System.Text.Json.Serialization;
using UMISModuleAPI.Configuration;
using UMISModuleAPI.Entities;
using UMISModuleApi.Entities;
using UMISModuleAPI.Models;

namespace UMISModuleAPI.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        LoginResponse LoginAuthenticate(LoginRequest model);
        IEnumerable<User> GetAll();
        // IEnumerable<ApplicationModule> GetApplicationModule();
        // IEnumerable<Menu> GetMenu();
    }

    public class UserService : IUserService
    {
        // private readonly IConfiguration _config;
        private readonly IOptions<conStr> _dbCon;

        private List<User> _users = new List<User>();

        private string cmd;

        private readonly JwtConfig _jwtConfig;

        public UserService(IOptions<JwtConfig> jwtConfig, IOptions<conStr> dbCon)
        {
            _jwtConfig = jwtConfig.Value;
            _dbCon = dbCon;
        }
        // public AuthenticateResponse Authenticate(AuthenticateRequest model)
        // {
            // var response = dapperQuery.SPReturn("SP_loginCRUD", model, _dbCon);

            // var data = response.Select(row => new { res = row.ToString() });

            // if (data.First().res != "Success")
            //     return null;

        //     cmd = "Select UserID as userLoginId, LoginName as loginName, '' as Password, roleId, EmpName as FullName from view_user_login where LoginName = '" + model.Loginname + "' ";

        //     List<User> user = new List<User>(dapperQuery.Qry<User>(cmd, _dbCon));

        //     var token = generateToken(user);

        //     return new AuthenticateResponse(user, token);
        // }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            // cmd = "Select 'userID' as userLoginId, 'loginName' as loginName, '' as Password, 'roleId', 'empName' as FullName from view_user_login where 'loginName' = '" + model.Loginname + "' and 'Password' = '" + model.hashpassword + "';";
            cmd = "Select userID as userLoginId, email as loginName, '' as Password, roleId,roleTitle, firstName as FullName, teacherID, branch_id from view_user_login where email = '" + model.Loginname + "' and Password = HASHBYTES('SHA2_512', '" + model.hashpassword + "')";
            // cmd = "Select * from view_user_login";

            List<User> user = new List<User>(dapperQuery.Qry<User>(cmd, _dbCon));

            if (user.Count == 0) return null;

            var token = generateToken(user);

            return new AuthenticateResponse(user, token);
        }

        public LoginResponse LoginAuthenticate(LoginRequest model)
        {
            cmd = @"Select userID as userLoginId, email as loginName, '' as Password, 
                    firstName as FullName,userCNIC,teacherID,cast(isTeacher as bit) isTeacher,
                    cast(isParent as bit) isParent,
                    cast(isEmployee as bit) isEmployee 
                    from view_mobile_user_login 
                    where (userCNIC = '" + model.email + "' or email = '" + model.email + "') and Password = HASHBYTES('SHA2_512','" + model.hashpassword + "')";
            
            List<LoginUser> user = new List<LoginUser>(dapperQuery.Qry<LoginUser>(cmd, _dbCon));

            if (user.Count == 0) return null;

            var token = LoginToken(user);

            return new LoginResponse(user, token);
        }

        private string generateToken(List<User> user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("userLoginId", user[0].userLoginId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }

        private string LoginToken(List<LoginUser> user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("userLoginId", user[0].userLoginId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<User> GetAll()
        {

            cmd = "select * from users;";
            return dapperQuery.Qry<User>(cmd, _dbCon);
        }
        // public IEnumerable<ApplicationModule> GetApplicationModule()
        // {

        //     cmd = "select * from view_application_modules;";
        //     return dapperQuery.Qry<ApplicationModule>(cmd, _dbCon);
        // }

        // public IEnumerable<Menu> GetMenu()
        // {

        //     cmd = "select * from view_user_role_details;";
        //     return dapperQuery.Qry<Menu>(cmd, _dbCon);
        // }
    }
}