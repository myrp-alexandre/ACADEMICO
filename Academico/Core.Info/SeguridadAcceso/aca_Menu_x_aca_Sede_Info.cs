using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.SeguridadAcceso
{
    public class aca_Menu_x_aca_Sede_Info
    {
        public int IdEmpresa { get; set; }
        public int IdSede { get; set; }
        public int IdMenu { get; set; }
        public string Observacion { get; set; }

        //Campos que no existen en la tabla
        public bool seleccionado { get; set; }
        public aca_Menu_Info info_menu { get; set; }
    }
}
