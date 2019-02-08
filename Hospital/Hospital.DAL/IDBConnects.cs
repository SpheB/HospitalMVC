using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public interface IDBConnects
    {
        List<Dictionary<string, object>> Get(string Nomtable);

        Dictionary<string, object> GetOne(int Id, string Nomtable, string nom_colonne);

        //+ajouter le getFilter()?

        bool Delete(int Id, string Nomtable, string NomId);

        bool Insert(Dictionary<string, object> d, string query);

        bool Update(Dictionary<string, object> d, string query);
    }
}
