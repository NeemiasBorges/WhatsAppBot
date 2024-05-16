using Infra.DTO;
using Infra.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace Infra.Repositorio
{
    public class MensagemRepository : IMensagensRepository
    {
        private string _connectionString;
        public async Task AtualizaMensagem(MensagemDTO msg)
        {
            setConfigureOption();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Mensagem SET StatusEnvio = @statusenvio WHERE Id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StatusEnvio", msg.StatusEnvio);
                    command.Parameters.AddWithValue("@id", msg.Id);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private void setConfigureOption()
        {
            try
            {
                string jsonContent = File.ReadAllText("C:\\Users\\ifspn\\OneDrive\\Desktop\\WHATSAPP_MESSAGE_SENDER\\WhatsAppBot\\Infra\\appsettings.json");
                JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);
                JsonElement connectionStringsElement;
                if (!jsonDocument.RootElement.TryGetProperty("ConnectionStrings", out connectionStringsElement))
                {
                    Console.WriteLine("Seção 'ConnectionStrings' não encontrada no arquivo appsettings.json.");
                    return;
                }
                JsonElement strBDElement;
                if (!connectionStringsElement.TryGetProperty("StrBD", out strBDElement))
                {
                    Console.WriteLine("Chave 'StrBD' não encontrada na seção 'ConnectionStrings'.");
                    return;
                }
                _connectionString = strBDElement.GetString();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao pegar a Conexao de String no arquivo de .appsettings, Error: {e.Message}");
            }
        }

        public async Task<List<MensagemDTO>> listMensagensNaoEnviadas()
        {
            try
            {
                setConfigureOption();
                List<MensagemDTO> Msgs = new List<MensagemDTO>();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM \"Mensagem\" WHERE \"StatusEnvio\" = 'P' ORDER BY \"Id\" DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();
                        SqlDataReader reader = await command.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            MensagemDTO cliente = new();
                            Msgs.Add(cliente.ConvertToDTO(reader));
                        }

                        await reader.CloseAsync();
                    }
                }

                return Msgs;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<MensagemDTO> ObterClientePorId(int id)
        {
            setConfigureOption();
            MensagemDTO msg = new MensagemDTO();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM CLIENTES WHERE ID = {id}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        MensagemDTO cliente = new();
                        msg = cliente.ConvertToDTO(reader);
                    }

                    reader.Close();
                }
            }

            return msg;
        }
    }
}
