using Metier;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace Dao
{
    public class DaoNiveau
    {
        public List<Niveau> GetAll()
        {
            List<Niveau> niveau = new List<Niveau>();
            using (MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection())
            {             
                cnx.Open();
                using (MySqlCommand cmd = new MySqlCommand("select id,niveauScolaire from niveau", cnx))
                {
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            niveau.Add(new Niveau(Convert.ToInt32(rdr["id"]), rdr["niveauScolaire"].ToString()));
                        }
                    }
                }
            }
            return niveau;
        }
    }
}
