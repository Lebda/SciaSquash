﻿using System;
using System.Linq;
using System.Web.Mvc;
using EFHelp.Concrete.ControllerHelp;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Entities;

namespace SciaSquash.Web.Controllers
{
    public class MatchDayController : ConrollerBase<MatchDay>
    {
        public MatchDayController(IMatchDayRepository repo)
            : base(repo)
        {
        }

        #region CRUD
        public ActionResult Index()
        {
            return base.IndexBase();
        }
        public ActionResult Details(int? id)
        {
            return base.DetailsBase(id);
        }
        public ActionResult Create()
        {
            return base.CreateBase();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchDate")] MatchDay matchDay)
        {
            return base.CreateBase(matchDay);
        }
        public ActionResult Edit(int? id)
        {
            return base.EditBase(id);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            return base.EditPostBase(id, null, null, null, "MatchDate");
        }
        public ActionResult Delete(int? id)
        {
            return DeleteBase(id);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return DeleteConfirmedBase(id, null);
        }
        #endregion
    }
}
