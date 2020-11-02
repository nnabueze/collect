using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.LevelOneDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;
namespace ErcasCollect.Commands.BranchCommand
{
    public class CreateLevelOneCommand : IRequest<string>
    {
        public CreateLevelOneDto createLevelOneDto { get; set; }
        public class CreateLevelOneCommandHandler : IRequestHandler<CreateLevelOneCommand, string>
        {
            private readonly ILevelOneRepository leveloneRepository;
            private readonly IMapper mapper;
            public CreateLevelOneCommandHandler(ILevelOneRepository leveloneRepository, IMapper mapper)
            {
                this.leveloneRepository = leveloneRepository ?? throw new ArgumentNullException(nameof(leveloneRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(CreateLevelOneCommand request, CancellationToken cancellationToken)
            {

                LevelOne levelone = mapper.Map<LevelOne>(request.createLevelOneDto);
                await leveloneRepository.Add(levelone);
                await leveloneRepository.CommitAsync();
                return levelone.Id;
            }
        }
    }
}



