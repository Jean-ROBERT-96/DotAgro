using DotAgro.entity;
using DotAgro.graphics;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DotAgro.data
{
    public class DataConnect
    {
        protected string server = "localhost";
        protected string dbName = "dotagro";
        protected string user = "root";
        protected string password = "";

        protected MySqlConnection connect;
        protected MySqlDataReader reader;
        protected MySqlCommand command;

        public List<Headquarters> headquartersList { get; set; }
        public List<Services> servicesList { get; set; }
        public List<ProfileFrame> profileFrames { get; set; }

        public DataConnect(string dbName = "dotagro")
        {
            this.dbName = dbName;
            headquartersList = new List<Headquarters>();
            servicesList = new List<Services>();
            profileFrames = new List<ProfileFrame>();
        }

        public void PreInitialization()
        {
            connect = new MySqlConnection($"server={server};database={dbName};uid={user};pwd={password};");

            try
            {
                connect.Open();
                command = new MySqlCommand("SELECT * FROM headquarters", connect);
                command.Prepare();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    headquartersList.Add(new Headquarters(Convert.ToInt32(reader["id_headquarters"]), Convert.ToString(reader["name"])));
                }
                reader.Close();

                command = new MySqlCommand("SELECT * FROM services", connect);
                command.Prepare();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    servicesList.Add(new Services(Convert.ToInt32(reader["id_services"]), Convert.ToString(reader["name"])));
                }
                reader.Close();

                command = new MySqlCommand("SELECT * FROM salaryman", connect);
                command.Prepare();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    profileFrames.Add(new ProfileFrame(new Salaryman(Convert.ToInt32(reader["id_salary"]), Convert.ToString(reader["image_link"]), Convert.ToString(reader["lastName"]), Convert.ToString(reader["firstName"]), Convert.ToChar(reader["gender"]), Convert.ToString(reader["mobile_phone"]), Convert.ToString(reader["mail"]), Convert.ToInt32(reader["id_headquarters"]), Convert.ToInt32(reader["id_services"]), Convert.ToString(reader["phone"])), headquartersList, servicesList));
                }
                reader.Close();

                connect.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show($"La connexion a échoué : {e.Message}", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
