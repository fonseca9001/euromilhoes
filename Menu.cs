using System;

namespace Euromilhoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Euromilhoes euromilhoes = new Euromilhoes();

                    while (true)
        {
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃  ↘  🎰  Escolha uma opção  🎰 ↙ ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃    1. Gerar chaves automáticas   ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃        2. Gerar chave manual     ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃         3. Fazer aposta          ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃       4. Verificar apostas       ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃          5. Consultar saldo      ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃         6. Adicionar saldo       ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃          7. Retirar saldo        ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃    8. Mostrar todas as apostas   ┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃9. Mostrar todas as chaves geradas┃");
            Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
            Console.WriteLine("┃              0. Sair             ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("┃ ❌ Opção inválida. ❌ ┃");
                Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━┛");
                continue;
            }

            switch (opcao)
            {
                case 0:
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━┓");
                    Console.WriteLine("┃🤡brigado por j🤡gar! ┃");
                    Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━┛");
                    return;
                case 1:
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━┓");
                    Console.WriteLine("┃Quantas 🔑 deseja gerar?┃");
                    Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━┛");
                    int quantidade;
                    if (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
                    {
                        Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                        Console.WriteLine("┃ ❌ Quantidade inválida. ❌ ┃");
                        Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                        continue;
                    }
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━┓");
                    Console.WriteLine("┃   Digite o seu NIF:   ┃");
                    Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━┛");
                    string nif = Console.ReadLine();
                    euromilhoes.GerarChavesAutomaticas(quantidade, nif);
                    Console.WriteLine($"Foram geradas {quantidade} chaves automáticas para o NIF {nif}.");
                    break;
                case 2:
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                    Console.WriteLine("┃    Digite a chave manual no formato '1,2,3,4,5':   ┃");
                    Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                    string chave = Console.ReadLine();
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━┓");
                    Console.WriteLine("┃   Digite o seu NIF:   ┃");
                    Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━┛");
                    nif = Console.ReadLine();
                    euromilhoes.GerarChaveManual(chave, nif);
                    break;
                case 3:
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━┓");
                    Console.WriteLine("┃   Digite o seu NIF:   ┃");
                    Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━┛");
                    nif = Console.ReadLine();
                    euromilhoes.FazerAposta(nif);
                    break;
                case 4:
                    euromilhoes.VerificarApostas();
                    break;
                case 5:
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━┓");
                    Console.WriteLine("┃   Digite o seu NIF:   ┃");
                    Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━┛");
                    nif = Console.ReadLine();
                    double saldo = euromilhoes.ConsultarSaldo(nif);
                    Console.WriteLine($"Saldo do NIF {nif}: {saldo}€");
                    break;
                case 6:
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━┓");
                    Console.WriteLine("┃   Digite o seu NIF:   ┃");
                    Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━┛");
                    nif = Console.ReadLine();
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                    Console.WriteLine("┃    Digite o valor a adicionar:   ┃");
                    Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                    double valor;
                    if (!double.TryParse(Console.ReadLine(), out valor) || valor <= 0)
                    {
                        Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━┓");
                        Console.WriteLine("┃ ❌ Valor inválido. ❌ ┃");
                        Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━┛");
                        continue;
                    }
                    euromilhoes.AtualizarSaldo(nif, valor);
                    Console.WriteLine($"Saldo do NIF {nif}: {euromilhoes.ConsultarSaldo(nif)}€");
                    break;
                case 7:
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━┓");
                    Console.WriteLine("┃   Digite o seu NIF:   ┃");
                    Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━┛");
                    nif = Console.ReadLine();
                    Console.WriteLine("Digite o valor a retirar:");
                    if (!double.TryParse(Console.ReadLine(), out valor) || valor <= 0)
                    {
                        Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━┓");
                        Console.WriteLine("┃ ❌ Valor inválido. ❌ ┃");
                        Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━┛");
                        continue;
                    }
                    if (euromilhoes.ConsultarSaldo(nif) < valor)
					{
                        Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
						Console.WriteLine("┃💸  Saldo insuficiente.  💸┃");
                        Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
						continue;
					}
						euromilhoes.AtualizarSaldo(nif, -valor);
						Console.WriteLine($"Saldo do NIF {nif}: {euromilhoes.ConsultarSaldo(nif)}€");
						break;
				case 8:
					euromilhoes.MostrarTodasApostas();
					break;
				case 9:
					euromilhoes.MostrarTodasChavesGeradas();
					break;
				default:
					Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━┓");
                    Console.WriteLine("┃ ❌ Opção inválida. ❌ ┃");
                    Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━┛");
					break;
			}
		}
	}
}

}