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
   public class AccesContact
    {
        /// <summary>
        /// Constructeur AccesContrat
        /// </summary>
        public AccesContact()
        {

        }
        public List<Contact> ListeContrat()
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

            SqlCommand objSelect = new SqlCommand();
            objSelect.Connection = cn;
            objSelect.CommandText = "dbo.GetContact";
            objSelect.CommandType = CommandType.StoredProcedure;

            List<Contact> ListeContact = new List<Contact>();

            DataTable objDataset = new DataTable();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objSelect);

            objDataAdapter.Fill(objDataset);

            foreach (DataRow contact in objDataset.Rows)
            {
                Contact Contact2 = new Contact();


                Contact2.IdContact = Convert.ToInt32(contact["IDCONTACT"]);
                Contact2.NomEntreprise = contact["NOMENTREPRISE"].ToString();
                Contact2.NomContact = contact["NOMCONTACT"].ToString();
                Contact2.TelContact = Convert.ToInt32(contact["TELCONTACT"]);
                Contact2.MailContact = contact["MAILCONTACT"].ToString();
                ListeContact.Add(Contact2);

            }
            return ListeContact;
        }
    }
}
