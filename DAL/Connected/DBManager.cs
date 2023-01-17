namespace DAL.Connected;

using BOL;
using MySql.Data.MySqlClient;


public class DBManager
{

    public static string conString = @"Server=localhost;
                                        port=3306;
                                        user=root;
                                        password=root123;
                                        database=yoninjas";


    public static List<Trainer> GetAllTrainers()
    {
        List<Trainer> allTrainer = new List<Trainer>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            con.Open();


            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            string query = "select * from Trainer";
            cmd.CommandText = query;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["Id"].ToString());
                string name = reader["Name"].ToString();
                string address = reader["Address"].ToString();
                string email = reader["Email"].ToString();
                string password = reader["Password"].ToString();

                Trainer trainers = new Trainer
                {
                    Id = id,
                    Name = name,
                    Address = address,
                    Email = email,
                    Password = password
                };
                allTrainer.Add(trainers);
            }

        }
        catch (Exception ee)
        {
            Console.WriteLine(ee.Message);
        }
        finally
        {
            con.Close();
        }
        return allTrainer;
    }

    public static bool AddTrainer(Trainer trainer)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            con.Open();
            string query = " insert into Trainer value('" + trainer.Id + "','" + trainer.Name + "','" + trainer.Address + "','" + trainer.Email + "','" + trainer.Password + "');";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            status = true;
        }
        catch (Exception ee)
        {
            Console.WriteLine(ee.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public static bool DeleteTrainer(int id)
    {
        bool status = false;
        Trainer trainer = new Trainer();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            con.Open();
            string query = "delete from Trainer where Id=" + id;
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            status = true;
        }
        catch (Exception ee)
        {
            Console.WriteLine(ee.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public static bool UpdateTrainer(Trainer trainer)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;

        try
        {
            con.Open();
            string query = "Update Table Trainer set Name = '" + trainer.Name + "', Address = '" + trainer.Address + "',Email = '" + trainer.Email + ", where id= " + trainer.Id;
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            status = true;
        }
        catch (Exception ee)
        {
            Console.WriteLine(ee.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public static Trainer SearchTrainer(string email, string password)
    {

        Trainer trainer = new Trainer();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString=conString;
        try{
            con.Open();
            string query="select from Trainer where Email='"+email+"'and password='"+password;
            MySqlCommand cmd = new MySqlCommand(query,con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()){
            int id=int.Parse(reader["Id"].ToString());
            string name= reader["Name"].ToString();
            string address = reader["Address"].ToString();
             email = reader["Email"].ToString();
            password = reader["Password"].ToString();
            trainer =new Trainer{
                Id=id,
                Name=name,
                Email=email,
                Password=password
            };
            }
        }
        catch(Exception ee){
            Console.WriteLine(ee.Message);
        }
        finally{
            con.Close();
        }
        return trainer;
    }

}