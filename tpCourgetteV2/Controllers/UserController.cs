using tpCourgettev2.Entities;
using tpCourgettev2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace tpCourgettev2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BotController : ControllerBase
    {
        private readonly TpCourgetteContext TpCourgetteContext;
        public BotController(TpCourgetteContext TpCourgetteContext)
        {
            this.TpCourgetteContext = TpCourgetteContext;
        }
        /// <summary>
        /// Definition du Web Service
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du client a retourné</param>
        /// <response code="200">client selectionné</response>
        /// <response code="404">client introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("GetBots")]
        public async Task<ActionResult<List<Bot>>> Get()
        {
            var List = await TpCourgetteContext.Bots.Select(
            s => new Bot
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Botname = s.Botname,
                Password = s.Password,
                EnrollmentDate = s.EnrollmentDate
            }
).ToListAsync();
            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }
        [HttpGet("GetBotById")]
        public async Task<ActionResult<Bot>> GetBotById(int Id)
        {
            Bot Bot = await TpCourgetteContext.Bots.Select(
            s => new Bot
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Botname = s.Botname,
                Password = s.Password,
                EnrollmentDate = s.EnrollmentDate
            })
            .FirstOrDefaultAsync(s => s.Id == Id);
            if (Bot == null)
            {
                return NotFound();
            }
            else
            {
                return Bot;
            }
        }
        [HttpPost("InsertBot")]
        public async Task<HttpStatusCode> InsertBot(Bot Bot)
        {
            var entity = new Bot()
            {
                Id = Bot.Id,
                FirstName = Bot.FirstName,
                LastName = Bot.LastName,
                Botname = Bot.Botname,
                Password = Bot.Password,
                EnrollmentDate = Bot.EnrollmentDate
            };
            TpCourgetteContext.Bots.Add(entity);
            await TpCourgetteContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("UpdateBot")]
        public async Task<HttpStatusCode> UpdateBot(Bot Bot)
        {
            var entity = await TpCourgetteContext.Bots.FirstOrDefaultAsync(s => s.Id == Bot.Id);
            entity.FirstName = Bot.FirstName;
            entity.LastName = Bot.LastName;
            entity.Botname = Bot.Botname;
            entity.Password = Bot.Password;
            entity.EnrollmentDate = Bot.EnrollmentDate;
            await TpCourgetteContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteBot/{Id}")]
        public async Task<HttpStatusCode> DeleteBot(int Id)
        {
            var entity = new Bot()
            {
                Id = Id
            };
            TpCourgetteContext.Bots.Attach(entity);
            TpCourgetteContext.Bots.Remove(entity);
            await TpCourgetteContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}