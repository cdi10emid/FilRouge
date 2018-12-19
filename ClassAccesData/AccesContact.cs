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
        /// <summary>
        /// Méthode de récupération des contacts
        /// </summary>
        /// <returns></returns>
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
                Contact2.TelContact = contact["TELCONTACT"].ToString();
                Contact2.MailContact = contact["MAILCONTACT"].ToString();
                ListeContact.Add(Contact2);

            }
            return ListeContact;
        }
        /// <summary>
        /// méthode de récupération d'un contact par son Id
        /// </summary>
        /// <param name="idContact"></param>
        /// <returns></returns>
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
                Contact Contact = new Contact();
                reader.Read();
                Contact.IdContact = Convert.ToInt32(reader.GetInt32(0));
                Contact.NomEntreprise = Convert.ToString(reader.GetString(1));
                Contact.NomContact = Convert.ToString(reader.GetString(2));
                Contact.TelContact = Convert.ToString(reader.GetString(3));
                Contact.MailContact = Convert.ToString(reader.GetString(4));


                return Contact;
           




        }
        /// <summary>
        /// Méthode d'insertion des contacts dans la base de données
        /// </summary>
        /// <param name="NomEntreprise"></param>
        /// <param name="NomContact"></param>
        /// <param name="TelContact"></param>
        /// <param name="MailContact"></param>
        /// <returns></returns>
        public int InsertContact(string NomEntreprise,string NomContact,string TelContact,string MailContact)
        {
            
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

                SqlCommand objSelect = new SqlCommand();
                objSelect.Connection = cn;
                cn.Open();
                objSelect.CommandText = "dbo.insertContact";
                objSelect.CommandType = CommandType.StoredProcedure;
                objSelect.Parameters.AddWithValue("@NOMENTREPRISE", NomEntreprise);
                objSelect.Parameters.AddWithValue("@NOMCONTACT", NomContact);
                objSelect.Parameters.AddWithValue("@TELCONTACT", TelContact);
                objSelect.Parameters.AddWithValue("@MAILCONTACT", MailContact);
                return objSelect.ExecuteNonQuery();
            

        }
    }
}
