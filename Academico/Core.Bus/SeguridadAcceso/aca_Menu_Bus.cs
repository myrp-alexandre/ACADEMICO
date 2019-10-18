using Core.Data.Academico;
using Core.Data.SeguridadAcceso;
using Core.Info.Academico;
using Core.Info.SeguridadAcceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.SeguridadAcceso
{
    public class aca_Menu_Bus
    {
        aca_Menu_Data odata = new aca_Menu_Data();

        public List<aca_Menu_Info> get_list(bool mostrar_anulados)
        {
            try
            {
                return odata.get_list(mostrar_anulados);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<aca_Menu_Info> get_list_combo(bool mostrar_anulados)
        {
            try
            {
                return odata.get_list_combo(mostrar_anulados);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public aca_Menu_Info get_info(int IdMenu)
        {
            try
            {
                return odata.get_info(IdMenu);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(aca_Menu_Info info)
        {
            try
            {
                return odata.guardarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(aca_Menu_Info info)
        {
            try
            {
                return odata.modificarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(aca_Menu_Info info)
        {
            try
            {
                return odata.anularDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
