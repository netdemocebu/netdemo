using Microsoft.AspNetCore.Mvc;
using NetDemo.Interfaces.Contract;
using System;
using System.Threading.Tasks;
using NetDemo.ViewModels;

namespace NetDemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        #region Members

        private readonly ITrainingService _trainingService;

        #endregion Members

        #region Constructor

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        #endregion Constructor

        #region CRUD

        // POST api/traninginfo/create
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TrainingCreateViewModel training)
        {
            try
            {
                await _trainingService.SaveAsync(training);

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
                var training = _trainingService.GetAllAsync().Result;

                return Ok(training);
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
                var training = await _trainingService.GetAsync(id);

                return Ok(training);
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
        public async Task<IActionResult> Update([FromBody] TrainingUpdateViewModel training)
        {
            try
            {
                await _trainingService.UpdateAsync(training);

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
                await _trainingService.DeleteAsync(id);

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
