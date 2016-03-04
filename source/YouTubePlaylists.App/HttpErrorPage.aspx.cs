namespace YouTubePlaylists.App
{
    using System;
    using System.Web;
    using System.Web.UI;

    public partial class HttpErrorPage : Page
    {
        protected HttpException ex = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ex = (HttpException)Server.GetLastError();
            if (ex == null)
            {
                ex = new HttpException(404, "Page not found", ex);
            }

            int httpCode = ex.GetHttpCode();

            // Filter for Error Codes and set text
            if (httpCode >= 400 && httpCode < 500)
            {
                ex = new HttpException(httpCode, ex.Message, ex);
            }
            else if (httpCode > 499)
            {
                ex = new HttpException(ex.ErrorCode, "A problem has occurred on this web site.Please try again. " +
                "If this error continues, please contact support.", ex);
            }
            else
            {
                ex = new HttpException(httpCode, "A problem has occurred on this web site.Please try again. " +
                "If this error continues, please contact support.", ex);
            }

            // Fill the page fields
            this.exMessage.Text = ex.Message;

            if (Request.IsLocal)
            {
                this.exTrace.Text = ex.StackTrace;
                this.exTrace.Visible = true;

                // Show Inner Exception fields for local access
                if (ex.InnerException != null)
                {
                    this.innerTrace.Text = ex.InnerException.StackTrace;
                    this.InnerErrorPanel.Visible = true;
                    this.innerMessage.Text = string.Format("HTTP {0}: {1}",
                      httpCode, ex.InnerException.Message);
                }
            }

            // Clear the error from the server
            Server.ClearError();
        }
    }
}