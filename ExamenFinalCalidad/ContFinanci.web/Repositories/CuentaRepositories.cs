using ContFinanci.web.DB;
using ContFinanci.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContFinanci.web.Repositories
{
    public interface ICuentaRepositories
    {
        void Actualizar(Cuenta cuenta);
        void Guardar(Cuenta cuenta);
        void Eliminar(int id);
        List<Cuenta> ObtenerTodos();
        Cuenta ObtenerNombre(string name);
        Cuenta ObtenerPorID(int id);
    }
    public class CuentaRepositories : ICuentaRepositories
    {
        private readonly DbEntities dbEntities;
        public CuentaRepositories(DbEntities dbEntities)
        {
            this.dbEntities = dbEntities;
        }

        public void Actualizar(Cuenta cuenta)
        {
            Cuenta cuentaDB = dbEntities.Cuentas.FirstOrDefault(o => o.CuentaId == cuenta.CuentaId);
            cuentaDB.SaldoInicial = cuenta.SaldoInicial;
            dbEntities.SaveChanges();
        }

        public void Eliminar(int id)
        {
            dbEntities.Cuentas.Remove(ObtenerPorID(id));
            dbEntities.SaveChanges();
        }

        public void Guardar(Cuenta cuenta)
        {
            dbEntities.Cuentas.Add(cuenta);
            dbEntities.SaveChanges();
        }

        public Cuenta ObtenerNombre(string name)
        {
            return dbEntities.Cuentas.FirstOrDefault(o => o.Nombre == name);
        }

        public Cuenta ObtenerPorID(int id)
        {
            return dbEntities.Cuentas.FirstOrDefault(o => o.CuentaId == id);
        }

        public List<Cuenta> ObtenerTodos()
        {
            return dbEntities.Cuentas.ToList();
        }
    }
}
