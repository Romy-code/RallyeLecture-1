using MySql.Data.MySqlClient;
using Metier;

namespace Dao
{
    public class DaoEleve
    {
        public void insert(Eleve eleve)
        {
            using (MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection())
            {
                cnx.Open();
                using (MySqlCommand cmd = new MySqlCommand("insert into eleve(nom,prenom,login) values(@nom,@prenom,@login)", cnx))
                {
                    cmd.Parameters.Add(new MySqlParameter("@nom", MySqlDbType.VarChar));
                    cmd.Parameters["@nom"].Value = eleve.GetNom();
                    cmd.Parameters.Add(new MySqlParameter("@prenom", MySqlDbType.VarChar));
                    cmd.Parameters["@prenom"].Value = eleve.GetPrenom();
                    cmd.Parameters.Add(new MySqlParameter("@login", MySqlDbType.VarChar));
                    cmd.Parameters["@login"].Value = eleve.GetLogin();

                    cmd.ExecuteNonQuery();
                }

                using (MySqlCommand cmd = new MySqlCommand("insert into aauth_users(email,pass,username) values(@email,@pass,@username)", cnx))
                {
                    Hash a = new Hash();

                    cmd.Parameters.Add(new MySqlParameter("@email", MySqlDbType.VarChar));
                    cmd.Parameters["@email"].Value = eleve.GetNom() + eleve.GetPrenom().Substring(0, 1) + "@sio.jjr.fr" ;
                    cmd.Parameters.Add(new MySqlParameter("@pass", MySqlDbType.VarChar));
                    cmd.Parameters["@pass"].Value = a.GetHashPassword( /*IdUser(eleve)+*/ eleve.GetPassWord());
                    cmd.Parameters.Add(new MySqlParameter("@username", MySqlDbType.VarChar));
                    cmd.Parameters["@username"].Value = eleve.GetPrenom().Substring(0, 1) + eleve.GetNom();

                    cmd.ExecuteNonQuery();
                }
                cnx.Close();
            }
        }
        public int select(Eleve eleve)
        {
            using (MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection())
            {
                cnx.Open();
                using (MySqlCommand requeteRecup = new MySqlCommand("select idAuth from eleve where login = @ans", cnx))
                {

                    requeteRecup.Parameters.Add(new MySqlParameter("@ans", MySqlDbType.VarChar));
                    requeteRecup.Parameters["@ans"].Value = eleve.GetLogin();
                    MySqlDataReader reader = requeteRecup.ExecuteReader();
                    return(int)reader["id"];

                }
            }
        }
    }
}
