using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using TengYueManager.Api.Application.DomainEventHandlers;
using TengYueManager.Domain.StudentAggregate;
using TengYueManager.Infrastructure;

namespace TengYueManager.Api.Application.Commands.CommandHandlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly ILogger<CreateStudentHandler> _logger;
        private readonly TengYueManagerDbContext _dbContext;

        public CreateStudentHandler(ILogger<CreateStudentHandler> logger, TengYueManagerDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = new Student(request.Name, request.Age, request.Sex, request.Address);
            _dbContext.Students.Add(student);
            return await _dbContext.SaveEntitiesAsync();
        }
    }
}
