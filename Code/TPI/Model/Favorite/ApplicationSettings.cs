using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ApplicationSettings
    {
        #region attributs
        private string connectionString;
        #endregion attributs
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="connectionString">the string used to connect to the database</param>
        public ApplicationSettings(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// accessor used for the connectionString attributs
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString; }
        }
    }
}
