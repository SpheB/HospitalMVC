using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.BuisnessModels
{
    public class Personne_client
    {
        private int _id_personne;
        private string _numeroNational;
        private string _nom;
        private string _prenom;
        private DateTime? _date_naissance; //DateTime est une structure qui contient des int ->leur valeur par défaut est 0. On utilise DateTime pour la rendre nullable (que si elle trouve rien elle renvoie null et pas 0000-00-00 par ex)
        private string _rue;
        private string _numero;
        private string _codePostal;
        private string _pays;
        private string _telephone;
        private string _gsm;
        private string _email;
        //pour gagner du temps: clic droit "Quick actions ans refactorings

        public int Id_personne
        {
            get
            {
                return _id_personne;
            }

            set
            {
                _id_personne = value;
            }
        }

        public string NumeroNational
        {
            get
            {
                return _numeroNational;
            }

            set
            {
                _numeroNational = value;
            }
        }

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }

        public DateTime? Date_naissance
        {
            get
            {
                return _date_naissance;
            }

            set
            {
                _date_naissance = value;
            }
        }

        public string Rue
        {
            get
            {
                return _rue;
            }

            set
            {
                _rue = value;
            }
        }

        public string Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public string CodePostal
        {
            get
            {
                return _codePostal;
            }

            set
            {
                _codePostal = value;
            }
        }

        public string Pays
        {
            get
            {
                return _pays;
            }

            set
            {
                _pays = value;
            }
        }

        public string Telephone
        {
            get
            {
                return _telephone;
            }

            set
            {
                _telephone = value;
            }
        }

        public string GSM
        {
            get
            {
                return _gsm;
            }

            set
            {
                _gsm = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }
    }
}
