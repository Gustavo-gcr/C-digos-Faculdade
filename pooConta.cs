using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_1_POO
{
    internal class Conta
    {
        Stack<string> pilha = new Stack<string>();//cria a pilha

        public Conta(string nome, string CPF, double saldo, int idConta)//construtor
        {
            this.Nome = nome;
            this.CPF = CPF;
            this.saldo = saldo;
            this.idConta = idConta;
        }
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private double saldo;
        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
        private int idConta;

        public int IdConta
        {
            get { return idConta; }
            set { idConta = value; }
        }

        private string cpf;

        public string CPF
        {
            get { return cpf; }
            set { cpf = value; }
        }
        //fim dos gets/sets
        public void Saque(double saque)//metodo saque
        {
            double limite = 100;
            double maximo = saldo + limite;
            if (saque > saldo)//saque maior q saldo
            {

                Console.WriteLine("Saldo insuficiente porém foi retirado do seu limite R$" + limite + " ,no seu proximo depoisito será descontado 3%");
                if (saque > maximo)//saque maior q saldo+limite
                {
                    Console.WriteLine("O maximo que podera ser sacado é de R$" + maximo);

                    Console.WriteLine("Deseja sacar essa contia da conta?\n (sim) (outra) (nao)");
                    string ler = Console.ReadLine();
                    ler = ler.ToLower();
                    if (ler == "sim")//aceitar o saque limite + saldo
                    {
                        double total = limite * -1;
                        Console.WriteLine("valor sacado:" + maximo);
                        this.saldo = total;
                        Console.WriteLine("Saldo atual da conta R$" + total);
                        pilha.Push(this.Nome + " saldo R$" + this.saldo);
                    }
                    else if (ler == "outra")//outro valor 
                    {
                        Console.WriteLine("Qual o novo valor a ser sacado?");
                        double valor = double.Parse(Console.ReadLine());
                        if (valor < limite + this.saldo)
                        {
                            while (valor > maximo)
                            {
                                Console.WriteLine("Não sera aceito valor mais alto, escreva novamente");
                                valor = double.Parse(Console.ReadLine());
                            }
                            Console.WriteLine("Valor sacado R$" + valor);
                            pilha.Push(this.Nome + " sacou R$" + this.saldo);
                            this.saldo = maximo - valor;
                            Console.WriteLine("Saldo atual da conta R$" + this.saldo);

                        }

                    }
                    else//nao foi efetuado saque
                        Console.WriteLine("Não foi efetuado novo saque");


                }
                else//saque menor que saldo+limite, porem maior que saldo apenas
                    this.saldo = (this.saldo + limite) - saque;
                this.saldo = this.saldo * -1;
                Console.WriteLine("Saldo autal da conta R$" + this.saldo);
                pilha.Push(this.Nome + " sacou R$" + this.saldo);

            }
            else//saldo maior que saque
            {
                double total = this.saldo - saque;
                Console.WriteLine("Saque no valor de R$" + saque + " realizado, saldo total de " + total);
                pilha.Push(this.Nome + " saldo R$" + total);
                this.saldo = total;
            }

        }

        public void Deposito()//metodo deposito
        {
            if (this.saldo < 0)
            {
                double taxa = (this.saldo * 0.03);
                double total = taxa + this.saldo;
                Console.WriteLine("Você está negativado e terá que pagar uma taxa");
                Console.WriteLine("Valor da taxa R$" + taxa + " ,valor total a ser pago R$" + total);
                Console.WriteLine("Deseja pagar? (sim/não)");
                string ler = Console.ReadLine().ToLower();

                if (ler == "sim")//taxa paga, saldo zerado
                {
                    this.saldo = 0;
                    pilha.Push(this.Nome + " depositou R$" + this.saldo);
                    Console.WriteLine("Taxa paga com sucesso.");
                }
            }
            else
            {
                Console.WriteLine("Qual o valor do depósito?");//novo deposito
                int valor = int.Parse(Console.ReadLine());
                this.saldo = valor;
                pilha.Push(this.Nome + " depositou R$" + this.saldo);
                Console.WriteLine("Depósito de R$" + valor + " realizado com sucesso.");

            }
        }

        public void Extrato()//metodo extrato
        {
           
            if (pilha.Count > 0)// se a pilha nao estiver vazia o metodo irá funcionar
            {
                Console.WriteLine("Ultima operação realizada na conta");
                Console.WriteLine(pilha.Peek());
                Console.WriteLine("Ultimas 10 operações na conta");
                Stack<string> novapilha = new Stack<string>(pilha);
                for (int i = 0; i < pilha.Count; i++)
                {
                    if (i == 9)
                    {
                        i = pilha.Count;
                    }
                    Console.WriteLine(novapilha.Peek());
                    novapilha.Pop();

                }
            }
               
            else
                Console.WriteLine("Não há operações na conta");

            
        }

    }
}