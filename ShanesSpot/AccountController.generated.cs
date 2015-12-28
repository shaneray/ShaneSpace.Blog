// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace ShanesSpot.Controllers
{
    public partial class AccountController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AccountController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ManageProfile()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ManageProfile);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Login()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Disassociate()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Disassociate);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Manage()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Manage);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ExternalLogin()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLogin);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ExternalLoginCallback()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLoginCallback);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult LinkLogin()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.LinkLogin);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ExternalLoginConfirmation()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLoginConfirmation);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AccountController Actions { get { return MVC.Account; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Account";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Account";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string ManageProfile = "ManageProfile";
            public readonly string Login = "Login";
            public readonly string Register = "Register";
            public readonly string Disassociate = "Disassociate";
            public readonly string Manage = "Manage";
            public readonly string ExternalLogin = "ExternalLogin";
            public readonly string ExternalLoginCallback = "ExternalLoginCallback";
            public readonly string LinkLogin = "LinkLogin";
            public readonly string LinkLoginCallback = "LinkLoginCallback";
            public readonly string ExternalLoginConfirmation = "ExternalLoginConfirmation";
            public readonly string LogOff = "LogOff";
            public readonly string ExternalLoginFailure = "ExternalLoginFailure";
            public readonly string RemoveAccountList = "RemoveAccountList";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string ManageProfile = "ManageProfile";
            public const string Login = "Login";
            public const string Register = "Register";
            public const string Disassociate = "Disassociate";
            public const string Manage = "Manage";
            public const string ExternalLogin = "ExternalLogin";
            public const string ExternalLoginCallback = "ExternalLoginCallback";
            public const string LinkLogin = "LinkLogin";
            public const string LinkLoginCallback = "LinkLoginCallback";
            public const string ExternalLoginConfirmation = "ExternalLoginConfirmation";
            public const string LogOff = "LogOff";
            public const string ExternalLoginFailure = "ExternalLoginFailure";
            public const string RemoveAccountList = "RemoveAccountList";
        }


        static readonly ActionParamsClass_ManageProfile s_params_ManageProfile = new ActionParamsClass_ManageProfile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ManageProfile ManageProfileParams { get { return s_params_ManageProfile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ManageProfile
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_Login s_params_Login = new ActionParamsClass_Login();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Login LoginParams { get { return s_params_Login; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Login
        {
            public readonly string returnUrl = "returnUrl";
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_Register s_params_Register = new ActionParamsClass_Register();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Register RegisterParams { get { return s_params_Register; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Register
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_Disassociate s_params_Disassociate = new ActionParamsClass_Disassociate();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Disassociate DisassociateParams { get { return s_params_Disassociate; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Disassociate
        {
            public readonly string loginProvider = "loginProvider";
            public readonly string providerKey = "providerKey";
        }
        static readonly ActionParamsClass_Manage s_params_Manage = new ActionParamsClass_Manage();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Manage ManageParams { get { return s_params_Manage; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Manage
        {
            public readonly string message = "message";
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_ExternalLogin s_params_ExternalLogin = new ActionParamsClass_ExternalLogin();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ExternalLogin ExternalLoginParams { get { return s_params_ExternalLogin; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ExternalLogin
        {
            public readonly string provider = "provider";
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ActionParamsClass_ExternalLoginCallback s_params_ExternalLoginCallback = new ActionParamsClass_ExternalLoginCallback();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ExternalLoginCallback ExternalLoginCallbackParams { get { return s_params_ExternalLoginCallback; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ExternalLoginCallback
        {
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ActionParamsClass_LinkLogin s_params_LinkLogin = new ActionParamsClass_LinkLogin();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_LinkLogin LinkLoginParams { get { return s_params_LinkLogin; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_LinkLogin
        {
            public readonly string provider = "provider";
        }
        static readonly ActionParamsClass_ExternalLoginConfirmation s_params_ExternalLoginConfirmation = new ActionParamsClass_ExternalLoginConfirmation();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ExternalLoginConfirmation ExternalLoginConfirmationParams { get { return s_params_ExternalLoginConfirmation; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ExternalLoginConfirmation
        {
            public readonly string model = "model";
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _ChangePasswordPartial = "_ChangePasswordPartial";
                public readonly string _ExternalLoginsListPartial = "_ExternalLoginsListPartial";
                public readonly string _ManageProfilePartial = "_ManageProfilePartial";
                public readonly string _RemoveAccountPartial = "_RemoveAccountPartial";
                public readonly string _SetPasswordPartial = "_SetPasswordPartial";
                public readonly string ExternalLoginConfirmation = "ExternalLoginConfirmation";
                public readonly string ExternalLoginFailure = "ExternalLoginFailure";
                public readonly string Login = "Login";
                public readonly string Manage = "Manage";
                public readonly string Register = "Register";
            }
            public readonly string _ChangePasswordPartial = "~/Views/Account/_ChangePasswordPartial.cshtml";
            public readonly string _ExternalLoginsListPartial = "~/Views/Account/_ExternalLoginsListPartial.cshtml";
            public readonly string _ManageProfilePartial = "~/Views/Account/_ManageProfilePartial.cshtml";
            public readonly string _RemoveAccountPartial = "~/Views/Account/_RemoveAccountPartial.cshtml";
            public readonly string _SetPasswordPartial = "~/Views/Account/_SetPasswordPartial.cshtml";
            public readonly string ExternalLoginConfirmation = "~/Views/Account/ExternalLoginConfirmation.cshtml";
            public readonly string ExternalLoginFailure = "~/Views/Account/ExternalLoginFailure.cshtml";
            public readonly string Login = "~/Views/Account/Login.cshtml";
            public readonly string Manage = "~/Views/Account/Manage.cshtml";
            public readonly string Register = "~/Views/Account/Register.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AccountController : ShanesSpot.Controllers.AccountController
    {
        public T4MVC_AccountController() : base(Dummy.Instance) { }

        partial void ManageProfileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, ShanesSpot.Models.ManageProfileViewModel model);

        public override System.Web.Mvc.ActionResult ManageProfile(ShanesSpot.Models.ManageProfileViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ManageProfile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ManageProfileOverride(callInfo, model);
            return callInfo;
        }

        partial void LoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        public override System.Web.Mvc.ActionResult Login(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            LoginOverride(callInfo, returnUrl);
            return callInfo;
        }

        partial void LoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, ShanesSpot.Models.LoginViewModel model, string returnUrl);

        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Login(ShanesSpot.Models.LoginViewModel model, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            LoginOverride(callInfo, model, returnUrl);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        partial void RegisterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Web.Mvc.ActionResult Register()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
            RegisterOverride(callInfo);
            return callInfo;
        }

        partial void RegisterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, ShanesSpot.Models.RegisterViewModel model);

        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Register(ShanesSpot.Models.RegisterViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            RegisterOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        partial void DisassociateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string loginProvider, string providerKey);

        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Disassociate(string loginProvider, string providerKey)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Disassociate);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "loginProvider", loginProvider);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "providerKey", providerKey);
            DisassociateOverride(callInfo, loginProvider, providerKey);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        partial void ManageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, ShanesSpot.Controllers.AccountController.ManageMessageId? message);

        public override System.Web.Mvc.ActionResult Manage(ShanesSpot.Controllers.AccountController.ManageMessageId? message)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Manage);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "message", message);
            ManageOverride(callInfo, message);
            return callInfo;
        }

        partial void ManageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, ShanesSpot.Models.ManageUserPasswordViewModel model);

        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Manage(ShanesSpot.Models.ManageUserPasswordViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Manage);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ManageOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        partial void ExternalLoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string provider, string returnUrl);

        public override System.Web.Mvc.ActionResult ExternalLogin(string provider, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLogin);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "provider", provider);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ExternalLoginOverride(callInfo, provider, returnUrl);
            return callInfo;
        }

        partial void ExternalLoginCallbackOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLoginCallback);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ExternalLoginCallbackOverride(callInfo, returnUrl);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        partial void LinkLoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string provider);

        public override System.Web.Mvc.ActionResult LinkLogin(string provider)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.LinkLogin);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "provider", provider);
            LinkLoginOverride(callInfo, provider);
            return callInfo;
        }

        partial void LinkLoginCallbackOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> LinkLoginCallback()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.LinkLoginCallback);
            LinkLoginCallbackOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        partial void ExternalLoginConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, ShanesSpot.Models.ExternalLoginConfirmationViewModel model, string returnUrl);

        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ExternalLoginConfirmation(ShanesSpot.Models.ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLoginConfirmation);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ExternalLoginConfirmationOverride(callInfo, model, returnUrl);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        partial void LogOffOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Web.Mvc.ActionResult LogOff()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.LogOff);
            LogOffOverride(callInfo);
            return callInfo;
        }

        partial void ExternalLoginFailureOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Web.Mvc.ActionResult ExternalLoginFailure()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLoginFailure);
            ExternalLoginFailureOverride(callInfo);
            return callInfo;
        }

        partial void RemoveAccountListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Web.Mvc.ActionResult RemoveAccountList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveAccountList);
            RemoveAccountListOverride(callInfo);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
