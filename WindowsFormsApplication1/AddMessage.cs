using InfraFramework.DTO;
using InfraFramework.Repository.Interfaces;
using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class AddMessage : Form
    {
        IConexaoBDRepository _conexao;
        public AddMessage(IConexaoBDRepository conexao)
        {
            _conexao = conexao;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MensagemDTO mensagem = new MensagemDTO();
            mensagem.Texto = "";
            _conexao.Add(mensagem);
        }
    }
}
