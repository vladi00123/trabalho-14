using System;

namespace Aula14
{
     public class Fornecedor : imprimivel
  {
      private string _nome;
      private string _cnpj;

            public string Cnpj
            {
                get
                {
                return this._cnpj;
                }
            }

            public string Nome
            {
                get
                {
                return this._nome;
                }
            }


            public Fornecedor(string nome, string cnpj)
            {
                this._cnpj = cnpj
                this._nome = nome;
                
            }
            
            public void Imprimir()
            {
                Console.WriteLine("CNPJ:\t{0}", this.Cnpj);
                Console.WriteLine("Nome:\t{0}", this.Nome); 
            }
   }
}
