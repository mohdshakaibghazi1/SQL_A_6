using System;
using  System.Data.SqlClient;

namespace ConAppConnectionwithsql
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        static string conStr = "server=HP\\SQLEXPRESS;database=ProductInventoryDb; trusted_connection = true;";
        public static  void Read()
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand("select * from Products", con);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(reader["ProductId"] + "\t");
                    Console.Write(reader["ProductName"] + "\t");
                    Console.Write(reader["Price"] + "\t");
                    Console.Write(reader["Quantity"] + "\t");
                    Console.Write(reader["MfDate"] + "\t");
                    Console.Write(reader["ExpDate"] + "\t");

  
                }
            }
            catch (Exception ex) { Console.WriteLine("Error!!!" + ex.Message); }
            finally
            {
                con.Close();
                Console.ReadKey();

            }

        }
        public static void Delete()
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand()
                {
                    CommandText = "Delete From Products where ProductId=@id",
                    Connection = con
                };
                Console.WriteLine("Enter Product ID to delete");
                cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));

                con.Open();
                int nor = cmd.ExecuteNonQuery();
                if (nor >= 1)
                {
                    Console.WriteLine("Result Deleted");
                }
            }
            catch (Exception ex) { Console.WriteLine("Error!!!" + ex.Message); }
            finally
            {
                con.Close();
                Console.ReadKey();

            }
        }
        public static void Update()
        {
            try
            {
                int id;
                Console.WriteLine("Enter Product Id to Update Details");
                id = int.Parse(Console.ReadLine());
                con = new SqlConnection(conStr);
                cmd = new SqlCommand()
                {
                    CommandText = "select * from Products where ProductId=@id",
                    Connection = con
                };

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    cmd.CommandText = "update Products set ProductName=@pn,Price=@p,Quantity=@Q,MfDate=@mfd,ExpDate=@exp where ProductId=@updateId"; // Change parameter name here
                    Console.WriteLine("Enter New Product Name");
                    cmd.Parameters.AddWithValue("@pn", Console.ReadLine());
                    Console.WriteLine("Enter  New Price");
                    cmd.Parameters.AddWithValue("@p", decimal.Parse(Console.ReadLine()));
                    Console.WriteLine("Enter Product New Quantity");
                    cmd.Parameters.AddWithValue("@Q", int.Parse(Console.ReadLine()));
                    Console.WriteLine("Enter Product New MfDate");
                    cmd.Parameters.AddWithValue("@mfd", Console.ReadLine());
                    Console.WriteLine("Enter Product New ExpDate");
                    cmd.Parameters.AddWithValue("@exp", Console.ReadLine());
                    cmd.Parameters.AddWithValue("@updateId", id); // Change parameter name here
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record Updated");
                }
                else
                {
                    Console.WriteLine($"No Such Id{id} exist in our database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static void Insert()
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand()
                {
                    CommandText = "insert into Products(ProductId,ProductName,Price,Quantity,MfDate,ExpDate)values (@pid,@pname,@p,@q,@mfd,@exp)",
                    Connection = con
                };
                Console.WriteLine("Enter Product ID");
                cmd.Parameters.AddWithValue("@pid", int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter Product Name");
                cmd.Parameters.AddWithValue("@pname", Console.ReadLine());
                Console.WriteLine("Enter Product price");
                cmd.Parameters.AddWithValue("@p", decimal.Parse(Console.ReadLine()));
                Console.WriteLine("Enter Product Quantity ");
                cmd.Parameters.AddWithValue("@q", int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter Product MfDate");
                cmd.Parameters.AddWithValue("@mfd", Console.ReadLine());
                Console.WriteLine("Enter Product EXpDate");
                cmd.Parameters.AddWithValue("@exp", Console.ReadLine());
                con.Open();
                int nor = cmd.ExecuteNonQuery();
                if (nor >= 1)
                {
                    Console.WriteLine("Result inserted");
                }
            }
            catch (Exception ex) { Console.WriteLine("Error!!!" + ex.Message); }
            finally
            {
                con.Close();
                Console.ReadKey();

            }

        }
        public static void Search()
        {
            try
            {
                int id;
                Console.WriteLine("Enter Product ID to delete");
                id = int.Parse(Console.ReadLine());
                con = new SqlConnection(conStr);
                cmd = new SqlCommand()
                {
                    CommandText = "Select * From Products where ProductId=@id",
                    Connection = con
                };

                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine($"Record   Found{id} in our database");
                    while (reader.Read())
                    {
                        Console.Write(reader["ProductId"] + "\t");
                        Console.Write(reader["ProductName"] + "\t");
                        Console.Write(reader["Price"] + "\t");
                        Console.Write(reader["Quantity"] + "\t");
                        Console.Write(reader["MfDate"] + "\t");
                        Console.Write(reader["ExpDate"] + "\t");

                    }
                }
                else
                {
                    Console.WriteLine($"Record  not Found{id} in our database");
                }

            }
            catch (Exception ex) { Console.WriteLine("Error!!!" + ex.Message); }
            finally
            {
                con.Close();
                Console.ReadKey();

            }

        }
        static void Main(string[] args)
        {
            start:

            Console.WriteLine("Press 1 For Read");
            Console.WriteLine("Press 2 For Delete");
            Console.WriteLine("Press 3 For Update");
            Console.WriteLine("Press 4 For Insert");
          int  exp= int.Parse(Console.ReadLine());
            switch (exp)
            {
                case 1:
                    Console.WriteLine("you choose Reading key");
                    Read();
                    Console.WriteLine("Want to perform Operation again press y for yes and n for no");
                    string Key = Console.ReadLine();
                    if (Key == "y")
                    {
                        goto start;
                    }
                    break;

                case 2:
                    Console.WriteLine("you choose Delete key"); 
                    Delete();
                    Console.WriteLine("Want to perform Operation again press y for yes and n for no");
                    string ey = Console.ReadLine();
                    if (ey == "y")
                    {
                        goto start;
                    }
                    break;

                case 3:Console.WriteLine("you choose Update key");
                    Update();
                    Console.WriteLine("Want to perform Operation again press y for yes and n for no");
                    string y = Console.ReadLine();
                    if (y == "y")
                    {
                        goto start;
                    }
                    break;

                case 4:
                    Console.WriteLine("you choose Insert key"); 
                    Insert();
                    Console.WriteLine("Want to perform Operation again press y for yes and n for no");
                    string K = Console.ReadLine();
                    if (K == "y")
                    {
                        goto start;
                    }
                    break;

                case 5: Console.WriteLine("you choose Insert key");
                    Search();
                    Console.WriteLine("Want to perform Operation again press y for yes and n for no");
                    string Ke = Console.ReadLine();
                    if (Ke == "y")
                    {
                        goto start;
                    }
                    break;

                default:
                    Console.WriteLine("invalid key");
                    Console.WriteLine("Want to perform Operation again press y for yes and n for no");
                   string e= Console.ReadLine();
                    if(e == "y")
                    {
                        goto start;
                    }
                        break;
                    

                    

            }
        }
    }
}
