#region Copyright(c) 2017 by HealthEquity Inc.
//
// All Rights Reserved.  Reproduction or transmission in whole or
// in part, in any form or by any means, electronic, mechanical or
// otherwise, is prohibited without the prior written consent of
// copyright owner.
//
// Property of HealthEquity, Inc.
//
// HealthEquity, Inc.
// 15 West Scenic Pointe Drive
// Draper, UT 84020  
// www.healthequity.com
// 
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LunchAndLearn.Data.Repositories
{
  public class AuthRepository : IDisposable
  {
    private AuthContext _ctx;

    private UserManager<IdentityUser> _userManager;

    public AuthRepository()
    {
      _ctx = new AuthContext();
      _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
    }

    public async Task<IdentityResult> RegisterUser(UserModel userModel)
    {
      IdentityUser user = new IdentityUser
      {
        UserName = userModel.UserName
      };

      var result = await _userManager.CreateAsync(user, userModel.Password);

      return result;
    }

    public async Task<IdentityUser> FindUser(string userName, string password)
    {
      IdentityUser user = await _userManager.FindAsync(userName, password);

      return user;
    }

    public void Dispose()
    {
      _ctx.Dispose();
      _userManager.Dispose();

    }
  }
}
