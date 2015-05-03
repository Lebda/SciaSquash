using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EFHelp.Concrete.ControllerHelp;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Entities;
using SciaSquash.Model.Infrastructure;

namespace SciaSquash.Web.Controllers
{
    public class MatchController : ConrollerBase<Match>
    {
        public MatchController(IMatchRepository repo, IPlayerReposiroty playersRepo)
            : base(repo)
        {
            m_playersRepo = playersRepo;
        }
        
        #region MEMBERS
        private SciaSquashContext db = new SciaSquashContext();
        private readonly IPlayerReposiroty m_playersRepo;
        #endregion
        
        // GET: Match
        public ActionResult Index()
        {
            return base.IndexBase();
        }
        // GET: Match/Details/5
        public ActionResult Details(int? id)
        {
            return base.DetailsBase(id);
        }
        // GET: Match/Create
        public ActionResult Create(int? matchDayID)
        {
            PopulatePlayersDropDownLists();
            if (matchDayID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match viewModel = new Match { MatchDayID = (int)matchDayID };
            return View(viewModel);
        }
        // POST: Match/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchDayID,FirstPlayerID,SecondPlayerID,ScorePlayerFirst,ScorePlayerSecond")] Match match)
        {
            return base.CreateBase(match, PopulatePlayersDropDownLists, null, () => RedirectToAction("Index", "MatchDay"));
        }
        // GET: Match/Edit/5
        public ActionResult Edit(int? id)
        {
            return base.EditBase(id);
        }
        // POST: Match/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchID,PlayerFirstID,PlayerSecondID,ScorePlayerFirst,ScorePlayerSecond,MatchDate")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(match);
        }
        // GET: Match/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matchs.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }
        // POST: Match/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matchs.Find(id);
            db.Matchs.Remove(match);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #region PROTECTED
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                m_playersRepo.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region METHODS
        private void PopulatePlayersDropDownLists(object selectedPlayerID = null)
        {
            var playersQuery = m_playersRepo.DataSet()
                                            .OrderBy(i => i.NickName);
            ViewBag.FirstPlayerID = new SelectList(playersQuery, "PlayerID", "NickName", selectedPlayerID);
            ViewBag.SecondPlayerID = new SelectList(playersQuery, "PlayerID", "NickName", selectedPlayerID);
        }
        #endregion
    }
}