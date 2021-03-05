using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shared.Domain.Core
{
    public interface IDomainEvent:INotification
    {
    }
}
