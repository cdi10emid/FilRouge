using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassMetier;

namespace ClassAccesData
{
    /// <summary>
    /// Classe d'accès aux données offre
    /// </summary>
    public class AccesOffre
    {
        /// <summary>
        /// Constructeur AccesOffre
        /// </summary>
        public AccesOffre()
        {

        }
        /// <summary>
        /// Méthode d'insertion d'une nouvelle offre dans la base de données
        /// </summary>
        /// <param name="IdPoste"></param>
        /// <param name="IdContrat"></param>
        /// <param name="IdRegion"></param>
        /// <param name="IdContact"></param>
        /// <param name="Titre"></param>
        /// <param name="DateParution"></param>
        /// <param name="Description"></param>
        /// <param name="LienWeb"></param>
        /// <returns></returns>
        public int InsertOffre(int IdPoste, int IdContrat, int IdRegion, int IdContact, string Titre, DateTime DateParution, string Description, string LienWeb)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

            SqlCommand objSelect = new SqlCommand();
            objSelect.Connection = cn;
            cn.Open();
            objSelect.CommandText = "dbo.InsertOffre";
            objSelect.CommandType = CommandType.StoredProcedure;
            objSelect.Parameters.AddWithValue("@IDPOSTE", IdPoste);
            objSelect.Parameters.AddWithValue("@IDCONTRAT", IdContrat);
            objSelect.Parameters.AddWithValue("@IDREGION", IdRegion);
            objSelect.Parameters.AddWithValue("@IDCONTACT", IdContact);
            objSelect.Parameters.AddWithValue("@TITRE", Titre);
            objSelect.Parameters.AddWithValue("@DATEPARUTION", DateParution);
            objSelect.Parameters.AddWithValue("@DESCRIPTION", Description);
            objSelect.Parameters.AddWithValue("@LIENWEB", LienWeb);
            return objSelect.ExecuteNonQuery();

        }
        /// <summary>
        /// Méthode de récupération de la liste des offres
        /// </summary>
        /// <returns></returns>
        public List<Offre> AfficheOffre()
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

            SqlCommand objSelect = new SqlCommand();
            objSelect.Connection = cn;
            objSelect.CommandText = "dbo.AfficheOffre";
            objSelect.CommandType = CommandType.StoredProcedure;

            List<Offre> offreRetour = new List<Offre>();

            DataTable objDataset = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

            objDataAdapter.Fill(objDataset);

            foreach (DataRow offre in objDataset.Rows)
            {

                Offre offre2 = new Offre();

                offre2.IdOffre = Convert.ToInt32(offre["IDOFFRE"]);
                offre2.IdPoste = Convert.ToInt32(offre["IDPOSTE"]);
                offre2.IdContrat = Convert.ToInt32(offre["IDCONTRAT"]);
                offre2.IdRegion = Convert.ToInt32(offre["IDREGION"]);
                offre2.IdContact = Convert.ToInt32(offre["IDCONTACT"]);
                offre2.Titre = offre["TITRE"].ToString();
                offre2.DateParution = Convert.ToDateTime(offre["DATEPARUTION"]);
                offre2.Description = Convert.ToString(offre["DESCRIPTION"]);
                offre2.LienWeb = offre["LIENWEB"].ToString();
                offre2.NomEntreprise = offre["NOMENTREPRISE"].ToString();
                offre2.NomContact = offre["NOMCONTACT"].ToString();
                offre2.TelContact = offre["TELCONTACT"].ToString();
                offre2.MailContact = offre["MAILCONTACT"].ToString();
                offre2.TypeContrat = offre["TYPECONTRAT"].ToString();
                offre2.Nomregion = offre["NOMREGION"].ToString();
                offre2.TypePoste = offre["TYPEPOSTE"].ToString();

                offreRetour.Add(offre2);

            }
            return offreRetour;

        }
        /// <summary>
        /// Méthode de récupération de la liste des offres selon Idposte
        /// </summary>
        /// <returns></returns>
        public List<Offre> AfficheOffreByIdPoste(int IdPoste)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

            SqlCommand objSelect = new SqlCommand();
            objSelect.Connection = cn;
           // cn.Open();
            objSelect.CommandText = "dbo.AfficheOffreByIdPoste";
            objSelect.CommandType = CommandType.StoredProcedure;
            objSelect.Parameters.AddWithValue("@IDPOSTE", IdPoste);
            
            List<Offre> offreRetour = new List<Offre>();

            DataTable objDataset = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

            objDataAdapter.Fill(objDataset);

            foreach (DataRow offre in objDataset.Rows)
            {

                Offre offre2 = new Offre();

                offre2.IdOffre = Convert.ToInt32(offre["IDOFFRE"]);
                offre2.IdPoste = Convert.ToInt32(offre["IDPOSTE"]);
                offre2.IdContrat = Convert.ToInt32(offre["IDCONTRAT"]);
                offre2.IdRegion = Convert.ToInt32(offre["IDREGION"]);
                offre2.IdContact = Convert.ToInt32(offre["IDCONTACT"]);
                offre2.Titre = offre["TITRE"].ToString();
                offre2.DateParution = Convert.ToDateTime(offre["DATEPARUTION"]);
                offre2.Description = Convert.ToString(offre["DESCRIPTION"]);
                offre2.LienWeb = offre["LIENWEB"].ToString();
                offre2.NomEntreprise = offre["NOMENTREPRISE"].ToString();
                offre2.NomContact = offre["NOMCONTACT"].ToString();
                offre2.TelContact = offre["TELCONTACT"].ToString();
                offre2.MailContact = offre["MAILCONTACT"].ToString();
                offre2.TypeContrat = offre["TYPECONTRAT"].ToString();
                offre2.Nomregion = offre["NOMREGION"].ToString();
                offre2.TypePoste = offre["TYPEPOSTE"].ToString();

                offreRetour.Add(offre2);

            }
            return offreRetour;

        }
        /// <summary>
        /// Méthode de récupération de la liste des offres selon IdPoste et IdContrat
        /// </summary>
        /// <returns></returns>
        public List<Offre> AfficheOffreByIdPosteIdContrat(int IdPoste, int IdContrat)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

            SqlCommand objSelect = new SqlCommand();
            objSelect.Connection = cn;
            objSelect.CommandText = "dbo.AfficheOffreByIdPosteIdContrat";
            objSelect.CommandType = CommandType.StoredProcedure;
            objSelect.Parameters.AddWithValue("@IDPOSTE", IdPoste);
            objSelect.Parameters.AddWithValue("@IDCONTRAT", IdContrat);

            List<Offre> offreRetour = new List<Offre>();

            DataTable objDataset = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

            objDataAdapter.Fill(objDataset);

            foreach (DataRow offre in objDataset.Rows)
            {

                Offre offre2 = new Offre();

                offre2.IdOffre = Convert.ToInt32(offre["IDOFFRE"]);
                offre2.IdPoste = Convert.ToInt32(offre["IDPOSTE"]);
                offre2.IdContrat = Convert.ToInt32(offre["IDCONTRAT"]);
                offre2.IdRegion = Convert.ToInt32(offre["IDREGION"]);
                offre2.IdContact = Convert.ToInt32(offre["IDCONTACT"]);
                offre2.Titre = offre["TITRE"].ToString();
                offre2.DateParution = Convert.ToDateTime(offre["DATEPARUTION"]);
                offre2.Description = Convert.ToString(offre["DESCRIPTION"]);
                offre2.LienWeb = offre["LIENWEB"].ToString();
                offre2.NomEntreprise = offre["NOMENTREPRISE"].ToString();
                offre2.NomContact = offre["NOMCONTACT"].ToString();
                offre2.TelContact = offre["TELCONTACT"].ToString();
                offre2.MailContact = offre["MAILCONTACT"].ToString();
                offre2.TypeContrat = offre["TYPECONTRAT"].ToString();
                offre2.Nomregion = offre["NOMREGION"].ToString();
                offre2.TypePoste = offre["TYPEPOSTE"].ToString();

                offreRetour.Add(offre2);

            }
            return offreRetour;

        }
        /// <summary>
        /// Méthode de récupération de la liste des offres selon IdPoste et IdContrat
        /// </summary>
        /// <returns></returns>
        public List<Offre> AfficheOffreByIdPosteIdContratIdRegion(int IdPoste, int IdContrat, int IdRegion)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

            SqlCommand objSelect = new SqlCommand();
            objSelect.Connection = cn;
            objSelect.CommandText = "dbo.AfficheOffreByIdPosteIdContratIdRegion";
            objSelect.CommandType = CommandType.StoredProcedure;
            objSelect.Parameters.AddWithValue("@IDPOSTE", IdPoste);
            objSelect.Parameters.AddWithValue("@IDCONTRAT", IdContrat);
            objSelect.Parameters.AddWithValue("@IDREGION", IdRegion);

            List<Offre> offreRetour = new List<Offre>();

            DataTable objDataset = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

            objDataAdapter.Fill(objDataset);

            foreach (DataRow offre in objDataset.Rows)
            {

                Offre offre2 = new Offre();

                offre2.IdOffre = Convert.ToInt32(offre["IDOFFRE"]);
                offre2.IdPoste = Convert.ToInt32(offre["IDPOSTE"]);
                offre2.IdContrat = Convert.ToInt32(offre["IDCONTRAT"]);
                offre2.IdRegion = Convert.ToInt32(offre["IDREGION"]);
                offre2.IdContact = Convert.ToInt32(offre["IDCONTACT"]);
                offre2.Titre = offre["TITRE"].ToString();
                offre2.DateParution = Convert.ToDateTime(offre["DATEPARUTION"]);
                offre2.Description = Convert.ToString(offre["DESCRIPTION"]);
                offre2.LienWeb = offre["LIENWEB"].ToString();
                offre2.NomEntreprise = offre["NOMENTREPRISE"].ToString();
                offre2.NomContact = offre["NOMCONTACT"].ToString();
                offre2.TelContact = offre["TELCONTACT"].ToString();
                offre2.MailContact = offre["MAILCONTACT"].ToString();
                offre2.TypeContrat = offre["TYPECONTRAT"].ToString();
                offre2.Nomregion = offre["NOMREGION"].ToString();
                offre2.TypePoste = offre["TYPEPOSTE"].ToString();

                offreRetour.Add(offre2);

            }
            return offreRetour;

        }
        /// <summary>
        /// Méthode de récupération d'une offre par son Id
        /// </summary>
        /// <param name="IdOffre"></param>
        /// <returns></returns>
        public Offre GetOffreByidoffre(int IdOffre)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

            SqlCommand objSelect = new SqlCommand();
            objSelect.Connection = cn;
            cn.Open();
            objSelect.CommandText = "dbo.GetOffreByIdoffre";
            objSelect.CommandType = CommandType.StoredProcedure;
            objSelect.Parameters.AddWithValue("@IDOFFRE", IdOffre);
            SqlDataReader reader = objSelect.ExecuteReader();
            Offre offreRetour = new Offre();
            reader.Read();

            offreRetour.IdOffre = Convert.ToInt32(reader.GetInt32(0));
            offreRetour.IdPoste = Convert.ToInt32(reader.GetInt32(1));
            offreRetour.IdContact = Convert.ToInt32(reader.GetInt32(2));
            offreRetour.IdContrat = Convert.ToInt32(reader.GetInt32(3));
            offreRetour.IdRegion = Convert.ToInt32(reader.GetInt32(4));
            offreRetour.Titre = Convert.ToString(reader.GetString(5));
            offreRetour.DateParution = reader.GetDateTime(6);
            offreRetour.Description = Convert.ToString(reader.GetString(7));

            offreRetour.LienWeb = Convert.ToString(reader.GetString(8));
            return offreRetour;

        }
        /// <summary>
        /// Méthode de suppression d'une offre par son Id
        /// </summary>
        /// <param name="idOffre"></param>
        /// <returns></returns>
        public int SuprimOffre(int idOffre)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
            cn.Open();
            SqlCommand objSelect = new SqlCommand();
            objSelect.Connection = cn;
            objSelect.CommandText = "dbo.DeleteOffre";
            objSelect.CommandType = CommandType.StoredProcedure;
            objSelect.Parameters.AddWithValue("@IDOFFRE", idOffre);

            return objSelect.ExecuteNonQuery();


        }
        /// <summary>
        /// Méthode pour updater une offre
        /// </summary>
        /// <param name="IdOffre"></param>
        /// <param name="IdPoste"></param>
        /// <param name="IdContrat"></param>
        /// <param name="IdRegion"></param>
        /// <param name="IdContact"></param>
        /// <param name="Titre"></param>
        /// <param name="DateParution"></param>
        /// <param name="Description"></param>
        /// <param name="LienWeb"></param>
        /// <param name="NomContact"></param>
        /// <param name="TelContact"></param>
        /// <param name="MailContact"></param>
        /// <returns></returns>
        public int UpdatetOffre(int IdOffre, int IdPoste, int IdContrat, int IdRegion, int IdContact, string Titre,
            DateTime DateParution, string Description, string LienWeb, string NomContact, string TelContact, string MailContact)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

            SqlCommand objSelect = new SqlCommand();
            objSelect.Connection = cn;
            cn.Open();
            objSelect.CommandText = "dbo.UpdateOffre";
            objSelect.CommandType = CommandType.StoredProcedure;
            objSelect.Parameters.AddWithValue("@IDOFFRE", IdOffre);
            objSelect.Parameters.AddWithValue("@IDPOSTE", IdPoste);
            objSelect.Parameters.AddWithValue("@IDCONTRAT", IdContrat);
            objSelect.Parameters.AddWithValue("@IDREGION", IdRegion);
            objSelect.Parameters.AddWithValue("@IDCONTACT", IdContact);
            objSelect.Parameters.AddWithValue("@TITRE", Titre);
            objSelect.Parameters.AddWithValue("@DATEPARUTION", DateParution);
            objSelect.Parameters.AddWithValue("@DESCRIPTION", Description);
            objSelect.Parameters.AddWithValue("@LIENWEB", LienWeb);
            objSelect.Parameters.AddWithValue("@NOMCONTACT", NomContact);
            objSelect.Parameters.AddWithValue("@TELCONTACT", TelContact);
            objSelect.Parameters.AddWithValue("@MAILCONTACT", MailContact);
            return objSelect.ExecuteNonQuery();


        }
        //public List<Offre> AfficheOffreByDate(string DateDebut, string DateFin)
        //{

        //    SqlConnection cn = new SqlConnection();
        //    cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

        //    SqlCommand objSelect = new SqlCommand();
        //    objSelect.Connection = cn;
        //    objSelect.CommandText = "dbo.AfficheOffreByDate";
        //    objSelect.CommandType = CommandType.StoredProcedure;
        //    objSelect.Parameters.AddWithValue("@DATEDEBUT", DateDebut.ToString());
        //    objSelect.Parameters.AddWithValue("@DATEFIN", DateFin.ToString());
        //    List<Offre> offreRetour = new List<Offre>();

        //    DataTable objDataset = new DataTable();
        //    SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

        //    objDataAdapter.Fill(objDataset);

        //    foreach (DataRow offre in objDataset.Rows)
        //    {

        //        Offre offre2 = new Offre();

        //        offre2.IdOffre = Convert.ToInt32(offre["IDOFFRE"]);
        //        offre2.IdPoste = Convert.ToInt32(offre["IDPOSTE"]);
        //        offre2.IdContrat = Convert.ToInt32(offre["IDCONTRAT"]);
        //        offre2.IdRegion = Convert.ToInt32(offre["IDREGION"]);
        //        offre2.IdContact = Convert.ToInt32(offre["IDCONTACT"]);
        //        offre2.Titre = offre["TITRE"].ToString();
        //        offre2.DateParution = Convert.ToDateTime(offre["DATEPARUTION"]);
        //        offre2.Description = Convert.ToString(offre["DESCRIPTION"]);
        //        offre2.LienWeb = offre["LIENWEB"].ToString();
        //        offre2.NomEntreprise = offre["NOMENTREPRISE"].ToString();
        //        offre2.NomContact = offre["NOMCONTACT"].ToString();
        //        offre2.TelContact = offre["TELCONTACT"].ToString();
        //        offre2.MailContact = offre["MAILCONTACT"].ToString();
        //        offre2.TypeContrat = offre["TYPECONTRAT"].ToString();
        //        offre2.Nomregion = offre["NOMREGION"].ToString();
        //        offre2.TypePoste = offre["TYPEPOSTE"].ToString();

        //        offreRetour.Add(offre2);

        //    }
        //    return offreRetour;

        //}
    }
}
