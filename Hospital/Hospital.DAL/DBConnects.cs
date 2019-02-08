using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class DBConnects : IDBConnects
    {
        SqlCommand _oCmd; //object commande
        SqlConnection _oConn; //objet connection
        string ConnectionString = @"Server = WAD-11\SQLEXPRESS; Database = Hospital; User Id = sa;
            Password = wad;"; //connection string 

        private bool Connect()  //on renvoie quelque chose pour ne pas la faire planter
        {
            //création de l'objet de connection
            _oConn = new SqlConnection(ConnectionString);

            //ouverture de la connection avec récupération de l'exception avec un try/catch
            try
            {
                _oConn.Open();
                _oCmd = new SqlCommand();
                _oCmd.Connection = _oConn;
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        private bool Disconnect()
        {

            try
            {
                _oConn.Close(); // pour entourer d'un code un truc déjà créé : Ctrl k->s
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }



        private Dictionary<string, object> ReaderToDictionary(SqlDataReader Odr)  //on passe l'objet SqlDataReader en paramètre (ici Odr): il appliquera ses méthodes à la ligne qu'il est currentement en train de lire)
        {
            Dictionary<string, object> el = new Dictionary<string, object>(); //on crée un tableau (Dictionnaire) 

            for (int i = 0; i < Odr.FieldCount; i++) //pour chaque colonne (FieldCount = méthode existant pour les objets SqlDataReader (Odr ici)), on rentre dans le tableau le nom de la colonne en string et la valeur en objet)
            {
                string Name = Odr.GetName(i);  //récupere nom de la colonne
                object valeur = Odr[i]; //récupère valeur
                el.Add(Name, valeur); //le met dans le tableau (Dictionnaire el)
            }

            return el;
        }

        private bool Execute(string query, Dictionary<string, object> datas)
        {
            if (Connect())
            {
                //associer la requête à la demande
                _oCmd.CommandText = query;
                //remplir les paramètres
                foreach (KeyValuePair<string, object> item in datas) //Parameters est une méthode de l'object commande (tableau (~Dictionnaire~)de paramètres vide à la base). Ici on le remplit en lui donnant chaque Key string (@) en Key et chaque Value en valeur  (~comme ça il sait au moment ou je vois @cetruc je le remplace par lavaleurdecetruc)
                {
                    SqlParameter Sp = new SqlParameter();
                    Sp.ParameterName = item.Key;
                    Sp.Value = item.Value;
                    _oCmd.Parameters.Add(Sp);
                }

                //exécuter la requête
                _oCmd.ExecuteNonQuery();
                Disconnect();
                return true;
            }
            else
            {
                return false;
            }
        }



        public List<Dictionary<string, object>> Get(string Nomtable)
        {
            if (Connect())
            {

                _oCmd.CommandText = string.Format(@"Select * FROM {0}", Nomtable); //on donne la commandeText (correspond à la query) à l'objet Commande pour qu'il sache ce qui devra être appelé


                SqlDataReader Odr = _oCmd.ExecuteReader(); //Odr est un objet SqlDataReader (~capabpable de lire les données~) qui "reprend" l'objet renvoyé par _oCmd.ExecuteReader() (fonction existante et "utilisable" comme (return se met dans) SqlDataReader)
                List<Dictionary<string, object>> ld = new List<Dictionary<string, object>>();  //on crée le dictionnaire ou on rentrera les résultats (= un tableau où on rangera les tableau crées pour chaque ligne utilisateur)

                while (Odr.Read()) // au moment où on fait le read (Read = méthode existant pour les objets SqlDataReader (Odr ici)), on ramène les données du Reader(Odr) du coté C# -> en mémoire et peut l'utiliser - chacune est lue jusqu'à ce qu'il n'y ai plus de lignes
                {
                    ld.Add(ReaderToDictionary(Odr)); //on rajoute chaque tableau au tableau (Dictionnaire) de tableau (un pour  chaque ligne)

                }

                Odr.Close();

                Disconnect();
                return ld;
            }
            else
            {
                return null;
            }
        }

        public Dictionary<string, object> GetOne(int id, string nomtable, string nom_colonne) //on donne le nom de la table, de la colonne id et le numero de l'id
        {
            if (Connect())
            {

                _oCmd.CommandText = string.Format(@"Select * FROM {0} WHERE {1} = {2}", nomtable, nom_colonne, id); //on cherche tous ceux qui ont la valeur (int Id) dans la colonne id (string nom_colonne)

                SqlDataReader Odr = _oCmd.ExecuteReader(); //(le return de _oCmd.ExecuteReader() devient l'objet SqlDataReader Odr)
                Dictionary<string, object> d = new Dictionary<string, object>(); //on crée le tableau (Dictionnaire) pour stocké ce qu'on trouve

                if (Odr.Read()) //si l'id est trouvé (qu'il y à quelque chose à lire)
                {
                    d = ReaderToDictionary(Odr); //on met les résultats dans le tableau

                }

                Odr.Close();

                Disconnect();
                return d;
            }
            else
            {
                return null;
            }
        }

        public List<Dictionary<string, object>> GetFilter(string query, Dictionary<string, object> parametres)
        {
            if (Connect())
            {

                //_oCmd.CommandText = string.Format(query, parametres.Values.ToArray());
                _oCmd.CommandText = query;  //on passe la query particulière à _oCmd (dans CommandText)
                foreach (KeyValuePair<string, object> item in parametres) 
                {
                    _oCmd.Parameters.Add(item.Key, item.Value);  // Parameters est une méthode de l'object commande. Qui retourne à la base un tableau vide mais qui peut être remplis -> return les parametres de la transition sql
                }


                SqlDataReader Odr = _oCmd.ExecuteReader();
                List<Dictionary<string, object>> ld = new List<Dictionary<string, object>>();

                while (Odr.Read()) // au moment où on fait le read, on ramène les données du Reader(Odr) du coté C# -> en mémoire et peut l'utiliser
                {
                    ld.Add(ReaderToDictionary(Odr));

                }

                Odr.Close();

                Disconnect();
                return ld;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(int id, string nomtable, string nom_colonne_id)
        {

            string query = string.Format(@"Delete from {0} where {1}=@id", nomtable, nom_colonne_id);  //on crée la requête en laissant des paramêtres "a substituer" (@) pour plus de sécurité/compatibilité
            Dictionary<string, object> datas = new Dictionary<string, object>(); //on crée un Dictionnaire (vide) ou on va ajouter en string index les @ à remplacer et en valeur leur valeur de substitution (rentrée en paramètre)
            datas.Add("@id", id);

            return Execute(query, datas);  //exécute la requête et renvoie true/false en cas de réussite/échec
        }

        public bool Insert(Dictionary<string, object> d, string query)
        {
            return Execute(query, d);  //on envoie direst le Dictionnaire et la query à Execute() qui va les associé et exécuter la requête complète
        }

        public bool Update(Dictionary<string, object> d, string query)
        {
            return Execute(query, d); //on envoie direst le Dictionnaire et la query à Execute() qui va les associé et exécuter la requête complète
        }
    }
}
