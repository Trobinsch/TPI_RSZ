using System;
using Model.Exceptions;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Model
{
    public class User
    {
        #region attributs
        private int idUser;
        private string userName;
        #endregion attributs

        #region constructor
        public User(int idUser, string userName)
        {
            this.idUser = idUser;
            this.userName = userName;
        }
        #endregion constructor

        #region accessors and mutators
        public int IdUser
        {
            get { return idUser; }
        }

        public string UserName
        {
            get { return userName; }
        }
        #endregion accessors and mutators
        /// <summary>
        /// this method was created to verify the identity of an user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public bool Login(string userName, string userPassword)
        {
            ApplicationSettings settings = JsonDataSaverReader.ReadAppSettings();
            DbConnector connector = new DbConnector(settings.ConnectionString);
            string loginQuery = "SELECT Hash_password, ID FROM users WHERE Name = '" + userName + "'";

            List<List<object>> queryResult = connector.Select(loginQuery);

            if (queryResult.Count == 1)
            {


                this.userName = userName;
                this.idUser = int.Parse(queryResult[0][1].ToString());
                return true;


            }
            else { return false; }

        }

        public override string ToString()
        {
            return idUser + "";
        }

    }
}