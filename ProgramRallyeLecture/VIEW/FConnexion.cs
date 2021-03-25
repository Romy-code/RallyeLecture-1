using System;
using System.Windows.Forms;
using Dao;
using Metier;
using System.Collections.Generic;

namespace Users_Rallye
{
    public partial class FConnexion : Form
    {
        public FConnexion()
        {
            InitializeComponent();
        }

        private void btn_val_Click(object sender, EventArgs e)
        {
            bool login = false;
            //bool mdp = false;
            DaoEnseignant b = new DaoEnseignant();
            List<Enseignant> lesEnseignants = b.GetAll();

            if ((textBox2.Text == "") || (tb_login.Text == ""))
            {
                MessageBox.Show("Vous devez renseigner tous les champs !", "Connexion... ",
                                    MessageBoxButtons.RetryCancel);
            }
            if(!login /*&& !mdp*/)
            {
                for (int i = 0; i < lesEnseignants.Count; i++)
                {
                    if (lesEnseignants[i].GetLogin() == tb_login.Text)
                    {
                        login = true;
                    }
                    //if (lesEnseignants[i].GetLogin() == tb_login.Text)
                    //{
                    //    mdp = true;
                    //}
                }
                
            }
            if((login) /*&& (mdp)*/)
            {

                users_import usersInterface = new users_import();
                usersInterface.Show();
                this.Close();
            }
        }
    }
}
