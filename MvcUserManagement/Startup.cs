﻿using Microsoft.Owin;
using MvcUserManagement;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MvcUserManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}