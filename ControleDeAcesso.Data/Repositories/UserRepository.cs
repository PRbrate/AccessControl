using AccessControl.Core;
using AccessControl.Data.Context;
using AccessControl.Data.Repositories.Interfaces;
using AccessControl.Domain.Entites;

namespace AccessControl.Data.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly AccessControlContext _context;
        private readonly long ContaId;

        public UserRepository(AccessControlContext context, IUser user)
        {
            _context = context;
            ContaId = user.GetAccountId();
        }

        public async Task<IQueryable<User>> GetList()
        {
            var query = _context.Users
                 .Where(c => c.ContaId == ContaId)
                 .AsQueryable();

            return await Task.FromResult(query);
        }

        public void Dispose() =>
       _context?.Dispose();

    }
}
