using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recommendations.Data;
using Recommendations.Entities;

namespace Recommendations.Tests.Database
{
    [TestClass]
    public class InitializeTests
    {
        [TestMethod]
        public void InitTestData()
        {
            CreateActors();
            CreateFilmsWithComments();
            AssignActorsToFilms();
        }

        [TestMethod]
        public void GetFilmsTest()
        {
            using (var context = new DataContext())
            {
                var films = context
                    .Films
                    .Include("Actors")
                    .Include("Comments")
                    .ToList();

                var c = films.Count;
            }
        }
        
        private void CreateActors()
        {
            using (var context = new DataContext())
            {
                for (var i = 0; i < 5; i++)
                {
                    var actor = new Actor
                    {
                        Name = "ActorName" + i,
                        Surname = "ActorSurname" + i
                    };
                    context.Actors.Add(actor);
                }
                context.SaveChanges();
            }
        }

        private void CreateFilmsWithComments()
        {
            using (var context = new DataContext())
            {
                for (var i = 0; i < 5; i++)
                {
                    var comment = new Comment
                    {
                        Title = "CommentTitle" + i,
                        Details = "CommentDetails" + i
                    };
                    context.Comments.Add(comment);

                    var film = new Film
                    {
                        Title = "FilmTitle" + i,
                        //Description = "FilmDescription" + i,
                        Comments = new List<Comment> {comment}
                    };
                    context.Films.Add(film);
                }
                context.SaveChanges();
            }
        }

        private void AssignActorsToFilms()
        {
            using (var context = new DataContext())
            {
                var actors = context.Actors.ToList();
                var films = context.Films.ToList();

                foreach (var film in films)
                {
                    film.Actors = new List<Actor>();
                    foreach (var actor in actors)
                    {
                        film.Actors.Add(actor);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
