using Core.Data.General;
using Core.Info.General;
using DevExpress.Web;
using System;
using System.Collections.Generic;

namespace Core.Erp.Bus.General
{
    public class tb_empresa_Bus        
    {
        tb_empresa_Data odata = new tb_empresa_Data();

        public List<tb_empresa_Info> get_list(bool mostrar_anulados)
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

        public tb_empresa_Info get_info(int IdEmpresa)
        {
            try
            {
                return odata.get_info(IdEmpresa);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
