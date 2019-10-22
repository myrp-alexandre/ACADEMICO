﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.Academico
{
    public class aca_AnioLectivo_Info
    {
        public decimal IdTransaccionSession { get; set; }
        public int IdEmpresa { get; set; }
        public int IdAnio { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo fecha desde es obligatorio")]
        public System.DateTime FechaDesde { get; set; }
        [Required(ErrorMessage = "El campo fecha desde es obligatorio")]
        public System.DateTime FechaHasta { get; set; }
        public bool Estado { get; set; }
        public bool EnCurso { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string IdUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string IdUsuarioAnulacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        [Required(ErrorMessage = "El campo motivo de anulación es obligatorio")]
        public string MotivoAnulacion { get; set; }
    }
}