﻿using Microsoft.AspNetCore.Mvc;
using NetDemo.Interfaces.Contract;
using System;
using System.Threading.Tasks;
using NetDemo.ViewModels;
using NetDemo.Services;

namespace NetDemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        #region Members

        private readonly IPersonService _personService;
        private readonly IPersonRepository _personRepository;

        #endregion Members

        #region Constructor

        public PersonController(IPersonService personService, IPersonRepository personRepository)
        {
            _personService = personService;
            _personRepository = personRepository;
        }

        #endregion Constructor

        #region CRUD

        // POST api/Person/create
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PersonCreateViewModel person)
        {
            try
            {
                await _personService.SaveAsync(person);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/Person/getall
        [Produces("application/json")]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var persons = _personService.GetAllAsync().Result;

                return Ok(persons);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/Person/get/{id}
        [Produces("application/json")]
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var person = await _personService.GetAsync(id);

                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/Person/update
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] PersonUpdateViewModel person)
        {
            try
            {
                await _personService.UpdateAsync(person);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE api/Person/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _personService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        #endregion CRUD
        [Produces("application/json")]
        [HttpDelete("verify/{token}")]
        public async Task<IActionResult> Verification(string token)
        {

            var svc = new AuthenticationService(_personRepository);
            var dbToken = svc.GetToken(token);

            if (string.IsNullOrEmpty(dbToken))
            {
                //registration success
                return Ok();
            }

            //registration failed
            return BadRequest();
        }
    }
}