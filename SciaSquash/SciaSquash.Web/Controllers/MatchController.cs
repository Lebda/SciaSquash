using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EFHelp.Concrete.ControllerHelp;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Entities;

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
            CallBack4DropDownListEmpty(null);
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
            return base.CreateBase(match, CallBack4DropDownListEmpty, Redirect2Owner);
        }
        // GET: Match/Edit/5
        public ActionResult Edit(int? id)
        {
            return base.EditBase(id, CallBack4DropDownList);
        }
        // POST: Match/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            return base.EditPostBase(id, CallBack4DropDownList, Redirect2Owner, null, "FirstPlayerID", "SecondPlayerID", "ScorePlayerFirst", "ScorePlayerSecond");
        }
        // GET: Match/Delete/5
        public ActionResult Delete(int? id)
        {
            return DeleteBase(id);
        }
        // POST: Match/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return DeleteConfirmedBase(id, Redirect2Owner);
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
        private void PopulatePlayersDropDownLists(object selectedPlayerIDFirst = null, object selectedPlayerIDSecond = null)
        {
            var playersQuery = m_playersRepo.DataEnumerable()
                                            .OrderBy(i => i.NickName);
            ViewBag.FirstPlayerID = new SelectList(playersQuery, "PlayerID", "NickName", selectedPlayerIDFirst);
            ViewBag.SecondPlayerID = new SelectList(playersQuery, "PlayerID", "NickName", selectedPlayerIDSecond);
        }
        private void CallBack4DropDownList(Match item)
        {
            PopulatePlayersDropDownLists(item.FirstPlayerID, item.SecondPlayerID);
        }
        private void CallBack4DropDownListEmpty(Match item)
        {
            PopulatePlayersDropDownLists();
        }
        private RedirectToRouteResult Redirect2Owner()
        {
            return RedirectToAction("Index", "MatchDay");
        }
        #endregion
    }
}