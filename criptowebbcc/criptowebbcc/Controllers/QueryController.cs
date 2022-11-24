using criptowebbcc.Models;
using criptowebbcc.Models.Consulta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace criptowebbcc.Controllers
{
    public class QueryController : Controller
    {
        private readonly Contexto contexto;
        public QueryController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Cliente(string filtro)
        {

            List<Cliente> lista = new List<Cliente>();

            if (filtro == null)
            {
             lista = contexto.clientes.OrderBy(o => o.estado)
              .ThenBy(p => p.cidade)
              .ThenByDescending(n => n.nome).ToList();
            }
            else 
            {
            lista = contexto.clientes.Where(c => c.nome.Contains(filtro))
                .OrderBy(o => o.estado)
                .ThenBy(p => p.cidade)
                .ThenByDescending(n => n.nome).ToList();

            }

            return View(lista);
        }

        public IActionResult Pesquisa() 
        {
            return View();
        }

        public IActionResult Transacoes()
        {
            IEnumerable<TransacaoQry> listaTransacao =
                from item in contexto.transacoes
                .Include(o => o.cliente)
                .Include(f => f.Produto)
                .OrderBy(o => o.cliente.nome)
                .ToList()
                select new TransacaoQry
                {
                    produto = item.produtoId,
                    cliente = item.clienteId,
                    tipoProduto = item.tipoProduto,
                    quantidade = item.Produto.quantidade,
                    data = item.data,
                    valor = item.valor,
                    clienteNome = item.cliente.nome,
                    total = item.Produto.quantidade * item.valor
                };

            return View(listaTransacao);
        }

        public IActionResult grpByProduto()
        {
            IEnumerable<TransacaoQry> listaTransacao =
                from item in contexto.transacoes
                .Include(o => o.cliente)
                .Include(f => f.Produto)
                .OrderBy(o => o.cliente.nome)
                .ToList()
                select new TransacaoQry
                {
                    produto = item.produtoId,
                    cliente = item.clienteId,
                    tipoProduto = item.tipoProduto,
                    quantidade = item.Produto.quantidade,
                    data = item.data,
                    valor = item.valor,
                    clienteNome = item.cliente.nome,
                    total = item.Produto.quantidade * item.valor
                };


            IEnumerable<TransacaoGrpProduto> listaGrpProduto =
               from linha in listaTransacao
               .ToList()
               group linha by new { linha.produto, linha.clienteNome, linha.data }
               into grupo
               orderby grupo.Key.produto
               select new TransacaoGrpProduto
               {
                   produto = grupo.Key.produto,
                   data = grupo.Key.data,
                   clienteNome = grupo.Key.clienteNome,
                   valor = grupo.Sum(p => p.quantidade * p.valor)
               };

            return View(listaGrpProduto);
        }

        public IActionResult grpByMes()
        {
            IEnumerable<TransacaoQry> listaTransacao =
                from item in contexto.transacoes
                .Include(o => o.cliente)
                .Include(f => f.Produto)
                .OrderBy(o => o.cliente.nome)
                .ToList()
                select new TransacaoQry
                {
                    produto = item.produtoId,
                    cliente = item.clienteId,
                    tipoProduto = item.tipoProduto,
                    quantidade = item.Produto.quantidade,
                    data = item.data,
                    valor = item.valor,
                    clienteNome = item.cliente.nome,
                    total = item.Produto.quantidade * item.valor
                };


            IEnumerable<TransacaoGrpMes> listaGrpMes =
              from linha in listaTransacao
              .ToList()
              group linha by new { linha.tipoProduto, linha.data.Month, linha.valor }
              into grupo
              orderby grupo.Key.Month
              select new TransacaoGrpMes
              {
                  tipoProduto = grupo.Key.tipoProduto,
                  mes = grupo.Key.Month,
                  valor = grupo.Key.valor

              };

            return View(listaGrpMes);
        }
    }
}
