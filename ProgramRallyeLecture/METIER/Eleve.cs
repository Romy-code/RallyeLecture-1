using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Eleve
    {
        private readonly int idClasse;
        private string nom;
        private string prenom;
        private string login;
        private int idAuth;
        private string passWord;
        public Eleve(int _idClasse, string _nom, string _prenom, string _login, bool _passWord, int _idAuth)
        {
            this.idClasse = _idClasse;
            this.nom = _nom;
            this.prenom = _prenom;
            this.login = _login;
            this.idAuth = _idAuth;
            this.passWord = GetNewPassWord(_passWord);
        }

        public int GetIdAuth() { return this.idAuth; }
        public string GetNom() { return this.nom; }
        public string GetPrenom() { return this.prenom; }
        public int GetIdClasse() { return this.idClasse; }
        public string GetLogin() { return this.login; }
        private string GetPasswordAleatoire()
        {
            string passWord = "";
            List<string> alpha = new List<string>() {
                "a", "z", "e", "r", "t", "y", "u", "i", "o", "p", "q", "s", "d", "f", "g", "h", "j", "k", "l", "m", "w", "x", "c", "v", "b", "n"
            };
            List<string> maj = new List<string>() {
                "A", "Z", "E", "R", "T", "Y", "U", "I", "O", "P", "Q", "S", "D", "F", "G", "H", "J", "K", "L", "M", "W", "X", "C", "V", "B", "N"
            };
            List<string> nbr = new List<string>() {
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
            };
            List<string> speCaract = new List<string>() {
                "&", "é", "#", "è", "-", "|", "_", "ç", "à", "@", "¤", "$", "£", "µ", "*", "§", "!"
            };
            Random alea = new Random();

            string majuscules = maj[alea.Next(0, maj.Count)];
            string nombre = nbr[alea.Next(0, nbr.Count)];
            string caractère_spé = speCaract[alea.Next(0, speCaract.Count)];
            List<string> alphabet = new List<string>();
            for (int j = 0; j < 6; j++)
            {
                alphabet.Add(alpha[alea.Next(0, alpha.Count)]);
            }
            List<string> preparePassWord = new List<string>() { majuscules, nombre, caractère_spé };
            foreach (var item in alphabet)
            {
                preparePassWord.Add(item);
            }
            int count = preparePassWord.Count;
            for (int i = 0; i < count; i++)
            {
                int index = alea.Next(0, preparePassWord.Count);
                string a = preparePassWord[index];
                passWord = passWord + a;
                preparePassWord.RemoveAt(index);
            }        
            return passWord;
        }

        private string GetPassWordConstruit()
        {
            string passWord = "";
            passWord = prenom.Substring(0, 1) + nom;
            return passWord;
        }

        public string GetNewPassWord(bool type)
        {
            if (!type)
            {
                return GetPasswordAleatoire();
            }
            return GetPassWordConstruit();
        }
        public string GetPassWord()
        {
            return this.passWord;
        }

    }
}
