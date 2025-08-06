using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualTimeCapsule.Api.Models
{
    public class CapsulaTempo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do remetente é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do remetente não pode exceder 100 caracteres.")]
        public string NomeRemetente { get; set; }

        [Required(ErrorMessage = "O e-mail do remetente é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(100, ErrorMessage = "O e-mail do remetente não pode exceder 100 caracteres.")]
        public string EmailRemetente { get; set; }

        [Required(ErrorMessage = "A mensagem é obrigatória.")]
        [StringLength(1000, ErrorMessage = "A mensagem não pode exceder 1000 caracteres.")]
        public string Mensagem { get; set; }

        [Required(ErrorMessage = "A data de envio é obrigatória.")]
        public DateTime DataEnvioEmail { get; set; }

        [StringLength(255, ErrorMessage = "O caminho da imagem não pode exceder 255 caracteres.")]
        public string? CaminhoImagem { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}