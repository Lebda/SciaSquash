using System;
using System.Linq;
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
        public ActionResult Ranking()
        {
            return PartialView(new RankingViewModel(m_resCalc));
        }
        [ChildActionOnly]
        public ActionResult Leader()
        {
            return PartialView(new LeaderViewModel(m_resCalc));
        } 
        #endregion

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