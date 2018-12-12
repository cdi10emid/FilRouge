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
   public class AccesOffre
    {
        public AccesOffre()
        {

        }
        public int InsertOffre(int IdPoste, int IdContrat, int IdRegion, int IdContact,string Titre, DateTime DateParution,string Description,string LienWeb)
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
                offre2.Titre = offre["TITRE"].ToString();
                offre2.DateParution =Convert.ToDateTime(offre["DATEPARUTION"]);
                offre2.Description = Convert.ToString( offre["DESCRIPTION"]);
                offre2.LienWeb = offre["LIENWEB"].ToString();
                
                offreRetour.Add(offre2);

            }
            return offreRetour;
        }
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
            offreRetour.Titre = Convert.ToString(reader.GetString(3));
            offreRetour.DateParution = reader.GetDateTime(4);
            offreRetour.Description = Convert.ToString(reader.GetString(5));

            offreRetour.LienWeb = Convert.ToString(reader.GetString(6));
            return offreRetour;
        }
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
    }
}
