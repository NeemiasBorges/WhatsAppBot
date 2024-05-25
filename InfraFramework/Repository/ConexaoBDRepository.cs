using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfraFramework.DTO;
using InfraFramework.Repository.Interfaces;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using InfraFramework.Infra;

namespace InfraFramework.Repository
{
    public class ConexaoBDRepository : IConexaoBDRepository
    {
        internal string _stringCon = "";

        public async Task Add(MensagemDTO entity)
        {
            try
            {
                List<MensagemDTO> Msgs = new List<MensagemDTO>();
                using (SqlConnection connection = await DbInstance.setDatabaseIntance())
                {
                    string query = "SELECT * FROM \"Mensagem\" WHERE \"StatusEnvio\" = 'P' ORDER BY \"Id\" DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();
                        SqlDataReader reader = await command.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            MensagemDTO mensagem = new MensagemDTO();
                            Msgs.Add(mensagem.ConvertToDTO(reader));
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<MensagemDTO>> List()
        {
            try
            {
                List<MensagemDTO> Msgs = new List<MensagemDTO>();
                using (SqlConnection connection = new SqlConnection(_stringCon))
                {
                    string query = "SELECT * FROM \"Mensagem\" WHERE \"StatusEnvio\" = 'P' ORDER BY \"Id\" DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();
                        SqlDataReader reader = await command.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            MensagemDTO mensagem = new MensagemDTO();
                            Msgs.Add(mensagem.ConvertToDTO(reader));
                        }

                        reader.Close();
                    }
                }

                return Msgs.ToArray();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MensagemDTO> Update(MensagemDTO entity)
        {
            using (SqlConnection connection = new SqlConnection(_stringCon))
            {
                string query = "UPDATE Mensagem SET StatusEnvio = @statusenvio WHERE Id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", entity.Id);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
            return entity;
        }
    }
}
