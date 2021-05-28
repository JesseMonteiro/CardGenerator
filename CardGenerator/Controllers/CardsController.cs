using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGenerator.Models;
using CardGenerator.Repositories;

namespace CardGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;



        public CardsController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet("user/{email}")]
        public async Task<IEnumerable<Card>> GetCardsByEmail(String email)
        {
            var cards = await _cardRepository.Get();
            var filter = from c in cards
                         where c.Email == email
                         select c;
            return filter;
        }


        [HttpPost("{email}")]
        public async Task<ActionResult<String>> PostCard(string email)
        {
            Card card = new Card();
            Random rd = new Random();

            int rand_num = rd.Next(11111111, 99999999);
            card.CardNumber = "41005678" + rand_num;
            card.Email = email;

            var newCard = await _cardRepository.Create(card);
            return "Your new credit card is: " + newCard.CardNumber;
        }


        [HttpPut]
        public async Task<ActionResult> PutCard(int id, [FromBody] Card card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }

            await _cardRepository.Update(card);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cardToDelete = await _cardRepository.Get(id);

            if (cardToDelete == null)
            {
                return NotFound();
            }

            await _cardRepository.Delete(cardToDelete.Id);
            return NoContent();
        }

    }
}
