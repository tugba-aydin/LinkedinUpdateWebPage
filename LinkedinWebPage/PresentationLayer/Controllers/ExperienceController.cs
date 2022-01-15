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
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService experienceService;
        public ExperienceController(IExperienceService _experienceService)
        {
            experienceService = _experienceService;
        }

        [HttpGet]
        public ActionResult GetAllExperience()
        {
            try
            {
                var experiences = experienceService.GetAllExperience();
                return Ok(experiences);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public ActionResult GetExperienceById(int id)
        {
            try
            {
                var experience = experienceService.GetExperienceById(id);
                return Ok(experience);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult AddContact([FromBody] Experience experience)
        {
            try
            {
                experienceService.AddExperience(experience);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult UpdateExperience([FromBody] Experience experience)
        {
            try
            {
                experienceService.UpdateExperience(experience);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteExperience(int id)
        {
            try
            {
                experienceService.DeleteExperience(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
