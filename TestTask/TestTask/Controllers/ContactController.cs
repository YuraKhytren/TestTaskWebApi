using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.DTO;
using TestTask.Models;
using TestTask.Services.Interface;
using TestTask.ViewModel;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ICrudService<Contact> _service;
        private readonly IMapper _mapper;
        public ContactController(ICrudService<Contact> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ContactViewModel>>(await _service.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<ContactViewModel>> GetByIdAsync(string email)
        {
            Contact model = await _service.GetByIdAsync(email);

            if (model == null)
            {
                return BadRequest();
            }

            return new ObjectResult(_mapper.Map<ContactViewModel>(model));
        }

        [HttpPost]
        public async Task<ActionResult<ContactViewModel>> CreateAsync(ContactViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<ContactViewModel>(await _service.CreateAsync(_mapper.Map<Contact>(model))));
        }

        [HttpPost("email")]
        public async Task<ActionResult<Contact>> CreateAsync(ContactDTO model)
        {
            if (model.AccountName == null || model.AccountName == string.Empty)
            {
                return NotFound();
            }
            Contact contact = await _service.GetByIdAsync(model.Email);

            if (contact != null)
            {
                return await _service.UpdateAsync(_mapper.Map<Contact>(model));
            }
            else
            {
                contact = await _service.CreateAsync(_mapper.Map<Contact>(model));
                Incident incident = new Incident() { Description = model.IncidentDescription };
                contact.Account.Incident = incident;
            }

            return Ok(contact);
        }


        [HttpPut]
        public async Task<ActionResult<ContactViewModel>> UpdateAsync(ContactViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<ContactViewModel>(await _service.UpdateAsync(_mapper.Map<Contact>(model))));
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
