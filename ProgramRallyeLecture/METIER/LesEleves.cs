using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class LesEleves
    {
        private List<Eleve> lesEleves;

        public void CreateCsvPasswordFile()
        {
            string directoryPath = Directory.GetCurrentDirectory();
            FileStream stream = new FileStream(directoryPath + "\\eleves.csv", FileMode.Create);
            stream.Close();
            StreamWriter writer = new StreamWriter(directoryPath + "\\eleves.csv");
            foreach (Eleve eleve in this.lesEleves)
            {
                writer.WriteLine("{0};{1}", eleve.GetLogin(), eleve.GetPassWord());
            }
            writer.Close();
        }

        public List<Eleve> LoadCsv(PassWordType type, string pathToCsv)
        {
            List<Eleve> eleves = new List<Eleve>();
            StreamReader reader = new StreamReader(pathToCsv);
            string line = "";
            line = reader.ReadLine();
            while (line != null)
            {
                //eleves.Add(new Eleve(line.Split(';')[0], line.Split(';')[1], string.Format("{1}{0}@sio.jjr.fr", line.Split(';')[0], line.Split(';')[1])));
                line = reader.ReadLine();
            }
            return eleves;
        }
    }
}
