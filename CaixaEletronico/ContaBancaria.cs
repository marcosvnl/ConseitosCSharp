using System.Globalization;

namespace CaixaEletronico
{
    public class ContaBancaria
    {

        private double _jurosSaque = 5.00;
        private double _saldoEmConta;
        public int NumeroConta;
        public string Nome;
        public string Resposta;

        public ContaBancaria(int numeroConta, string nome, string resposta)
        {
            NumeroConta = numeroConta;
            Nome = nome;
            Resposta = resposta;
        }

        //public double ValorInicial
        //{
        //    get
        //    {
        //        return _saldoEmConta;
        //    }
        //    set
        //    {
        //        if (VerificarResposta() == false)
        //        {
        //            _saldoEmConta = 0.0;
        //        }
        //    }
        //}

        public bool VerificarResposta()
        {
            if (Resposta[0].ToString().ToUpper() == "S")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double DepositoInicial(double deposito)
        {
            if(VerificarResposta() == true)
            {
                _saldoEmConta += deposito;
                return _saldoEmConta;
            }
            else
            {
                return 0.00;
            }
            
        }

        public double Deposito(double deposito)
        {
            if(VerificarResposta() == true)
            { 
                return DepositoInicial(_saldoEmConta) + deposito; 
            }
            else
            {
                return _saldoEmConta = deposito;
            }
            
        }

        public double Saque(double saque)
        {
            _saldoEmConta = (_saldoEmConta - saque) - _jurosSaque;
            return _saldoEmConta;
        }

        public override string ToString()
        {
            return "Conta "
                    + NumeroConta
                    + " Titular: "
                    + Nome
                    + " Saldo R$"
                    + _saldoEmConta.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
