using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrganizadorMusicas.API.Models
{
    public class ViewModelMidia
    {
        
        public int Id { get; set; }
        public string Titulo { get; set; }
        public Nullable<int> Ano { get; set; }
        public Nullable<int> Numero { get; set; }
        public string Genero { get; set; }
        public string Album { get; set; }
        public string Artista { get; set; }
        public byte[] Capa { get; set; }
        
    }
}