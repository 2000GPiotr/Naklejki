using Database;
using Microsoft.AspNetCore.Mvc;
using Seeder;

namespace API.Controllers
{
    [Route("/Seeder")]
    [ApiController]
    public class SeederController : Controller
    {
        private readonly LabelDbContext dbContext;
        public SeederController(LabelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("/clear")]
        public ActionResult ClearDatabase()
        {
            MainSeeder.clearDatabase(dbContext);
            return Ok();
        }

        [HttpGet("/seed")]
        public ActionResult SeedDatabase()
        {
            MainSeeder.seedAll(dbContext);
            return Ok();
        }
    }
}
