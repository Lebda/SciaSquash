using Microsoft.AspNet.Identity.EntityFramework;

namespace SciaSquash.Web.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
            : base()
        {
        }
        public ApplicationRole(string name)
            : base(name)
        {
        }
        public string Description { get; set; }
    }
}