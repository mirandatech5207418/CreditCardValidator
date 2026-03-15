using System;

namespace CreditCardValidator
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Validador de Cartão de Crédito");
      Console.WriteLine("Digite o número do cartão (sem espaços ou traços):");
      string cardNumber = Console.ReadLine().Trim();

      if (string.IsNullOrEmpty(cardNumber) || !long.TryParse(cardNumber, out _))
      {
        Console.WriteLine("Número inválido. Deve conter apenas dígitos.");
        return;
      }

      string bandeira = IdentificarBandeira(cardNumber);
      bool valido = ValidarLuhn(cardNumber) && ValidarComprimento(cardNumber, bandeira);

      if (valido)
      {
        Console.WriteLine($"O cartão é válido! Bandeira: {bandeira}");
      }
      else
      {
        Console.WriteLine("O cartão é inválido.");
      }
    }

    static string IdentificarBandeira(string numero)
    {
      if (numero.StartsWith("4")) return "Visa";

      if (numero.Length >= 4)
      {
        int primeiros2 = int.Parse(numero.Substring(0, 2));
        int primeiros4 = int.Parse(numero.Substring(0, 4));

        // MasterCard
        if ((primeiros2 >= 51 && primeiros2 <= 55) || (primeiros4 >= 2221 && primeiros4 <= 2720))
          return "MasterCard";

        // American Express
        if (primeiros2 == 34 || primeiros2 == 37) return "American Express";

        // Discover
        if (primeiros4 == 6011 || primeiros2 == 65 ||
            (numero.Length >= 3 && int.Parse(numero.Substring(0, 3)) >= 644 && int.Parse(numero.Substring(0, 3)) <= 649))
          return "Discover";

        // Hipercard
        if (primeiros4 == 6062) return "Hipercard";

        // Elo (baseado na tabela e ranges comuns: 4011, 4312, 4389, e mais como 4514, 4576, 5067, 5090, 6277, 6362, 6363)
        string[] eloPrefixes = { "4011", "4312", "4389", "4514", "4573", "4576", "5041", "5067", "5090", "6277", "6362", "6363", "6504", "6505", "6516", "6550" };
        foreach (string prefix in eloPrefixes)
        {
          if (numero.StartsWith(prefix)) return "Elo";
        }
      }

      return "Desconhecida";
    }

    static bool ValidarComprimento(string numero, string bandeira)
    {
      int len = numero.Length;
      switch (bandeira)
      {
        case "Visa": return len == 13 || len == 16 || len == 19;
        case "MasterCard": return len == 16;
        case "American Express": return len == 15;
        case "Discover": return len >= 16 && len <= 19;
        case "Elo": return len == 16;
        case "Hipercard": return len == 13 || len == 16 || len == 19; // Similar a Visa, comum no Brasil
        default: return false;
      }
    }

    static bool ValidarLuhn(string numero)
    {
      int sum = 0;
      bool alternar = false;
      for (int i = numero.Length - 1; i >= 0; i--)
      {
        int digito = int.Parse(numero[i].ToString());
        if (alternar)
        {
          digito *= 2;
          if (digito > 9) digito -= 9;
        }
        sum += digito;
        alternar = !alternar;
      }
      return sum % 10 == 0;
    }
  }
}
