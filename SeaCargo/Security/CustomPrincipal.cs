using SeaCargo.Models.ViewModel;
using System.Linq;
using System.Security.Principal;
using SeaCargo.Models.DB;

namespace SeaCargo.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private SeaCargoDbContext db = new SeaCargoDbContext();
        private tbl_Account Account;
        //private AccountModel am = new AccountModel();
        public CustomPrincipal(tbl_Account account )
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.Username);
        }
       public IIdentity Identity
        {
            get; set;
        }

        public bool IsInRole(string role)
        {
            var getAR = from a in db.tbl_accounts
                        select new AccountRoleViewModel
                        {
                            AID = a.AID,
                            Username = a.Username,
                            FName = a.FName,
                            LName = a.LName,
                            CDate=a.CDate,
                            Role =a.Role
                        };
            
            if(getAR.Count()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //public bool IsInRole(string role)
        // {
        //     var roles = role.Split(new char[] {','});
        //     return roles.Any(r => this.Account.Roles.Contains(r));
        // }
    }
}
