
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
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
            private readonly IBillerRepository billerRepository;

            private readonly ResponseCode _responseCode;

            public UpdateBillerDetailCommandHandler(IBillerRepository billerRepository, IOptions<ResponseCode> responseCode)
            {
                this.billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));
                _responseCode = responseCode.Value;
            }
            public async Task<SuccessfulResponse> Handle(UpdateBillerDetailCommand request, CancellationToken cancellationToken)
            {
                var biller = await billerRepository.GetSingle(x => x.Id.Equals(request.updateBillerDetailDto.Id));

                if (biller != null)
                {

                    biller.ModifiedDate = DateTime.UtcNow;


                
                    billerRepository.Update(biller);
                        await billerRepository.CommitAsync();
                    return new SuccessfulResponse { Message = "Updated Successfully", StatusCode = _responseCode.OK };

                }
                else
                {
                    return new SuccessfulResponse { Message = "Opps Something Went Wrong", StatusCode = _responseCode.BadRequest };
                }
            

            }
        }
    }
}