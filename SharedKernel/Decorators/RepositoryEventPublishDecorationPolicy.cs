using StructureMap.Building.Interception;

namespace SharedKernel.Decorators
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
