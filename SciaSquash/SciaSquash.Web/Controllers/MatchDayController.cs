using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Entities;

namespace SciaSquash.Web.Controllers
{
    public class MatchDayController : Controller
    {
        public MatchDayController(IMatchDayRepository repo)
        {
            m_repo = repo;
        }

        #region MEMBERS
        readonly IMatchDayRepository m_repo;
        #endregion

        // GET: MatchDay
        public ActionResult Index()
        {
            return View(m_repo.SelectAll());
        }

        // GET: MatchDay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = m_repo.SelectByID(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: MatchDay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MatchDay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchDate")] MatchDay matchDay)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    m_repo.Insert(matchDay);
                    m_repo.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(matchDay);
        }

        // GET: MatchDay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = m_repo.SelectByID(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: MatchDay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item2Update = m_repo.SelectByID(id);
            if (TryUpdateModel(item2Update, "",
               new string[] { "MatchDate"}))
            {
                try
                {
                    m_repo.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(item2Update);
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = m_repo.SelectByID(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: MatchDay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            m_repo.Delete(id);
            m_repo.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                m_repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
