namespace SIS.MvcFramework.Interfaces
{
    public interface IView
    {
        string GetHtml(object model, string userId, string username, string role);
    }
}
