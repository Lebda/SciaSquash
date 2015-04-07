﻿using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Entities;

namespace SciaSquash.Web.Controllers
{
    public class PlayerController : Controller
    {
        public PlayerController(IPlayerReposiroty repo)
        {
            m_repo = repo;
        }
        
        #region MEMBERS
        readonly IPlayerReposiroty m_repo;
        //private readonly SciaSquashContext m_db = new SciaSquashContext();
        #endregion
        
        // GET: Player
        public ActionResult Index()
        {
            return View(m_repo.SelectAll());
        }
        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Player player = m_db.Players.Find(id);
            var item = m_repo.SelectByID(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        // GET: Player/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,NickName")]
                                   Player player)
        {
            try 
            { 
                if (ModelState.IsValid)
                {
                    m_repo.Insert4ID(player, item => item.PlayerID, (item, id) => { item.PlayerID = id; });
                    m_repo.SaveChanges();
                    //m_db.Players.Add(player);
                   // m_db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }        
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(player);
        }
        // GET: Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Player player = m_db.Players.Find(id);
            var item = m_repo.SelectByID(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        // POST: Player/Edit/5
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
            //var studentToUpdate = db.Students.Find(id);
            var item2Update = m_repo.SelectByID(id);
            if (TryUpdateModel(item2Update, "",
               new string[] { "LastName", "FirstMidName", "NickName" }))
            {
                try
                {
                    m_repo.SaveChanges();
                    //db.SaveChanges();

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
            //Player player = m_db.Players.Find(id);
            var item = m_repo.SelectByID(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Player player = m_db.Players.Find(id);
            //m_db.Players.Remove(player);
            //m_db.SaveChanges();
            m_repo.Delete(id);
            m_repo.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                m_repo.Dispose();
                //m_db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}