namespace SulsApp.Services
{
    public interface ISubmissionsService
    {
        public void Create(string code, string problemId, string user);

        public void Delete(string id);
    }
}
