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
    public class tbAlbumsController : ApiController
    {
        private MusicasEntities db = new MusicasEntities();

        // GET: api/tbAlbums
        public IQueryable<tbAlbum> GettbAlbum()
        {
            return db.tbAlbum;
        }

        // GET: api/tbAlbums/5
        [ResponseType(typeof(tbAlbum))]
        public IHttpActionResult GettbAlbum(int id)
        {
            tbAlbum tbAlbum = db.tbAlbum.Find(id);
            if (tbAlbum == null)
            {
                return NotFound();
            }

            return Ok(tbAlbum);
        }

        // PUT: api/tbAlbums/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttbAlbum(int id, tbAlbum tbAlbum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbAlbum.id)
            {
                return BadRequest();
            }

            db.Entry(tbAlbum).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbAlbumExists(id))
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

        // POST: api/tbAlbums
        [ResponseType(typeof(tbAlbum))]
        public IHttpActionResult PosttbAlbum(tbAlbum tbAlbum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbAlbum.Add(tbAlbum);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbAlbum.id }, tbAlbum);
        }

        // DELETE: api/tbAlbums/5
        [ResponseType(typeof(tbAlbum))]
        public IHttpActionResult DeletetbAlbum(int id)
        {
            tbAlbum tbAlbum = db.tbAlbum.Find(id);
            if (tbAlbum == null)
            {
                return NotFound();
            }

            db.tbAlbum.Remove(tbAlbum);
            db.SaveChanges();

            return Ok(tbAlbum);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbAlbumExists(int id)
        {
            return db.tbAlbum.Count(e => e.id == id) > 0;
        }
    }
}