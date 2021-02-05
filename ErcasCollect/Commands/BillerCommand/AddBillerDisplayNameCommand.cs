using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.BillerCommand
{
    public class AddBillerDisplayNameCommand : IRequest<SuccessfulResponse>
    {
        public BillerDisplayNameDto billerDisplayNameDto { get; set; }

        public class AddBillerDisplayNameCommandHandler : IRequestHandler<AddBillerDisplayNameCommand, SuccessfulResponse>
        {
            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

            public AddBillerDisplayNameCommandHandler(IGenericRepository<Biller> billerRepository, IOptions<ResponseCode> responseCode, IGenericRepository<LevelDisplayName> levelDisplayNameRepository)
            {
                _billerRepository = billerRepository;

                _responseCode = responseCode.Value;

                _levelDisplayNameRepository = levelDisplayNameRepository;
            }

            public async Task<SuccessfulResponse> Handle(AddBillerDisplayNameCommand request, CancellationToken cancellationToken)
            {
                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request.billerDisplayNameDto.BillerId);

                if (biller == null)

                    return ResponseGenerator.Response("Invalid biller Id", _responseCode.NotFound, false);

                var billerDisplayName = new LevelDisplayName()
                {
                    BillerId = biller.Id,

                    CategoryOneDisplayName = request.billerDisplayNameDto.CategoryOneDisplayName,

                    CategoryTwoDisplayName = request.billerDisplayNameDto.CategoryTwoDisplayName,

                    LevelOneDisplayName = request.billerDisplayNameDto.LevelOneDisplayName,

                    LevelTwoDisplayName = request.billerDisplayNameDto.LevelTwoDisplayName,

                    CreatedDate = DateTime.UtcNow
                    
                };

                var saveBillerDisplayName = await _levelDisplayNameRepository.Add(billerDisplayName);

                await _levelDisplayNameRepository.CommitAsync();

                return ResponseGenerator.Response("Created", _responseCode.Created, true, saveBillerDisplayName);
            }
        }
    }
}
