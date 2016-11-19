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
    public class tbGeneroesController : ApiController
    {
        private MusicasEntities db = new MusicasEntities();

        // GET: api/tbGeneroes
        public IQueryable<tbGenero> GettbGenero()
        {
            return db.tbGenero;
        }

        // GET: api/tbGeneroes/5
        [ResponseType(typeof(tbGenero))]
        public IHttpActionResult GettbGenero(int id)
        {
            tbGenero tbGenero = db.tbGenero.Find(id);
            if (tbGenero == null)
            {
                return NotFound();
            }

            return Ok(tbGenero);
        }

        // PUT: api/tbGeneroes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttbGenero(int id, tbGenero tbGenero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbGenero.id)
            {
                return BadRequest();
            }

            db.Entry(tbGenero).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbGeneroExists(id))
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

        // POST: api/tbGeneroes
        [ResponseType(typeof(tbGenero))]
        public IHttpActionResult PosttbGenero(tbGenero tbGenero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbGenero.Add(tbGenero);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbGenero.id }, tbGenero);
        }

        // DELETE: api/tbGeneroes/5
        [ResponseType(typeof(tbGenero))]
        public IHttpActionResult DeletetbGenero(int id)
        {
            tbGenero tbGenero = db.tbGenero.Find(id);
            if (tbGenero == null)
            {
                return NotFound();
            }

            db.tbGenero.Remove(tbGenero);
            db.SaveChanges();

            return Ok(tbGenero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbGeneroExists(int id)
        {
            return db.tbGenero.Count(e => e.id == id) > 0;
        }
    }
}