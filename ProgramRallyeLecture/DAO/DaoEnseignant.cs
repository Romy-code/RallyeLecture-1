using System;
using System.Collections.Generic;
using Metier;
using MySql.Data.MySqlClient;

namespace Dao
{
    public class DaoEnseignant
    {
        public List<Enseignant> GetAll()
        {
            List<Enseignant> login = new List<Enseignant>();
            using (MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection())
            {
                cnx.Open();
                using (MySqlCommand cmd = new MySqlCommand("select * from enseignant", cnx))
                {
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            login.Add(new Enseignant( rdr["nom"].ToString(), rdr["prenom"].ToString(), rdr["login"].ToString(), Convert.ToInt32(rdr["idAuth"])));
                        }
                    }
                }
            }
            return login;
        }
    }
}
