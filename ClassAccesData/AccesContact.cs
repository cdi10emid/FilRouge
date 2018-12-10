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
        public List<Contact> ListeContact()
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
        public Contact GetContactByIdContact(int idContact)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

            SqlCommand objSelect = new SqlCommand();
            objSelect.Connection = cn;
            cn.Open();
            objSelect.CommandText = "dbo.GetContactByIdContact";
            objSelect.CommandType = CommandType.StoredProcedure;
            objSelect.Parameters.AddWithValue("@IDCONTACT", idContact);
            SqlDataReader reader = objSelect.ExecuteReader();
            Contact Contact2 = new Contact();
            reader.Read();
                Contact2.IdContact = Convert.ToInt32( reader.GetInt32(0));
                Contact2.NomEntreprise = Convert.ToString( reader.GetString(1));
                Contact2.NomContact = Convert.ToString(reader.GetString(2));
                Contact2.TelContact = Convert.ToInt32(reader.GetInt32(3));
                Contact2.MailContact = Convert.ToString(reader.GetString(4));


            return Contact2;



        }
    }
}
