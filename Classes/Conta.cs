using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private string Nome {get; set;}

        private double Saldo {get; set ;}

        private double Credito {get; set;}

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome){
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque){
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("O saldo da conta de {0} e {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Despositar(double valorDepositado){
            this.Saldo += valorDepositado;
            Console.WriteLine("O saldo da conta de {0} e {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTRansferencia, Conta contaDestino){
            if(this.Sacar(valorTRansferencia)){
                contaDestino.Despositar(valorTRansferencia);
            }
        }

        public override string ToString(){
            string retorno = "";
            retorno += "Tipoconta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito + " | ";
            return retorno;
        }
    
    }
}