﻿using MaterialDeContrucaoAppWeb.Data;
using MaterialDeContrucaoAppWeb.Models;

namespace MaterialDeContrucaoAppWeb.Services.Data;

public class ServiceProduto : IServiceProduto
{

    private MatConstDBContext _context;

    public ServiceProduto(MatConstDBContext context)
    {
        _context = context;
    }

    public void Alterar(Produto produto)
    {
        var produtoEncontrado = Obter(produto.ProdutoId);
        produtoEncontrado.Nome = produto.Nome;
        produtoEncontrado.Descricao = produto.Descricao;
        produtoEncontrado.Preco = produto.Preco;
        produtoEncontrado.EntregaExpressa = produto.EntregaExpressa;
        produtoEncontrado.DataCadastro = produto.DataCadastro;
        produtoEncontrado.ImagemUrl = produto.ImagemUrl;
        produtoEncontrado.MarcaId = produto.MarcaId;
        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var produtoEncontrado = Obter(id);
        _context.Produtos.Remove(produtoEncontrado);
        _context.SaveChanges();
    }

    public void Incluir(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    public Produto Obter(int id)
    {
        return _context.Produtos.SingleOrDefault(item => item.ProdutoId == id);
    }

    public IList<Produto> ObterTodos()
    {
        return _context.Produtos.ToList();
    }

    public IList<Marca> ObterTodasMarcas()
        => _context.Marcas.ToList();
}
