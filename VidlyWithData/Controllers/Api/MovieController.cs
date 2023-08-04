using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using VidlyWithData.Dtos;
using VidlyWithData.Models;

namespace VidlyWithData.Controllers.Api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/movie
        
        public IHttpActionResult GetMovies()
        {

            var movies = _context.Movies.Include(m=> m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);

            if (movies == null)
                return NotFound();

            return Ok(movies);
        }

        //GET/api/movie/{id}
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);

                if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));

        }

        //POST/api/movie
        [HttpPost]
        public IHttpActionResult CreatMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();


            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT/api/movie/{id}
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
        }

        //DELETE/api/movie/{id}
        [HttpDelete]
        public void Delete (int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }

    }
}
