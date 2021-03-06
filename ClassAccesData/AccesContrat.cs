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
    /// Class d'accès aux contrats
    /// </summary>
    public class AccesContrat
    {
        /// <summary>
        /// Constructeur AccesContrat
        /// </summary>
        public AccesContrat()
        {

        }
        /// <summary>
        /// Méthode qui retourne la liste des contrats
        /// </summary>
        /// <returns></returns>
        public List<Contrat> ListeContrat()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
            SqlCommand objSelect = new SqlCommand();
            objSelect.Connection = cn;
            objSelect.CommandText = "dbo.GetContrat";
            objSelect.CommandType = CommandType.StoredProcedure;

            List<Contrat> ListeContrat = new List<Contrat>();

            DataTable objDataset = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

            objDataAdapter.Fill(objDataset);

            foreach (DataRow contrat in objDataset.Rows)
            {
                Contrat Contrat2 = new Contrat();
                Contrat2.IdContrat = Convert.ToInt32(contrat["IDCONTRAT"]);
                Contrat2.TypeContrat = contrat["TYPECONTRAT"].ToString();
                ListeContrat.Add(Contrat2);
            }
            return ListeContrat;
        }
        /// <summary>
        /// Méthode d'ajaut d'un nouveau contrat dans la base de données
        /// </summary>
        /// <param name="TypeContrat"></param>
        /// <returns></returns>
        public int ajoutContrat(string TypeContrat)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
            cn.Open();
            SqlCommand objSelect = new SqlCommand();
            objSelect.Connection = cn;
            objSelect.CommandText = "dbo.InsertContrat";
            objSelect.CommandType = CommandType.StoredProcedure;
            objSelect.Parameters.AddWithValue("@TYPECONTRAT", TypeContrat);
            return objSelect.ExecuteNonQuery();
        }
    }
}
