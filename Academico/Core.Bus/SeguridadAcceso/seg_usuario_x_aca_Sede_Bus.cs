using Core.Data.SeguridadAcceso;
using Core.Info.SeguridadAcceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.SeguridadAcceso
{
    public class seg_usuario_x_aca_Sede_Bus
    {
        seg_usuario_x_aca_Sede_Data odata = new seg_usuario_x_aca_Sede_Data();

        public List<seg_usuario_x_aca_Sede_Info> GetList(string IdUsuario)
        {
            try
            {
                return odata.GetList(IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
