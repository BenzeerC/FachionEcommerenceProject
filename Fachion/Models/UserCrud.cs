using System.Data.SqlClient;

namespace Fachion.Models
{
    public class UserCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public UserCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }

        
        public int AddUser(User user)
        {

            int result = 0;
            string qry = "insert into Customer values(@cus_name,@cus_email,@cus_password,@cus_contact,@confirmpassword,@r_id)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cus_name", user.Name);
            cmd.Parameters.AddWithValue("@cus_email", user.Email);
            cmd.Parameters.AddWithValue("@cus_password", user.Password);
            cmd.Parameters.AddWithValue("@cus_contact", user.Phone);
            cmd.Parameters.AddWithValue("@confirmpassword", user.ConfirmPassword);

            cmd.Parameters.AddWithValue("@r_id", user.RoleId);
            //cmd.Parameters.AddWithValue("@cus_id", user.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public User GetUserLogin(string email, string password)
        {
            User user = new User();
            string qry = "select * from Customer where cus_email=@cus_email and cus_password=@cus_password";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cus_email", email);
            cmd.Parameters.AddWithValue("@cus_password", password);
           // cmd.Parameters.AddWithValue("@cus_id", user.Id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    
                    user.Id = Convert.ToInt32(dr["cus_id"]);
                    user.Name = dr["cus_name"].ToString();
                    user.Email = dr["cus_email"].ToString();
                    user.RoleId = Convert.ToInt32(dr["r_id"]);
                }
            }
            con.Close();
            return user;

        }


    }
}