using AutoMapper;
using Grocery.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Grocery.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        private IRootRepository _rootRepository;
        private IMapper _mapper;
        //private IWebHostEnvironment _webHostEnvironment;
        ///private UserManager<ApplicationUser> _userManager;
        //private SignInManager<ApplicationUser> _signInManager;
        //private RoleManager<IdentityRole> roleManager;
        //private ICommonRepository _commonClass;

        protected IRootRepository RootRepository =>
                    _rootRepository ?? (_rootRepository = HttpContext.RequestServices.GetService<IRootRepository>());
        protected IMapper Mapper =>
                    _mapper ?? (_mapper = HttpContext.RequestServices.GetService<IMapper>());
        //protected IWebHostEnvironment WebHostEnvironment =>
        //           _webHostEnvironment ?? (_webHostEnvironment = HttpContext.RequestServices.GetService<IWebHostEnvironment>());

        //protected UserManager<ApplicationUser> UserManager =>
        //           _userManager ?? (_userManager = HttpContext.RequestServices.GetService<UserManager<ApplicationUser>>());

        //protected SignInManager<ApplicationUser> SignInManager =>
        //           _signInManager ?? (_signInManager = HttpContext.RequestServices.GetService<SignInManager<ApplicationUser>>());

        //protected RoleManager<IdentityRole> RoleManager =>
        //           roleManager ?? (roleManager = HttpContext.RequestServices.GetService<RoleManager<IdentityRole>>());

        //protected ICommonRepository CommonRepository =>
        //           _commonClass ?? (_commonClass = HttpContext.RequestServices.GetService<ICommonRepository>());

        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    base.OnActionExecuted(context);
        //}

        //[HttpPost]
        //public virtual IActionResult Configurations(BaseViewModel model)
        //{
        //    FinancialYearRelUser financialYearRelUser = new FinancialYearRelUser();
        //    string strUserID = UserManager.GetUserId(User);
        //    financialYearRelUser = RootRepository.GetFinancialYearRelUserByUserID(strUserID);
        //    if (financialYearRelUser == null)
        //    {
        //        financialYearRelUser.FinancialYearRelUserID = RootRepository.GetNewGUIId(TableName.FinancialYearRelUser,null);
        //        financialYearRelUser.UserID = strUserID;
        //        financialYearRelUser.FinancialYearRelUserID =model.FinancialYearID;
        //        RootRepository.AddNewFinancialYearRelUser(financialYearRelUser);
        //    }
        //    else
        //    {
        //        financialYearRelUser.FinancialYearRelUserID = model.FinancialYearID;
        //        RootRepository.UpdateFinancialYearRelUser(financialYearRelUser);
        //    }
        //   return RedirectToAction("Index");
        //}
    }
}