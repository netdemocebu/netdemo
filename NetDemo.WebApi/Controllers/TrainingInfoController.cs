using Microsoft.AspNetCore.Mvc;
using NetDemo.Interfaces.Contract;
using NetDemo.Models;
using System;
using System.Threading.Tasks;

namespace NetDemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        #region Members

        private readonly ITrainingService _TrainingService;

        #endregion Members

        #region Constructor

        public TrainingController(ITrainingService TrainingService)
        {
            _TrainingService = TrainingService;
        }

        #endregion Constructor

        #region CRUD

        // POST api/traninginfo/create
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Training Training)
        {
            try
            {
                await _TrainingService.SaveAsync(Training);

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
                var Training = _TrainingService.GetAllAsync();

                return Ok(Training);
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
                var Training = await _TrainingService.GetAsync(id);

                return Ok(Training);
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
        public async Task<IActionResult> Update([FromBody] Training Training)
        {
            try
            {
                await _TrainingService.UpdateAsync(Training);

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
                await _TrainingService.DeleteAsync(id);

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
