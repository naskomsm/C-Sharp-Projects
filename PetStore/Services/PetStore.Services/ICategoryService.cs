namespace PetStore.Services
{
    public interface ICategoryService
    {
        bool Exists(int categoryId);

        void Add(string name);

        void Add(string name, string description);

        int GetIdByName(string name);
    }
}
