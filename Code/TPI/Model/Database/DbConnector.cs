using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

using Model.Exceptions;

namespace Model
{
    public class DbConnector
    {
        private string connetionString = null;
        private MySqlConnection connection;

        public DbConnector(string connectionString)
        {


            connection = new MySqlConnection(connectionString);
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
        public bool Insert(string query)
        {
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and the opened connection
                MySqlCommand cmd = new MySqlCommand(query, connection);
                int queryResult;
                //Execute command
                try
                {
                    queryResult = cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    return false;
                }
                //close connection
                cmd.Dispose();
                this.CloseConnection();
                if (queryResult != 0)
                {
                    return true;
                }
                else { return false; }
            }
            else { throw new DbError(); }
        }
        public int InsertWithReturn(string query)
        {
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and the opened connection
                MySqlCommand cmd = new MySqlCommand(query, connection);
                int queryResult;
                //Execute command
                try
                {
                    queryResult = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    throw new DbError();
                }
                //close connection
                cmd.Dispose();
                this.CloseConnection();
                return queryResult;
            }
            else { throw new DbError(); }
        }
        public bool Update(string query)
        {
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and the opened connection
                MySqlCommand cmd = new MySqlCommand(query, connection);
                int queryResult;
                //Execute command
                try
                {
                    queryResult = cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    return false;
                }
                //close connection
                cmd.Dispose();
                this.CloseConnection();
                if (queryResult != 0)
                {
                    return true;
                }
                else { return false; }
            }
            else { throw new DbError(); }
        }

        public List<List<object>> Select(string query)
        {
            //Create a list to store the result
            List<List<object>> list = new List<List<object>>();

            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int i = 0;
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(new List<object>());
                    for (int j = 0; j < dataReader.FieldCount; j++)
                    {
                        list[i].Add(dataReader.GetValue(j)); //vérifier que ça marche
                    }
                    i++;
                }

                //close Data Reader
                dataReader.Close();

                cmd.Dispose();
                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                throw new DbError();
            }
        }
    }
}
