using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TengYueManager.Api.Application.Commands;
using TengYueManager.Domain.StudentAggregate;

namespace TengYueManager.Api.Controllers
{
    [Route("identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly ILogger<IdentityController> _logger;
        private readonly IMediator _mediator;

        public IdentityController(ILogger<IdentityController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            CreateStudentCommand createStudentCommand = new CreateStudentCommand("张三", "20", "10", new Address("连云港", "大街上"));
           await _mediator.Send(createStudentCommand);
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
       
    }
}
