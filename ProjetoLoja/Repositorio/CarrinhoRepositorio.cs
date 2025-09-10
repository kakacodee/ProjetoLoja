using Newtonsoft.Json;
using ProjetoLoja.Models;

//newtonsoft.json é uma biblioteca para a linguagem de programação .NET que serve para serializar (converter objetos para o formato JSON) e desserializar (converter texto JSON de volta para objetos) dados JSON de forma eficiente e flexível.


namespace ProjetoLoja.Repositorio
{
    public class CarrinhoRepositorio
    {
        private const string CartSessionKey = "Carrinho";

        public List<ItemCarrinho> CarrinhoItems(ISession session)
        {
            var cartJson = session.GetString(CartSessionKey);
            return cartJson == null ? new List<ItemCarrinho>() : JsonConvert.DeserializeObject<List<ItemCarrinho>>(cartJson);
        }

        public void AdicionarCarrinho(ISession session, Produto produto, int quantidade)
        {
            var cart = CarrinhoItems(session);
            var existingItem = cart.FirstOrDefault(item => item.ProdutoId == produto.Id);

            if (existingItem != null)
            {
                existingItem.Quantidade += quantidade;
            }
            else
            {
                cart.Add(new ItemCarrinho
                {
                    ProdutoId = produto.Id,
                    //Produto = produto,
                    Quantidade = quantidade,
                    Preco = produto.Preco
                });
            }
            SalvarCarrinho(session, cart);
        }

        public void AlterarQuantidadeItem(ISession session, int produtoId, int novaQuantidade)
        {
            var cart = CarrinhoItems(session);
            var itemAlterar = cart.FirstOrDefault(item => item.ProdutoId == produtoId);

            if (itemAlterar != null)
            {
                if (novaQuantidade <= 0)
                {
                    cart.Remove(itemAlterar);
                }
                else
                {
                    itemAlterar.Quantidade = novaQuantidade;
                }
                SalvarCarrinho(session, cart);
            }
        }

        public void RemoverItemCarrinho(ISession session, int produtoId)
        {
            var cart = CarrinhoItems(session);
            var itemRemover = cart.FirstOrDefault(item => item.ProdutoId == produtoId);
            if (itemRemover != null)
            {
                cart.Remove(itemRemover);
                SalvarCarrinho(session, cart);
            }
        }

        public void LimparCarrinho(ISession session)
        {
            session.Remove(CartSessionKey);
        }

        public decimal TotalCarrinho(ISession session)
        {
            return CarrinhoItems(session).Sum(item => item.Total);
        }

        private void SalvarCarrinho(ISession session, List<ItemCarrinho> cart)
        {
            session.SetString(CartSessionKey, JsonConvert.SerializeObject(cart));
        }
    }
}