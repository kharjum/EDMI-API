using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMDI.Models;
using EMDI.Repository.Interfaces;
using System;

namespace EMDI.Controllers
{
    /// <summary>
    /// WaterMeter Controller API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WaterMetersController : ControllerBase
    {
        /// <summary>
        /// WaterMeter Repository
        /// </summary>
        private readonly IWaterMeterRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">WaterMeter Repository</param>
        public WaterMetersController(IWaterMeterRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get a list of WaterMeter avaible
        /// </summary>
        /// <remarks>This API will get all values.</remarks>
        /// <returns>list of WaterMeter avaible</returns>
        [HttpGet]
        public async Task<ActionResult<List<WaterMeter>>> Get()
        {
            try
            {
                return await _repository.GetWaterMeterAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get a specific WaterMeter
        /// </summary>
        /// <remarks>This API will get a specific values.</remarks>
        /// <param name="id"></param>
        /// <returns>A WaterMeter</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public async Task<ActionResult<WaterMeter>> Get(int id)
        {
            try
            {
                var item = await _repository.GetWaterMeterAsync(id);

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
        /// Add a new WaterMeter
        /// </summary>
        /// <remarks>This API will add a values.</remarks>
        /// <param name="item">New WaterMeter</param>
        /// <returns>Gatway added</returns>
        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<ActionResult<WaterMeter>> Post(WaterMeter item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest("WaterMeter object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                await _repository.AddWaterMeterAsync(item);

                return CreatedAtAction(nameof(Get),
                    new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Update a WaterMeter
        /// </summary>
        /// <remarks>This API will update a values.</remarks>
        /// <param name="item">WaterMeter to update</param>
        /// <param name="id">WaterMeter id</param>
        /// <returns>WaterMeter updated</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        public async Task<ActionResult<WaterMeter>> Put(WaterMeter item, int id)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest("WaterMeter object is null");
                }

                var dbItem = await _repository.GetWaterMeterAsync(id);
                if (dbItem == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _repository.UpdateWaterMeterAsync(dbItem, item);

                return CreatedAtAction(nameof(Get),
                    new { id = item.Id }, item);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a WaterMeter
        /// </summary>
        /// <remarks>This API will delete values.</remarks>
        /// <param name="id">WaterMeter id</param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await _repository.GetWaterMeterAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                await _repository.DeleteWaterMeterAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}