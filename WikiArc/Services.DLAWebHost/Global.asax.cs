using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.MiniProfiler;
using ServiceStack.WebHost.Endpoints;
using System.Net;
using ServiceStack.Razor;
using ServiceStack.OrmLite;
using WikiArc.Interface;

namespace WikiArc.WebHost
{


    public class AppHost : AppHostBase
    {
        private static ILog log;
        public AppHost()
            : base("WikiMap for ArcGIS", typeof(GetServices).Assembly)
        {
            LogManager.LogFactory = new ConsoleLogFactory();
            log = LogManager.GetLogger(typeof(AppHost));
       
        }

        public override void Configure(Funq.Container container)
        {
            Plugins.Add(new RazorFormat());
            SetConfig(new EndpointHostConfig
            {
                CustomHttpHandlers = {
                    { HttpStatusCode.NotFound, new RazorHandler("/notfound") },
                    { HttpStatusCode.Unauthorized, new RazorHandler("/login") },
                }
            });


            //global request filter..for the arcgis....this was the coolest finding 
            this.RequestFilters.Add((httpReq, httpResp, requestDto) =>
            {
                //Console.Write(httpReq);
                var format = httpReq.QueryString["f"];
                if (format != null)
                {
                    httpReq.ResponseContentType = "application/json";
                }
            });


        }
    }
    
    

    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }
/*        protected void Application_BeginRequest(object src, EventArgs e)
        {
            if (Request.IsLocal)
                Profiler.Start();
        }

        protected void Application_EndRequest(object src, EventArgs e)
        {
            Profiler.Stop();
        }
  */     
    }
}