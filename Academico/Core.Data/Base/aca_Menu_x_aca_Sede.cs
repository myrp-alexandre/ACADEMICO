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
    
    public partial class aca_Menu_x_aca_Sede
    {
        public int IdEmpresa { get; set; }
        public int IdSede { get; set; }
        public int IdMenu { get; set; }
        public string Observacion { get; set; }
    
        public virtual aca_Menu aca_Menu { get; set; }
    }
}
