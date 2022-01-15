using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;
        public ContactController(IContactService _contactService)
        {
            contactService = _contactService;
        }

        [HttpGet]
        public ActionResult GetAllContact()
        {
            try
            {
                var contacts = contactService.GetAllContact();
                return Ok(contacts);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public ActionResult GetContactById(int id)
        {
            try
            {
                var contact = contactService.GetContactById(id);
                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult AddContact([FromBody] Contact contact)
        {
            try
            {
                contactService.AddContact(contact);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult UpdateContact([FromBody] Contact contact)
        {
            try
            {
                contactService.UpdateContact(contact);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContact(int id)
        {
            try
            {
                contactService.DeleteContact(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
