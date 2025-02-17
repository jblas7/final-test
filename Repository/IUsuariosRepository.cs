using Models;

namespace CoWorking.Repositories
{
    public interface IUsuariosRepository
    {
        Task<List<Usuarios>> GetAllAsync();
        Task<Usuarios?> GetByIdAsync(int id);
        Task AddAsync(Usuarios usuario);
        Task UpdateAsync(Usuarios usuario);
        Task DeleteAsync(int id);
    }
}