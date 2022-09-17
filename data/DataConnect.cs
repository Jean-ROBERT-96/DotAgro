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
        MainWindow mainWindow;

        public List<ManageFrame> manageFrame { get; set; }

        public DataConnect(string dbName = "dotagro")
        {
            this.dbName = dbName;
            manageFrame = new List<ManageFrame>();
            mainWindow = (MainWindow)Application.Current.MainWindow;
        }

        public void PreInitialization()
        {
            List<Headquarters> headquartersList = new List<Headquarters>();
            List<Services> servicesList = new List<Services>();
            List<Salaryman> salarymanList = new List<Salaryman>();
            List<ProfileFrame> profileFrames = new List<ProfileFrame>();

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
                    salarymanList.Add(new Salaryman(Convert.ToInt32(reader["id_salary"]), Convert.ToString(reader["image_link"]), Convert.ToString(reader["lastName"]), Convert.ToString(reader["firstName"]), Convert.ToChar(reader["gender"]), Convert.ToString(reader["mobile_phone"]), Convert.ToString(reader["mail"]), Convert.ToInt32(reader["id_headquarters"]), Convert.ToInt32(reader["id_services"]), Convert.ToString(reader["phone"])));
                }
                reader.Close();

                connect.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show($"La connexion a échoué : {e.Message}", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            mainWindow.headquartersList = headquartersList;
            mainWindow.servicesList = servicesList;
            mainWindow.salarymanList = salarymanList;
            mainWindow.profileFrames = profileFrames;
        }
        public void PreInitManage(string parametre)
        {
            if (parametre == "headquarters")
            {
                foreach (Headquarters h in mainWindow.headquartersList)
                {
                    manageFrame.Add(new ManageFrame(mainWindow.salarymanList, h));
                }
            }
            else if (parametre == "services")
            {
                foreach (Services s in mainWindow.servicesList)
                {
                    manageFrame.Add(new ManageFrame(mainWindow.salarymanList, s));
                }
            }
        }

        public void DeleteManage(int id, string manage)
        {
            connect = new MySqlConnection($"server={server};database={dbName};uid={user};pwd={password};");
            command = new MySqlCommand($"DELETE FROM {manage} WHERE id_{manage} = '{id}'", connect);

            try
            {
                connect.Open();
                command.Prepare();
                reader = command.ExecuteReader();
                reader.Read();
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show($"La connexion a échoué : {e.Message}", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
