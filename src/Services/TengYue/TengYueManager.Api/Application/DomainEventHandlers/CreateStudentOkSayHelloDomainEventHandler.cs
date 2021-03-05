using Microsoft.Extensions.Logging;
using Shared.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TengYueManager.Domain.DomainEvent;

namespace TengYueManager.Api.Application.DomainEventHandlers
{
    public class CreateStudentOkSayHelloDomainEventHandler : IDomainEventHandler<CreateStudentOkSayHelloDomainEvent>
    {
        private readonly ILogger<CreateStudentOkSayHelloDomainEventHandler> _logger;

        public CreateStudentOkSayHelloDomainEventHandler(ILogger<CreateStudentOkSayHelloDomainEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CreateStudentOkSayHelloDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Hello {notification.Name}--{DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}
