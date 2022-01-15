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
    public class EducationController : ControllerBase
    {
        private readonly IEducationService educationService;
        public EducationController(IEducationService _educationService)
        {
            educationService = _educationService;
        }

        [HttpGet]
        public ActionResult GetAllEducation()
        {
            try
            {
                var educations = educationService.GetAllEducation();
                return Ok(educations);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public ActionResult GetEducationById(int id)
        {
            try
            {
                var education = educationService.GetEducationById(id);
                return Ok(education);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult AddEducation([FromBody] Education education)
        {
            try
            {
                educationService.AddEducation(education);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult UpdateEducation([FromBody] Education education)
        {
            try
            {
                educationService.UpdateEducation(education);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEducation(int id)
        {
            try
            {
                educationService.DeleteEducation(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
