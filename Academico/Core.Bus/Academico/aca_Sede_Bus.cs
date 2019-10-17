using Core.Data.Academico;
using Core.Info.Academico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.Academico
{
    public class aca_Sede_Bus
    {
        aca_Sede_Data odata = new aca_Sede_Data();

        public List<aca_Sede_Info> GetList(int IdEmpresa, bool MostrarAnulados)
        {
            try
            {
                return odata.GetList(IdEmpresa, MostrarAnulados);
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
                return odata.GetInfo(IdEmpresa, IdSede);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
