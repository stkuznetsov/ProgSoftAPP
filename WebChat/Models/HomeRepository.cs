using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace WebChat.Models
{
    public class HomeRepository : IRepository
    {


        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Poster> GetPosters()
        {
            List<Poster> posters = new List<Poster>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                posters = db.Query<Poster>("SELECT * FROM TablePoster").ToList();
            }
            return posters;
        }

        public Poster Get(int id)
        {
            Poster poster = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                poster = db.Query<Poster>("SELECT * FROM TablePoster WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return poster;
        }

        public Poster Create(Poster poster)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO TablePoster (Name, Advert, Email, PhoneNumber) VALUES(@Name, @Advert, @Email, @PhoneNumber); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? posterId = db.Query<int>(sqlQuery, poster).FirstOrDefault();
                poster.Id = posterId.Value;
            }
            return poster;
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM TablePoster WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }


    }
}