using AutoMapper;
using FirstBankTest.Application.DTOs.Cards;
using FirstBankTest.Application.Features.CustomerCardRequests.Commands;
using FirstBankTest.Domain.Entities;

namespace FirstBankTest.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateCustomerCardRequestCommand, CustomerCardRequest>().ReverseMap();
            CreateMap<CreateCustomerCardRequestCommand, CustomerCard.Request>().ReverseMap();
            CreateMap<CustomerCard.Request, CustomerCardRequest>().ReverseMap();
            CreateMap<CheckCustomerCardRequestStatusCommand, CardRequestStatus.Request>().ReverseMap();
        }
    }
}
