using MySql.Data.MySqlClient;

namespace Dao
{
    public static class DaoConnectionSingleton
    {
        private static string user;
        private static string password;
        private static string server;
        private static string database;

        private static MySqlConnection mySqlConnection;

        public static string User
        {
            get { return user; }
        }

        public static string Password
        {
            get { return password; }
        }

        public static string Server
        {
            get { return server; }
        }

        public static string Database
        {
            get { return database; }
        }

        public static string GetStringConnection()
        {
            return string.Format("user={0};password={1};server={2};database={3}", user, password, server, database);
        }

        public static void SetStringConnection(string user, string password, string server, string database)
        {
            DaoConnectionSingleton.user = user;
            DaoConnectionSingleton.password = password;
            DaoConnectionSingleton.server = server;
            DaoConnectionSingleton.database = database;
        }

        public static MySqlConnection GetMySqlConnection()
        {
            if (DaoConnectionSingleton.mySqlConnection == null)
            {
                DaoConnectionSingleton.mySqlConnection = new MySqlConnection(DaoConnectionSingleton.GetStringConnection());
            }
            return DaoConnectionSingleton.mySqlConnection;
        }
    }
}
