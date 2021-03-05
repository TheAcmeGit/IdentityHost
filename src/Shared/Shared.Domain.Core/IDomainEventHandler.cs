using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shared.Domain.Core
{
    public interface IDomainEventHandler<TDomainEvent>:INotificationHandler<TDomainEvent> where TDomainEvent:IDomainEvent
    {
    }
}
