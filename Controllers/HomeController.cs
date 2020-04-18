using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Grocery.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Configurations(BaseViewModel model)
        //{
        //    FinancialYearRelUser financialYearRelUser = new FinancialYearRelUser();
        //    string strUserID = UserManager.GetUserId(User);
        //    financialYearRelUser = RootRepository.GetFinancialYearRelUserByUserID(strUserID);
        //    if (financialYearRelUser == null)
        //    {
        //        financialYearRelUser = new FinancialYearRelUser();
        //        financialYearRelUser.FinancialYearRelUserID = RootRepository.GetNewGUIId(TableName.FinancialYearRelUser, null);
        //        financialYearRelUser.UserID = strUserID;
        //        financialYearRelUser.FinancialYearID = model.FinancialYearID;
        //        RootRepository.AddNewFinancialYearRelUser(financialYearRelUser);
        //    }
        //    else
        //    {
        //        financialYearRelUser.UserID = strUserID;
        //        financialYearRelUser.FinancialYearID = model.FinancialYearID;
        //        RootRepository.UpdateFinancialYearRelUser(financialYearRelUser);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}