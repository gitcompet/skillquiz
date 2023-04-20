using Microsoft.AspNetCore.Mvc;

using WebApiMiniPj.Modeles;

namespace WebApiMiniPj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private SkillquizdbContext db = new SkillquizdbContext();
        // GET: user
        [HttpGet("")]
        public IQueryable<Test> GetTest()
        {
            return db.Tests;
        }
    }
}