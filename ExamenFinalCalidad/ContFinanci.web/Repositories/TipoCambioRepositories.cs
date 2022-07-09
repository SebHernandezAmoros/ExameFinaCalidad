using ContFinanci.web.DB;
using ContFinanci.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContFinanci.web.Repositories
{
    public interface ITipoCambioRepositories
    {
        TipoCambio ObtenerUltimo();
    }
    public class TipoCambioRepositories : ITipoCambioRepositories
    {
        private readonly DbEntities dbEntities;
        public TipoCambioRepositories(DbEntities dbEntities)
        {
            this.dbEntities = dbEntities;
        }
        public TipoCambio ObtenerUltimo()
        {
            return dbEntities.TipoCambios.OrderByDescending(o => o.TipoCambioId).First();
        }
    }
}
