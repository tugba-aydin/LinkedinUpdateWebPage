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
    public class AboutController : ControllerBase
    {
        private readonly IAboutService aboutService;
        public AboutController(IAboutService _aboutService)
        {
            aboutService = _aboutService;
        }

        [HttpGet()]
        public ActionResult GetAllAbout()
        {
            try
            {
                var contact = aboutService.GetAllAbout();
                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetAboutById(int id)
        {
            try
            {
                var contact = aboutService.GetAboutById(id);
                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult UpdateAbout([FromBody] About about)
        {
            try
            {
                aboutService.UpdateAbout(about);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult AddAbout([FromBody] About about)
        {
            try
            {
                aboutService.AddAbout(about);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
