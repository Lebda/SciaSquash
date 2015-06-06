using System;
using System.Linq;

namespace SciaSquash.Web.ViewModels.Shared
{
    public class CrudActionLinksViewModel
    {
        public CrudActionLinksViewModel()
        {
            ControllerName = "Home";
        }

        #region MEMBERS
        object m_index;
        #endregion

        #region PROPERTIES
        public string ControllerName { get; set; }
        public object Id
        {
            get { return m_index; }
            set { m_index = value; }
        }
        public Func<bool> SeeEditCallBack { get; set; }
        public Func<bool> SeeDetailedCallBack { get; set; }
        public Func<bool> SeeDeleteCallBack { get; set; }
        public Func<bool> SeeCreateNewCallBack { get; set; }
        #endregion



    }
}