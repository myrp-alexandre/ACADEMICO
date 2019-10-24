using Core.Data.Academico;
using Core.Data.SeguridadAcceso;
using Core.Info.Academico;
using Core.Info.SeguridadAcceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.Academico
{
    public class aca_Menu_x_aca_Sede_Bus
    {
        aca_Menu_x_aca_Sede_Data odata = new aca_Menu_x_aca_Sede_Data();

        public List<aca_Menu_x_aca_Sede_Info> get_list(int IdEmpresa, int IdSede)
        {
            try
            {
                return odata.get_list(IdEmpresa, IdSede);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool eliminarDB(int IdEmpresa, int IdSede)
        {
            try
            {
                return odata.eliminarDB(IdEmpresa, IdSede);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(List<aca_Menu_x_aca_Sede_Info> Lista)
        {
            try
            {
                return odata.guardarDB(Lista);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
