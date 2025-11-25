using AutoMapper;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Community;
using HelioApp.Domain.Entities.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelioApp.Application.Services
{
    internal sealed class DiscussionCircleService : IDiscussionCircleService
    {
        private readonly IDiscussionCircleRepository repository;
        private readonly IMapper mapper;

        public DiscussionCircleService(IDiscussionCircleRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DiscussionCircleDto>> GetAll()
        {
            var entities = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<DiscussionCircleDto>>(entities);
        }

        public async Task<Guid> Create(CreateDiscussionCircleDto request)
        {
            var entity = mapper.Map<DiscussionCircle>(request);
            await repository.AddAsync(entity);
            await repository.CompleteAsync();
            return entity.Id;
        }

        public async Task Update(Guid id, UpdateDiscussionCircleDto request)
        {
            var existing = await repository.GetByIdAsync(id)
                           ?? throw new KeyNotFoundException("DiscussionCircle not found");
            mapper.Map(request, existing);
            existing.UpdatedAt = DateTimeOffset.UtcNow;

            repository.Update(existing);
            await repository.CompleteAsync();
        }

        public async Task Delete(Guid id)
        {
            var existing = await repository.GetByIdAsync(id)
                           ?? throw new KeyNotFoundException("DiscussionCircle not found");
            repository.Delete(existing);
            await repository.CompleteAsync();
        }
    }
}
