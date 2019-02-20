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
        private readonly DataTable objDataset = new DataTable();
        private readonly SqlConnection cn = new SqlConnection
        {
            ConnectionString = "User id=user15;password=218user15;server=176.31.248.137;Trusted_Connection=no;database=user15"
        };
        public async Task<List<Offre>> ListeOffre()
        {
            using (await _sem.LockAsync())
            {
                SqlCommand objSelect = new SqlCommand
                {
                    Connection = cn,
                    CommandText = "dbo.AfficheOffre",
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);
                objDataAdapter.Fill(objDataset);
                return DatasetToList(objDataset);
            }
        }
        public async Task<List<Offre>> ListeOffrebyDate(string DateDebutint, string DateFinint)
        {
            using (await _sem.LockAsync())
            {
                SqlCommand objSelect = new SqlCommand
                {
                    Connection = cn,
                    CommandText = "dbo.AfficheOffreByDate",
                    CommandType = CommandType.StoredProcedure
                };
                objSelect.Parameters.AddWithValue("@DEBUT", DateDebutint.ToString());
                objSelect.Parameters.AddWithValue("@FIN", DateFinint.ToString());

                SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);
                objDataAdapter.Fill(objDataset);
                return DatasetToList(objDataset);
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
                if (IdPosteint == null && IdContratint == null && IdRegionint == null)
                {
                    SqlCommand objSelect = new SqlCommand
                    {
                        Connection = cn,
                        CommandText = "dbo.AfficheOffre",
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);
                    objDataAdapter.Fill(objDataset);
                    CreateListOffre(objDataset);
                }
                else if (IdContratint == null && IdRegionint == null)
                {
                    SqlCommand objSelect = new SqlCommand
                    {
                        Connection = cn,
                        CommandText = "dbo.AfficheOffreByIdPoste",
                        CommandType = CommandType.StoredProcedure
                    };
                    objSelect.Parameters.AddWithValue("@IDPOSTE", IdPosteint);

                    SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);
                    objDataAdapter.Fill(objDataset);
                    CreateListOffre(objDataset);
                }
                else if (IdRegionint == null)
                {
                    SqlCommand objSelect = new SqlCommand
                    {
                        Connection = cn,
                        CommandText = "dbo.AfficheOffreByIdPosteIdContrat",
                        CommandType = CommandType.StoredProcedure
                    };
                    objSelect.Parameters.AddWithValue("@IDPOSTE", IdPosteint);
                    objSelect.Parameters.AddWithValue("@IDCONTRAT", IdContratint);

                    SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);
                    objDataAdapter.Fill(objDataset);
                    CreateListOffre(objDataset);
                }
                else
                {
                    SqlCommand objSelect = new SqlCommand
                    {
                        Connection = cn,
                        CommandText = "dbo.AfficheOffreByIdPosteIdContratIdRegion",
                        CommandType = CommandType.StoredProcedure
                    };
                    objSelect.Parameters.AddWithValue("@IDPOSTE", IdPosteint);
                    objSelect.Parameters.AddWithValue("@IDCONTRAT", IdContratint);
                    objSelect.Parameters.AddWithValue("@IDREGION", IdRegionint);

                    SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);
                    objDataAdapter.Fill(objDataset);
                    CreateListOffre(objDataset);
                }
                return _listeOffre.ToList();
            }
        }
        #region Méthodes privées

        private List<Offre> DatasetToList(DataTable objDataset)
        {
            CreateListOffre(objDataset);
            return _listeOffre.ToList();
        }
        private void CreateListOffre(DataTable objDataset)
        {
            foreach (DataRow offre in objDataset.Rows)
            {
                Offre offre2 = new Offre
                {
                    IdOffre = Convert.ToInt32(offre["IDOFFRE"]),
                    IdPoste = Convert.ToInt32(offre["IDPOSTE"]),
                    IdContrat = Convert.ToInt32(offre["IDCONTRAT"]),
                    IdRegion = Convert.ToInt32(offre["IDREGION"]),
                    IdContact = Convert.ToInt32(offre["IDCONTACT"]),
                    Titre = offre["TITRE"].ToString(),
                    DateParution = Convert.ToDateTime(offre["DATEPARUTION"]),
                    Description = Convert.ToString(offre["DESCRIPTION"]),
                    LienWeb = offre["LIENWEB"].ToString(),
                    NomEntreprise = offre["NOMENTREPRISE"].ToString(),
                    NomContact = offre["NOMCONTACT"].ToString(),
                    TelContact = offre["TELCONTACT"].ToString(),
                    MailContact = offre["MAILCONTACT"].ToString(),
                    TypeContrat = offre["TYPECONTRAT"].ToString(),
                    Nomregion = offre["NOMREGION"].ToString(),
                    TypePoste = offre["TYPEPOSTE"].ToString()
                };
                _listeOffre.Add(offre2);
            }
        }
        #endregion Méthodes privées
    }
}
