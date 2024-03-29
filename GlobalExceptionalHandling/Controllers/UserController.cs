﻿using GlobalExceptionalHandling.Interface;
using GlobalExceptionalHandling.Model;
using GlobalExceptionalHandling.Unit_Of_Work;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlobalExceptionalHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<User> _userService;
        private readonly IUnitOfWork _unitOfWork;

        private readonly SieveProcessor _sieveProcessor;
        public UserController(
            IGenericRepository<User> userService,
            IUnitOfWork unitofwork,
            SieveProcessor sieveProcessor
            )
        {
            _userService = userService;
            _unitOfWork = unitofwork;
            _sieveProcessor = sieveProcessor;
        }
        // GET: api/<UserController>
        [HttpGet]
        public List<User> Get([FromQuery] SieveModel model)
        {
            var users = _userService.GetAll().AsQueryable();
            users = _sieveProcessor.Apply(model, users);
            return users.ToList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var result = _userService.GetById(id);
            return result;
        }

        // POST api/<UserController>
        [HttpPost]
        public User Post([FromBody] User obj)
        {
            var user = _unitOfWork.Users.Add(obj);
            _unitOfWork.Save();
            //var user = _userService.Add(obj);
            return user;
        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public User Put(int id, [FromBody] User value)
        {
            if (id != value.Id)
            {
                throw new Exception("Please enter the valid details");
            }
            var result = _userService.Update(value, id);
            return result;
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            bool result = _userService.Delete(id);
            return result;
        }
    }
}
