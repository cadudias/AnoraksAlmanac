using AnoraksAlmanacModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AnoraksAlmanacApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private HttpClient client = new HttpClient();
        private IConfiguration _configuration;
        //private readonly IMovieService _service;

        public MoviesController(IConfiguration configuration)
        {
            //_service = service;

            _configuration = configuration;

            client.BaseAddress = new Uri(_configuration.GetSection("TheMovieDBApi:BaseURL").Value);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // TODO - buscar da api do movie db
        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get()
        {
            HttpResponseMessage response = client.GetAsync($"discover/movie?api_key={_configuration.GetSection("TheMovieDBApi:ApiKey").Value}&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&primary_release_year=1980&primary_release_date.gte=1980&primary_release_date.lte=1980&year=1980").Result;

            response.EnsureSuccessStatusCode();

            string conteudo = response.Content.ReadAsStringAsync().Result;

            //dynamic resultado = JsonConvert.DeserializeObject(conteudo);
            dynamic resultado = JsonConvert.DeserializeObject(conteudo);

            dynamic resultados = resultado.results;

            return JsonConvert.DeserializeObject<List<Movie>>(resultados.ToString());

            //Movie movie = new Movie();
            //movie.Title = resultado[0].title.ToString();
            //movie.OriginalTitle = resultado[0].originalTitle.ToString();
            //movie.OriginalLanguage = resultado[0].originalLanguage.ToString();

            //return new List<Movie> { movie };
            /*
            return new List<Movie> {
                new Movie {
                    Title = "movie 1",
                    OriginalTitle = "title 2",
                    OriginalLanguage = "en",
                    Adult = true,
                    ReleaseDate = new DateTimeOffset().AddDays(5)
                }
            };
            */
        }

        //[HttpGet]
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
    }
}