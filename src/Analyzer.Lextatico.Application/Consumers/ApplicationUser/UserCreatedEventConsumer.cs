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
    public class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
    {
        private readonly IApplicationUserRepository _userRepository;

        public UserCreatedEventConsumer(IApplicationUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            await _userRepository.InsertAsync(context.Message.ApplicationUser);
        }
    }
}
