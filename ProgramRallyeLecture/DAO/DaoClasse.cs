using MySql.Data.MySqlClient;
using Metier;

namespace Dao
{
    public class DaoClasse
    {
        public void insert(Classe classe)
        {
            using (MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection())
            {
                cnx.Open();
                using (MySqlCommand cmd = new MySqlCommand("insert into classe(anneeScolaire,idNiveau) values(@annéeScolaire,@idNiveau)", cnx))
                {
                    //cmd.Parameters.Add(new MySqlParameter("@idEnseignant", MySqlDbType.Int32));
                    //cmd.Parameters["@idEnseignant"].Value = classe.GetIdEnseignant();
                    cmd.Parameters.Add(new MySqlParameter("@annéeScolaire", MySqlDbType.VarChar));
                    cmd.Parameters["@annéeScolaire"].Value = classe.GetAnneeScolaire();
                    cmd.Parameters.Add(new MySqlParameter("@idNiveau", MySqlDbType.Int32));
                    cmd.Parameters["@idNiveau"].Value = classe.GetIdNiveau();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
