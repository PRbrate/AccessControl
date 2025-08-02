using AccessControl.Core;
using AccessControl.Core.Base;
using AccessControl.Data.Context;
using AccessControl.Data.Repositories.Interfaces;
using ControleDeAcesso.Domain.Entites;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AccessControl.Data.Repositories
{
    public class EventDomainRepository(AccessControlContext context, IUser user) : RepositoryBase<EventDomain>(context, user), IEventDomainRepository
    {
        public Task<EventDomain> GetFindByDater(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<List<EventDomain>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<EventDomain> GetUserFromId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
