using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMDI.Business.Entities;
using EMDI.Repository.Interfaces;
using System;
using AutoMapper;
using EMDI.API.Models;

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
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Gateway Repository</param>
        /// <param name="mapper">Mapper</param>
        public GatewaysController(IGatewaysRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a list of Gateway avaible
        /// </summary>
        /// <remarks>This API will get all values.</remarks>
        /// <returns>list of Gateway avaible</returns>
        [HttpGet]
        public async Task<ActionResult<List<GatewaysModel>>> Get()
        {            
            try
            {
                var items = await _repository.GetGatewaysAsync();

                return _mapper.Map<List<GatewaysModel>>(items);
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
        public async Task<ActionResult<GatewaysModel>> Get(int id)
        {
            try
            {
                var item = await _repository.GetGatewaysAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GatewaysModel>(item));
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
        /// <param name="itemModel">New Gateway</param>
        /// <returns>Gatway added</returns>
        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Gateways>> Post(GatewaysModel itemModel)
        {
            try
            {
                if (itemModel == null)
                {
                    return BadRequest("Gateways object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var item = _mapper.Map<Gateways>(itemModel);

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
        /// <param name="itemModel">Gateway to update</param>
        /// <param name="id">Gateway id</param>
        /// <returns>Gateway updated</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Gateways>> Put(GatewaysModel itemModel, int id)
        {
            try
            {
                if (itemModel == null)
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

                var item = _mapper.Map<Gateways>(itemModel);

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