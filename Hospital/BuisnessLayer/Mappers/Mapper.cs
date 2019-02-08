using BuisnessLayer.BuisnessModels;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Mappers
{
    public static class Mapper
    {
        public static Personne Personne_clientTOPersonne(Personne_client p_c){

            return new Personne
            {
                NumeroNational = p_c.NumeroNational,
                Nom = p_c.Nom,
                Prenom = p_c.Prenom,
                Date_naissance = p_c.Date_naissance,
                Rue = p_c.Rue,
                Numero = p_c.Numero,
                CodePostal = p_c.CodePostal,
                Pays = p_c.Pays,
                Telephone = p_c.Telephone,
                GSM = p_c.GSM,
                Email = p_c.Email
            };
        }

        public static Personne_client PersonneTOPersonne_client(Personne p)
        {
            return new Personne_client
            {
                NumeroNational = p.NumeroNational,
                Nom = p.Nom,
                Prenom = p.Prenom,
                Date_naissance = p.Date_naissance,
                Rue = p.Rue,
                Numero = p.Numero,
                CodePostal = p.CodePostal,
                Pays = p.Pays,
                Telephone = p.Telephone,
                GSM = p.GSM,
                Email = p.Email
            };
        }
    }
}
