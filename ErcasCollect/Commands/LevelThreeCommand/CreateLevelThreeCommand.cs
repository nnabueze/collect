using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.LevelThreeDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;

namespace ErcasCollect.Commands.LevelThreeCommand
{
    public class CreateLevelThreeCommand : IRequest<string>
    {
        public CreateLevelThreeDto createLevelthreeDto { get; set; }
        public class CreateLevelThreeCommandHandler : IRequestHandler<CreateLevelThreeCommand, string>
        {
            private readonly ILevelThreeRepository levelthreeRepository;
            private readonly IMapper mapper;
            public CreateLevelThreeCommandHandler(ILevelThreeRepository levelthreeRepository, IMapper mapper)
            {
                this.levelthreeRepository = levelthreeRepository ?? throw new ArgumentNullException(nameof(levelthreeRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(CreateLevelThreeCommand request, CancellationToken cancellationToken)
            {

                LevelThree levelthree = mapper.Map<LevelThree>(request.createLevelthreeDto);
                await levelthreeRepository.Insert(levelthree);
                return levelthree.Id;
            }
        }
    }
}

