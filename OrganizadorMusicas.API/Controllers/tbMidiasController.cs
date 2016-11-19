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
using System.Threading.Tasks;
using System.IO;
using OrganizadorMusicas.API.Models;
using System.Drawing;

namespace OrganizadorMusicas.API.Controllers
{
    public class tbMidiasController : ApiController
    {
        private MusicasEntities db = new MusicasEntities();


        [HttpPost, Route("api/midiaUpload")]
        public async Task<IHttpActionResult> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                var buffer = await file.ReadAsByteArrayAsync();
                var nomeGuid = Guid.NewGuid().ToString();
                var destino = AppDomain.CurrentDomain.BaseDirectory + "/midia/" + nomeGuid + ".mp3";
                File.WriteAllBytes(destino, buffer);

                TagLib.File tagFile = TagLib.File.Create(destino);
                var infoArtista = tagFile.Tag.FirstAlbumArtist;
                var infoAlbum = tagFile.Tag.Album;
                var infoTitulo = tagFile.Tag.Title;
                var infoAno = tagFile.Tag.Year;
                var infoNumero = tagFile.Tag.Track;
                var infoGenero = tagFile.Tag.FirstGenre;
                var listaImagens = tagFile.Tag.Pictures;

                tbMidia novaMidia = new tbMidia();
                
                var tbArtista = db.tbArtista.Where(x => x.nome == infoArtista).FirstOrDefault();
                var tbAlbum = db.tbAlbum.Where(x => x.nome == infoAlbum).FirstOrDefault();
                var tbGenero = db.tbGenero.Where(x => x.nomeGenero == infoGenero).FirstOrDefault();

                tbArtista novoArtista = new tbArtista();
                if(tbArtista == null)
                {
                    novoArtista.nome = infoArtista;
                    db.tbArtista.Add(novoArtista);
                    db.SaveChanges(); 
                }
                else
                {
                    novoArtista = tbArtista;
                }

                tbAlbum novoAlbum = new tbAlbum();
                if (tbAlbum == null)
                {
                    novoAlbum.nome = infoAlbum;

                    if (listaImagens.Length > 0)
                    {
                        var infoImagem = listaImagens[0];
                        novoAlbum.capa = infoImagem.Data.Data;
                    }
                    else
                    {
                        Image imagem = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Imagens/semcapa.png");
                        MemoryStream ms = new MemoryStream();
                        imagem.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        novoAlbum.capa = ms.ToArray();
                    }

                    db.tbAlbum.Add(novoAlbum);
                    db.SaveChanges();
                }
                else
                {
                    novoAlbum = tbAlbum;
                }

                tbGenero novoGenero = new tbGenero();
                if(tbGenero == null)
                {
                    novoGenero.nomeGenero = infoGenero;
                    db.tbGenero.Add(novoGenero);
                    db.SaveChanges();
                }
                else
                {
                    novoGenero = tbGenero;
                }

                novaMidia.titulo = infoTitulo;
                novaMidia.ano = (int)infoAno;
                novaMidia.numero = (int)infoNumero;
                novaMidia.idArtista = novoArtista.id;
                novaMidia.idAlbum = novoAlbum.id;
                novaMidia.idGenero = novoGenero.id;
                db.tbMidia.Add(novaMidia);
                db.SaveChanges();

            }

            return Ok();
        }

        [HttpGet, Route("api/GetListMidia")]
        public List<ViewModelMidia> GetListMidia()
        {
            var midia = (from m in db.tbMidia
                         join g in db.tbGenero on m.idGenero equals g.id
                         join b in db.tbAlbum on m.idAlbum equals b.id
                         join a in db.tbArtista on m.idArtista equals a.id
                         select new ViewModelMidia()
                         {
                             Id = m.id,
                             Titulo = m.titulo,
                             Ano = m.ano,
                             Numero = m.numero,
                             Album = b.nome,
                             Artista = a.nome,
                             Genero = g.nomeGenero,
                             Capa = b.capa
                         }).OrderBy(x => x.Titulo).ToList();
            return midia;
        }

        // GET: api/tbMidias
        public IQueryable<tbMidia> GettbMidia()
        {
            return db.tbMidia;
        }        

        // GET: api/tbMidias/5
        [ResponseType(typeof(tbMidia))]
        public IHttpActionResult GettbMidia(int id)
        {
            tbMidia tbMidia = db.tbMidia.Find(id);
            if (tbMidia == null)
            {
                return NotFound();
            }

            return Ok(tbMidia);
        }

        // PUT: api/tbMidias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttbMidia(int id, tbMidia tbMidia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbMidia.id)
            {
                return BadRequest();
            }

            db.Entry(tbMidia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbMidiaExists(id))
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

        // POST: api/tbMidias
        [ResponseType(typeof(tbMidia))]
        public IHttpActionResult PosttbMidia(tbMidia tbMidia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbMidia.Add(tbMidia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbMidia.id }, tbMidia);
        }

        // DELETE: api/tbMidias/5
        [ResponseType(typeof(tbMidia))]
        public IHttpActionResult DeletetbMidia(int id)
        {
            tbMidia tbMidia = db.tbMidia.Find(id);
            if (tbMidia == null)
            {
                return NotFound();
            }

            db.tbMidia.Remove(tbMidia);
            db.SaveChanges();

            return Ok(tbMidia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbMidiaExists(int id)
        {
            return db.tbMidia.Count(e => e.id == id) > 0;
        }
    }
}