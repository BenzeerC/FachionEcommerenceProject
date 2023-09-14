using System.Data.SqlClient;

namespace Fachion.Models
{
    public class ContactCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public ContactCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }
        public IEnumerable<Contact> GetMessahge()
        {
            List<Contact> contacts = new List<Contact>();
            string qry = "Select * from Contact ";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Contact c = new Contact();
                    
                    c.Phone= dr["contact"].ToString();
                    c.Email = dr["email"].ToString();
                    c.Message= dr["message"].ToString();
                    
                    contacts.Add(c);
                }
            }
            con.Close();
            return contacts;
        }
        public int AddMessage(Contact contact)
        {

            int result = 0;
            string qry = "insert into Contact values(@contact,@email,@message)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@contact", contact.Phone);
            cmd.Parameters.AddWithValue("@email", contact.Email);
            cmd.Parameters.AddWithValue("@message", contact.Message);
            
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
