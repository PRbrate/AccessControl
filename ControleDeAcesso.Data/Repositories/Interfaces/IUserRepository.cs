using AccessControl.Domain.Entites;

namespace AccessControl.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IQueryable<User>> GetList();
        public void Dispose();
    }
}
