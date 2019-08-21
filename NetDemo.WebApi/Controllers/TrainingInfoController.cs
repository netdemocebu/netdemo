using Microsoft.AspNetCore.Mvc;
using NetDemo.Interfaces.Contract;
using NetDemo.Models;
using System;
using System.Threading.Tasks;

namespace NetDemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingInfoController : ControllerBase
    {
        #region Members

        private readonly ITrainingInfoService _trainingInfoService;

        #endregion Members

        #region Constructor

        public TrainingInfoController(ITrainingInfoService trainingInfoService)
        {
            _trainingInfoService = trainingInfoService;
        }

        #endregion Constructor

        #region CRUD

        // POST api/traninginfo/create
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TrainingInfo trainingInfo)
        {
            try
            {
                await _trainingInfoService.SaveAsync(trainingInfo);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/traninginfo/getall
        [Produces("application/json")]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var trainingInfo = _trainingInfoService.GetAllAsync();

                return Ok(trainingInfo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/traninginfo/get/{id}
        [Produces("application/json")]
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var trainingInfo = await _trainingInfoService.GetAsync(id);

                return Ok(trainingInfo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/traninginfo/update
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] TrainingInfo trainingInfo)
        {
            try
            {
                await _trainingInfoService.UpdateAsync(trainingInfo);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE api/traninginfo/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _trainingInfoService.DeleteAsync(id);

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
