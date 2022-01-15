using BLL.Interfaces;
using BLL.Services;
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
    public class SkillController : ControllerBase
    {
        private readonly ISkillService skillService;
        public SkillController(ISkillService _skillService)
        {
            skillService = _skillService;
        }

        [HttpGet]
        public ActionResult GetAllSkill()
        {
            try
            {
                var skills = skillService.GetAllSkill();
                return Ok(skills);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public ActionResult GetSkillById(int id)
        {
            try
            {
                var skill = skillService.GetSkillById(id);
                return Ok(skill);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult AddSkill([FromBody] Skill skill)
        {
            try
            {
                skillService.AddSkill(skill);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult UpdateSkill([FromBody] Skill skill)
        {
            try
            {
                skillService.UpdateSkill(skill);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSkill(int id)
        {
            try
            {
                skillService.DeleteSkill(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
