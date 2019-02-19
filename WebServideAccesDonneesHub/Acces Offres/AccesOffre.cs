﻿using System;
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
                SqlConnection cn = new SqlConnection
                {
                    ConnectionString = "User id=user15;password=218user15;server=176.31.248.137;Trusted_Connection=no;database=user15"
                };
                SqlCommand objSelect = new SqlCommand
                {
                    Connection = cn,
                    CommandText = "dbo.AfficheOffre",
                    CommandType = CommandType.StoredProcedure
                };


                DataTable objDataset = new DataTable();
                SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

                objDataAdapter.Fill(objDataset);

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
                return _listeOffre.ToList();
            }
        }
        public async Task<List<Offre>> ListeOffrebyDate(string DateDebutint,string DateFinint)
        {
            using (await _sem.LockAsync())
            {

                SqlConnection cn = new SqlConnection
                {
                    ConnectionString = "User id=user15;password=218user15;server=176.31.248.137;Trusted_Connection=no;database=user15"
                };

                new SqlCommand
                {
                    Connection = cn,

                    CommandText = "dbo.AfficheOffreByDate",
                    CommandType = CommandType.StoredProcedure
                }.Parameters.AddWithValue("@DEBUT", DateDebutint.ToString());
                new SqlCommand
                {
                    Connection = cn,

                    CommandText = "dbo.AfficheOffreByDate",
                    CommandType = CommandType.StoredProcedure
                }.Parameters.AddWithValue("@FIN", DateFinint.ToString());



                DataTable objDataset = new DataTable();
                SqlDataAdapter objDataAdapter = new SqlDataAdapter(new SqlCommand
                {
                    Connection = cn,

                    CommandText = "dbo.AfficheOffreByDate",
                    CommandType = CommandType.StoredProcedure
                });

                objDataAdapter.Fill(objDataset);

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

                    SqlConnection cn = new SqlConnection
                    {
                        ConnectionString = "User id=user15;password=218user15;server=176.31.248.137;Trusted_Connection=no;database=user15"
                    };
                    SqlCommand objSelect = new SqlCommand
                    {
                        Connection = cn,
                        CommandText = "dbo.AfficheOffre",
                        CommandType = CommandType.StoredProcedure
                    };


                    DataTable objDataset = new DataTable();
                    SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

                    objDataAdapter.Fill(objDataset);

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
                else if (IdContratint == null && IdRegionint == null )
                {

                    SqlConnection cn = new SqlConnection
                    {
                        ConnectionString = "User id=user15;password=218user15;server=176.31.248.137;Trusted_Connection=no;database=user15"
                    };
                    SqlCommand objSelect = new SqlCommand
                    {
                        Connection = cn,

                        CommandText = "dbo.AfficheOffreByIdPoste",
                        CommandType = CommandType.StoredProcedure
                    };
                    objSelect.Parameters.AddWithValue("@IDPOSTE", IdPosteint);



                    DataTable objDataset = new DataTable();
                    SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

                    objDataAdapter.Fill(objDataset);

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
                else if (IdRegionint == null )
                {

                    SqlConnection cn = new SqlConnection
                    {
                        ConnectionString = "User id=user15;password=218user15;server=176.31.248.137;Trusted_Connection=no;database=user15"
                    };

                    SqlCommand objSelect = new SqlCommand
                    {
                        Connection = cn,
                        CommandText = "dbo.AfficheOffreByIdPosteIdContrat",
                        CommandType = CommandType.StoredProcedure
                    };
                    objSelect.Parameters.AddWithValue("@IDPOSTE", IdPosteint);
                    objSelect.Parameters.AddWithValue("@IDCONTRAT", IdContratint);



                    DataTable objDataset = new DataTable();
                    SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

                    objDataAdapter.Fill(objDataset);

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
                else 
                {

                    SqlConnection cn = new SqlConnection
                    {
                        ConnectionString = "User id=user15;password=218user15;server=176.31.248.137;Trusted_Connection=no;database=user15"
                    };

                    SqlCommand objSelect = new SqlCommand
                    {
                        Connection = cn,
                        CommandText = "dbo.AfficheOffreByIdPosteIdContratIdRegion",
                        CommandType = CommandType.StoredProcedure
                    };
                    objSelect.Parameters.AddWithValue("@IDPOSTE", IdPosteint);
                    objSelect.Parameters.AddWithValue("@IDCONTRAT", IdContratint);
                    objSelect.Parameters.AddWithValue("@IDREGION", IdRegionint);



                    DataTable objDataset = new DataTable();
                    SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

                    objDataAdapter.Fill(objDataset);

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
                
                return _listeOffre.ToList();
            }
            

        }
    }
}
