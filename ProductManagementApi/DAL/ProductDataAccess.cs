namespace ProductManagementApi.DAL;

using ProductManagementApi.Model;
using System.Data;
using MySql.Data.MySqlClient;


public class ProductsDataAccess{
     public static string conString = @"server=localhost; port=3306; user=root; password=Tushar123; database=product";
     public static List<Product> GetAllProducts(){
         List<Product> allNotes = new List<Product>();
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            string query = "select * from products";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                Product product = new Product
                {
                    productid = int.Parse(row["productid"].ToString()),
                    productname = row["productname"].ToString(),
                    productqty = row["productqty"].ToString(),
                    price = row["price"].ToString()
                };
                allNotes.Add(product);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return allNotes;
    }

    public static Product GetProductById(int id)
    {
        Product product = null;
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = "select * from users where productid=" + id;
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                product = new Product
                {
                    productid = int.Parse(reader["productid"].ToString()),
                    productname = reader["productname"].ToString(),
                    productqty = reader["productqty"].ToString(),
                    price = reader["price"].ToString()
                };
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return product;
    }

    public static void SaveNewProduct(Product product)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = $"insert into products(productname, productqty, price) values('{product.productname}', '{product.productqty}', '{product.price}')";
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static void DeleteProductById(int id)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = "delete from products where id =" + id;
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

}

     