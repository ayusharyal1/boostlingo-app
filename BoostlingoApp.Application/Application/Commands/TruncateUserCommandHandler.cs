﻿using BoostlingoApp.Domain.Entities;
using BoostlingoApp.Infrastructure.Repository;
using Microsoft.Extensions.Logging;

namespace BoostlingoApp.Application.Commands
{
    public class TruncateUserCommandHandler(IUserRepository repo, ILogger<TruncateUserCommandHandler> logger) : ITruncateUserCommand
    {
        public void Execute()
        {
            try 
            {
                logger.LogInformation("Truncate Started");
                repo.Truncate<UserEntity>();
            }
            catch (Exception ex)
            {
                logger.LogError($"Could not truncate table User. Message:{ex.Message}");
                throw new Exception($"Could not truncate table User. Message:{ ex.Message}");
            }
        }
    }
}
