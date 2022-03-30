using DomainModel.Models;
using FlightManagementWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            try
            {
                _userRepository.InsertUser(user);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{userId:int}")]
        public IActionResult GetUser(int userId)
        {
            try
            {
                var user = _userRepository.GetUser(userId);
                return Ok(user);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{username}")]
        public IActionResult GetUser(string username)
        {
            try
            {
                var user = _userRepository.GetUser(username);
                return Ok(user);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
