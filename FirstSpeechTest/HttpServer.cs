using System;
using System.Text;
using System.Net;
using System.IO;
//using Westwind.Tools;

// originally from http://www.west-wind.com/weblog/posts/2005/Dec/04/Add-a-Web-Server-to-your-NET-20-app-with-a-few-lines-of-code
// but modified, esp. for error handling
namespace Westwind.InternetTools
{
    public delegate void delReceiveWebRequest(HttpListenerContext Context);

    /// <summary>
    /// Wrapper class for the HTTPListener to allow easier access to the
    /// server, for start and stop management and event routing of the actual
    /// inbound requests.
    /// </summary>
    public class HttpServer
    {

        protected HttpListener Listener;
        protected bool IsStarted = false;

        public event delReceiveWebRequest ReceiveWebRequest;

        public HttpServer()
        {
        }

        /// <summary>
        /// Starts the Web Service
        /// </summary>
        /// <param name="UrlBase">
        /// A Uri that acts as the base that the server is listening on.
        /// Format should be: http://127.0.0.1:8080/ or http://127.0.0.1:8080/somevirtual/
        /// Note: the trailing backslash is required! For more info see the
        /// HttpListener.Prefixes property on MSDN.
        /// </param>
        public bool Start(string UrlBase)
        {
            // *** Already running - just leave it in place
            if (this.IsStarted)
                return this.IsStarted;

            if (this.Listener == null)
            {
                this.Listener = new HttpListener();
            }

            this.Listener.Prefixes.Add(UrlBase);

            // original
            //this.Listener.Start();
            // new
            try
            {
                this.Listener.Start();
                this.IsStarted = true;
                IAsyncResult result = this.Listener.BeginGetContext(new AsyncCallback(WebRequestCallback), this.Listener);
            }
            catch (Exception exeption)
            {
                Console.WriteLine( "server startup failed, on WinXP or newer WITH admin privileges?" );
                Console.WriteLine(exeption);
            }

            return this.IsStarted;
            
        }

        /// <summary>
        /// Shut down the Web Service
        /// </summary>
        public void Stop()
        {
            if (Listener != null)
            {
                this.Listener.Close();
                this.Listener = null;
                this.IsStarted = false;
            }
        }


        protected void WebRequestCallback(IAsyncResult result)
        {
            if (this.Listener == null)
                return;

            // Get out the context object
            HttpListenerContext context = this.Listener.EndGetContext(result);

            // *** Immediately set up the next context
            this.Listener.BeginGetContext(new AsyncCallback(WebRequestCallback), this.Listener);

            if (this.ReceiveWebRequest != null)
                this.ReceiveWebRequest(context);

            this.ProcessRequest(context);
        }

        /// <summary>
        /// Overridable method that can be used to implement a custom hnandler
        /// </summary>
        /// <param name="Context"></param>
        protected virtual void ProcessRequest(HttpListenerContext Context)
        {
        }

    }
}