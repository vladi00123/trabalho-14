using System;
using System.Collections.Generic;
using System.Linq;
using Aula14;

namespace Aula14
{
public class Compras
{
    private ComprasAtributos _compra_atributos;
    private Carrinho _carrinho;
    private Estoque _estoque;




        public Compras(Carrinho carrinho_, Estoque estoque_, Cliente cliente_ )
        {
            this.compra_atributos = new Compra_Atributos(cliente);
            this.carrinho = carrinho;
            this.estoque = estoque;      
        }



        public bool Ver_Estoque()
        {
                    
        foreach (var item in _carrinho.Itens)
            {
                var System_Linq_Query = _estoque.Itens.FirstOrDefault(x => x.Key.Nome == item.Key.Nome);   

                if(item.Value > System_Linq_Query.Value)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"O Estoque não possui \"{item.Key.Nome}\" suficientes para a compra - [\"{item.Value}\" itens no carrinho / \"{System_Linq_Query.Value}\" restantes no estoque] ]");
                    return false;
                }
            
            }
            
            if(_carrinho.Itens.Count <= 0)
            {
                Console.WriteLine($"O carrinho não tem intens suficientes para efetuar a compra - [\"{_carrinho.Itens.Count}\" produtos / \"{_estoque.Itens.Count}\" restantes no estoque] ]");
                return false;
            }
        

        return true;
        }


         public void Comprar_Produtos()
        {

            if(!checar_Estoque()) return;
      
            foreach (var item in _carrinho.Itens)
            {

            var System_Linq_Query = _estoque.Itens.FirstOrDefault(x => x.Key.Nome == item.Key.Nome);             
                
                for (var i = 0; i < item.Value; i++)
                {                        
                    _estoque.Remover(item.Key);                              
                }   

            var RestCount = _estoque.Itens.FirstOrDefault(x => x.Key.Nome == item.Key.Nome);
            Console.WriteLine($"Voce adquiriu o produto \"{item.Key.Nome}\" [\"{item.Value}\" Unidades compradas / \"{RestCount.Value}\" restantes no estoque] ");
                                
           }
        
       
        _compra_atributos.Adicionar(_carrinho.Itens);
        
        _carrinho.Limpar();
        
        }

       public void ImprimirRecibo()
       {
         _compra_atributos.ImprimirAtributos(); 
         _compra_atributos.Limpar(); 
       }
       
    
    }
}
