using System.Data.SqlClient;

namespace Fachion.Models
{
    public class CartCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public CartCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }

        public int AddToCart(Cart cart)
        {
            int result = 0;
            string qry = "insert into Cart values (@cus_id,@id,@qty)";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cus_id", cart.CusId);
            cmd.Parameters.AddWithValue("@id", cart.Id);
            cmd.Parameters.AddWithValue("@qty", cart.Qty);
            con.Open();
            result=cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }

        public List<Product> ViewCart(int CusId)
        {
           
                List<Product> list = new List<Product>();
                string qry = "select p.* , c.qty ,c.cart_id ,c.cus_id from Product p join Cart c on c.id=p.id where c.cus_id=@cus_id";

                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@cus_id", CusId);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Product product = new Product();
                        product.Id = Convert.ToInt32(dr["id"]);
                        product.Name = dr["name"].ToString();
                        product.Price = Convert.ToDouble(dr["price"]);
                        product.Imageurl = dr["imageurl"].ToString();
                        product.Cid = Convert.ToInt32(dr["cid"]);
                        product.Qty = Convert.ToInt32(dr["qty"]);
                        product.CartId = Convert.ToInt32(dr["cart_id"]);
                        list.Add(product);
                    }
                }
                con.Close();
                return list;
            
        }

        public int DeleteCart(int CartId)
        {
            int result = 0;
            string qry = "delete from Cart where cart_id=@cart_id";
            cmd.Parameters.AddWithValue("@cart_id", CartId);
            con.Open();
            result=cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }










    }
}
