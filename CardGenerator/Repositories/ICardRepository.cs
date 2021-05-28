using CardGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGenerator.Repositories
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> Get();

        Task<IEnumerable<Card>> Get(String email);

        Task<Card> Get(int id);

        Task<Card> Create(Card card);

        Task Update(Card card);

        Task Delete(int id);
    }
}
