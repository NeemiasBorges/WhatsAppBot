using Infra.DTO;
using Infra.Interfaces;

namespace WhatsAppProject
{
    public partial class Form1 : Form
    {
        private readonly IMensagensRepository _mensagensRepository;
        public Form1(IMensagensRepository mensagensRepository)
        {
            _mensagensRepository = mensagensRepository;
            InitializeComponent();
        }
        public async void Form1_LoadAsync(object sender, EventArgs e)
        {
            WhatsAppSendMessage zpSender = new WhatsAppSendMessage();
            List<MensagemDTO> listMensagens = await _mensagensRepository.listMensagensNaoEnviadas();

            foreach (var item in listMensagens)
            {
                zpSender.SendMessageToZap(item.Mensagens, item.Destinatario);
                item.StatusEnvio = "Y";
                await _mensagensRepository.AtualizaMensagem(item);
            }
        }
    }
}