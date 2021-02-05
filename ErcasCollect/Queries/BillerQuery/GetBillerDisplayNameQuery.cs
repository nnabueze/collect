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

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetBillerDisplayNameQuery : IRequest<SuccessfulResponse>
    {
        private string _billerId;

        public GetBillerDisplayNameQuery(string billerId)
        {
            _billerId = billerId;
        }
        public class GetBillerDisplayNameQueryHandler : IRequestHandler<GetBillerDisplayNameQuery, SuccessfulResponse>
        {
            private readonly ResponseCode responseCode;

            private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            public GetBillerDisplayNameQueryHandler(IOptions<ResponseCode> responseCode, IGenericRepository<LevelDisplayName> levelDisplayNameRepository, IGenericRepository<Biller> billerRepository)
            {
                this.responseCode = responseCode.Value;

                _levelDisplayNameRepository = levelDisplayNameRepository;

                _billerRepository = billerRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetBillerDisplayNameQuery request, CancellationToken cancellationToken)
            {
                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request._billerId);

                if (biller == null)

                    return ResponseGenerator.Response("Invalid biller Id", responseCode.NotFound, false);

                var levelDispayName = GetDisplayName(biller.Id);

                var displayName = new
                {
                    LevelOneDisplayName = levelDispayName.LevelOneDisplayName,

                    LevelTwoDisplayName = levelDispayName.LevelTwoDisplayName,

                    CategoryOneDisplayName = levelDispayName.CategoryOneDisplayName,

                    CategoryTwoDisplayName = levelDispayName.CategoryTwoDisplayName
                };

                return ResponseGenerator.Response("Successful", responseCode.OK, true, displayName);
            }

            private LevelDisplayName GetDisplayName(int billerId)
            {
                return _levelDisplayNameRepository.FindFirst(x => x.BillerId == billerId);
            }
        }
    }
}
