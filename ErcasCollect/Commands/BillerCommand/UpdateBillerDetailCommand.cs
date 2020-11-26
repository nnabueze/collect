
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Responses;
using MediatR;
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

            public UpdateBillerDetailCommandHandler(IBillerRepository billerRepository)
            {
                this.billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));
            }
            public async Task<SuccessfulResponse> Handle(UpdateBillerDetailCommand request, CancellationToken cancellationToken)
            {
                var biller = await billerRepository.GetSingle(x => x.Id.Equals(request.updateBillerDetailDto.Id));

                if (biller != null)
                {

                    biller.ModifiedDate = DateTime.UtcNow;


                
                    billerRepository.Update(biller);
                        await billerRepository.CommitAsync();
                    return new SuccessfulResponse { Message = "Updated Successfully", StatusCode = "200" };

                }
                else
                {
                    return new SuccessfulResponse { Message = "Opps Something Went Wrong", StatusCode = "400" };
                }
            

            }
        }
    }
}