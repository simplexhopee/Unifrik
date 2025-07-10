
using AuthService.Application.Commands.ConfirmEmail;
using AuthService.Application.Commands.RefreshToken;
using AuthService.Application.Commands.ResetPassword;
using AuthService.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Unifrik.Common.Shared.Exceptions;
using Unifrik.Common.Shared.Utils;


namespace AuthService.API.Controllers
{
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register-buyer")]
        public async Task<IActionResult> RegisterBuyer([FromBody] RegisterBuyerDto input)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            try
            {
                var result = await _mediator.Send(input);
                return Created("",result);
            }
            catch (EntityConflictException ex)
            {
                return Conflict(new { message = ex.Message });
            }

           
        }
        [HttpPost("register-seller")]
        public async Task<IActionResult> RegisterSeller([FromForm] RegisterSellerDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _mediator.Send(input);
                return Created("", result);
            }
            catch (EntityConflictException ex)
            {
                return Conflict(new { message = ex.Message });
            }


        }

        [HttpPost("register-agent")]
        public async Task<IActionResult> RegisterLogistics([FromForm] RegisterLogisticsAgentDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _mediator.Send(input);
                return Created("", result);
            }
            catch (EntityConflictException ex)
            {
                return Conflict(new { message = ex.Message });
            }


        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string email, string token)
        {
            if (email == null)
                return BadRequest("Token empty");
            try
            {
               await _mediator.Send(new ConfirmEmailCommand(email, token));
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new {message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost("login")]
        public async  Task<IActionResult> Login([FromBody] LoginDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _mediator.Send(input);
                return Ok(result);
            }
            catch (AuthenticationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }



        [HttpGet("refresh-token")]
        public async  Task<IActionResult> RefreshToken([FromQuery] string token)
        {
            if (token == null)
                return BadRequest("Token empty");
            try
            {
                var result = await  _mediator.Send(new RefreshTokenCommand(token));
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (AuthenticationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpGet("reset-password")]
        public async Task<IActionResult> ResetPassword([FromQuery] string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
               var result = await _mediator.Send(new ResetPasswordCommand(email));
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("new-password")]
        public async Task<IActionResult> NewPassword([FromBody] NewPasswordDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                await _mediator.Send(input);
                return Ok(new { message = "Password Changed Successfully" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
