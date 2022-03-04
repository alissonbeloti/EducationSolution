using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.VO
{
    public class CursoVO
    {
        public Guid CursoId { get; set; }

        public string? Titulo { get; set; }

        public string? Descricao { get; set; }

        public DateTime? DataPublicacao { get; set; }

        public decimal Preco { get; set; }
    }
}
