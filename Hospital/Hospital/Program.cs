using Hospital.DAL;
using Hospital.DAL.Repository;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {

            DBConnects dbtest = new DBConnects();

            //List<Dictionary<string, object>> liste_test = dbtest.Get("Personne");


            //foreach (var item in liste_test)
            //{
            //    foreach (KeyValuePair<string, object> ld in item)
            //    {
            //        Console.Write(ld.Key + ": " + ld.Value + "|| " );
            //    }

            //    Console.WriteLine();
            //}

            //Console.WriteLine();
            //Console.WriteLine();

            //Dictionary<string, object> dico_test = dbtest.GetOne(2,"Personne", "id_personne");

            //foreach (KeyValuePair<string, object> ld in dico_test)
            //{
            //    Console.Write(ld.Key + ": " + ld.Value + "|| ");
            //}

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //string query = "SELECT * FROM Personne WHERE Pays=@Pays and CodePostal =@CodePostal";  //on écrit la query en laissant "libre" (@) les places des paramètres de tri

            //Dictionary<string, Object> parametres = new Dictionary<string, Object>(); //on crée un Dictionnaire où on mettra en clef (string) les noms de colonne et en valeur (object) les valeurs
            //parametres.Add("Pays", "USA");
            //parametres.Add("CodePostal", 1500);

            //List<Dictionary<string, Object>> retourFilter = dbtest.GetFilter(query, parametres); //on fait appel a GetFilter avec la query et la requête en paramètres

            //foreach (var item in retourFilter)
            //{
            //    foreach (KeyValuePair<string, object> ld in item)
            //    {
            //        Console.Write(ld.Key + ": " + ld.Value + "|| ");
            //    }

            //    Console.WriteLine();
            //}

            //Console.WriteLine();
            //Console.WriteLine();

            //Console.WriteLine(dbtest.Delete(2, "Personne", "Id_personne"));

            //Console.WriteLine();
            //Console.WriteLine();


            //string numeroNational = "0999";
            //string nom = "Star";
            //string prenom = "Patrick";
            //DateTime date_naissance = new DateTime(1960, 6, 5);
            //string rue = "Cetterue";
            //string numero = "3";
            //string codePostal = "1500";
            //string pays = "USA";
            //string telephone = "02-16-37";
            //string gsm = "070-2060";
            //string email = "Patrick@Star.com";

            //string query_insert = @"INSERT INTO [dbo].[Personne] (NumeroNational, Nom, Prenom, Date_naissance, Rue, Numero, CodePostal, Pays, Telephone, GSM, Email) 
            //                        VALUES (@NumeroNational, @Nom, @Prenom, @Date_naissance, @Rue, @Numero, @CodePostal, @Pays, @Telephone, @GSM, @Email)";

            //Dictionary<string, object> parametres_insert = new Dictionary<string, object>();
            //parametres_insert.Add("@NumeroNational", numeroNational); //le nom avec ou sans @, le programme comprends les deux apparemment: dans le execute, les entrées du tableau seront données (la Key en Key et la Value en Value) au SqlParameter (=Dictionnaire) qui servira à remplacer les @nom par les valeurs du tableau SqlParameter dont la clef @Nom ou Nom correspond
            //parametres_insert.Add("@Nom", nom);
            //parametres_insert.Add("@Prenom", prenom);
            //parametres_insert.Add("@Date_naissance", date_naissance);
            //parametres_insert.Add("@Rue", rue);
            //parametres_insert.Add("@Numero", numero);
            //parametres_insert.Add("@CodePostal", codePostal);
            //parametres_insert.Add("@Pays", pays);
            //parametres_insert.Add("@Telephone", telephone);
            //parametres_insert.Add("@GSM", gsm);
            //parametres_insert.Add("@Email", email);

            //Console.WriteLine(dbtest.Insert(parametres_insert, query_insert)); //on envoie la requête  et le tableau (Dictionnaire parametres_insert) en paramètre de Insert() -> renvoie false ou true en cas d'echec/desucces

            //Console.WriteLine();
            //Console.WriteLine();

            //List<Dictionary<string, object>> liste_test2 = dbtest.Get("Personne");


            //foreach (var item in liste_test2)
            //{
            //    foreach (KeyValuePair<string, object> ld in item)
            //    {
            //        Console.Write(ld.Key + ": " + ld.Value + " || ");
            //    }

            //    Console.WriteLine();
            //}


            //Console.WriteLine();
            //Console.WriteLine();

            //string query_update = @"UPDATE [Personne]
            //                        SET Telephone = @Telephone, Prenom = @Prenom
            //                        WHERE NumeroNational = '0222354'";


            //Dictionary<string, object> parametres_update = new Dictionary<string, object>();
            //parametres_update.Add("@Prenom", "Patrick Senior");
            //parametres_update.Add("@Telephone", "2");

            //Console.WriteLine(dbtest.Update(parametres_update, query_update));




            ////PERSONNE REPOSITORY/////////////////////////////////////////////////////////////////////////

            //List<Personne> liste_ps = Personne_repository.Get_personne();

            //foreach (var item in liste_ps)
            //{
            //    Console.WriteLine(item.Id_personne);
            //    Console.WriteLine(item.NumeroNational);
            //    Console.WriteLine(item.Nom);
            //    Console.WriteLine(item.Prenom);
            //    Console.WriteLine(item.Date_naissance);
            //    Console.WriteLine(item.Rue);
            //    Console.WriteLine(item.Numero);
            //    Console.WriteLine(item.CodePostal);
            //    Console.WriteLine(item.Pays);
            //    Console.WriteLine(item.Telephone);
            //    Console.WriteLine(item.GSM);
            //    Console.WriteLine(item.Email);

            //    Console.WriteLine();
            //    Console.WriteLine();
            //}


            //Console.WriteLine("------------------------------------------------------------------");
            //Console.WriteLine();
            //Console.WriteLine();

            //Personne p = Personne_repository.GetOne_personne(8);
            //Console.WriteLine(p.Id_personne);
            //Console.WriteLine(p.NumeroNational);
            //Console.WriteLine(p.Nom);
            //Console.WriteLine(p.Prenom);
            //Console.WriteLine(p.Date_naissance);
            //Console.WriteLine(p.Rue);
            //Console.WriteLine(p.Numero);
            //Console.WriteLine(p.CodePostal);
            //Console.WriteLine(p.Pays);
            //Console.WriteLine(p.Telephone);
            //Console.WriteLine(p.GSM);
            //Console.WriteLine(p.Email);

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("------------------------------------------------------------------");
            //Console.WriteLine();
            //Console.WriteLine();

            //Dictionary<string, Object> parametres_get_filter_personne = new Dictionary<string, Object>();
            //parametres_get_filter_personne.Add("Pays", "USA");
            //parametres_get_filter_personne.Add("CodePostal", 1500);
            //string query_GetFilter_where = "Pays=@Pays and CodePostal =@CodePostal";

            //List<Personne> liste_ps_filter = Personne_repository.GetFilter_personne(query_GetFilter_where, parametres_get_filter_personne);

            //foreach (var item in liste_ps_filter)
            //{
            //    Console.WriteLine(item.Id_personne);
            //    Console.WriteLine(item.NumeroNational);
            //    Console.WriteLine(item.Nom);
            //    Console.WriteLine(item.Prenom);
            //    Console.WriteLine(item.Date_naissance);
            //    Console.WriteLine(item.Rue);
            //    Console.WriteLine(item.Numero);
            //    Console.WriteLine(item.CodePostal);
            //    Console.WriteLine(item.Pays);
            //    Console.WriteLine(item.Telephone);
            //    Console.WriteLine(item.GSM);
            //    Console.WriteLine(item.Email);

            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            //Console.WriteLine("------------------------------------------------------------------");
            //Console.WriteLine();
            //Console.WriteLine();

            //Console.WriteLine(Personne_repository.Delete_personne(10));

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("------------------------------------------------------------------");
            //Console.WriteLine();
            //Console.WriteLine();

            //Personne p2 = new Personne();

            //p2.NumeroNational = "3600";
            //p2.Nom = "Simpson";
            //p2.Prenom = "Bart";
            //p2.Date_naissance = new DateTime(1985, 2, 10);
            //p2.Rue = "Evergreen Terasse";
            //p2.Numero = "143";
            //p2.CodePostal = "1000";
            //p2.Pays = "USA";
            //p2.Telephone = "02415999";
            //p2.GSM = "04578962";
            //p2.Email = "bart@gmail.com";

            //Console.WriteLine(Personne_repository.Insert_personne(p2));

            Dictionary<string, object> parametres_update = new Dictionary<string, object>();
            Personne p2 = new Personne();

            p2.Id_personne = 110;
            p2.NumeroNational = "3600";
            p2.Nom = "Simpson";
            p2.Prenom = "Bart";
            p2.Date_naissance = new DateTime(1985, 2, 10);
            p2.Rue = "Evergreen Terasse";
            p2.Numero = "143";
            p2.CodePostal = "1000";
            p2.Pays = "USA";
            p2.Telephone = "02415999";
            p2.GSM = "04578962";
            p2.Email = "bart@gmail.com";

            //Console.Write(p2.GetType().GetProperties().Length);
            for (int i = 0; i < p2.GetType().GetProperties().Length; i++)
            {
                parametres_update.Add(p2.GetType().GetProperties()[i].Name.ToString(), p2.GetType().GetProperties()[i].GetValue(p2));
                //Console.WriteLine(p2.GetType().GetProperties()[i].GetValue(p2).ToString()); //valeur de chaque propriété
            }

            foreach (KeyValuePair<string, object> item in parametres_update)
            {
                Console.Write(item.Key + " " + item.Value + " || ");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();





            ////BUISNESS LAYER//////////////////////////////////////////////////////////////////////////////////////








            Console.Read();
        }
    }
}
