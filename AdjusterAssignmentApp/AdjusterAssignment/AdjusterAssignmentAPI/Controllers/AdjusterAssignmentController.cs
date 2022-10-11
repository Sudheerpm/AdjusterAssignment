using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using AdjusterAssignmentAPI.Models;
using AdjusterAssignmentAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdjusterAssignmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdjusterAssignmentController : ControllerBase
    {
        
        private readonly ILogger<AdjusterAssignmentController> _logger;
        private readonly IAdjusterAssignmentService _adjusterAssignmentService;

        public AdjusterAssignmentController(ILogger<AdjusterAssignmentController> logger, IAdjusterAssignmentService adjusterAssignmentService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _adjusterAssignmentService = adjusterAssignmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _adjusterAssignmentService.GetAllAsync().ConfigureAwait(false));
        }
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var customer = await _adjusterAssignmentService.GetByIdAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdjAssignment customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _adjusterAssignmentService.CreateAsync(customer).ConfigureAwait(false);
            return Ok(customer.Id);
        }
        [HttpPut()]
        public async Task<IActionResult> Update(string id, AdjAssignment customerIn)
        {
            var customer = await _adjusterAssignmentService.GetByIdAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            await _adjusterAssignmentService.UpdateAsync(id, customerIn).ConfigureAwait(false);
            return NoContent();
        }
        [HttpDelete()]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _adjusterAssignmentService.GetByIdAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            await _adjusterAssignmentService.DeleteAsync(customer.Id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
