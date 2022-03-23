using System;


namespace Bank_Proj
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }
        public bool Sacar(double valorSaque)
        {
            //Verificando se há saldo suficiente para saque.
            if (Saldo - valorSaque < Credito * -1)
            {
                Console.WriteLine("Saldo Insulficiente.");
                return false;
            }
                Saldo -= valorSaque;
                Console.WriteLine($"Saldo atual da conta de {Nome} é {Saldo}");
           
            return true;
        }
        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {Nome} é {Saldo}");
        }
        public void Transferir(double valorTranferencia, Conta contaDestino)
        {
            if (Sacar(valorTranferencia))
            {
                contaDestino.Depositar(valorTranferencia);
            }
        }
        public override string ToString()
        {
            return "Tipo de Conta " + TipoConta + " | " +
                    "Nome: " + Nome + " | " +
                    "Saldo: " + Saldo + " | " +
                    "Crédito " + Credito;

        }
    }
}
