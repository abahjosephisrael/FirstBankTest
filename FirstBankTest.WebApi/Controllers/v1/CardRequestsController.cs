using AutoMapper;
using FirstBankTest.Application.DTOs.Cards;
using FirstBankTest.Application.Features.CustomerCardRequests.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBankTest.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CardRequestsController : BaseApiController
    {
        private readonly IMapper mapper;

        public CardRequestsController(
            IMapper mapper
            )
        {
            this.mapper = mapper;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> CreateCustomerCardRequest([FromBody] CreateCustomerCardRequestCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost("status")]
        public async Task<IActionResult> CheckCustomerCardRequest([FromBody] CardRequestStatus.Request request)
        {
            var command = mapper.Map<CheckCustomerCardRequestStatusCommand>(request);
            return Ok(await Mediator.Send(command));
        }
    }
}
