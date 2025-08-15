using AccessControl.Core;
using AccessControl.Core.Base;
using AccessControl.Data.Context;
using AccessControl.Data.Repositories.Interfaces;
using ControleDeAcesso.Domain.Entites;

namespace AccessControl.Data.Repositories
{
    public class EventDomainRepository : RepositoryBase<EventDomain>, IEventDomainRepository
    {
        //(AccessControlContext context, IUser user)

        private readonly AccessControlContext _context;
        public EventDomainRepository(AccessControlContext context, IUser user) : base(context, user)
        {
            _context = context;
        }


        public virtual async Task<EventDomain> CreateEvent(EventDomain eventDomain)
        {
            eventDomain.CreatedAt = DateTime.UtcNow;
            _context.Add(eventDomain);
            await SaveChanges();
            return eventDomain;
        }

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
