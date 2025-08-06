using AidCare.Business.Abstract;
using AidCare.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AidCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            try
            {
                _userService.Add(user);
                return Ok("Kullanıcı başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); // özel mesaj dön
            }
        }
        

        [HttpPut]
        public IActionResult Update(User user)
        {
            _userService.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
