using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebApiMiniPj.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Data.SqlClient;
using System.CodeDom;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.IO;

using System.Net.Http.Json;
using System.Collections;
//using System.Web.Http;

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

//       [HttpGet("{id}")]
//        public IHttpActionResult GetUsrById(int id)
//        {
//            var getusrbyid = usr.FirstOrDefault((p) => p.id == id);
//
//            if (GetUsrById == null)
//            {
//                Console.WriteLine("erreur pas de user avec cet id");
//                return NotFound();
//            }
//
//            return getusrbyid;
//        }



        // POST: user
        [HttpPost("")]
        public async void postUsr(Usr usrParam)
        {
            Usr usrTmp = new Usr();
            usrTmp.LoginTxt = usrParam.LoginTxt;
            usrTmp.FirstName = usrParam.FirstName;
            usrTmp.LastName = usrParam.LastName;
            usrTmp.Email = usrParam.Email;
            usrTmp.Comment = usrParam.Comment;
            usrTmp.Passwordtxt = "";
            usrTmp.IsActive = 0;
            usrTmp.TypeUserId = 0;

            db.Usrs.AddAsync(usrTmp);
            await db.SaveChangesAsync();
        }
    }
}