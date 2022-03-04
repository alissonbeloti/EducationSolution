﻿using System.ComponentModel.DataAnnotations;

namespace Education.Domain
{
    public class Curso
    {
        [Key]
        public Guid CursoId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Titulo { get; set; }

        [Required]
        [StringLength(200)]
        public string? Descricao { get; set; }

        [DataType(DataType.Date)]
        [DateInFuture]
        public DateTime? DataPublicacao { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataCriacao { get; set; }

        public decimal Preco { get; set; }
    }
}
