﻿using Microsoft.AspNet.Builder;
using Microsoft.Framework.Logging;

namespace Acando.CodeCamp.XSockets
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();
            loggerFactory.AddConsole();
        }
    }
}