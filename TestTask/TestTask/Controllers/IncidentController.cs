using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTask.Services.Interface;
using TestTask.ViewModel;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly ICrudService<Incident> _service;
        private readonly IMapper _mapper;
        public IncidentController(ICrudService<Incident> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<IncidentViewModel>> GetAllAsync() 
        {
            return _mapper.Map<IEnumerable<IncidentViewModel>>(await _service.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<IncidentViewModel>> GetByIdAsync(string id) 
        { 
            Incident model = await _service.GetByIdAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            return new ObjectResult(_mapper.Map<IncidentViewModel>(model));
        }

        [HttpPost]
        public async Task<ActionResult<IncidentViewModel>> CreateAsync(IncidentViewModel model) 
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<IncidentViewModel>(await _service.CreateAsync(_mapper.Map<Incident>(model))));
        }

        [HttpPut]
        public async Task<ActionResult<IncidentViewModel>> UpdateAsync(IncidentViewModel model)
        {

        }
    }
}
