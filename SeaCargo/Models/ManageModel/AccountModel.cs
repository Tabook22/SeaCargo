using SeaCargo.Models.DB;
using SeaCargo.Models.ViewModel;
using System.Linq;

namespace SeaCargo.Models.ManageModel
{
    public class AccountModel
    {
        private SeaCargoDbContext db = new SeaCargoDbContext();
        private tbl_Account listAccounts = new tbl_Account();
       
        //checks to see if there is any role associated with the Username which sotred in the session Username
        public tbl_Account find(string username)
        {
            
        var getAR = (from a in db.tbl_accounts
                        select new AccountRoleViewModel
                        {
                            AID = a.AID,
                            Username = a.Username,
                            FName = a.FName,
                            LName = a.LName,
                            Role = a.Role,
                            Branch = a.Branch,
                            CDate = a.CDate
                        }).FirstOrDefault();
            listAccounts.AID = getAR.AID;
            listAccounts.Username = getAR.Username;
            listAccounts.Password = getAR.Password;
            listAccounts.FName = getAR.FName;
            listAccounts.LName = getAR.LName;
            listAccounts.CDate = getAR.CDate;
            return listAccounts;
        }

        public tbl_Account login(string username, string password)
        {
            return db.tbl_accounts.Where(x=>x.Username==username && x.Password ==password).FirstOrDefault() ;
        }
    }
}
