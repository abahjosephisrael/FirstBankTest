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
    public class CheckCustomerCardRequestStatusCommand : CardRequestStatus.Request, IRequest<Response<CardRequestStatus.Response>>
    {
    }
    public class CheckCustomerCardRequestStatusCommandHandler : IRequestHandler<CheckCustomerCardRequestStatusCommand, Response<CardRequestStatus.Response>>
    {
        private readonly IGenericRepositoryAsync<CustomerCardRequest> requestRepo;
        private readonly IMapper mapper;

        public CheckCustomerCardRequestStatusCommandHandler(
            IGenericRepositoryAsync<CustomerCardRequest> requestRepo,
            IMapper mapper
            )
        {
            this.requestRepo = requestRepo;
            this.mapper = mapper;
        }
        public async Task<Response<CardRequestStatus.Response>> Handle(CheckCustomerCardRequestStatusCommand request, CancellationToken cancellationToken)
        {
            var cardRequest = await requestRepo.GetByIdAsync(request.RequestId);
            if (cardRequest == null) throw new KeyNotFoundException($"Card request with ID '{request.RequestId}' not found.");
            return new Response<CardRequestStatus.Response>
            {
                Data = new CardRequestStatus.Response
                {
                    RequestId = cardRequest.Id,
                    CardType = cardRequest.CardType.ToString(),
                    Currency = cardRequest.Currency.ToString(),
                    FirstName = cardRequest.FirstName,
                    LastName = cardRequest.LastName,
                    Status = cardRequest.Status.ToString()
                },
                Message = $"Card request status :{cardRequest.Status.ToString().ToUpper()}!",
                Succeeded = true
            };
        }
    }
}
