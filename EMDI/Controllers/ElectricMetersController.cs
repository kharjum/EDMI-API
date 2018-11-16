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
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">ElectricMeter Repository</param>
        /// <param name="mapper"> Mapper </param>
        public ElectricMetersController(IElectricMeterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a list of ElectricMeter avaible
        /// </summary>
        /// <returns>list of ElectricMeter avaible</returns>
        [HttpGet]
        public async Task<ActionResult<List<ElectricMeterModel>>> Get()
        {
            try
            {
                var items = await _repository.GetElectricMeterAsync();

                return _mapper.Map<List<ElectricMeterModel>>(items);
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
        public async Task<ActionResult<ElectricMeterModel>> Get(int id)
        {
            try
            {
                var item = await _repository.GetElectricMeterAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<ElectricMeterModel>(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Add a new ElectricMeter
        /// </summary>
        /// <param name="itemModel">New ElectricMeter</param>
        /// <returns>Gatway added</returns>
        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ElectricMeter>> Post(ElectricMeterModel itemModel)
        {
            try
            {
                if (itemModel == null)
                {
                    return BadRequest("ElectricMeter object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                ElectricMeter item = _mapper.Map<ElectricMeter>(itemModel);

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
        /// <param name="itemModel">ElectricMeter to update</param>
        /// <param name="id">ElectricMeter id</param>
        /// <returns>ElectricMeter updated</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ElectricMeterModel>> Put(ElectricMeterModel itemModel, int id)
        {
            try
            {
                if (itemModel == null)
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

                ElectricMeter item = _mapper.Map<ElectricMeter>(itemModel);

                await _repository.UpdateElectricMeterAsync(dbItem, item);

                return CreatedAtAction(nameof(Get),
                    new { id = itemModel.Id }, item);

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
