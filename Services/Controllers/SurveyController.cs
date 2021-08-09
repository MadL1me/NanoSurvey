using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Domain;

namespace Services.Controllers
{
    [Route("survey")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private NanoSurveyDbContext _dbContext;

        public SurveyController(NanoSurveyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("question/{id}")]
        public async Task<JsonResult> GetQuestion(int id)
        {
            var question = await _dbContext.Questions.FirstOrDefaultAsync(q => q.Id == id);
            return new JsonResult(new {}, question);
        }

        [HttpPost("question/{questionId}/{answerId}")]
        public async Task<StatusCodeResult> SaveQuestionAnswer(int questionId, int answerId, [FromQuery(Name = "interviewId")] int interviewId)
        {
            _dbContext.Results.Add(new Result {InterviewId = interviewId, AnswerId = answerId, QuestionId = questionId});
           
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }
            
            return new OkResult();
        }
    }
}