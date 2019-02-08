using BuisnessLayer.BuisnessModels;
using Hospital.DAL.Repository;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.BuisnessConnect
{
    public static class Personne_client_connect
    {
        public static List<Personne_client> Get_personne_client()
        {

            List<Personne> liste_personne = Personne_repository.Get_personne();

            List<Personne_client> liste_personne_client = new List<Personne_client>();

            foreach (Personne item in liste_personne)
            {
                Personne_client p_c = Mappers.Mapper.PersonneTOPersonne_client(item);
                liste_personne_client.Add(p_c);
            }

            return liste_personne_client;
        }

        public static Personne_client GetOne_personne_client(int id)
        {
            Personne p = Personne_repository.GetOne_personne(id);

            return Mappers.Mapper.PersonneTOPersonne_client(p);
        }

        public static List<Personne_client> GetFilter_personne_client(string query_where, Dictionary<string, object> parametres)
        {
            List<Personne> liste_personne = Personne_repository.GetFilter_personne(query_where, parametres);

            List<Personne_client> liste_personne_client = new List<Personne_client>();

            foreach (Personne item in liste_personne)
            {
                Personne_client p_c = Mappers.Mapper.PersonneTOPersonne_client(item);
                liste_personne_client.Add(p_c);
            }

            return liste_personne_client;
        }

        public static bool Delete_personne_client(int id)
        {
            return Personne_repository.Delete_personne(id);
        }

        public static bool Insert_personne_client(Personne_client p_c)
        {
            return Personne_repository.Insert_personne(Mappers.Mapper.Personne_clientTOPersonne(p_c) );
        }
    }

}
