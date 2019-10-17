using Core.Bus.Academico;
using Core.Bus.SeguridadAcceso;
using Core.Info.Academico;
using Core.Info.SeguridadAcceso;
using Core.Web.Helps;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Areas.SeguridadAcceso
{
    public class UsuarioController : Controller
    {
        #region Index/Metodos
        seg_usuario_Bus bus_usuario = new seg_usuario_Bus();
        aca_Menu_Info bus_menu = new aca_Menu_Info();
        seg_usuario_x_sede_list List_det = new seg_usuario_x_sede_list();
        aca_Sede_Bus bus_sede = new aca_Sede_Bus();
        seg_usuario_x_aca_Sede_Bus bus_usuario_x_sucursal = new seg_usuario_x_aca_Sede_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_usuario()
        {
            List<seg_usuario_Info> model = bus_usuario.get_list(true);
            return PartialView("_GridViewPartial_usuario", model);
        }

        private void cargar_combos(seg_usuario_Info model)
        {
            /*
            var lst_menu = bus_menu.get_list_combo(false);
            lst_menu.Add(new seg_Menu_Info { IdMenu = 0, DescripcionMenu_combo = "== Seleccione ==" });
            ViewBag.lst_menu = lst_menu;
            */
        }

        #endregion

        #region Acciones

        public ActionResult Nuevo()
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            seg_usuario_Info model = new seg_usuario_Info
            {
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual),
            };
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession);
            var lst = bus_usuario_x_sucursal.GetList(Convert.ToString(SessionFixed.IdUsuario));
            List_det.set_list(lst, model.IdTransaccionSession);

            cargar_combos(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(seg_usuario_Info model)
        {
            if (bus_usuario.validar_existe_usuario(model.IdUsuario))
            {
                ViewBag.mensaje = "Usuario ya se encuentra registrado";
                return View(model);
            }

            model.ListaUsuarioPorSede = List_det.get_list(model.IdTransaccionSession);
            if (!bus_usuario.guardarDB(model))
                return View(model);
            cargar_combos(model);

            return RedirectToAction("Index");
        }

        public ActionResult Modificar(string IdUsuario = "")
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            seg_usuario_Info model = bus_usuario.get_info(IdUsuario);
            if (model == null)
                return RedirectToAction("Index");
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession);
            model.ListaUsuarioPorSede = bus_usuario_x_sucursal.GetList(model.IdUsuario);
            List_det.set_list(model.ListaUsuarioPorSede, model.IdTransaccionSession);
            cargar_combos(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Modificar(seg_usuario_Info model)
        {
            model.ListaUsuarioPorSede = List_det.get_list(model.IdTransaccionSession);
            if (!bus_usuario.modificarDB(model))
                return View(model);

            return RedirectToAction("Index");
        }

        public ActionResult Anular(string IdUsuario = "")
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            seg_usuario_Info model = bus_usuario.get_info(IdUsuario);
            if (model == null)
                return RedirectToAction("Index");
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession);
            model.ListaUsuarioPorSede = bus_usuario_x_sucursal.GetList(model.IdUsuario);
            List_det.set_list(model.ListaUsuarioPorSede, model.IdTransaccionSession);
            cargar_combos(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Anular(seg_usuario_Info model)
        {
            if (!bus_usuario.anularDB(model))
                return View(model);

            return RedirectToAction("Index");
        }
        #endregion
        #region Json
        public JsonResult ResetearContrasena(string IdUsuario = "")
        {
            int resultado = 0;

            if (bus_usuario.ResetearContrasenia(IdUsuario, "1234"))
                resultado = 1;

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Detalle
        [ValidateInput(false)]
        public ActionResult GridViewPartial_Usuario_x_Sucursal()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_Usuario_x_Sucursal", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] seg_usuario_x_aca_Sede_Info info_det)
        {
            if (ModelState.IsValid)
            {
                seg_usuario_x_aca_Sede_Info info_ = new seg_usuario_x_aca_Sede_Info();
                info_.IdSede = info_det.IdSede;
                info_.IdEmpresa = info_det.IdEmpresa;
                var lista = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
                List_det.AddRow(info_det, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            }
            var model = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_Usuario_x_Sucursal", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] seg_usuario_x_aca_Sede_Info info_det)
        {
            if (ModelState.IsValid)
            {
                List_det.UpdateRow(info_det, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            }
            var model = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_Usuario_x_Sucursal", model);
        }
        public ActionResult EditingDelete(int Secuencia = 0)
        {
            List_det.DeleteRow(Secuencia, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            var model = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_Usuario_x_Sucursal", model);
        }

        #endregion
    }
    public class seg_usuario_x_sede_list
    {
        string Variable = "seg_usuario_x_aca_Sede_Info";
        public List<seg_usuario_x_aca_Sede_Info> get_list(decimal IdTransaccionSession)
        {

            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<seg_usuario_x_aca_Sede_Info> list = new List<seg_usuario_x_aca_Sede_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<seg_usuario_x_aca_Sede_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<seg_usuario_x_aca_Sede_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }

        public void AddRow(seg_usuario_x_aca_Sede_Info info_det, decimal IdTransaccionSession)
        {
            List<seg_usuario_x_aca_Sede_Info> list = get_list(IdTransaccionSession);

            if (list.Where(q => q.IdEmpresa == info_det.IdEmpresa && q.IdSede == info_det.IdSede).Count() == 0)
            {
                info_det.Secuencia = list.Count == 0 ? 1 : list.Max(q => q.Secuencia) + 1;
                info_det.IdUsuario = info_det.IdUsuario;
                info_det.IdSede = info_det.IdSede;
                info_det.IdEmpresa = info_det.IdEmpresa;
                list.Add(info_det);
            }

        }

        public void UpdateRow(seg_usuario_x_aca_Sede_Info info_det, decimal IdTransaccionSession)
        {
            seg_usuario_x_aca_Sede_Info edited_info = get_list(IdTransaccionSession).Where(m => m.Secuencia == info_det.Secuencia).First();
            edited_info.IdUsuario = info_det.IdUsuario;
            edited_info.IdSede = info_det.IdSede;
            edited_info.IdEmpresa = info_det.IdEmpresa;
        }

        public void DeleteRow(int Secuencia, decimal IdTransaccionSession)
        {
            List<seg_usuario_x_aca_Sede_Info> list = get_list(IdTransaccionSession);
            list.Remove(list.Where(m => m.Secuencia == Secuencia).First());
        }
    }
}