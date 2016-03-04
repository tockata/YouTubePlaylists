namespace YouTubePlaylists.App
{
    using System;
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;
    using YouTubePlaylists.App.App_Start;

    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DbConfig.Initialize();
            MapperConfig.RegisterMappings();
        }

        private void Application_Error(object sender, EventArgs e)
        {
            // Get last error from the server
            Exception exc = Server.GetLastError();

            if (exc is HttpUnhandledException)
            {
                if (exc.InnerException != null)
                {
                    exc = new Exception(exc.InnerException.Message);
                    Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax",
                        true);
                }
            }
            else if (exc is HttpException)
            {
                // Handle HTTP errors
                // The Complete Error Handling Example generates
                // some errors using URLs with "NoCatch" in them;
                // ignore these here to simulate what would happen
                // if a global.asax handler were not implemented.
                //if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
                //    return;

                //Redirect HTTP errors to HttpError page
                Server.Transfer("HttpErrorPage.aspx");
            }

            // For other kinds of errors give the user some information
            // but stay on the default page
            Response.Write("<h2>Global Page Error</h2>\n");
            Response.Write("<p>" + exc.Message + "</p>\n");
            Response.Write("Return to the <a href='Default.aspx'>Default Page</a>\n");

            // Clear the error from the server
            Server.ClearError();
        }
    }
}