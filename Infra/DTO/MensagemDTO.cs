
using System.Data.SqlClient;

namespace Infra.DTO
{
    public class MensagemDTO
    {
        public MensagemDTO(){}
        public int Id               { get; set; }
        public string? Destinatario { get; set; }
        public string? Remetente    { get; set; }
        public string? Mensagens    { get; set; }
        public string? StatusEnvio  { get; set; }
        public string? DataEnvio    { get; set; }
        public MensagemDTO ConvertToDTO(SqlDataReader reader)
        {
            int id              = reader.GetInt32(reader.GetOrdinal("Id"));
            string mensagem     = reader.GetString(reader.GetOrdinal("MensagemTexto"));
            string nDestino     = reader.GetString(reader.GetOrdinal("Destinatario"));
            string sStatusEnvio = reader.GetString(reader.GetOrdinal("StatusEnvio"));

            MensagemDTO mensagemDTO = new MensagemDTO()
            {
                Id = id,
                Mensagens = mensagem,
                Destinatario = nDestino,
                StatusEnvio = sStatusEnvio
            };

            return mensagemDTO;
        }

    }
}
