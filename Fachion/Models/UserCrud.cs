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

        public IEnumerable<User> GetUsers()
        {
            List<User> list = new List<User>();
            string qry = "Select * from Customer ";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    User u = new User();
                    u.Id = Convert.ToInt32(dr["cus_id"]);
                    u.Name = dr["cus_name"].ToString();
                    u.Email = dr["cus_email"].ToString();
                    u.Password = dr["cus_password"].ToString();
                    u.ConfirmPassword = dr["confirmpassword"].ToString();
                    u.RoleId = Convert.ToInt32(dr["r_id"]);
                    list.Add(u);
                }
            }
            con.Close();
            return list;
        }

        public User GetUserById(int id)
        {
            User u = new User();
            string qry = "select * from Customer where cus_id=@cus_id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cus_id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    u.Id = Convert.ToInt32(dr["cus_id"]);
                    u.Name = dr["cus_name"].ToString();
                    u.Email = dr["cus_email"].ToString();
                    u.Password = dr["cus_password"].ToString();
                    u.ConfirmPassword = dr["confirmpassword"].ToString();
                    u.RoleId = Convert.ToInt32(dr["r_id"]);

                }
            }
            con.Close();
            return u;
        }
        public int AddUser(User user)
        {
            
            int result = 0;
            string qry = "insert into Customer values(@cus_name,@cus_email,@cus_password,@confirmpassword,@cus_contact,@r_id)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cus_name", user.Name);
            cmd.Parameters.AddWithValue("@cus_email", user.Email);
            cmd.Parameters.AddWithValue("@cus_password", user.Password);
            cmd.Parameters.AddWithValue("@confirmpassword", user.ConfirmPassword);
            cmd.Parameters.AddWithValue("@cus_contact", user.Phone);
            cmd.Parameters.AddWithValue("@r_id", user.RoleId);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public User GetUserLogin(string email,string password)
        {
            User user=new User();
            string qry = "select * from Customer where cus_email=@cus_email and cus_password=@cus_password";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cus_email", email);
            cmd.Parameters.AddWithValue ("@cus_password", password);
            con.Open();
            dr=cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
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
        public int UpdateUser(User user)
        {
           

            int result = 0;
            string qry = "update Customer set cus_name=@cus_name,cus_email=@cus_email," +
                "cus_password=@cus_password,confirmpassword=@confirmpassword,cus_contact=@cus_contact,r_id=@r_id where roll=@roll";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cus_name", user.Name);
            cmd.Parameters.AddWithValue("@cus_email", user.Email);
            cmd.Parameters.AddWithValue("@cus_password", user.Password);
            cmd.Parameters.AddWithValue("@confirmpassword", user.ConfirmPassword);
            cmd.Parameters.AddWithValue("@cus_contact", user.Phone);
            cmd.Parameters.AddWithValue("@r_id", user.RoleId);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteUser(int id)
        {
            int result = 0;
            string qry = "Delete Customer where cus_id=@cus_id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cus_id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
   