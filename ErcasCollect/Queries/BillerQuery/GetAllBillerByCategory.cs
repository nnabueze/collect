﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetAllBillerByCategoryQuery : IRequest<IEnumerable<ReadBillerDto>>
    {

        public string id { get; set; }
        public class GetAllBillerByCategoryHandler : IRequestHandler<GetAllBillerByCategoryQuery, IEnumerable<ReadBillerDto>>
        {
            private readonly IGenericRepository<Biller> billerRepository;
            private readonly IMapper mapper;

            public GetAllBillerByCategoryHandler(IGenericRepository<Biller> billerRepository, IMapper mapper)
            {
                this.billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadBillerDto>> Handle(GetAllBillerByCategoryQuery query, CancellationToken cancellationToken)
            {

                var result = await billerRepository.FindAllInclude(x => x.BillerTypeId == query.id, x => x.State, x => x.BillerType);
                if (result != null)
                {
                    var biller = mapper.Map<IEnumerable<ReadBillerDto>>(result);
                    return biller;
                }
                else
                {
                    return null;
                }

            }


        }
    }
}

