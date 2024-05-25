using System.Data.SqlClient;

namespace InfraFramework.DTO
{
    public class MensagemDTO
    {
        public MensagemDTO(int id, string texto)
        {
            Id = id;
            Texto = texto;
        }

        public MensagemDTO(){ }

        public int Id  { get; set; }
        public string Texto { get; set; }
        public MensagemDTO ConvertToDTO(SqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("Id"));
            string mensagem = reader.GetString(reader.GetOrdinal("texto"));

            MensagemDTO mensagemDTO = new MensagemDTO()
            {
                Id = id,
                Texto = mensagem
            };

            return mensagemDTO;
        }

    }
}
