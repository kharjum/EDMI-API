using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMDI.Models;
using EMDI.Repository.Interfaces;
using System;

namespace EMDI.Controllers
{
    /// <summary>
    /// Gateway Controller API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GatewaysController : ControllerBase
    {
        /// <summary>
        /// Gateway Repository
        /// </summary>
        private readonly IGatewaysRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Gateway Repository</param>
        public GatewaysController(IGatewaysRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get a list of Gateway avaible
        /// </summary>
        /// <remarks>This API will get all values.</remarks>
        /// <returns>list of Gateway avaible</returns>
        [HttpGet]
        public async Task<ActionResult<List<Gateways>>> Get()
        {            
            try
            {
                return await _repository.GetGatewaysAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get a specific gateway
        /// </summary>
        /// <remarks>This API will get a specific value.</remarks>
        /// <param name="id"></param>
        /// <returns>A gateway</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Gateways>> Get(int id)
        {
            try
            {
                var item = await _repository.GetGatewaysAsync(id);

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
        /// Add a new gateway
        /// </summary>
        /// <remarks>This API will add a new value.</remarks>
        /// <param name="item">New Gateway</param>
        /// <returns>Gatway added</returns>
        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Gateways>> Post(Gateways item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest("Gateways object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                await _repository.AddGatewaysAsync(item);

                return CreatedAtAction(nameof(Get),
                    new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Update a Gateway
        /// </summary>
        /// <remarks>This API will update a value.</remarks>
        /// <param name="item">Gateway to update</param>
        /// <param name="id">Gateway id</param>
        /// <returns>Gateway updated</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Gateways>> Put(Gateways item, int id)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest("Gateways object is null");
                }

                var dbItem = await _repository.GetGatewaysAsync(id);
                if (dbItem == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _repository.UpdateGatewaysAsync(dbItem, item);

                return CreatedAtAction(nameof(Get),
                    new { id = item.Id }, item);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a gateway
        /// </summary>
        /// <param name="id">Gateway id</param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await _repository.GetGatewaysAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                await _repository.DeleteGatewaysAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}