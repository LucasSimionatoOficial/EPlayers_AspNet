using System.Collections.Generic;

namespace Eplayers_AspNetCore.Models
{
    public interface IEquipe
    {
         void Create(Equipe equipe);

         List<Equipe> ReadAll();

         void Update(Equipe equipe);
         
         void Delete(int id);
    }
}