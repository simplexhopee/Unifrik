using AuthService.Application.Commands.Profile;
using AuthService.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unifrik.Common.Shared.Exceptions;
using Unifrik.Infrastructure.Shared.User;

namespace AuthService.API.Controllers
{

    [Authorize]
    [Route("api/v1/account")]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUser _currentUser;
        public AccountController(IMediator mediator, ICurrentUser currentUser)
        {
            _mediator = mediator;
            _currentUser = currentUser;
        }


        [HttpGet("my-profile")]
        public async Task<IActionResult> MyProfile()
        {
            var result = await _mediator.Send(new ProfileCommand(_currentUser.Email));
            return Ok(result);
        }

        [HttpPost("update-buyer")]
        public async Task<IActionResult> UpdateBuyer([FromBody] UpdateBuyerDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _mediator.Send(input);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
 
        [HttpPost("update-seller")]
        public async Task<IActionResult> UpdateSeller([FromForm] UpdateSellerDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _mediator.Send(input);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        [HttpPost("update-agent")]
        public async Task<IActionResult> UpdateAgent([FromForm] UpdateLogisticsAgentDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _mediator.Send(input);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("update-kyc")]
        public async Task<IActionResult> UpdateKyc([FromForm] BuyerAndSellerKycDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _mediator.Send(input);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("update-kyc-logistics")]
        public async Task<IActionResult> UpdateKycLogistics([FromForm] LogisticsKycDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _mediator.Send(input);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
