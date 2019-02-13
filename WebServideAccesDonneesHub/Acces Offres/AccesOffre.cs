using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebServideAccesDonneesHub
{
    public class AccesOffre : IAccesOffre
    {
        private List<Offre> _listeOffre = new List<Offre>();
        private readonly AsyncLock _sem = new AsyncLock();
        public async Task<List<Offre>> ListeOffre()
        {
            using (await _sem.LockAsync())
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "User id=user15;password=218user15;server=176.31.248.137;Trusted_Connection=no;database=user15";
                SqlCommand objSelect = new SqlCommand();
                objSelect.Connection = cn;
                objSelect.CommandText = "dbo.AfficheOffre";
                objSelect.CommandType = CommandType.StoredProcedure;


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

                    _listeOffre.Add(offre2);
                }
                return _listeOffre.ToList();
            }
        }
        public async Task<List<Offre>> ListeOffrebyDate(string DateDebutint,string DateFinint)
        {
            using (await _sem.LockAsync())
            {

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "User id=user15;password=218user15;server=176.31.248.137;Trusted_Connection=no;database=user15";

                SqlCommand objSelect = new SqlCommand();
                objSelect.Connection = cn;

                objSelect.CommandText = "dbo.AfficheOffreByDate";
                objSelect.CommandType = CommandType.StoredProcedure;
                objSelect.Parameters.AddWithValue("@DEBUT", DateDebutint.ToString());
                objSelect.Parameters.AddWithValue("@FIN", DateFinint.ToString());



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
                    _listeOffre.Add(offre2);
                }


                return _listeOffre.ToList();
            }
        }
        public async Task<List<Offre>> ListeOffreInject(string IdPoste, string IdContrat, string IdRegion)
        {
            int? IdPosteint;
            int? IdContratint;
            int? IdRegionint;
            
            if (IdPoste != "")
            {
                 IdPosteint = Convert.ToInt32(IdPoste);
            }
            else
            {
                IdPosteint = null;
            }
            if (IdContrat != "")
            {
                IdContratint = Convert.ToInt32(IdContrat);
            }
            else
            {
                IdContratint = null;
            }
            if (IdRegion != "")
            {
                IdRegionint = Convert.ToInt32(IdRegion);
            }
            else
            {
                IdRegionint = null;
            }
       


            
            using (await _sem.LockAsync())
            {
                if (IdPosteint == null && IdContratint == null && IdRegionint == null )
                {

                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = "User id=user15;password=218user15;server=176.31.248.137;Trusted_Connection=no;database=user15";
                    SqlCommand objSelect = new SqlCommand();
                    objSelect.Connection = cn;
                    objSelect.CommandText = "dbo.AfficheOffre";
                    objSelect.CommandType = CommandType.StoredProcedure;


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

                        _listeOffre.Add(offre2);

                    }



                }
                else if (IdContratint == null && IdRegionint == null )
                {

                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = "User id=user15;password=218user15;server=176.31.248.137;Trusted_Connection=no;database=user15";
                    SqlCommand objSelect = new SqlCommand();
                    objSelect.Connection = cn;

                    objSelect.CommandText = "dbo.AfficheOffreByIdPoste";
                    objSelect.CommandType = CommandType.StoredProcedure;
                    objSelect.Parameters.AddWithValue("@IDPOSTE", IdPosteint);



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
                        _listeOffre.Add(offre2);
                    }


                }
                else if (IdRegionint == null )
                {

                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = "User id=user15;password=218user15;server=176.31.248.137;Trusted_Connection=no;database=user15";

                    SqlCommand objSelect = new SqlCommand();
                    objSelect.Connection = cn;
                    objSelect.CommandText = "dbo.AfficheOffreByIdPosteIdContrat";
                    objSelect.CommandType = CommandType.StoredProcedure;
                    objSelect.Parameters.AddWithValue("@IDPOSTE", IdPosteint);
                    objSelect.Parameters.AddWithValue("@IDCONTRAT", IdContratint);



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

                        _listeOffre.Add(offre2);

                    }


                }
                else 
                {

                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = "User id=user15;password=218user15;server=176.31.248.137;Trusted_Connection=no;database=user15";

                    SqlCommand objSelect = new SqlCommand();
                    objSelect.Connection = cn;
                    objSelect.CommandText = "dbo.AfficheOffreByIdPosteIdContratIdRegion";
                    objSelect.CommandType = CommandType.StoredProcedure;
                    objSelect.Parameters.AddWithValue("@IDPOSTE", IdPosteint);
                    objSelect.Parameters.AddWithValue("@IDCONTRAT", IdContratint);
                    objSelect.Parameters.AddWithValue("@IDREGION", IdRegionint);



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

                        _listeOffre.Add(offre2);

                    }


                }
                
                return _listeOffre.ToList();
            }
            

        }
    }
}
