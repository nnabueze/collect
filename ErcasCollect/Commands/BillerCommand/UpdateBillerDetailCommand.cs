
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

namespace Ercas.Pay.Service.Commands
{
    public class UpdateBillerDetailCommand : IRequest<SuccessfulResponse>
    {

        public UpdateBillerDetailDto updateBillerDetailDto { get; set; }

        public class UpdateBillerDetailCommandHandler : IRequestHandler<UpdateBillerDetailCommand, SuccessfulResponse>
        {
            private readonly IBillerRepository _billerRepository;

            private readonly ResponseCode _responseCode;

            public UpdateBillerDetailCommandHandler(IBillerRepository billerRepository, IOptions<ResponseCode> responseCode)
            {
                _billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));

                _responseCode = responseCode.Value;
            }
            public async Task<SuccessfulResponse> Handle(UpdateBillerDetailCommand request, CancellationToken cancellationToken)
            {
                var biller = await _billerRepository.GetSingle(x => x.ReferenceKey.Equals(request.updateBillerDetailDto.BillerId));

                if (biller == null)
                {
                    return ResponseGenerator.Response("Biller Not Fount", _responseCode.NotFound, false, request.updateBillerDetailDto);
                }

                await UpdatebIller(request, biller);

                return ResponseGenerator.Response("Updated Successfully", _responseCode.OK, true);

            }

            private async Task UpdatebIller(UpdateBillerDetailCommand request, Biller biller)
            {
                biller.ModifiedDate = DateTime.UtcNow;

                biller.Address = request.updateBillerDetailDto.Address;

                biller.PhoneNumber = request.updateBillerDetailDto.PhoneNumber;

                biller.Description = request.updateBillerDetailDto.Description;

                biller.StateId = request.updateBillerDetailDto.StateId;

                biller.Latitude = request.updateBillerDetailDto.Latitude;

                biller.Longitude = request.updateBillerDetailDto.Longitude;

                biller.Abbreviation = request.updateBillerDetailDto.Abbreviation;

                _billerRepository.Update(biller);

                await _billerRepository.CommitAsync();
            }
        }
    }
}