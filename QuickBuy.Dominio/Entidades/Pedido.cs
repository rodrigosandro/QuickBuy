using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public string NumeroEndereco { get; set; }
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPgamento { get; set; }

        /// <summary>
        /// Pedido deve ter pelo menos um Item de pedido 
        /// ou muitos Itens de Pedidos
        /// </summary>
        public ICollection<ItemPedido> ItensPedidos { get; set; }

        public override void validate()
        {
            LimparMensagensValidacao();

            if (!ItensPedidos.Any())
                AdicionarCritica("Critica - Pedido não pode ficar sem item de pedido");

            if (string.IsNullOrEmpty(CEP))
                AdicionarCritica("Critica - CEP deve estar preenchido");

            if (FormaPagamentoId == 0)
            {
                AdicionarCritica("Critica - Não foi informado a forma de pagamento");
            }
        }
    }
}
