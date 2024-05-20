using System.Data.SqlClient;

namespace InfraFramework.DTO
{
    public class MensagemDTO
    {
        public MensagemDTO(int id, string nome)
        {
            Id = id;
            nome = Nome;
        }

        public MensagemDTO()
        {
        }
        public int Id  { get; set; }
        public string Nome { get; set; }
        public MensagemDTO ConvertToDTO(SqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("Id"));
            string mensagem = reader.GetString(reader.GetOrdinal("MensagemTexto"));
            string nDestino = reader.GetString(reader.GetOrdinal("Destinatario"));
            string sStatusEnvio = reader.GetString(reader.GetOrdinal("StatusEnvio"));

            MensagemDTO mensagemDTO = new MensagemDTO()
            {
                Id = id,
            };

            return mensagemDTO;
        }

    }
}
