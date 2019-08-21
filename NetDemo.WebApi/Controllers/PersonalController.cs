using Microsoft.AspNetCore.Mvc;
using NetDemo.Interfaces.Contract;
using NetDemo.Models;
using System;
using System.Threading.Tasks;

namespace NetDemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        #region Members

        private readonly IPersonService _PersonService;

        #endregion Members

        #region Constructor

        public PersonController(IPersonService PersonService)
        {
            _PersonService = PersonService;
        }

        #endregion Constructor

        #region CRUD

        // POST api/Person/create
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Person Person)
        {
            try
            {
                await _PersonService.SaveAsync(Person);

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
                var Person = _PersonService.GetAllAsync();

                return Ok(Person);
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
                var Person = await _PersonService.GetAsync(id);

                return Ok(Person);
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
        public async Task<IActionResult> Update([FromBody] Person Person)
        {
            try
            {
                await _PersonService.UpdateAsync(Person);

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
                await _PersonService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        #endregion CRUD
    }
}