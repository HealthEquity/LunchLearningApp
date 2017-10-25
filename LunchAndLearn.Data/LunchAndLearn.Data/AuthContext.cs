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
using Microsoft.AspNet.Identity.EntityFramework;

namespace LunchAndLearn.Data
{
  public class AuthContext : IdentityDbContext<IdentityUser>
  {
    public AuthContext()
      : base("AuthContext")
    {

    }
  }
}
