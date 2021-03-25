using System.Windows.Forms;
using Metier;
using Dao;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Users_Rallye
{
    
    public partial class users_import : Form
    {
        int idClasse = 0;
        public users_import()
        {
            InitializeComponent();
            DaoConnectionSingleton.SetStringConnection("root", "siojjr", "172.16.20.51", "rallyeLecturembrd");
            DateTime now = DateTime.Now;
            this.comboBox2.Items.AddRange(new object[] {
                        
                        now.Year + "-" + (now.Year+1),
                       (now.Year-1) + "-" + (now.Year),
                        (now.Year-2) +"-" + (now.Year-1),
                        (now.Year-3) +"-" + (now.Year-2),
                        (now.Year-4) +"-" + (now.Year-3)
            });
            DaoNiveau b = new DaoNiveau();
            List<Niveau> lesNiveaux = b.GetAll();
            for (int i = 0; i < lesNiveaux.Count; i++)
            {
                this.comboBox1.Items.Add(lesNiveaux[i].ToString());
            }
            
        }

        private void btn_ouvrir_Click(object sender, EventArgs e)
        {
            od_ouvrir.Filter = "text.csv |*.csv |All |*.*";
            //""
            if (od_ouvrir.ShowDialog() == DialogResult.OK)
            {
                rt_text.Text = od_ouvrir.FileName;
            }
        }

        private void btn_integ_Click(object sender, EventArgs e)
        {
            bool rb = false;
            if (rt_text.Text != " ")
            {
                if (rB.Checked)
                {
                    rb = false;
                }
                else if (rB2.Checked)
                {
                    rb = true;
                }
                string annéeScolaire = comboBox2.Text;
                int niveau = comboBox2.SelectedIndex + 1;

                using (MySqlConnection cnx = DaoConnectionSingleton.GetMySqlConnection())
                {
                    cnx.Open();
                    using (MySqlCommand requeteRecup = new MySqlCommand("select id from classe where anneeScolaire = @ans and idNiveau = @niv", cnx))
                    {

                        requeteRecup.Parameters.Add(new MySqlParameter("@ans", MySqlDbType.VarChar));
                        requeteRecup.Parameters["@ans"].Value = annéeScolaire;
                        requeteRecup.Parameters.Add(new MySqlParameter("@niv", MySqlDbType.Int32));
                        requeteRecup.Parameters["@niv"].Value = niveau;
                        try
                        {
                            MySqlDataReader reader = requeteRecup.ExecuteReader();
                            idClasse = (int)reader[0];
                        }
                        catch
                        {
                            idClasse = 0;
                        } 
                    }
                }
                if (idClasse == 0)
                {
                    Classe newClasse = new Classe(0, annéeScolaire, niveau);
                    DaoClasse Dao = new DaoClasse();
                    Dao.insert(newClasse);
                }
               

                string[] read;
                char[] seperators = { ';' };

                StreamReader sr = new StreamReader(rt_text.Text, Encoding.GetEncoding(1252));
                string data = sr.ReadLine();

                while ((data = sr.ReadLine()) != null)
                {
                    read = data.Split(seperators, StringSplitOptions.None);
                    string nom = read[0];
                    string prenom = read[1];
                    Eleve newEleve = new Eleve(0, nom, prenom, (nom.Substring(0, 1) + prenom), rb, 0);
                    DaoEleve Dao1 = new DaoEleve();
                    Dao1.insert(newEleve);
                }
            }
            else
            {
                MessageBox.Show("Vous devez renseigner tous les champs !", "Intégration... ", MessageBoxButtons.RetryCancel);
            }
            

        }
    }
}
