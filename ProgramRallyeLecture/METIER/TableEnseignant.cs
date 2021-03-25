using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class TableEnseignant
    {
        private string login;
        private string prenom;
        private string nom;
        private int idAuth;

        public TableEnseignant(string _nom, string _prenom, string _login, int _idAuth)
        {
            this.login = _login;
            this.prenom = _prenom;
            this.nom = _nom;
            this.idAuth = _idAuth;
        }

        public int GetIdAuth() { return this.idAuth; }
        public string GetNom() { return this.nom; }
        public string GetPrenom() { return this.prenom; }
        public string GetLogin() { return this.login; }
    }
}
