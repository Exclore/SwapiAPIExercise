using Microsoft.AspNetCore.Mvc;

namespace StarWarsAPIExercise.Controllers
{
    public class StarshipController : Controller
    {
        //private StarshipContext db = new StarshipContext();

        // GET: StarshipController
        public ActionResult Index()
        {
            return View();
            //db.Starships.ToList()
        }

        // GET: StarshipController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StarshipController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StarshipController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StarshipController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StarshipController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StarshipController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StarshipController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
