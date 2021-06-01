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
        private string password;
        #endregion attributs

        #region constructor
        public User(int idUser, string userName, string password)
        {
            this.idUser = idUser;
            this.userName = userName;
            this.password = password;
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
            string loginQuery = "SELECT HashPassword, ID FROM users WHERE Name = '" + userName + "'";

            List<List<object>> queryResult = connector.Select(loginQuery);

            if (queryResult.Count == 1)
            {
                List<object> row = queryResult[0];
                string userHashPsw = row[0].ToString();
                string hashedInputPsw = this.Hash(userPassword);
                
                if (hashedInputPsw == userHashPsw)
                {

                    this.userName = userName;
                    this.idUser = int.Parse(queryResult[0][1].ToString());
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else { return false; }

        }
        /// <summary>
        /// this method is created ro hash the user Password
        /// found on https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/
        /// <param name="dataToHash">The data that we want to hash</param>
        /// <returns></returns>
        private string Hash(string dataToHash)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //hash the data
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));

                //convert the byte array to string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        

    }
}