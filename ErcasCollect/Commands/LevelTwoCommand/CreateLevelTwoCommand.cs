using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.LevelTwoDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;

namespace ErcasCollect.Commands.LevelTwoCommand
{
    public class CreateLevelTwoCommand : IRequest<int>
    {
        public CreateLevelTwoDto createLeveltwoDto { get; set; }
        public class CreateLevelTwoCommandHandler : IRequestHandler<CreateLevelTwoCommand, int>
        {
            private readonly ILevelTwoRepository leveltwoRepository;
            private readonly IMapper mapper;
            public CreateLevelTwoCommandHandler(ILevelTwoRepository leveltwoRepository, IMapper mapper)
            {
                this.leveltwoRepository = leveltwoRepository ?? throw new ArgumentNullException(nameof(leveltwoRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<int> Handle(CreateLevelTwoCommand request, CancellationToken cancellationToken)
            {

                LevelTwo leveltwo = mapper.Map<LevelTwo>(request.createLeveltwoDto);
                await leveltwoRepository.Add(leveltwo);
                await leveltwoRepository.CommitAsync();

                return leveltwo.Id;
            }
        }
    }
}
