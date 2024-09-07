namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("A placa não pode ser vazia ou composta apenas por espaços.");
                return;
            }

            placa = placa.ToUpper(); // Garantir que a comparação de placas seja consistente

            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Já existe um veículo com essa placa.");
                return;
            }

            veiculos.Add(placa);
            Console.WriteLine($"Veículo de placa {placa} adicionado com sucesso.");
        }

        public void AtualizarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo a ser atualizado:");
            string atualizarPlaca = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(atualizarPlaca))
            {
                Console.WriteLine("A placa não pode ser vazia ou composta apenas por espaços.");
                return;
            }

            atualizarPlaca = atualizarPlaca.ToUpper();
            var veiculoEncontrado = veiculos.FirstOrDefault(x => x == atualizarPlaca);

            if (veiculoEncontrado != null)
            {
                Console.WriteLine("Digite a nova placa do veículo:");
                string novaPlaca = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(novaPlaca))
                {
                    Console.WriteLine("A nova placa não pode ser vazia ou composta apenas por espaços.");
                    return;
                }

                novaPlaca = novaPlaca.ToUpper();

                if (veiculos.Contains(novaPlaca))
                {
                    Console.WriteLine("Já existe um veículo com essa nova placa.");
                    return;
                }

                int index = veiculos.IndexOf(veiculoEncontrado);
                veiculos[index] = novaPlaca;
                Console.WriteLine("Placa atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Veículo não encontrado com a placa informada.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string removerPlaca = Console.ReadLine().ToUpper();
            if (string.IsNullOrWhiteSpace(removerPlaca))
            {
                Console.WriteLine("A placa não pode ser vazia ou composta apenas por espaços.");
                return;
            }

            if (veiculos.Any(x => x == removerPlaca))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(removerPlaca);
                Console.WriteLine($"O veículo {removerPlaca} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}