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
                    Lista = Context.tb_empresa.Where(q => q.Estado == (mostrar_anulados == true ? q.Estado : "A")).Select(q => new tb_empresa_Info
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

        #region Bajo demanda
        public tb_empresa_Info get_info_demanda(int value)
        {
            tb_empresa_Info info = new tb_empresa_Info();
            using (EntitiesGeneral Contex = new EntitiesGeneral())
            {
                info = (from q in Contex.tb_empresa
                        where q.IdEmpresa == value
                        select new tb_empresa_Info
                        {
                            IdEmpresa = q.IdEmpresa,
                            codigo = q.codigo,
                            em_nombre = q.em_nombre
                        }).FirstOrDefault();
            }
            return info;
        }
        public tb_empresa_Info get_info_bajo_demanda(ListEditItemRequestedByValueEventArgs args)
        {
            decimal id;
            if (args.Value == null || !decimal.TryParse(args.Value.ToString(), out id))
                return null;
            return get_info_demanda((int)args.Value);
        }
        public List<tb_empresa_Info> get_list(int skip, int take, string filter)
        {
            try
            {
                List<tb_empresa_Info> Lista = new List<tb_empresa_Info>();

                EntitiesGeneral context_g = new EntitiesGeneral();

                var lstg = context_g.tb_empresa.Where(q => q.Estado == "A" && (q.IdEmpresa.ToString() + " " + q.em_nombre).Contains(filter)).OrderBy(q => q.IdEmpresa).Skip(skip).Take(take);
                foreach (var q in lstg)
                {
                    Lista.Add(new tb_empresa_Info
                    {
                        IdEmpresa = q.IdEmpresa,
                        codigo = q.codigo,
                        em_nombre = q.em_nombre
                    });
                }
                context_g.Dispose();
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<tb_empresa_Info> get_list_bajo_demanda(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            var skip = args.BeginIndex;
            var take = args.EndIndex - args.BeginIndex + 1;
            List<tb_empresa_Info> Lista = new List<tb_empresa_Info>();
            Lista = get_list(skip, take, args.Filter);
            return Lista;
        }
        #endregion
    }
}
