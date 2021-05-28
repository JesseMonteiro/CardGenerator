using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardGenerator.Models
{
    public class Card
    {
        [Key()]
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string Email { get; set; }

    }


}
