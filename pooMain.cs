using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_1_POO
{
    internal class Program
    {
        static int GerarIdConta()//gera id aleatorio pra conta
        {
            Random random = new Random();
            return random.Next(00001, 100000);
        }
        static Conta CriarConta()//cria conta
        {
            int numIdConta = GerarIdConta();
            Console.WriteLine("Escreva seu nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Escreva seu CPF");
            string CPF = Console.ReadLine();
            Console.WriteLine("Seu id será " + numIdConta);
            Console.WriteLine("Insira seu saldo");
            double saldo = double.Parse(Console.ReadLine());
            Conta conta = new Conta(nome, CPF, saldo, numIdConta);
            return conta;
        }
        static Conta PesquisarConta(List<Conta> lista)//pesquisa conta
        {
            Console.WriteLine("Voce deseja buscaar a conta pelo CPF ou idConta?");//pesquisa pelo cppf ou id
            string op = Console.ReadLine();
            op = op.ToLower();
            if (op == "cpf")
            {
                Console.WriteLine("Escreva o CPF:");
                string cpf = Console.ReadLine();

                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i].CPF == cpf)
                    {
                        return lista[i];
                    }
                }
            }
            else if (op == "idconta")
            {
                Console.WriteLine("Escreva o idConta:");
                int idConta = int.Parse(Console.ReadLine());

                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i].IdConta == idConta)
                    {
                        return lista[i];
                    }
                }
            }
            else
            {
                Console.WriteLine("conta inválida");
            }

            Console.WriteLine("Conta não encontrada.");
            return null;
        }
        static void Main(string[] args)
        {
            List<Conta> lista = new List<Conta>();//cria a lista de contas
            string op;
            do//repetição da aplicação
            {

                Console.WriteLine("\nOla seja bem vindo!\nVocê deseja criar uma conta ou pesquisar uma existente?\nResonda com (criar)ou(pesquisar)");
                string ler = Console.ReadLine();
                ler = ler.ToLower();


                if (ler == "criar")//chama o metodo criar e adiciona na lista
                {
                    Conta conta = CriarConta();
                    lista.Add(conta);
                }
                else if (ler == "pesquisar")//chama o metodo pesquisar
                {
                    Conta conta = PesquisarConta(lista);
                    if (conta != null)
                    {
                        Console.WriteLine("Deseja fazer um deposito ou saque?\nResponda(deposito)(saque)");
                        ler = Console.ReadLine();
                        ler = ler.ToLower();
                        if (ler == "deposito")// deposita na conta
                        {
                            conta.Deposito();
                        }
                        else if (ler == "saque")
                        {
                            Console.WriteLine("Quanto você deseja sacar?");
                            double saque = double.Parse(Console.ReadLine());
                            conta.Saque(saque);//saca na conta
                        }
                        else
                            Console.WriteLine("Opção Inválida");



                        Console.WriteLine("Deseja ver o extrato da sua conta?\n (sim) (nao)");
                        ler = Console.ReadLine();
                        ler = ler.ToLower();
                        if (ler == "sim")//chama o extrato
                        {
                            conta.Extrato();
                        }
                    }
                    else
                        Console.WriteLine("Não é possivel usar uma conta que não tenha sido criada");

                }

                Console.WriteLine("Deseja continuar a pesquisar ou a criar?\n (sim) (nao)");
                op = Console.ReadLine();
                op = op.ToLower();
            } while (op != "nao");
            //fim do programa
            Console.WriteLine("Fim do programa!");
            Console.ReadKey();
        }
    }

}