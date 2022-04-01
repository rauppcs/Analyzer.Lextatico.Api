using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Domain.Events;
using Analyzer.Lextatico.Domain.Interfaces.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using User = Analyzer.Lextatico.Domain.Models.ApplicationUser;

namespace Analyzer.Lextatico.Application.Consumers.ApplicationUser
{
    public class UserUpdatedEventConsumer : IConsumer<UserUpdatedEvent>
    {
        private readonly IApplicationUserRepository _userRepository;

        public UserUpdatedEventConsumer(IApplicationUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Consume(ConsumeContext<UserUpdatedEvent> context)
        {
            await _userRepository.UpdateAsync(context.Message.ApplicationUser);
        }
    }
}
