using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WordEvaluatorMSSQL.Context;
using WordEvaluatorMSSQL.Models;
using WordEvaluatorMSSQL.Models.Request;

namespace WordEvaluatorMSSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController
    {
        private readonly DatabaseContext _context;

        public WordController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("details")]
        public ActionResult<bool> Exists(Guid wordSetId, string word)
        {
            return _context.Words.Any(w => w.WordSetId == wordSetId && w.Value == word);
        }

        [HttpPost("insert")]
        public async Task<ActionResult> Insert(InsertWordsRequest request)
        {
            List<Word> words = request.Words.Select(w => new Word { WordSetId = request.WordSetId, Value = w}).ToList();
            try
            {
                await _context.AddRangeAsync(words);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
            
            return new OkResult();
        }
    }
}
