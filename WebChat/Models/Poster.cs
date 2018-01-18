using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public class Poster
    {
        public int Id { get; set; }
        [Required, StringLength(50, ErrorMessage = " max 50 characters")]

        public string Name { get; set; }
        [Required, StringLength(50, ErrorMessage = " in the message and not more than 250 characters")]
        public string Advert { get; set; }
        [Required,RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "incorrect address")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}