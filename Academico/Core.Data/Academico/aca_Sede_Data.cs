using Core.Data.Base;
using Core.Info.Academico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Academico
{
    public class aca_Sede_Data
    {
        public List<aca_Sede_Info> GetList(int IdEmpresa, bool MostrarAnulados)
        {
            try
            {
                List<aca_Sede_Info> Lista = new List<aca_Sede_Info>();

                using (EntitiesAcademico odata = new EntitiesAcademico())
                {
                    var lst = odata.aca_Sede.Where(q => q.IdEmpresa == IdEmpresa && q.Estado == (MostrarAnulados ? q.Estado : true)).ToList();

                    lst.ForEach(q =>
                    {
                        Lista.Add(new aca_Sede_Info
                        {
                            IdEmpresa = q.IdEmpresa,
                            IdSede = q.IdSede,
                            IdSucursal = q.IdSucursal,
                            NomSede = q.NomSede,
                            Direccion = q.Direccion,
                            NombreRector = q.NombreRector,
                            NombreSecretaria = q.NombreSecretaria,
                            Estado = q.Estado
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

        public aca_Sede_Info GetInfo(int IdEmpresa, int IdSede)
        {
            try
            {
                aca_Sede_Info info;

                using (EntitiesAcademico db = new EntitiesAcademico())
                {
                    var Entity = db.aca_Sede.Where(q => q.IdEmpresa == IdEmpresa && q.IdSede == IdSede).FirstOrDefault();
                    if (Entity == null)
                        return null;

                    info = new aca_Sede_Info
                    {
                        IdEmpresa = Entity.IdEmpresa,
                        IdSede = Entity.IdSede,
                        IdSucursal = Entity.IdSucursal,
                        NomSede = Entity.NomSede,
                        Direccion = Entity.Direccion,
                        NombreRector = Entity.NombreRector,
                        NombreSecretaria = Entity.NombreSecretaria,
                        Estado = Entity.Estado
                    };
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
