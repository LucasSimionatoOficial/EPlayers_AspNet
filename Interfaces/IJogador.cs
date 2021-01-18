using System.Collections.Generic;
using Eplayers_AspNetCore.Models;

namespace EPlayers_AspNet.Interfaces
{
    public interface IJogador
    {
        void Create(Jogador jogador);
        List<Jogador> ReadAll();
        void Update(Jogador jogador);
        void Delete(int id);
    }
}