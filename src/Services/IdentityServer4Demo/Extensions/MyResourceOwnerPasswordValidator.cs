using IdentityServer4.Validation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4Demo.Extensions
{
    public class MyResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ILogger<MyResourceOwnerPasswordValidator> _logger;

        public MyResourceOwnerPasswordValidator(ILogger<MyResourceOwnerPasswordValidator> logger)
        {
            _logger = logger;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            _logger.LogInformation($"用户名：{context.UserName}--密码：{context.Password}");
            context.Result = new GrantValidationResult("1001", "MyResourceOwnerPasswordValidator");
            return Task.CompletedTask;
        }
    }
}
