
using ErcasCollect.Commands.Dto;
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
    public class DeleteBillerCommand : IRequest<SuccessfulResponse>
    {
        public string id { get; set; }

        public class DeleteBillerCommandHandler : IRequestHandler<DeleteBillerCommand, SuccessfulResponse>
        {
            private readonly IBillerRepository billerRepository;

            public DeleteBillerCommandHandler(IBillerRepository billerRepository)
            {
                this.billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));
            }
            public async Task<SuccessfulResponse> Handle(DeleteBillerCommand request, CancellationToken cancellationToken)
            {
                var biller = await billerRepository.GetSingle(x => x.Id.Equals(request.id));

                if (biller != null)
                {
                    biller.IsDeleted = true;
                 

                    billerRepository.Update(biller);
                    await billerRepository.CommitAsync();
                    return new SuccessfulResponse { Message = "Deleted Successfully", StatusCode = "200" };

                }
                else
                {
                    return new SuccessfulResponse { Message = "Opps Something Went Wrong", StatusCode = "400" };
                }


            }
        }
    }
}