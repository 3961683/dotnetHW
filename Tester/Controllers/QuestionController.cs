using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tester.Models;

namespace Tester.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private TestContext _context;

        public QuestionController (TestContext context)
        {
            this._context = context;
        }

        [EnableCors()]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await Task.Run(() => _context.Questions));
        }

        [EnableCors()]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Question question)
        {
            _context.Questions.Add(question);

            await _context.SaveChangesAsync();

            return Ok(question);
        }

        [EnableCors()]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            Question question = new Question() { Id = id };
            _context.Questions.Attach(question);
            _context.Questions.Remove(question);
            _context.SaveChanges();
            return Ok("Ok");
        }

        [EnableCors()]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Question question)
        {
            var question_up = _context.Questions.First(i => i.Id == question.Id);
            question_up.Name = question.Name;

            await _context.SaveChangesAsync();

            return Ok("Ok");
        }
    }
}
