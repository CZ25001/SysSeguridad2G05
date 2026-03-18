using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using SysSeguridad2G05.EN;

namespace SysSeguridad2G05.DAL
{
    public class RolDAL
    {
        public static async Task<int> CreateAsync(Rol pRol) //Metodo de guardar un nuevo rol en la base de datos, recibe un objeto de tipo Rol y devuelve un entero que indica el resultado de la operación
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pRol);
                result = await dbContexto.SaveChangesAsync();

            }
            return result;
        }

        public static async Task<int> ModificarAsync(Rol pRol) //Metodo de modificar un rol existente en la base de datos, recibe un objeto de tipo Rol con los datos actualizados y devuelve un entero que indica el resultado de la operación
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var rol = await dbContexto.Rol.FirstOrDefaultAsync(s => s.Id == pRol.Id);
                rol.Nombre = pRol.Nombre;
                dbContexto.Update(rol);
                result = await dbContexto.SaveChangesAsync();

            }
            return result;
        }

        public static async Task<int> EliminarAsync(Rol pRol) //Metodo de eliminar un rol de la base de datos, recibe el id del rol a eliminar y devuelve un entero que indica el resultado de la operación, siempre eliminar el registro de forma logica, es decir, cambiar el estado del registro a inactivo en lugar de eliminarlo físicamente de la base de datos
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var rol = await dbContexto.Rol.FirstOrDefaultAsync(x => x.Id == pRol.Id);
                dbContexto.Rol.Remove(rol);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Rol> ObtenerPorId(Rol pRol) //metodo de busqueda de un rol por su id, recibe el id del rol a buscar y devuelve un objeto de tipo Rol con los datos del rol encontrado, si no se encuentra el rol devuelve null
        {
            Rol rol = new Rol();
            //Selec Id, Nombre from Rol where Id = 1; 
            using (var dbContexto = new DBContexto())
            {
                rol = await dbContexto.Rol.FirstOrDefaultAsync(s => s.Id == pRol.Id);
            }
            return rol;

        }

        public static async Task<List<Rol>> ObtenerTodosAsync() //metodo de busqueda de todos los roles en la base de datos, devuelve una lista de objetos de tipo Rol con los datos de todos los roles encontrados, si no se encuentran roles devuelve una lista vacia
        {
            List<Rol> roles = new List<Rol>();
            using (var dbContexto = new DBContexto())
            {
                roles = await dbContexto.Rol.ToListAsync();
            }
            return roles;
        }

        internal static IQueryable<Rol> QuerySelect(IQueryable<Rol> pQuery, Rol pRol) //Metodo de filtro de busqueda de roles, recibe una consulta de tipo IQueryable<Rol> y un objeto de tipo Rol con los datos de filtro, devuelve una consulta de tipo IQueryable<Rol> con los datos filtrados segun los criterios establecidos en el objeto de filtro, si no se establecen criterios de filtro devuelve la consulta original sin filtrar
        {
            if (pRol.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pRol.Id);
            if (!string.IsNullOrWhiteSpace(pRol.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pRol.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pRol.Top_Aux > 0)
                pQuery = pQuery.Take(pRol.Top_Aux).AsQueryable();
            return pQuery;
        }

        /// <summary>
        /// Carlos Emanuel 
        /// 18/03/2026
        /// Este metodo se ocupa para hacer las busquedas de uno o varios roles por medio de condiciones
        /// </summary>
        /// <param name="pRol">Parametro con los datos a buscar</param>
        /// <returns></returns>
        public static async Task<List<Rol>> BuscarAsync(Rol pRol) //Metodo de busqueda de roles con filtro, recibe un objeto de tipo Rol con los datos de filtro y devuelve una lista de objetos de tipo Rol con los datos de los roles encontrados segun los criterios establecidos en el objeto de filtro, si no se establecen criterios de filtro devuelve una lista con todos los roles
        {
            List<Rol> roles = new List<Rol>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Rol.AsQueryable();
                select = QuerySelect(select, pRol);
                roles = await select.ToListAsync();
            }
            return roles;
        }

    }
}
