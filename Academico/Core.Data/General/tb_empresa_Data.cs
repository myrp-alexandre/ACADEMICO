using Core.Data.Base;
using Core.Info.General;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Data.General
{
    public class tb_empresa_Data
    {
        public List<tb_empresa_Info> get_list(bool mostrar_anulados)
        {
            try
            {
                List<tb_empresa_Info> Lista;

                using (EntitiesGeneral Context = new EntitiesGeneral())
                {
                    if (mostrar_anulados)
                        Lista = (from q in Context.tb_empresa
                                 select new tb_empresa_Info
                                 {
                                     IdEmpresa = q.IdEmpresa,
                                     codigo = q.codigo,
                                     em_nombre = q.em_nombre,
                                     em_ruc = q.em_ruc,
                                     Estado = q.Estado,
                                     em_direccion = q.em_direccion,
                                     em_telefonos = q.em_telefonos
                                 }).ToList();
                    else
                        Lista = (from q in Context.tb_empresa
                                 where q.Estado == "A"
                                 select new tb_empresa_Info
                                 {
                                     IdEmpresa = q.IdEmpresa,
                                     codigo = q.codigo,
                                     em_nombre = q.em_nombre,
                                     em_ruc = q.em_ruc,
                                     Estado = q.Estado,
                                     em_direccion = q.em_direccion,
                                     em_telefonos = q.em_telefonos
                                 }).ToList();
                }

                return Lista;
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
                tb_empresa_Info info = new tb_empresa_Info();

                using (EntitiesGeneral Context = new EntitiesGeneral())
                {
                    tb_empresa Entity = Context.tb_empresa.FirstOrDefault(q => q.IdEmpresa == IdEmpresa);
                    if (Entity == null) return null;
                    info = new tb_empresa_Info
                    {
                        IdEmpresa = Entity.IdEmpresa,
                        codigo = Entity.codigo,
                        em_nombre = Entity.em_nombre,
                        RazonSocial = Entity.RazonSocial,
                        NombreComercial = Entity.NombreComercial,
                        ContribuyenteEspecial = Entity.ContribuyenteEspecial,
                        em_ruc = Entity.em_ruc,
                        em_gerente = Entity.em_gerente,
                        em_contador = Entity.em_contador,
                        em_rucContador = Entity.em_rucContador,
                        em_telefonos = Entity.em_telefonos,
                        em_direccion = Entity.em_direccion,
                        em_logo = Entity.em_logo,
                        em_fechaInicioContable = Entity.em_fechaInicioContable,
                        Estado = Entity.Estado,
                        em_fechaInicioActividad = Entity.em_fechaInicioActividad,
                        cod_entidad_dinardap = Entity.cod_entidad_dinardap,
                        em_Email = Entity.em_Email
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
