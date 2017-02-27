using Microsoft.AspNet.Identity;
using Raven.Client;
using ShanesSpot.Areas.Blog.Models;
using ShanesSpot.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShanesSpot.Areas.Blog.Controllers
{
    public partial class BlogEntryController : ShaneSpotAbstractController
    {
        //
        // GET: /Blog/BlogEntry/
        public virtual ActionResult Index()
        {
            int take = Convert.ToInt32(Request.QueryString["take"]);
            int skip = Convert.ToInt32(Request.QueryString["skip"]);
            if (take == 0)
            {
                take = 5;
            }

            // Get results from database
            RavenQueryStatistics stats;
            var dbResult = RavenSession.Query<BlogEntry>().Statistics(out stats).OrderByDescending(x => x.DateTime).Skip(skip).Take(take).ToList();
            var totalResults = stats.TotalResults;
            ViewBag.TotalResults = stats.TotalResults;
            ViewBag.Take = take;

            // Convert list to view Model
            List<BlogEntryViewModel> output = dbResult.Select(b => b.ToBlogEntryViewModel(RavenSession)).ToList();

            // Disable PreviousLink if at beginning of collection.
            if (skip <= 0)
            {
                ViewBag.PreviousButtonState = "disabled";
                int next = skip + take;
                ViewBag.NextButtonLink = string.Format("?take={0}&skip={1}", take, next);
            }
            else
            {
                int previous = skip - take;
                ViewBag.PreviousButtonLink = string.Format("?take={0}&skip={1}", take, previous);


                int next = skip + take;
                if (next > totalResults)
                {
                    ViewBag.NextButtonState = "disabled";
                }
                else
                {
                    ViewBag.NextButtonLink = string.Format("?take={0}&skip={1}", take, next);
                }
            }

            return View(output);
        }

        //
        // GET: /Blog/BlogEntry/Details/5
        public virtual ActionResult Details(int id)
        {
            var item = RavenSession.Load<BlogEntry>(id).ToBlogEntryViewModel(RavenSession);
            return View(item);
        }

        //
        // GET: /Blog/BlogEntry/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Blog/BlogEntry/Create
        [HttpPost]
        [ValidateInput(false)]
        public virtual ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                BlogEntry newEntry = new BlogEntry();
                UpdateModel(newEntry);
                newEntry.DateTime = DateTime.Now;
                newEntry.UserId = User.Identity.GetUserId();

                RavenSession.Store(newEntry);
                RavenSession.SaveChanges();
                return RedirectToAction("Details", new { Id = newEntry.Id });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Blog/BlogEntry/Edit/5
        public virtual ActionResult Edit(int id)
        {
            var item = RavenSession.Load<BlogEntry>(id).ToBlogEntryViewModel(RavenSession);
            return View(item);
        }

        //
        // POST: /Blog/BlogEntry/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public virtual ActionResult Edit(int id, BlogEntryViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                BlogEntry entry = new BlogEntry();
                UpdateModel(entry);
                RavenSession.Store(entry);

                return RedirectToAction("Details", new { Id = entry.Id });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Blog/BlogEntry/Delete/5
        public virtual ActionResult Delete(int id)
        {
            var item = RavenSession.Load<BlogEntry>(id).ToBlogEntryViewModel(RavenSession);

            return View(item);
        }

        //
        // POST: /Blog/BlogEntry/Delete/5
        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var item = RavenSession.Load<BlogEntry>(id);
                RavenSession.Delete(item);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
