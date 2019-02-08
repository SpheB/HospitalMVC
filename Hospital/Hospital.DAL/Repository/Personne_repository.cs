using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Repository
{
    public static class Personne_repository
    {
        public static List<Personne> Get_personne()
        {
            DBConnects dbtest = new DBConnects();

            List<Dictionary<string, object>> liste_personnes_brute = dbtest.Get("Personne");

            List<Personne> liste_personnes = new List<Personne>();


            foreach (var item in liste_personnes_brute)
            {
                Personne p = new Personne();
                p.Id_personne = (int)item["Id_personne"];
                //en cas de valueur nullable dans la DB: on prends l'objet renvoyé, on regarde si sa valeur est DBNulle
                //--> si c'est le cas, on prend null comme valeur à mettre dans p.lapropriété
                //--> si ce n'est pas le cas, on prends la valeur convertie (en int, en string, en DateTime?,...)
                p.NumeroNational = item["NumeroNational"] == DBNull.Value ? null: item["NumeroNational"].ToString();
                p.Nom = item["Nom"] == DBNull.Value ? null : item["Nom"].ToString();
                p.Prenom = item["Prenom"] == DBNull.Value ? null : item["Prenom"].ToString();
                p.Date_naissance = item["Date_naissance"] == DBNull.Value ? null : (DateTime?)item["Date_naissance"];
                p.Rue = item["Rue"] == DBNull.Value ? null : item["Rue"].ToString();
                p.Numero = item["Numero"] == DBNull.Value ? null : item["Numero"].ToString();
                p.CodePostal = item["CodePostal"] == DBNull.Value ? null : item["CodePostal"].ToString();
                p.Pays = item["Pays"] == DBNull.Value ? null :  item["Pays"].ToString();
                p.Telephone = item["Telephone"] == DBNull.Value ? null : item["Telephone"].ToString();
                p.GSM = item["GSM"] == DBNull.Value ? null : item["GSM"].ToString();
                p.Email = item["Email"] == DBNull.Value ? null : item["Email"].ToString();

                liste_personnes.Add(p);
            }


            return liste_personnes;


        }

        public static Personne GetOne_personne(int id)
        {
            DBConnects dbtest = new DBConnects();

            Dictionary<string, object> d = dbtest.GetOne(id, "Personne", "id_personne");

            Personne p = new Personne();
            p.Id_personne = (int)d["Id_personne"];
            //en cas de valueur nullable dans la DB: on prends l'objet renvoyé, on regarde si sa valeur est DBNulle
            //--> si c'est le cas, on prend null comme valeur à mettre dans p.lapropriété
            //--> si ce n'est pas le cas, on prends la valeur convertie (en int, en string, en DateTime?,...)
            p.NumeroNational = d["NumeroNational"] == DBNull.Value ? null : d["NumeroNational"].ToString();
            p.Nom = d["Nom"] == DBNull.Value ? null : d["Nom"].ToString();
            p.Prenom = d["Prenom"] == DBNull.Value ? null : d["Prenom"].ToString();
            p.Date_naissance = d["Date_naissance"] == DBNull.Value ? null : (DateTime?)d["Date_naissance"];
            p.Rue = d["Rue"] == DBNull.Value ? null : d["Rue"].ToString();
            p.Numero = d["Numero"] == DBNull.Value ? null : d["Numero"].ToString();
            p.CodePostal = d["CodePostal"] == DBNull.Value ? null : d["CodePostal"].ToString();
            p.Pays = d["Pays"] == DBNull.Value ? null : d["Pays"].ToString();
            p.Telephone = d["Telephone"] == DBNull.Value ? null : d["Telephone"].ToString();
            p.GSM = d["GSM"] == DBNull.Value ? null : d["GSM"].ToString();
            p.Email = d["Email"] == DBNull.Value ? null : d["Email"].ToString();

            return p;
        }

        public static List<Personne> GetFilter_personne(string query_where, Dictionary<string, object> parametres)
        {
            DBConnects dbtest = new DBConnects();
            string query_filter = "SELECT * FROM Personne WHERE " + query_where; //le début de la requête ne change pas, on ne doit rajouter que les conditions qu'il y a après le Where (et concatener)

            List<Dictionary<string, Object>> liste_personnes_filter_brute = dbtest.GetFilter(query_filter, parametres); //liste de Dictionnaires to be convertis en personnes

            List<Personne> liste_personnes = new List<Personne>(); //liste_personnes de personne vide ou l'on mettre les new personnes créées (une par Dictionnaire de la liste)

            foreach (var item in liste_personnes_filter_brute)  //on attribue les values de chaque Dictionnaires de la liste aux propriétées d'une personne nouvellement créée (on utilise la clef/index du dictionnaire traité pour attribuer la bonne valeur à la bonne propriété (!faire correspondre les noms))
            {
                Personne p = new Personne();
                p.Id_personne = (int)item["Id_personne"];
                //en cas de valueur nullable dans la DB: on prends l'objet renvoyé, on regarde si sa valeur est DBNulle
                //--> si c'est le cas, on prend null comme valeur à mettre dans p.lapropriété
                //--> si ce n'est pas le cas, on prends la valeur convertie (en int, en string, en DateTime?,...)
                p.NumeroNational = item["NumeroNational"] == DBNull.Value ? null : item["NumeroNational"].ToString();
                p.Nom = item["Nom"] == DBNull.Value ? null : item["Nom"].ToString();
                p.Prenom = item["Prenom"] == DBNull.Value ? null : item["Prenom"].ToString();
                p.Date_naissance = item["Date_naissance"] == DBNull.Value ? null : (DateTime?)item["Date_naissance"];
                p.Rue = item["Rue"] == DBNull.Value ? null : item["Rue"].ToString();
                p.Numero = item["Numero"] == DBNull.Value ? null : item["Numero"].ToString();
                p.CodePostal = item["CodePostal"] == DBNull.Value ? null : item["CodePostal"].ToString();
                p.Pays = item["Pays"] == DBNull.Value ? null : item["Pays"].ToString();
                p.Telephone = item["Telephone"] == DBNull.Value ? null : item["Telephone"].ToString();
                p.GSM = item["GSM"] == DBNull.Value ? null : item["GSM"].ToString();
                p.Email = item["Email"] == DBNull.Value ? null : item["Email"].ToString();

                liste_personnes.Add(p);
            }

            return liste_personnes;
        }

        public static bool Delete_personne(int id) // on connait déjà le nom de la table et de la clonne_id --> on ne doit préciser que l'id
        {
            DBConnects dbtest = new DBConnects();

            return dbtest.Delete(id, "Personne", "Id_personne");
        }

        public static bool Insert_personne(Personne p)
        {
            DBConnects dbtest = new DBConnects();

            string query_insert = @"INSERT INTO [dbo].[Personne] (NumeroNational, Nom, Prenom, Date_naissance, Rue, Numero, CodePostal, Pays, Telephone, GSM, Email) 
                                   VALUES (@NumeroNational, @Nom, @Prenom, @Date_naissance, @Rue, @Numero, @CodePostal, @Pays, @Telephone, @GSM, @Email)"; //la query propre à l'insert de "Personne" (comprends tous les champs (sauf id_personne)vu qu'on insert une personne entière)

            Dictionary<string, object> parametres_insert = new Dictionary<string, object>();

            //on rempli le Dictionnaire nouvellement créé avec, en clé, le string qui indique quelle valeur en @ de la query sera remplacée (automatiquement) en en value, la valeur par laquelle le @... sera remplacé
            //ici cette valeur est trouvée grace aux propriétés de la Peronne p passée en paramètre
            parametres_insert.Add("@NumeroNational", p.NumeroNational); //le nom avec ou sans @, le programme comprends les deux apparemment: dans le execute, les entrées du tableau seront données (la Key en Key et la Value en Value) au SqlParameter (=Dictionnaire) qui servira à remplacer les @nom par les valeurs du tableau SqlParameter dont la clef @Nom ou Nom correspond
            parametres_insert.Add("@Nom", p.Nom);
            parametres_insert.Add("@Prenom", p.Prenom);
            parametres_insert.Add("@Date_naissance", p.Date_naissance);
            parametres_insert.Add("@Rue", p.Rue);
            parametres_insert.Add("@Numero", p.Numero);
            parametres_insert.Add("@CodePostal", p.CodePostal);
            parametres_insert.Add("@Pays", p.Pays);
            parametres_insert.Add("@Telephone", p.Telephone);
            parametres_insert.Add("@GSM", p.GSM);
            parametres_insert.Add("@Email", p.Email);

            return dbtest.Insert(parametres_insert, query_insert);
        }

        public static bool Update_personne(Personne p, string query_where)  //alternative à cette méthode: aller chercher la personne concerné, completer les données non données par l'utilisateur pour compléter la personne et insérer toute la personne en mode Insert
        {
            DBConnects dbtest = new DBConnects();
            string query_update = @"UPDATE [Personne] SET ";

            Dictionary<string, object> parametres_update = new Dictionary<string, object>();

            for (int i = 0; i < p.GetType().GetProperties().Length; i++)
            {
                if (p.GetType().GetProperties()[i].GetValue(p) != null) //!! par les type valeur (=0) et pour mettre à null (dema,der si mettre à null et remplir d'une valeur reconnaissable (ex "a_null") qui fera changer la valeur à null (if c'est cette valeur Add(nompropriété, null));
                {
                    parametres_update.Add("@" + p.GetType().GetProperties()[i].Name.ToString(), p.GetType().GetProperties()[i].GetValue(p)); //met dans le dictionnaire parametres_update le Nom des propriétées non nulles (string) en Key et leur valeur en Value

                    query_update = query_update + p.GetType().GetProperties()[i].Name.ToString() + " = @" + p.GetType().GetProperties()[i].Name.ToString() + ","; // on rajoute à la string query tout ce qui va être changé
                }
                //Console.WriteLine(p.GetType().GetProperties()[i].GetValue(p).ToString()); //reprend (et écrit) chaque propriété (rajouter .Name si veut que le nom)
                //p.GetType().GetFields()[i].GetValue(p).ToString(); //valeur de chaque champs (attribut public)
            }

            query_update = query_update.Substring(0, query_update.Length - 1) + " WHERE " + query_where; //enleve la derniere virgule

            return dbtest.Update(parametres_update, query_update); //on envoie direst le Dictionnaire et la query à Execute() qui va les associé et exécuter la requête complète
        }
    }
}
