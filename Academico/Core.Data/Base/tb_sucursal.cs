//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Data.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_sucursal
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public string codigo { get; set; }
        public string Su_Descripcion { get; set; }
        public string Su_CodigoEstablecimiento { get; set; }
        public string Su_Ruc { get; set; }
        public string Su_JefeSucursal { get; set; }
        public string Su_Telefonos { get; set; }
        public string Su_Direccion { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string Estado { get; set; }
        public string MotiAnula { get; set; }
        public bool Es_establecimiento { get; set; }
        public string IdCtaCble_cxp { get; set; }
        public string IdCtaCble_vtaIVA0 { get; set; }
        public string IdCtaCble_vtaIVA { get; set; }
    
        public virtual tb_empresa tb_empresa { get; set; }
    }
}
