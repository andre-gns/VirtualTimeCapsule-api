using System;

namespace VirtualTimeCapsule.Api.DTOs
{
    public class CapsulaTempoReadDto
    {
        public int Id { get; set; }
        public string NameRemetente { get; set; }
        public string EmailRemetente { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataEnvioEmail { get; set; }
        public string? CaminhoImagem { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}