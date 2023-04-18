using Microsoft.AspNetCore.Mvc;

using WebApiMiniPj.Modeles;

namespace WebApiMiniPj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsrController : ControllerBase
    {
        private SkillquizdbContext db = new SkillquizdbContext();
        // GET: user
        [HttpGet("")]
        public IQueryable<Usr> GetUsr()
        {
            return db.Usrs;
        }
    }
}