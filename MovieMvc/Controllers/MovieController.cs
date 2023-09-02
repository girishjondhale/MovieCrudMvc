using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieMvc.Models;


namespace MovieMvc.Controllers
{
    public class MovieController : Controller
    {
        private readonly IConfiguration configuration;
        private MovieCrud crud;

        public MovieController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new MovieCrud(this.configuration);
        }

        public ActionResult Index()
        {
            var model = crud.GetAllMovie();
            return View(model);

        }



        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var result = crud.GetMovieById(id);
            return View(result);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                int result = crud.AddMovie(movie);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = crud.GetMovieById(id);
            return View(result);

        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            try
            {
                int result = crud.UpdateMovie(movie);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = crud.GetMovieById(id);
            return View(result);

        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteMovie(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}
