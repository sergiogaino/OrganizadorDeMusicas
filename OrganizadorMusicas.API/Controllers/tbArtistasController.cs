using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OrganizadorMusicas.API;

namespace OrganizadorMusicas.API.Controllers
{
    public class tbArtistasController : ApiController
    {
        private MusicasEntities db = new MusicasEntities();

        // GET: api/tbArtistas
        public IQueryable<tbArtista> GettbArtista()
        {
            return db.tbArtista;
        }

        // GET: api/tbArtistas/5
        [ResponseType(typeof(tbArtista))]
        public IHttpActionResult GettbArtista(int id)
        {
            tbArtista tbArtista = db.tbArtista.Find(id);
            if (tbArtista == null)
            {
                return NotFound();
            }

            return Ok(tbArtista);
        }

        // PUT: api/tbArtistas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttbArtista(int id, tbArtista tbArtista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbArtista.id)
            {
                return BadRequest();
            }

            db.Entry(tbArtista).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbArtistaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tbArtistas
        [ResponseType(typeof(tbArtista))]
        public IHttpActionResult PosttbArtista(tbArtista tbArtista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbArtista.Add(tbArtista);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbArtista.id }, tbArtista);
        }

        // DELETE: api/tbArtistas/5
        [ResponseType(typeof(tbArtista))]
        public IHttpActionResult DeletetbArtista(int id)
        {
            tbArtista tbArtista = db.tbArtista.Find(id);
            if (tbArtista == null)
            {
                return NotFound();
            }

            db.tbArtista.Remove(tbArtista);
            db.SaveChanges();

            return Ok(tbArtista);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbArtistaExists(int id)
        {
            return db.tbArtista.Count(e => e.id == id) > 0;
        }
    }
}