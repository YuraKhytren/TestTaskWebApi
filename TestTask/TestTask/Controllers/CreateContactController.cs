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
    public class CreateContactController : ControllerBase
    {
        private readonly ICrudService<Contact> _service;
        private readonly IMapper _mapper;
        public CreateContactController(ICrudService<Contact> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateAsync(ContactDTO model)
        {
            if (model.AccountName == null)
            {
                return NotFound();
            }
            Contact contact = await _service.GetByIdAsync(model.Email);

            if (contact != null)
            {
                await _service.UpdateAsync(contact);
            }

            return Ok( await _service.CreateAsync(_mapper.Map<Contact>(model)));
        }

    }
}
