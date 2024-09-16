namespace ProdutoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Lista de produtos
            List<Produto> produtos =
            [
                new Produto { Descricao = "Produto A", ValorVenda = 150, ValorCompra = 100, Tipo = TipoProduto.Final, DataCriacao = new DateTime(2024, 04, 15) },
                new Produto { Descricao = "Produto B", ValorVenda = 300, ValorCompra = 250, Tipo = TipoProduto.MateriaPrima, DataCriacao = new DateTime(2024, 05, 20) },
                new Produto { Descricao = "Produto C", ValorVenda = 120, ValorCompra = 90, Tipo = TipoProduto.Consumo, DataCriacao = new DateTime(2024, 06, 12) },
                new Produto { Descricao = "Produto D", ValorVenda = 500, ValorCompra = 200, Tipo = TipoProduto.Intermediario, DataCriacao = new DateTime(2024, 04, 10) },
                new Produto { Descricao = "Produto E", ValorVenda = 100, ValorCompra = 100, Tipo = TipoProduto.Final, DataCriacao = new DateTime(2024, 07, 10) },
            ];

            // Filtrando os produtos válidos
            var produtosValidos = produtos.Where(p =>
                p.ValorVenda > p.ValorCompra && // Regra 1
                p.DataCriacao >= new DateTime(2024, 01, 01) && // Regra 2
                p.Descricao.Length >= 5 && // Regra 3
                p.ValorCompra > 0 && p.ValorVenda > 0 // Regra 4
            ).ToList();

            // Filtrando produtos criados no segundo trimestre de 2024
            var produtosSegundoTrimestre = produtosValidos.Where(p =>
                p.DataCriacao >= new DateTime(2024, 04, 01) &&
                p.DataCriacao <= new DateTime(2024, 06, 30)
            );

            // Ordenando produtos por tipo
            var produtosOrdenadosPorTipo = produtosSegundoTrimestre.OrderBy(p => p.Tipo);

            // Exibindo os 3 produtos com maior margem de lucro
            var top3MaiorMargem = produtosValidos.OrderByDescending(p => p.ValorVenda - p.ValorCompra)
                                                 .Take(3);

            // Exibir Resultados
            Console.WriteLine("Produtos válidos do segundo trimestre de 2024, ordenados por Tipo:");
            foreach (var produto in produtosOrdenadosPorTipo)
            {
                Console.WriteLine($"Descrição: {produto.Descricao}, Tipo: {produto.Tipo}, Valor de Venda: {produto.ValorVenda}, Data de Criação: {produto.DataCriacao.ToShortDateString()}");
            }

            Console.WriteLine("\nTop 3 produtos com maior margem de lucro:");
            foreach (var produto in top3MaiorMargem)
            {
                double margemLucro = produto.ValorVenda - produto.ValorCompra;
                Console.WriteLine($"Descrição: {produto.Descricao}, Margem de Lucro: {margemLucro}");
            }
        }
    }
        public enum TipoProduto
    {
        Final,
        Intermediario,
        Consumo,
        MateriaPrima
    }

    // Classe Produto
    public class Produto
    {
        public string Descricao { get; set; }
        public double ValorVenda { get; set; }
        public double ValorCompra { get; set; }
        public TipoProduto Tipo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
