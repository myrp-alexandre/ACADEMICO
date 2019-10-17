using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Core.Web.Models;
using Core.Info.SeguridadAcceso;
using Core.Bus.SeguridadAcceso;

namespace Core.Web.Controllers
{
    public class AccountController : Controller
    {
        #region Variables
        seg_usuario_Bus bus_usuario = new seg_usuario_Bus();
        #endregion
        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            seg_usuario_Info info_usuario = bus_usuario.validar_login(model.IdUsuario, model.Contrasena);
            if (info_usuario != null)
            {
                if (info_usuario.CambiarContraseniaSgtSesion)
                    return RedirectToAction("CambiarContrasena", new { IdUsuario = model.IdUsuario });
                return RedirectToAction("LoginEmpresa", new { IdUsuario = model.IdUsuario });
            }
            ViewBag.mensaje = "Credenciales incorrectas";
            return View(model);
        }
    }
}