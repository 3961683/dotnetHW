using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tester.Models;

namespace Tester.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : Controller
    {
        private TestContext _context;

        public CommonController(TestContext context)
        {
            this._context = context;
        }

        [EnableCors()]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await Task.Run(() => _context.Commons));
        }

        [EnableCors()]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Common common)
        {
            _context.Commons.Add(common);

            await _context.SaveChangesAsync();

            return Ok(common);
        }

        [EnableCors()]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            Common common = new Common() { Id = id };
            _context.Commons.Attach(common);
            _context.Commons.Remove(common);
            _context.SaveChanges();
            return Ok("Ok");
        }

        [EnableCors()]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Common common)
        {
            var common_up = _context.Commons.First(i => i.Id == common.Id);
            common_up.Answer = common.Answer;

            await _context.SaveChangesAsync();

            return Ok("Ok");
        }
    }
}
