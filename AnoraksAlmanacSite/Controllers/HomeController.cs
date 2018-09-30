using AnoraksAlmanacDAL;
using AnoraksAlmanacModel;
using AnoraksAlmanacSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

namespace AnoraksAlmanacSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Movie> _repo;

        private readonly HttpClient client = new HttpClient();

        private readonly IConfiguration _configuration;

        public HomeController(IRepository<Movie> repo, IConfiguration configuration)
        {
            _configuration = configuration;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var movies = GetMovies();
            ViewBag.movies = movies;
            return View();
        }

        public List<Movie> GetMovies()
        {
            client.BaseAddress = new Uri(_configuration.GetSection("AnoraksApi:BaseUrl").Value);

            HttpResponseMessage response = client.GetAsync("movies").Result;

            response.EnsureSuccessStatusCode();

            string conteudo = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Movie>>(conteudo);
        }

        private IEnumerable<Movie> GetListType(MoviesListsTypes type)
        {
            return _repo.All
                .Where(l => l.ListType == type)
                .ToList();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}