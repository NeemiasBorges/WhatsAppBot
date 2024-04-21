using Infra.DTO;

namespace Infra.Interfaces
{
    public interface IMensagensRepository
    {
        public Task<List<MensagemDTO>> listMensagensNaoEnviadas();
        public Task<MensagemDTO> ObterClientePorId(int id);
        public Task AtualizaMensagem(MensagemDTO msg);
    }
}
