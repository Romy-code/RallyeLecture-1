using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class TableNiveau
    {
        private int id;
        private string niveauScolaire;

        public TableNiveau(int _id, string _niveauScolaire)
        {
            this.id = _id;
            this.niveauScolaire = _niveauScolaire;
        }

        public string GetNiveauScolaire() { return this.niveauScolaire; }
        public int GetID() { return this.id; }

        public override string ToString()
        {
            return this.niveauScolaire;
        }
    }
}
