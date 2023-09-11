using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleContas
{
    class Conta
    {
        public long Numero { get; private set; }
        public decimal Saldo { get; private set; }

        private Agencia agencia;

        public Agencia GetAgencia()
        {
            return agencia;
        }

        public void SetAgencia(Agencia value)
        {
            agencia = value;
        }

        public Cliente Titular { get; set; }


        private static decimal saldoTotalGeral = 0;
        private static Conta contaComMaiorSaldo;

        public Conta(long numero, decimal saldoInicial, Cliente titular, Agencia agencia)
        {
            if (saldoInicial < 10.0m)
            {
                throw new ArgumentException("Saldo inicial deve ser maior que R$10,00. ");
            }
            Numero = numero;
            Titular = titular;
            Saldo = saldoInicial;
            SetAgencia(agencia);
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
            saldoTotalGeral += valor;
            AtualizarContaComMaiorSaldo();
        }

        public bool Sacar(decimal valor)
        {
            if ((Saldo - valor - 0.1m) < 0)
            {
                return false;
            }

            Saldo -= (valor + 0.1m);
            saldoTotalGeral -= (valor + 0.1m);
            AtualizarContaComMaiorSaldo();
            return true;
        }

        public bool Transferir(Conta destino, decimal valor)
        {
            if (Sacar(valor))
            {
                destino.Depositar(valor);
                return true;
            }
            return false;
        }


        private void AtualizarContaComMaiorSaldo()
        {
            if (contaComMaiorSaldo == null || Saldo > contaComMaiorSaldo.Saldo)
            {
                contaComMaiorSaldo = this;
            }
        }


        public static decimal ObterSaldoTotalGeral()
        {
            return saldoTotalGeral;
        }


        public static long ObterNumeroContaComMaiorSaldo()
        {
            return contaComMaiorSaldo != null ? contaComMaiorSaldo.Numero : -1;
        }

        public class Banco
        {
            public int Numero { get; set; }
            public string Nome { get; set; }
        }

        public class Agencia
        {
            public int Numero { get; set; }
            public string CEP { get; set; }
            public string Telefone { get; set; }
            public Banco Banco { get; set; }
        }

    }
}