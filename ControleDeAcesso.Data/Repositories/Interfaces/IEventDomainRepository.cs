using AccessControl.Core.Base.Repositories.Interface;
using AccessControl.Domain.Entites;
using ControleDeAcesso.Domain.Entites;

namespace AccessControl.Data.Repositories.Interfaces
{
    public interface IEventDomainRepository : IRepositoryBase<EventDomain>  
    {
        Task<List<EventDomain>> GetList();
        Task<EventDomain> GetUserFromId(string id);
        Task<EventDomain> GetFindByDater(DateTime date);
        Task<bool> Update(EventDomain eventDomain);
        void Dispose();
    }
}
