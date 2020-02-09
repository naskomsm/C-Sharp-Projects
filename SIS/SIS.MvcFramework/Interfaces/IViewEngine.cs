namespace SIS.MvcFramework.Interfaces
{
    public interface IViewEngine
    {
        string GetHtml(string templateHtml, object model, string user);
    }
}
