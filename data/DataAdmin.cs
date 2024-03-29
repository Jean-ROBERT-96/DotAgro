﻿using DotAgro.entity;
using DotAgro.graphics;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace DotAgro.data
{
    internal class DataAdmin : DataConnect
    {
        public DataAdmin() : base()
        {

        }

        public List<ManageFrame> PreInitManage(string parametre)
        {
            List<ManageFrame> manageFrame = new List<ManageFrame>();

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
            return manageFrame;
        }

        public void DeleteManage(int id, string manage)
        {
            connect = new MySqlConnection($"server={server};database={dbName};uid={user};pwd={password};");
            command = new MySqlCommand($"DELETE FROM {manage} WHERE id_{manage} = '{id}'", connect);
            Read();
        }

        public void EditManage(string type, string name, string newname)
        {
            connect = new MySqlConnection($"server={server};database={dbName};uid={user};pwd={password};");
            command = new MySqlCommand($"UPDATE {type} SET name = '{newname}' WHERE name = '{name}'", connect);
            Read();
        }

        public void AddManage(string type, string name)
        {
            connect = new MySqlConnection($"server={server};database={dbName};uid={user};pwd={password};");
            command = new MySqlCommand($"INSERT INTO {type} (name) VALUES ('{name}');", connect);
            Read();
        }

        public void DeleteSalary(int id)
        {
            connect = new MySqlConnection($"server={server};database={dbName};uid={user};pwd={password};");
            command = new MySqlCommand($"DELETE FROM salaryman WHERE id_salary = '{id}';", connect);
            Read();
        }

        public void EditSalary(int id, string fname, string lname, char gender, string mobilePhone, string mail, int idHead, int idServ, string phone = null)
        {
            connect = new MySqlConnection($"server={server};database={dbName};uid={user};pwd={password};");
            command = new MySqlCommand($"UPDATE salaryman SET image_link = 'http://www.clker.com/cliparts/R/S/Z/4/t/f/crossed-hammers-bw-100x100-md.png', firstName = '{fname}', lastName = '{lname}', gender = '{gender}', phone = '{phone}', mobile_phone = '{mobilePhone}', mail = '{mail}', id_headquarters = {idHead}, id_services = {idServ} WHERE id_salary = {id};", connect);
            Read();
        }

        public void AddSalary(string fname, string lname, char gender, string mobilePhone, string email, int idHead, int idServ, string phone = null)
        {
            connect = new MySqlConnection($"server={server};database={dbName};uid={user};pwd={password};");
            command = new MySqlCommand($"INSERT INTO salaryman (image_link, firstName, lastName, gender, phone, mobile_phone, mail, id_headquarters, id_services) VALUES ('http://www.clker.com/cliparts/R/S/Z/4/t/f/crossed-hammers-bw-100x100-md.png', '{fname}', '{lname}', '{gender}', '{phone}', '{mobilePhone}', '{email}', {idHead}, {idServ});", connect);
            Read();
        }
    }
}
