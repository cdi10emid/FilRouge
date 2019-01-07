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
    /// Class d'accès aux régions
    /// </summary>
   public class AccesRegion
    {
        /// <summary>
        /// Constructeur acces aux régions
        /// </summary>
        public AccesRegion()
        {

        }
        /// <summary>
        /// Méthode qui renvoie la liste des régions
        /// </summary>
        /// <returns></returns>
        public List<Region> listeRegion()
        {
            
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

                SqlCommand objSelect = new SqlCommand();
                objSelect.Connection = cn;
                objSelect.CommandText = "dbo.GetRegion";
                objSelect.CommandType = CommandType.StoredProcedure;

                List<Region> ListeRegion = new List<Region>();

                DataTable objDataset = new DataTable();
                SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

                objDataAdapter.Fill(objDataset);

                foreach (DataRow region in objDataset.Rows)
                {
                    Region Region2 = new Region();


                    Region2.IdRegion = Convert.ToInt32(region["IDREGION"]);
                    Region2.NomRegion = region["NOMREGION"].ToString();
                    ListeRegion.Add(Region2);

                }
                return ListeRegion;
          
        }
    }
}
