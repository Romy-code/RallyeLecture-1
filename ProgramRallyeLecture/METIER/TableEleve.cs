using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class TableEleve
    {
        private int idClasse;
        private string nom;
        private string prenom;
        private string login;
        private int idAuth;
        public TableEleve(int _idClasse, string _nom, string _prenom, string _login, int _idAuth)
        {
            this.idClasse = _idClasse;
            this.nom = _nom;
            this.prenom = _prenom;
            this.login = _login;
            this.idAuth = _idAuth;
        }

        public int GetIdAuth() { return this.idAuth; }
        public string GetNom() { return this.nom; }
        public string GetPrenom() { return this.prenom; }
        public int GetIdClasse() { return this.idClasse; }
        public string GetLogin() { return this.login; }
    }
}
