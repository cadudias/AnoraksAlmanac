using AnoraksAlmanacModel;

namespace AnoraksAlmanacDAL
{
    public class MovieRepository : RepositorioBaseEF<Movie>, IMovieRepository
    {
        //private HttpClient client = new HttpClient();

        //public MovieRepository()
        //{
        //    client.BaseAddress = new Uri("https://localhost:44390/api/");

        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //}

        //public async Task<List<Movie>> GetMoviesAsync()
        //{
        //    //HttpResponseMessage response = await client.GetAsync("api/movies");
        //    HttpResponseMessage response = await client.GetAsync("movies");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var dados = await response.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<List<Movie>>(dados);
        //    }
        //    return new List<Movie>();
        //}
        public MovieRepository(AnoraksAlmanacContext context) : base(context)
        {
        }
    }
}