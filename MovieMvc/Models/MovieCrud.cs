using System.Data.SqlClient;

namespace MovieMvc.Models
{
    public class MovieCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public MovieCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));

        }
        public IEnumerable<Movie> GetAllMovie()
        {
            List<Movie> list = new List<Movie>();
            string qry = "select * from Movie where isActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Movie m = new Movie();
                    m.Id = Convert.ToInt32(dr["id"]);
                    m.Title = dr["title"].ToString();
                    m.ReleaseDate = Convert.ToDateTime(dr["releasedate"]);
                    m.MoviesType = dr["movietype"].ToString();
                    m.StarName = dr["starname"].ToString();
                    m.isActive = Convert.ToInt32(dr["isActive"]);
                    list.Add(m);


                }
            }
            con.Close();
            return list;
        }
        public Movie GetMovieById(int id)
        {
            Movie m = new Movie();
            string qry = "select * from Movie where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    m.Id = Convert.ToInt32(dr["id"]);
                    m.Title = dr["title"].ToString();
                    m.ReleaseDate = Convert.ToDateTime(dr["releasedate"]);
                    m.MoviesType = dr["movietype"].ToString();
                    m.StarName = dr["starname"].ToString();
                    m.isActive = Convert.ToInt32(dr["isActive"]);
                }
            }
            con.Close();
            return m;
        }
        public int AddMovie(Movie movie)
        {
            movie.isActive = 1;
            int result = 0;
            string qry = "insert into Movie values(@title,@releasedate,@movietype,@starname,@isActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@title", movie.Title);
            cmd.Parameters.AddWithValue("@releasedate", movie.ReleaseDate);
            cmd.Parameters.AddWithValue("@movietype", movie.MoviesType);
            cmd.Parameters.AddWithValue("@starname", movie.StarName);
            cmd.Parameters.AddWithValue("@isActive", movie.isActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }
        public int UpdateMovie(Movie movie)
        {
            movie.isActive = 1;
            int result = 0;
            string qry = "update Movie set Title=@title,ReleaseDate=@releasedate,MovieType=@movietype,StarName=@starname,isActive=@isActive where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@title", movie.Title);
            cmd.Parameters.AddWithValue("@releasedate", movie.ReleaseDate);
            cmd.Parameters.AddWithValue("@movietype", movie.MoviesType);
            cmd.Parameters.AddWithValue("starname", movie.StarName);
            cmd.Parameters.AddWithValue("@isActive", movie.isActive);
            cmd.Parameters.AddWithValue("@id", movie.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        // soft delete --> record should be present in DB , but should not visible on the form
        public int DeleteMovie(int id)
        {
            int result = 0;
            string qry = "update Movie set isActive=0 where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }

}