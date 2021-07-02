using System;
using System.Collections.Generic;
using System.Linq;
using Aula14;

namespace Aula14
{
public class ComprasAtributos
{
    private Dictionary<Produto, int> _itens;
    
    private Cliente _cliente;

    public Dictionary<Produto, int> Itens
    {
        get { return this._itens; }
    }

    public double Total
    {
        get
        {
            double somatorioitens = 0;
            foreach (KeyValuePair<Produto, int> parOrdenado in this._itens)
                somatorioitens += parOrdenado.Key.ValorTotal() * parOrdenado.Value;

            return somatorioitens;
        }
    }

    
    public ComprasAtributos(Cliente cliente_)
    {
        this._itens = new Dictionary<Produto, int>();
        this.cliente = cliente;
    }
    
    public void Adicionar(Produto item, int quantidade)
    {
        if (this._itens.ContainsKey(item))
            this._itens[item] = this._itens[item] + quantidade;
        else
            this._itens[item] = quantidade;
    }

    public void Adicionar(Produto item)
    {
        this.Adicionar(item, 1);
    }
    
    public void Adicionar(List<Produto> itens)
    {
        foreach (var item in itens)
        {
            this.Adicionar(item);
        }
    }
    
    public void Adicionar(Dictionary<Produto, int> itens)
    {
        foreach (KeyValuePair<Produto, int> parOrdenado in itens)
        {
            this.Adicionar(parOrdenado.Key, parOrdenado.Value);
        }
    }


    public void Limpar()  { _itens.Clear(); }




    public void ImprimirAtributos()
    { 
        DateTime dateTime = DateTime.UtcNow.Date;
        Console.WriteLine("Cliente: \t{0}", _cliente.Nome);     
        Console.WriteLine("CPF: \t{0}", _cliente.Cpf);        
       
        foreach (KeyValuePair<Produto, int> parOrdenado in this._itens)
        {
            parOrdenado.Key.Imprimir();
            Console.WriteLine("Data:\t{0:0.00}", dateTime.ToString("dd/MM/yyyy"));
            Console.WriteLine("Quantidade: \tx{0} Unidades", parOrdenado.Value);         
            Console.WriteLine("Subtotal:\tR$ {0:0.00}", parOrdenado.Value * parOrdenado.Key.CalculaValorTotal());
           
        }
        Console.WriteLine("Total:\tR$ {0:0.00}", this.Total);
       
}
}
