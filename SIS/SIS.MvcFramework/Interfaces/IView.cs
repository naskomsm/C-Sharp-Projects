namespace SIS.MvcFramework.Interfaces
{
    public interface IView
    {
        string GetHtml(object model, string user);
    }
}
