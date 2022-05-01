using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register.Models;

namespace Register.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class TestController : ControllerBase
    {
            private readonly IConfiguration _config;
            private readonly DataContext _context;
            public TestController(IConfiguration config, DataContext context)
            {
                _config = config;
               _context = context;
            }
        [HttpPost("SaveUser")]

        public IActionResult Create(Data data)
        {   
            if(_context.user.Where(u=> u.Email == data.Email).FirstOrDefault() != null)
            {
                return Ok("cikis");
            }  

            data.MemberSice =DateTime.Now;
            _context.user.Add(data);
            _context.SaveChanges();
            return Ok("kayıt oldun");

        }


    }
}
