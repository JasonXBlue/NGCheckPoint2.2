using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class Dog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }

        public int Age { get; set; }

        public bool KidFriendly { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}