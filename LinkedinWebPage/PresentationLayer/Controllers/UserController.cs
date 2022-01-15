using BLL.Interfaces;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public ActionResult GetAllUser()
        {
            try
            {
                var users = userService.GetAllUser();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public ActionResult GetUserById(int id)
        {
            try
            {
                var user = userService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult AddUser([FromBody] User user)
        {
            try
            {
                userService.AddUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public class UploadData
        {
            public IFormFile image { get; set; }
            public int id { get; set; }
        }

        [HttpPost("ImageUpload")]
        public ActionResult ImageUpload([FromForm] UploadData data)
        {
            var file = data.image;
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                userService.UpdateUserImage(dbPath, data.id);
                return Ok(new { dbPath });
            }

            return BadRequest();
        }

        [HttpPut]
        public ActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                userService.UpdateUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
