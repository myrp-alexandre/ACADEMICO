using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.Academico
{
    public class aca_Sede_Info
    {
        public int IdEmpresa { get; set; }
        public int IdSede { get; set; }
        public int IdSucursal { get; set; }
        public string NomSede { get; set; }
        public string Direccion { get; set; }
        public string NombreRector { get; set; }
        public string NombreSecretaria { get; set; }
        public bool Estado { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public string MotivoAnulacion { get; set; }
    }
}
