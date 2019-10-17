﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.SeguridadAcceso
{
    public class seg_usuario_Info
    {
        public decimal IdTransaccionSession { get; set; }
        [Key]
        [Required(ErrorMessage = "El campo usuario es obligatorio")]
        public string IdUsuario { get; set; }
        public string Contrasena { get; set; }
        public string estado { get; set; }
        public bool EstadoBool { get; set; }
        public string MotivoAnulacion { get; set; }
        public string Nombre { get; set; }
        public bool ExigirDirectivaContrasenia { get; set; }
        public bool CambiarContraseniaSgtSesion { get; set; }
        public bool es_super_admin { get; set; }
        public string contrasena_admin { get; set; }
        public Nullable<int> IdMenu { get; set; }
        public string IPMaquina { get; set; }
        public string IPImpresora { get; set; }

        #region Campos que no existen en la tabla
        public List<seg_usuario_x_aca_Sede_Info> ListaUsuarioPorSede { get; set; }
        #endregion
    }
}