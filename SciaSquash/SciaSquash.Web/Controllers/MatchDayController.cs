using System;
using System.Linq;
using System.Web.Mvc;
using EFHelp.Concrete.ControllerHelp;
using IdenityHelp.Infrastructure.Atrributes;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Entities;
using SciaSquash.Web.ViewModels.MatchDay;

namespace SciaSquash.Web.Controllers
{
    public class MatchDayController : ConrollerBase<MatchDay>
    {
        public MatchDayController(IMatchDayRepository repo)
            : base(repo)
        {
        }
        
        #region CHILD ACTIONS
        [ChildActionOnly]
        public ActionResult NextMatchDayPartial()
        {
            var query = m_repo.DataEnumerable()
                              .Where(item => item.MatchDate > DateTime.Now)
                              .OrderBy(item => item.MatchDate)
                              .FirstOrDefault();
            return PartialView(new NextMatchDayViewModel { MatchDay = query });
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
        [AuthorizeRoles4CreateAttribute]
        public ActionResult Create()
        {
            return base.CreateBase();
        }
        [AuthorizeRoles4CreateAttribute]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchDate")]
                                   MatchDay matchDay)
        {
            return base.CreateBase(matchDay);
        }
        [AuthorizeRoles4EditAttribute]
        public ActionResult Edit(int? id)
        {
            return base.EditBase(id);
        }
        [AuthorizeRoles4EditAttribute]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            return base.EditPostBase(id, null, null, null, "MatchDate");
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