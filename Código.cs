using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Euromilhoes
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string NIF { get; set; }
        public double Saldo { get; set; }

        public Cliente(string nome, string nif, double saldo)
        {
            Nome = nome;
            NIF = nif;
            Saldo = saldo;
        }

        public void AdicionarSaldo(double valor)
        {
            Saldo += valor;
        }

        public void RetirarSaldo(double valor)
        {
            Saldo -= valor;
        }
    }

    public class Aposta
    {
        public List<int> Chaves { get; set; }
        public DateTime Data { get; set; }
        public bool Sorteado { get; set; }

        public Aposta(List<string> chaves, DateTime data, bool sorteado)
        {
            Chaves = chaves;
            Data = data;
            Sorteado = sorteado;
        }
    }

	public class Euromilhoes
	{
			private readonly string _basePath = @"C:\Euromilhoes\";
		
			private readonly decimal _precoAposta = 2.5m;
		
			private readonly decimal _premioMultiplicador = 0.75m;
		
			private static readonly Random _random = new Random();

			public Euromilhoes()
			{
				if (!Directory.Exists(_basePath))
				{
				Directory.CreateDirectory(_basePath);
				}
			}

			public void GerarChavesAutomaticas(int quantidade, string nif)
			{
				for (var i = 0; i < quantidade; i++)
				{
					var chave = GerarChaveAutomatica();
					var path = Path.Combine(_basePath, $"{nif}.txt");
					using var streamWriter = new StreamWriter(path, true);
					streamWriter.WriteLine(string.Join(",", chave));
				}
			}

			public void GerarChaveManual(string chave, string nif)
			{
				var numeros = chave.Split(",").Select(int.Parse).ToList();
				if (numeros.Count != 5 || numeros.Any(n => n < 1 || n > 50))
				{
					Console.WriteLine("Chave inválida.");
					return;
				}
				var path = Path.Combine(_basePath, $"{nif}.txt");
				using var streamWriter = new StreamWriter(path, true);
				streamWriter.WriteLine(chave);
			}

			private List<int> GerarChaveAutomatica()
			{
				var numeros = new List<int>();
				while (numeros.Count < 5)
				{
					var numero = _random.Next(1, 50);
					if (!numeros.Contains(numero))
					{
						numeros.Add(numero);
					}
				}
				return numeros.OrderBy(n => n).ToList();
			}

			public void FazerAposta(string nif)
			{
            var path = Path.Combine(_basePath, $"{nif}.txt");
            var chaves = new List<string>();
            using var streamReader = new StreamReader(path);
            while (!streamReader.EndOfStream)
            {
                chaves.Add(streamReader.ReadLine());
            }
            if (chaves.Count < 5)
            {
                Console.WriteLine("Não é possível fazer a aposta com menos de 5 chaves.");
                return;
            }
            var saldo = ConsultarSaldo(nif);
            if (saldo < _precoAposta)
            {
                Console.WriteLine("Saldo insuficiente para fazer a aposta.");
                return;
            }
            var novaAposta = new Aposta
            {
                Chaves = chaves,
                Data = DateTime.Today,
                Sorteado = false
            };
            var apostas = CarregarApostas();
            apostas.Add(novaAposta);
            SalvarApostas(apostas);
            AtualizarSaldo(nif, -_precoAposta);
			}

			public void VerificarApostas()
			{
				var apostas = CarregarApostas();
				var dataSorteio = ObterDataSorteio();
				if (DateTime.Today >= dataSorteio)
				{
                var numerosSorteados = GerarNumerosSorteados();
                foreach (var aposta in apostas.Where(a => a.Data == dataSorteio && !a.Sorteado))
                {
                var acertos = aposta.Chaves.Select(c => c.Split(",").Count(n => numerosSorteados.Contains(int.Parse(n)))).ToList();
                var premio = CalcularPremio(acertos);
                if (premio > 0)
                {
                var nif = ObterNifCliente(aposta);
                AtualizarSaldo(nif, premio);
                }
                aposta.Sorteado = true;
				}
                SalvarApostas(apostas);
				}
			}

			private void SalvarApostas(List<Aposta> apostas)
			{
			foreach (var aposta in apostas)
			{
				var path = Path.Combine(_basePath, $"{aposta.Chaves.First()}.txt");
				using var streamWriter = new StreamWriter(path);
				streamWriter.WriteLine($"Data:{aposta.Data}");
				foreach (var chave in aposta.Chaves)
				{
					streamWriter.WriteLine(chave);
				}
			}
		}

			private List<Aposta> CarregarApostas()
			{
				var apostas = new List<Aposta>();
				var files = Directory.GetFiles(_basePath, "*.txt");
				foreach (var file in files)
				{
					using var streamReader = new StreamReader(file);
					var dataLine = streamReader.ReadLine();
					if (dataLine != null && dataLine.Contains(":"))
					{
						var data = DateTime.Parse(dataLine.Split(":")[1]);
						var chaves = new List<string>();
						while (!streamReader.EndOfStream)
						{
							chaves.Add(streamReader.ReadLine());
						}
						apostas.Add(new Aposta { Data = data, Chaves = chaves, Sorteado = false });
					}
				}
				return apostas;
			}

        private DateTime ObterDataSorteio()
        {
            var dataHoje = DateTime.Today;
            var diaDaSemana = dataHoje.DayOfWeek;
            var diasAteSexta = ((int)DayOfWeek.Friday - (int)diaDaSemana + 7) % 7;
            return dataHoje.AddDays(diasAteSexta);
        }

        private List<int> GerarNumerosSorteados()
        {
            var numerosSorteados = new List<int>();
            var random = new Random();
            while (numerosSorteados.Count < 5)
            {
                var numero = random.Next(1, 50);
                if (!numerosSorteados.Contains(numero))
                {
                    numerosSorteados.Add(numero);
                }
            }
            numerosSorteados.Sort();
            numerosSorteados.AddRange(GerarEstrelasSorteadas());
            return numerosSorteados;
        }

        private List<int> GerarEstrelasSorteadas()
        {
            var estrelasSorteadas = new List<int>();
            var random = new Random();
            while (estrelasSorteadas.Count < 2)
            {
                var estrela = random.Next(1, 13);
                if (!estrelasSorteadas.Contains(estrela))
                {
                    estrelasSorteadas.Add(estrela);
                }
            }
            estrelasSorteadas.Sort();
            return estrelasSorteadas;
        }

		private string ObterNifCliente(Aposta aposta)
		{
			var path = Path.Combine(_basePath, $"{aposta.Chaves.First()}.txt");
			var nif = "";
			if (File.Exists(path))
			{
				using var streamReader = new StreamReader(path);
				var line = streamReader.ReadLine();
				if (line != null && line.Contains(":"))
				{
					nif = line.Split(":")[1];
				}
			}
			return nif;
		}
	
		public double ConsultarSaldo(string nif)
		{
        var path = Path.Combine(_basePath, $"{nif}.txt");
        if (!File.Exists(path)) return 0;
        using var streamReader = new StreamReader(path);
        var clienteInfo = streamReader.ReadLine();
        var saldoStr = clienteInfo.Split(",")[2];
        return double.Parse(saldoStr);
		}

		private decimal ConsultarSaldo(string nif)
		{
			var cliente = _clientes.FirstOrDefault(c => c.NIF == nif);
			return cliente?.Saldo ?? 0;
		}

		public void AtualizarSaldo(string nif, double valor)
		{
        var path = Path.Combine(_basePath, $"{nif}.txt");
        if (!File.Exists(path)) return;
        var cliente = ObterCliente(nif);
        cliente.Saldo += valor;
        var linhas = File.ReadAllLines(path);
        linhas[0] = $"{cliente.Nome},{cliente.NIF},{cliente.Saldo}";
        File.WriteAllLines(path, linhas);
    }

		private Cliente ObterCliente(string nif)
		{
			var path = Path.Combine(_basePath, $"{nif}.txt");
			using var streamReader = new StreamReader(path);
			var clienteInfo = streamReader.ReadLine();
			var clienteInfoSplit = clienteInfo.Split(",");
			var cliente = new Cliente(clienteInfoSplit[0], clienteInfoSplit[1], double.Parse(clienteInfoSplit[2]));
			return cliente;
		}
		
		private decimal CalcularPremio(List<int> acertos)
		{
			switch (acertos.Count(a => a > 0))
			{
				case 5:
					return 50000000m * _premioMultiplicador / acertos.Count(a => a == 5);
				case 4:
					return 5000m * _premioMultiplicador / acertos.Count(a => a == 4);
				case 3:
					return 100m * _premioMultiplicador / acertos.Count(a => a == 3);
				case 2:
					return 10m;
				default:
					return 0m;
			}
		}
		
		public List<Aposta> PesquisarApostasPorData(DateTime data)
		{
			List<Aposta> apostas = new List<Aposta>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string sql = "SELECT * FROM Apostas WHERE Data = @Data";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@Data", data);
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Aposta aposta = new Aposta();
							aposta.Id = reader.GetInt32(0);
							aposta.Cliente = PesquisarClientePorNIF(reader.GetString(1));
							aposta.Data = reader.GetDateTime(2);
							aposta.Valor = reader.GetDecimal(3);
							apostas.Add(aposta);
						}
					}
				}
			}
			return apostas;
		}

		public void ImportarChavesCliente(string nif, List<Chave> chaves)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string sql = "UPDATE Clientes SET Chaves = @Chaves WHERE NIF = @NIF";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
				command.Parameters.AddWithValue("@Chaves", JsonConvert.SerializeObject(chaves));
				command.Parameters.AddWithValue("@NIF", nif);
				command.ExecuteNonQuery();
				}
			}
		}
	}
}