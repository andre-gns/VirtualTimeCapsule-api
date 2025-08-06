using System;
using System.ComponentModel.DataAnnotations;

namespace VirtualTimeCapsule.Api.DTOs
{
    public class CapsulaTempoCreateDto
    {
        [Required(ErrorMessage = "O nome do rementende é obrigatório.")]
        [StringLength(100)]
        public string NameRemetente { get; set; }

        [Required(ErrorMessage = "O e-mail do remetente é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(100)]
        public string EmailRemetente { get; set; }

        public DateTime DataEnvioEmail { get; set; }

        [Required(ErrorMessage = "A mensagem é obrigatória.")]
        [StringLength(100)]
        public string Mensagem { get; set; }

        [Required(ErrorMessage = "A data de envio é obrigatório.")]

        public string? CaminhoImagem { get; set; }
    }
}