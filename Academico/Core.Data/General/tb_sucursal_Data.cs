using Core.Data.Base;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
    public class tb_sucursal_Data
    {
        public List<tb_sucursal_Info> get_list(int IdEmpresa, bool mostrar_anulados)
        {
            try
            {
                List<tb_sucursal_Info> Lista;

                using (EntitiesGeneral Context = new EntitiesGeneral())
                {
                    Lista = Context.tb_sucursal.Where(q => q.IdEmpresa == IdEmpresa && q.Estado == (mostrar_anulados == true ? q.Estado : "A")).Select(q => new tb_sucursal_Info
                    {
                        IdEmpresa = q.IdEmpresa,
                        IdSucursal = q.IdSucursal,
                        Su_Descripcion = q.Su_Descripcion,
                        Su_CodigoEstablecimiento = q.Su_CodigoEstablecimiento,
                        Su_Ruc = q.Su_Ruc,
                        Estado = q.Estado,

                        EstadoBool = q.Estado == "A" ? true : false
                    }).ToList();
                }

                Lista.ForEach(v => { v.IdString = v.IdEmpresa.ToString("000") + v.IdSucursal.ToString("000"); });
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
