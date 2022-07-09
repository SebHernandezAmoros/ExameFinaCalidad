using ContFinanci.web.DB;
using ContFinanci.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContFinanci.web.Repositories
{
    public interface ITransaccionRepositories
    {
        void Guardar(Transaccion transaccion);
        void Eliminar(int id);
        List<Transaccion> ObtenerTodos();
        List<Transaccion> ObtenerTodosCuentaGasto( string cuenta);
        List<Transaccion> ObtenerTodosCuentaIngreso(string cuenta);
        Transaccion ObtenerPorID(int id);
    }
    public class TransaccionRepositories : ITransaccionRepositories
    {
        private readonly DbEntities dbEntities;
        public TransaccionRepositories(DbEntities dbEntities)
        {
            this.dbEntities = dbEntities;
        }
        public void Eliminar(int id)
        {
            dbEntities.Transaccions.Remove(ObtenerPorID(id));
            dbEntities.SaveChanges();
        }

        public void Guardar(Transaccion transaccion)
        {
            dbEntities.Transaccions.Add(transaccion);
            dbEntities.SaveChanges();
        }

        public Transaccion ObtenerPorID(int id)
        {
            return dbEntities.Transaccions.FirstOrDefault(o => o.TransaccionId == id);
        }

        public List<Transaccion> ObtenerTodos()
        {
            return dbEntities.Transaccions.ToList();
        }

        public List<Transaccion> ObtenerTodosCuentaGasto(string cuenta)
        {
            return dbEntities.Transaccions.Where(o => o.Cuenta.ToLower().Contains(cuenta) && o.Gasto == true).ToList();
        }

        public List<Transaccion> ObtenerTodosCuentaIngreso(string cuenta)
        {
            return dbEntities.Transaccions.Where(o => o.Cuenta.ToLower().Contains(cuenta) && o.Gasto == false).ToList();
        }
    }
}
