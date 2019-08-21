using Microsoft.AspNetCore.Mvc;
using NetDemo.Interfaces.Contract;
using NetDemo.Models;
using System;
using System.Threading.Tasks;

namespace NetDemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        #region Members

        private readonly IPersonalInfoService _personalInfoService;

        #endregion Members

        #region Constructor

        public PersonalInfoController(IPersonalInfoService personalInfoService)
        {
            _personalInfoService = personalInfoService;
        }

        #endregion Constructor

        #region CRUD

        // POST api/personalinfo/create
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PersonalInfo personalInfo)
        {
            try
            {
                await _personalInfoService.SaveAsync(personalInfo);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/personalinfo/getall
        [Produces("application/json")]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var personalInfo = _personalInfoService.GetAllAsync();

                return Ok(personalInfo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/personalinfo/get/{id}
        [Produces("application/json")]
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var personalInfo = await _personalInfoService.GetAsync(id);

                return Ok(personalInfo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/personalinfo/update
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] PersonalInfo personalInfo)
        {
            try
            {
                await _personalInfoService.UpdateAsync(personalInfo);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE api/personalinfo/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _personalInfoService.DeleteAsync(id);

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