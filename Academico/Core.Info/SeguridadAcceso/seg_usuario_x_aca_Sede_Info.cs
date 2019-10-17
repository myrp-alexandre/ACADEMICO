using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.SeguridadAcceso
{
    public class seg_usuario_x_aca_Sede_Info
    {
        public string IdUsuario { get; set; }
        public int IdEmpresa { get; set; }
        public int IdSede { get; set; }
        public string Observacion { get; set; }

        #region Campos que no existen en la tabla
        public string NomSede { get; set; }
        public int Secuencia { get; set; }
        #endregion
    }
}
