namespace SIS.MvcFramework
{
    using SIS.HTTP;
    using System.IO;
    using SIS.HTTP.Response;
    using SIS.MvcFramework.Interfaces;
    using System.Runtime.CompilerServices;
    using SIS.MvcFramework.Errors;

    public abstract class Controller
    {
        public HttpRequest Request { get; set; }

        protected HttpResponse View<T>(T viewModel = null, [CallerMemberName]string viewName = null)
            where T : class
        {
            var typeName = this.GetType().Name/*.Replace("Controller", string.Empty)*/;
            var controllerName = typeName.Substring(0, typeName.Length - 10);
            var viewPath = "Views/" + controllerName + "/" + viewName + ".html";
            return this.ViewByName<T>(viewPath, viewModel);
        }

        protected HttpResponse View([CallerMemberName]string viewName = null)
        {
            return this.View<object>(null, viewName);
        }

        protected HttpResponse Error(string error)
        {
            return this.ViewByName<ErrorViewModel>("Views/Shared/Error.html", new ErrorViewModel { Error = error });
        }

        protected HttpResponse Redirect(string url)
        {
            return new RedirectResponse(url);
        }

        private HttpResponse ViewByName<T>(string viewPath, object viewModel)
        {
            IViewEngine viewEngine = new ViewEngine();
            
            var html = File.ReadAllText(viewPath);
            html = viewEngine.GetHtml(html, viewModel, this.UserId, this.Username, this.Role);

            var layout = File.ReadAllText("Views/Shared/_Layout.html");
            var bodyWithLayout = layout.Replace("@RenderBody()", html);
            bodyWithLayout = viewEngine.GetHtml(bodyWithLayout, viewModel, this.UserId, this.Username, this.Role);
            return new HtmlResponse(bodyWithLayout);
        }

        protected bool IsUserLoggedIn()
        {
            return this.UserId != null;
        }

        protected void SignIn(string userId, string username)
        {
            this.Request.SessionData["UserId"] = userId;
        }

        protected void SignOut()
        {
            this.Request.SessionData["UserId"] = null;
        }

        public string UserId =>
            this.Request.SessionData.ContainsKey("UserId") ?
                this.Request.SessionData["UserId"] : null;


        public string Username =>
              this.Request.SessionData.ContainsKey("Username") ?
                this.Request.SessionData["Username"] : null;

        public string Role =>
              this.Request.SessionData.ContainsKey("Role") ?
                this.Request.SessionData["Role"] : null;
    }
}
