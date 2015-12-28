using ShanesSpot.Classes;
using System.Web.Mvc;

namespace ShanesSpot.Areas.Todo.Controllers
{
    [Authorize]
    public partial class ToDoEntryController : ShaneSpotAbstractController
    {
        //
        // GET: /Todo/ToDoEntry/
        public virtual ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Todo/ToDoEntry/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Todo/ToDoEntry/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Todo/ToDoEntry/Create
        [HttpPost]
        public virtual ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Todo/ToDoEntry/Edit/5
        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Todo/ToDoEntry/Edit/5
        [HttpPost]
        public virtual ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Todo/ToDoEntry/Delete/5
        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Todo/ToDoEntry/Delete/5
        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
