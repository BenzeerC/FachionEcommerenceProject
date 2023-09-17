using System.Data.SqlClient;

namespace Fachion.Models
{
    public class OrderCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public OrderCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }


        public int AddOrder(Order order)
        {

            int result = 0;
            string qry = "insert into Order values(@o_date,@cus_id)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@o_date", order.OrderDate);
            cmd.Parameters.AddWithValue("@cus_id", order.CustomerID);
            
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        
        public int DeleteOrder(Order order)
        {
            int result = 0;
            string qry = "delete order where o_id=@o_id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@o_id", order.OrderID);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
       




    }
}
