using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudocNetAPi_1.Models.RequestModels;
using StudocNetAPi_1.Models.ResponseModels;
using StudocNetAPi_1.Services;

namespace StudocNetAPi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerService ownerService, IMapper mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }

        [HttpGet("owners")]
        public async Task<IActionResult> GetOwners()
        {
            var result = await _ownerService.GetOwners();
            if(result == null)
            {
                return NotFound("No Owner found");
            }
            return Ok(_mapper.Map<List<OwnerResponse>>(result));
        }

        [HttpGet("owner/{ownerId}")]
        public async Task<IActionResult> GetOwnerById(int ownerId)
        {
            var result = await _ownerService.GetOwner(ownerId);
            if (result == null)
            {
                return NotFound("No Owner found");
            }
            return Ok(_mapper.Map<OwnerResponse>(result));
        }

        [HttpPost("create/owner")]
        public async Task<IActionResult> CreateOwner([FromBody] OwnerRequest ownerRequest)
        {
            if(ownerRequest == null)
            {
                return BadRequest();
            }
            _ownerService.CreateOwner(ownerRequest);
            return Ok();
        }
    }
}
