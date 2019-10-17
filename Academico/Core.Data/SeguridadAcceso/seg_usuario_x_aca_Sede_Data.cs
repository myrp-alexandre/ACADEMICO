using Core.Data.Base;
using Core.Info.SeguridadAcceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.SeguridadAcceso
{
    public class seg_usuario_x_aca_Sede_Data
    {
        public List<seg_usuario_x_aca_Sede_Info> GetList(string IdUsuario)
        {
            try
            {
                List<seg_usuario_x_aca_Sede_Info> Lista = new List<seg_usuario_x_aca_Sede_Info>();

                using (EntitiesSeguridadAcceso db = new EntitiesSeguridadAcceso())
                {
                    var lst = db.seg_usuario_x_aca_Sede.Where(q => q.IdUsuario == IdUsuario).ToList();

                    int Secuencia = 1;
                    lst.ForEach(q =>
                    {
                        Lista.Add(new seg_usuario_x_aca_Sede_Info
                        {
                            IdEmpresa =  q.IdEmpresa,
                            IdSede = q.IdSede,
                            IdUsuario = q.IdUsuario,
                            Secuencia = Secuencia++
                        });
                    });
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
