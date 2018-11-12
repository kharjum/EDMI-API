using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMDI.Models;
using EMDI.Repository.Interfaces;
using System;

namespace EMDI.Controllers
{
    /// <summary>
    /// ElectricMeter Controller API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricMetersController : ControllerBase
    {
        /// <summary>
        /// ElectricMeter Repository
        /// </summary>
        private readonly IElectricMeterRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">ElectricMeter Repository</param>
        public ElectricMetersController(IElectricMeterRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get a list of ElectricMeter avaible
        /// </summary>
        /// <returns>list of ElectricMeter avaible</returns>
        [HttpGet]
        public async Task<ActionResult<List<ElectricMeter>>> Get()
        {
            try
            {
                return await _repository.GetElectricMeterAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get a specific ElectricMeter
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A ElectricMeter</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ElectricMeter>> Get(int id)
        {
            try
            {
                var item = await _repository.GetElectricMeterAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Add a new ElectricMeter
        /// </summary>
        /// <param name="item">New ElectricMeter</param>
        /// <returns>Gatway added</returns>
        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ElectricMeter>> Post(ElectricMeter item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest("ElectricMeter object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                await _repository.AddElectricMeterAsync(item);

                return CreatedAtAction(nameof(Get),
                    new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Update a ElectricMeter
        /// </summary>
        /// <param name="item">ElectricMeter to update</param>
        /// <param name="id">ElectricMeter id</param>
        /// <returns>ElectricMeter updated</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ElectricMeter>> Put(ElectricMeter item, int id)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest("ElectricMeter object is null");
                }

                var dbItem = await _repository.GetElectricMeterAsync(id);
                if (dbItem == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _repository.UpdateElectricMeterAsync(dbItem, item);

                return CreatedAtAction(nameof(Get),
                    new { id = item.Id }, item);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a ElectricMeter
        /// </summary>
        /// <param name="id">ElectricMeter id</param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await _repository.GetElectricMeterAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                await _repository.DeleteElectricMeterAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }        
    }
}
