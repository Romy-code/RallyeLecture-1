using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class TableClasse
    {
        private int id;
        private int idEnseignant;
        private string annéeScolaire;
        private int idNiveau;

        public TableClasse(int _id, int _idEnseignant, string _annéeScolaire, int _idNiveau)
        {
            this.id = _id;
            this.idEnseignant = _idEnseignant;
            this.annéeScolaire = _annéeScolaire;
            this.idNiveau = _idNiveau;
        }

        public int GetIdEnseignant() { return this.idEnseignant; }
        public string GetAnneeScolaire() { return this.annéeScolaire; }
        public int GetIdNiveau() { return this.idNiveau; }
        public int GetID() { return this.id; }
    }
}
