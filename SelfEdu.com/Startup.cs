﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SelfEdu.com.Startup))]
namespace SelfEdu.com
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
