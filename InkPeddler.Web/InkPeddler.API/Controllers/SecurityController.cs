using InkPeddler.Common.Interfaces;
using InkPeddler.Common.RequestAndResponses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkPeddler.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SecurityController : BaseController
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService ?? throw new ArgumentNullException(nameof(securityService));
        }

        [HttpGet("testauth")]
        public IActionResult TestAuth()
        {
            try
            {
                return Ok("THIS IS WORKING");
            }
            catch (Exception ex)
            {
                return Unauthorized(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("RegisterUserWithDeviceTokenAsync")]
        public async Task<IActionResult> RegisterUserWithDeviceTokenAsync([FromBody] RegisterUserWithDeviceTokenRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new RegisterUserResponse { ErrorMessage = "Invalid Payload" });

                var registerResponse = await _securityService.RegisterUserWithDeviceTokenAsync(request);
                return registerResponse.Success ? Ok(registerResponse) : BadRequest(registerResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(new RegisterUserResponse { ErrorMessage = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("RegisterUserWithEmailAsync")]
        public async Task<IActionResult> RegisterUserWithEmailAsync([FromBody] RegisterUserWithEmailRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new RegisterUserResponse { ErrorMessage = "Invalid Payload" });

                var registerResponse = await _securityService.RegisterUserWithEmailAsync(request);
                return registerResponse.Success ? Ok(registerResponse) : BadRequest(registerResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(new RegisterUserResponse { ErrorMessage = ex.Message });
            }
        }

        //[AllowAnonymous]
        //[HttpPost("token")]
        //public IActionResult AuthenticateUser([FromBody] AuthenticateUserRequest request)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest(new AuthenticateUserResponse { ErrorMessage = "Invalid Payload" });

        //        var authenticateResponse = _securityService.AuthenticateUser(request);
        //        return authenticateResponse.Success ? Ok(authenticateResponse) : BadRequest(authenticateResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new AuthenticateUserResponse { ErrorMessage = ex.Message });
        //    }
        //}

        [AllowAnonymous]
        [HttpPost("RefreshUserAuthenticationAsync")]
        public async Task<IActionResult> RefreshUserAuthenticationAsync([FromBody] RefreshUserAuthenticationRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new RefreshUserAuthenticationResponse { ErrorMessage = "Invalid Payload" });

                var authenticateResponse = await _securityService.RefreshUserAuthenticationAsync(request);
                return authenticateResponse.Success ? Ok(authenticateResponse) : BadRequest(authenticateResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(new RefreshUserAuthenticationResponse { ErrorMessage = ex.Message });
            }
        }
    }
}