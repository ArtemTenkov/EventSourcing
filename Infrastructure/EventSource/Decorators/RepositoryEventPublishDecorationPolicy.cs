using SharedKernel;
using StructureMap.Building.Interception;

namespace Infrastructure.EventSource.Decorators
{
    public class RepositoryEventPublishDecorationPolicy : DecoratorPolicy
    {
        public RepositoryEventPublishDecorationPolicy()
            : base(typeof (IEventRepository<>), typeof (RepositoryEventPublishDecorator<>)
                  , type => true)
        {
        }
    }    
}
