using Analyzer.Lextatico.Application.Consumers.ApplicationUser;

namespace Analyzer.Lextatico.Application.ConsumersDefinition.ApplicationUser
{
    public class UserCreatedEventConsumerDefinition : BaseConsumerDefinition<UserCreatedEventConsumer>
    {
        public UserCreatedEventConsumerDefinition()
            : base("lextatico.exchange.UserCreatedEvent", "lextatico.UserCreated", "analyzer.lextatico.queue.UserCreatedEvent")
        {
        }
    }
}
