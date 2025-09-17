using System;
using System.Globalization;

public struct Pessoa
{
    public string NomeCompleto;
    public DateTime DataNascimento;
}

class Program
{
    static void Main(string[] args)
    {
        Pessoa usuario = new Pessoa();

        Console.WriteLine("--- Calculadora de Idade ---");

        // Loop pra garantir que o nome não venha vazio
        while (true)
        {
            Console.Write("Digite seu nome completo: ");
            string nomeDigitado = Console.ReadLine();

            if (!string.IsNullOrEmpty(nomeDigitado))
            {
                usuario.NomeCompleto = nomeDigitado;
                break; // Se o nome estiver ok, sai do loop
            }
            else
            {
                Console.WriteLine("O nome não pode estar em branco. Tente novamente.");
            }
        }

        // Variável pra guardar a data depois de converter
        DateTime dataNasc;
        while (true)
        {
            Console.Write("Digite sua data de nascimento (formato DD/MM/AAAA): ");
            string dataDigitada = Console.ReadLine();

            // Tenta converter o que o usuário digitou para um formato de data válido
            if (DateTime.TryParseExact(dataDigitada, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNasc))
            {
                usuario.DataNascimento = dataNasc;
                break;
            }
            else
            {
                Console.WriteLine("Formato de data inválido. Por favor, tente novamente.");
            }
        }

        // Calculo inicial da idade, só pelos anos
        DateTime dataAtual = DateTime.Today;
        int idade = dataAtual.Year - usuario.DataNascimento.Year;

        // Aqui corrige a idade se a pessoa ainda não fez aniversário no ano atual
        if (usuario.DataNascimento.DayOfYear > dataAtual.DayOfYear)
        {
            idade = idade - 1;
        }

        Console.WriteLine("\nOlá, " + usuario.NomeCompleto + "!");
        Console.WriteLine("Sua idade é: " + idade + " anos.");

        // Verifica se a pessoa pode tirar CNH
        if (idade >= 18)
        {
            Console.WriteLine("Você é maior de idade.");
            Console.WriteLine("Você já pode tirar a carteira de habilitação.");
        }
        else
        {
            Console.WriteLine("Você é menor de idade.");
        }

        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}