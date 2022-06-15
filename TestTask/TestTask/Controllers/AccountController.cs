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
    public class AccountController : ControllerBase
    {
        private readonly ICrudService<Account> _service;
        private readonly IMapper _mapper;
        public AccountController(ICrudService<Account> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<AccountViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<AccountViewModel>>(await _service.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<AccountViewModel>> GetByIdAsync(string id)
        {
            Account model = await _service.GetByIdAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            return new ObjectResult(_mapper.Map<AccountViewModel>(model));
        }

        [HttpPost]
        public async Task<ActionResult<AccountViewModel>> CreateAsync(AccountViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<AccountViewModel>(await _service.CreateAsync(_mapper.Map<Account>(model))));
        }

        [HttpPut]
        public async Task<ActionResult<AccountViewModel>> UpdateAsync(AccountViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<AccountViewModel>(await _service.UpdateAsync(_mapper.Map<Account>(model))));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == default)
            {
                return NotFound();
            }

            return Ok(await _service.DeleteAsync(id));
        }
    }
}
