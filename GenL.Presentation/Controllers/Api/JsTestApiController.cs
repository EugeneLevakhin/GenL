using Microsoft.AspNetCore.Mvc;
using GenL.Business.Services.Abstract;
using GenL.Presentation.Models.Users;

namespace GenL.Presentation.Controllers.Api
{
    [Route("api/jstest")]
    [ApiController]
    public class JsTestApiController : ControllerBase
    {
        private readonly IUserService _userService;

        public JsTestApiController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Users()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var user = await _userService.GetAsync(id);

            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost("users/add")]
        public IActionResult Post([FromBody] AddUserRequest addUserRequest)
        {
            return Ok(
                new
                {
                    FirstName = addUserRequest.FirstName,
                    LastName = addUserRequest.LastName,
                    Age = addUserRequest.Age
                });
            //return BadRequest(addUserRequest);
            //return Ok();
        }

        //// PUT api/<UsersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}