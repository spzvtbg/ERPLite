namespace ERPLite.Users.API.Controllers
{
    using ERPLite.Users.Application.Commans.RegisterUser;

    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController(RegisterUserHandler registerUserHandler) : ControllerBase
    {
        private readonly RegisterUserHandler registerUserHandler = registerUserHandler;

        [HttpPost]
        public async Task<IActionResult> Post(RegisterUserRequest reguest)
        {
            var lang = this.Request.Headers["Accept-Language"].ToString();
            var response = await this.registerUserHandler.HandleAsync(reguest);

            return this.Ok(response);
        }
    }
}
