﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practica5.Startup))]
namespace Practica5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
