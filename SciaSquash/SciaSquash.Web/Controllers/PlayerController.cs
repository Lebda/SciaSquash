using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFHelp.Concrete.ControllerHelp;
using EFHelp.Extensions;
using IdenityHelp.Infrastructure.Atrributes;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Entities;
using SciaSquash.Web.ViewModels.Player;

namespace SciaSquash.Web.Controllers
{
    public class PlayerController : Conroller4ImageHolder<Player>
    {
        public PlayerController(IPlayerReposiroty repo, IResultsCalculator resCalc)
            : base(repo)
        {
            m_resCalc = resCalc;
        }
        
        #region MEMBERS
        readonly IResultsCalculator m_resCalc;
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
        public ActionResult TotalPlayerResultPartial(int id)
        {
            return PartialView(m_resCalc.GetResults4PlayerID(id));
        }
        [ChildActionOnly]
        public ActionResult RivalResultsPartial(int id, int? rivalID)
        {
            return PartialView(new RivalResultsViewModel(m_resCalc.GetResults4PlayerID(id), rivalID));
        }
        [ChildActionOnly]
        public ActionResult RivalMatchesPartial(int? id, int? rivalID)
        {
            return PartialView(new RivalMatchesViewModel(m_resCalc, id, rivalID));
        }
        [ChildActionOnly]
        public ActionResult PlayerInfoPartial(int? id, bool showCRUDActions)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var player = m_repo.SelectByID(id);
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
        public ActionResult Details(int? id, int? rivalID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var player = m_repo.SelectByID(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(new PlayerDetailsViewModel(player, rivalID));
        }
        [AuthorizeRoles4CreateAttribute]
        public ActionResult Create()
        {
            return View();
        }
        [AuthorizeRoles4CreateAttribute]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,NickName")]
                                   Player player)
        {
            return base.CreateBase(player);
        }
        [AuthorizeRoles4EditAttribute]
        public ActionResult Edit(int? id)
        {
            return base.EditBase(id);
        }
        [AuthorizeRoles4EditAttribute]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, HttpPostedFileBase image)
        {
            return base.EditPostBase(id, null, null, (player) => HttpPostedFileBaseExtension.ImageUpdate(image, player), "FirstName", "LastName", "NickName");
        }
        [AuthorizeRoles4DeleteAttribute]
        public ActionResult Delete(int? id)
        {
            return DeleteBase(id);
        }
        [AuthorizeRoles4DeleteAttribute]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return DeleteConfirmedBase(id, null);
        }
        #endregion
    }
}