using System.ComponentModel.DataAnnotations;

namespace TwitterApi.Models
{
    public class Twit
    {
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }
        public User Author { get; set; }

        public Twit[] Childs;
        public Twit Parent;
    }
}
