using System.Collections.Generic;
using System.IO;

namespace Eplayers_AspNetCore.Models
{
    public class Equipe: EplayersBase, IEquipe
    {
        public int IdEquipe { get; set; }
        public string NomeEquipe { get; set; }
        public string Imagem { get; set; }
        private string PATH = "Database/Equipe.csv";

        public Equipe(){
            CreateFolderAndFile(PATH);
        }
        public void Create(Equipe equipe)
        {
            string[] linhas = {Prepare(equipe)};
            File.AppendAllLines(PATH, linhas);
        }

        private string Prepare(Equipe equipe)
        {
            return $"{equipe.IdEquipe};{equipe.NomeEquipe};{equipe.Imagem}";
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                Equipe equipe = new Equipe();
                equipe.IdEquipe = int.Parse(item.Split(";")[0]);
                equipe.NomeEquipe = item.Split(";")[1];
                equipe.Imagem = item.Split(";")[2];
                equipes.Add(equipe);
            }
            return equipes;
        }

        public void Update(Equipe equipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => int.Parse(x.Split(";")[0]) == equipe.IdEquipe);
            linhas.Add(Prepare(equipe));
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => int.Parse(x.Split(";")[0]) == id);
            RewriteCSV(PATH, linhas);
        }
    }
}