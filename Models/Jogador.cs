using System.Collections.Generic;
using System.IO;
using EPlayers_AspNet.Interfaces;

namespace Eplayers_AspNetCore.Models
{
    public class Jogador: EplayersBase, IJogador
    {
        public int IdJogador { get; set; }
        public string NomeJogador { get; set; }
        public string IdEquipe { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        
        public string PATH = "Database/Jogador.csv";
        public Jogador(){
            CreateFolderAndFile(PATH);
        }

        public void Create(Jogador jogador)
        {
            string[] linhas = {Prepare(jogador)};
            File.AppendAllLines(PATH, linhas);
        }

        private string Prepare(Jogador jogador){
            return $"{jogador.IdJogador};{jogador.NomeJogador};{jogador.IdEquipe};{jogador.Email};{jogador.Senha}";
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => int.Parse(x.Split(";")[0]) == id);
            RewriteCSV(PATH, linhas);
        }

        public List<Jogador> ReadAll()
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            List<Jogador> j = new List<Jogador>();
            foreach (var linha in linhas)
            {
                Jogador jogador = new Jogador();
                jogador.IdJogador = int.Parse(linha.Split(";")[0]);
                jogador.NomeJogador = linha.Split(";")[1];
                jogador.IdEquipe = linha.Split(";")[2];
                jogador.Email = linha.Split(";")[3];
                jogador.Senha = linha.Split(";")[4];
                j.Add(jogador);
            }
            return j;
        }

        public void Update(Jogador jogador)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => int.Parse(x.Split(";")[0]) == jogador.IdJogador);
            RewriteCSV(PATH, linhas);
        }
    }
}