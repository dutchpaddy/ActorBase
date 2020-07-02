using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using ActorBase.Models;
using ActorBase.Repository;
using Microsoft.AspNetCore.Authorization;

namespace ActorBase.Controllers
{
    //[Authorize(Policy = "RequireEmail")]
    //[Authorize(Roles = "Administrator")]
    public class ActorsController : Controller
    {
        private IActorsRepository _context;
        private IWebHostEnvironment _environment;

        public ActorsController(IActorsRepository context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_context.GetActors());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Actors actors)
        {
            if (ModelState.IsValid)
            {
                _context.CreateActor(actors);

                return RedirectToAction("Index");
            }

            return View(actors);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Actors actor = _context.GetActorById(id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        [HttpPost, ActionName("Edit/{id:int}")]
        public async Task<IActionResult> EditPost(int id)
        {
            var actorToUpdate = _context.GetActorById(id);
            bool isUpdated = await TryUpdateModelAsync<Actors>(
                                actorToUpdate,
                                "",
                                c => c.Id,
                                c => c.Name,
                                c => c.Age,
                                c => c.AcademyWinner
                                );
            if (isUpdated)
            {
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(actorToUpdate);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var actor = _context.GetActorById(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.DeleteActor(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var actor = _context.GetActorById(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }
    }
}
