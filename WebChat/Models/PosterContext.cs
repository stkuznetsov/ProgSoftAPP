using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public class PosterContext : DbContext
    {

        public PosterContext() : 
            base("DefaultConnection")
        { }
        public DbSet<Poster> Posters { get; set; }
    }

}
