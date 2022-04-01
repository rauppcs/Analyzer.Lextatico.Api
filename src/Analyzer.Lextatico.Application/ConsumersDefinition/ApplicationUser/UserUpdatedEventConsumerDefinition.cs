using Analyzer.Lextatico.Application.Consumers.ApplicationUser;

namespace Analyzer.Lextatico.Application.ConsumersDefinition.ApplicationUser
{
    public class UserUpdatedEventConsumerDefinition : BaseConsumerDefinition<UserUpdatedEventConsumer>
    {
        public UserUpdatedEventConsumerDefinition()
            : base("lextatico.exchange:UserUpdatedEvent", "lextatico.UserUpdated", "analyzer.lextatico.queue.UserUpdatedEvent")
        {
        }
    }
}
