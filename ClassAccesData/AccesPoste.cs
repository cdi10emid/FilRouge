﻿using System;
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
    /// Class d'accès aux postes
    /// </summary>
    public class AccesPoste
    {
        /// <summary>
        /// Constructeur Acces au Poste
        /// </summary>
        public AccesPoste()
        {

        }
        /// <summary>
        /// Méthode retournant la liste des postes
        /// </summary>
        /// <returns></returns>
        public List<Poste> listePoste()
        {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
                cn.Open();
                SqlCommand objSelect = new SqlCommand();
                objSelect.Connection = cn;
                objSelect.CommandText = "dbo.GetPoste";
                objSelect.CommandType = CommandType.StoredProcedure;

                List<Poste> ListePoste = new List<Poste>();

                DataTable objDataset = new DataTable();
                SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

                objDataAdapter.Fill(objDataset);

                foreach (DataRow poste in objDataset.Rows)
                {
                    Poste Poste2 = new Poste();
                    Poste2.Idposte = Convert.ToInt32(poste["IDPOSTE"]);
                    Poste2.TypePoste = poste["TYPEPOSTE"].ToString();
                    ListePoste.Add(Poste2);
                }
                return ListePoste;
          
        }
        /// <summary>
        /// Méthode de rajout d'un poste
        /// </summary>
        /// <param name="TypePoste"></param>
        /// <returns></returns>
        public int ajoutPoste(string TypePoste)
        {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
                cn.Open();
                SqlCommand objSelect = new SqlCommand();
                objSelect.Connection = cn;
                objSelect.CommandText = "dbo.InsertPoste";
                objSelect.CommandType = CommandType.StoredProcedure;
                objSelect.Parameters.AddWithValue("@TYPEPOSTE", TypePoste);
                return objSelect.ExecuteNonQuery();
        }
    }
}
