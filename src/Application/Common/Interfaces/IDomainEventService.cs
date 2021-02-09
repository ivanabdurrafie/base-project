using todo_api.Domain.Common;
using System.Threading.Tasks;

namespace todo_api.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
