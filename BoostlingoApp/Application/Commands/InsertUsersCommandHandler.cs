﻿using AutoMapper;
using BoostlingoApp.Application.Mappers;
using BoostlingoApp.Domain.Entities;
using BoostlingoApp.Domain.Models;
using BoostlingoApp.Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BoostlingoApp.Application.Commands
{
    public class InsertUsersCommandHandler(IUserRepository repo, ILogger<InsertUsersCommandHandler> logger, IMapper mapper) : IInsertUsersCommand
    {
        public bool Execute(List<User> users)
        {
            try 
            {
                logger.LogInformation("Start insert");
                repo.AddRange(mapper.Map<List<User>,List<UserEntity>>(users));
            }
            catch(Exception ex) 
            {
                logger.LogError($"Could not insert data to  table User. Message:{JsonSerializer.Serialize(ex)}");
                throw new Exception($"Could not insert data to table User. Message:{JsonSerializer.Serialize(ex)}");
            }
            return true;
        }
    }
}