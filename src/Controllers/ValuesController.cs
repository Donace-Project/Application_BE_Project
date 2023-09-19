using BE_Event_Project.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_Event_Project.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet("test")]
    public Task TestEx()
    {
        throw new FriendlyException("BE.EVENT.PROJECT.001", "Lỗi không tìm thấy event");
    }
}
