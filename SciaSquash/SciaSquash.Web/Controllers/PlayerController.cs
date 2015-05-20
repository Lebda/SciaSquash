using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFHelp.Concrete.ControllerHelp;
using EFHelp.Extensions;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Entities;
using SciaSquash.Web.ViewModels.Player;

namespace SciaSquash.Web.Controllers
{
    public class PlayerController : Conroller4ImageHolder<Player>
    {
        public PlayerController(IPlayerReposiroty repo, IResultsCalculator resCalc) : base (repo)
        {
            m_resCalc = resCalc;
        }

        #region MEMBERS
        IResultsCalculator m_resCalc;
        #endregion


        #region IMAGES
        public FileContentResult GetImage(int id)
        {
            return base.GetImageBase(id);
        }
        #endregion

        #region CHILD ACTIONS
        [ChildActionOnly]
        public ActionResult RankingPartial()
        {
            return PartialView(new RankingViewModel(m_resCalc));
        }
        [ChildActionOnly]
        public ActionResult LeaderPartial()
        {
            return PartialView(new LeaderViewModel(m_resCalc));
        }
        [ChildActionOnly]
        public ActionResult TotalPlayerResultPartial(int playerID)
        {
            return PartialView(m_resCalc.GetResults4PlayerID(playerID));
        }
        [ChildActionOnly]
        public ActionResult RivalResultsPartial(int playerID, int? rivalID)
        {
            return PartialView(new RivalResultsViewModel(m_resCalc.GetResults4PlayerID(playerID), rivalID));
        }
        [ChildActionOnly]
        public ActionResult RivalMatchesPartial(int? playerID, int? rivalID)
        {
            return PartialView(new RivalMatchesViewModel(m_resCalc, playerID, rivalID));
        }
        [ChildActionOnly]
        public ActionResult PlayerInfoPartial(int? playerID, bool showCRUDActions)
        {
            if (playerID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var player = m_repo.SelectByID(playerID);
            if (player == null)
            {
                return HttpNotFound();
            }
            return PartialView(new PlayerInfoViewModel(player, showCRUDActions));
        } 
        #endregion

        #region CRUD
        public ActionResult Index()
        {
            return base.IndexBase();
        }
        public ActionResult Details(int? playerID, int? rivalID)
        {
            if (playerID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var player = m_repo.SelectByID(playerID);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(new PlayerDetailsViewModel(player, rivalID));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,NickName")] Player player)
        {
            return base.CreateBase(player);
        }
        public ActionResult Edit(int? id)
        {
            return base.EditBase(id);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, HttpPostedFileBase image)
        {
            return base.EditPostBase(id, null, null, (player) => HttpPostedFileBaseExtension.ImageUpdate(image, player), "FirstName", "LastName", "NickName");
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