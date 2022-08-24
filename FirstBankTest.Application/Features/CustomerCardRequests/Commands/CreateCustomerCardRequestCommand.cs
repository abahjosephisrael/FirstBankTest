using AutoMapper;
using FirstBankTest.Application.DTOs.Cards;
using FirstBankTest.Application.Interfaces;
using FirstBankTest.Application.Wrappers;
using FirstBankTest.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstBankTest.Application.Features.CustomerCardRequests.Commands
{
    public class CreateCustomerCardRequestCommand : CustomerCard.Request, IRequest<Response<CustomerCard.Response>>
    {
    }
    public class CreateCustomerCardRequestCommandHandler : IRequestHandler<CreateCustomerCardRequestCommand, Response<CustomerCard.Response>>
    {
        private readonly IGenericRepositoryAsync<CustomerCardRequest> requestRepo;
        private readonly IMapper mapper;

        public CreateCustomerCardRequestCommandHandler(
            IGenericRepositoryAsync<CustomerCardRequest> requestRepo,
            IMapper mapper
            )
        {
            this.requestRepo = requestRepo;
            this.mapper = mapper;
        }
        public async Task<Response<CustomerCard.Response>> Handle(CreateCustomerCardRequestCommand request, CancellationToken cancellationToken)
        {
            var cardRequest = mapper.Map<CustomerCardRequest>(request);
            cardRequest.Status = Domain.Enums.Status.Pending;
            await requestRepo.AddAsync(cardRequest);
            return new Response<CustomerCard.Response>
            {
                Data = new CustomerCard.Response
                {
                    RequestId = cardRequest.Id
                },
                Message = "Card request submitted successfully!",
                Succeeded = true
            };
        }
    }
}
