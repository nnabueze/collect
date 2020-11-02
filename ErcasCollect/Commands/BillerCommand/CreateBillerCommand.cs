﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.DataAccess.Repository;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;

namespace ErcasCollect.Commands.BillerCommand
{
    public class CreateBillerCommand:IRequest<string>
    {
        public CreateBillerDto createBillerDto { get; set; }
        public class CreateBillerCommandHandler : IRequestHandler<CreateBillerCommand, string>
        {
            private readonly IBillerRepository billerRepository;
            private readonly IMapper mapper;
            public CreateBillerCommandHandler(IBillerRepository billerRepository, IMapper mapper)
            {
                this.billerRepository= billerRepository?? throw new ArgumentNullException(nameof(billerRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(CreateBillerCommand request, CancellationToken cancellationToken)
            {

                Biller biller  = mapper.Map<Biller>(request.createBillerDto);
                await billerRepository.Add(biller);
                await billerRepository.CommitAsync();

                return biller.Id;
            }
        }
        }
}



