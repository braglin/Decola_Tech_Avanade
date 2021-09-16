using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                 switch (opcaoUsuario)
                 {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                 }
                 opcaoUsuario = ObterOpcaoUsuario();
            }            
            Console.WriteLine("Obrigado por utilizar o DIO.Series!");
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar série");

            Console.Write("Digite o ID da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(entradaId);
            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir série");

            Console.Write("Digite o ID da série: ");
            int entradaId = int.Parse(Console.ReadLine());
            
            Console.Write("Deseja realmente excluir (S/N): ");            
            string entradaConfirmacao = Console.ReadLine().ToUpper();

            if (entradaConfirmacao == "S")
            {
                repositorio.Exclui(entradaId);
            }
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar série");

            Console.Write("Digite o ID da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero de acordo com as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: entradaId,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao );

            repositorio.Atualiza(entradaId, atualizaSerie);
        }

        private static void InserirSerie()
        {            
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            Console.Write("Digite o gênero de acordo com as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao );

            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {            
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {                
            Console.WriteLine("Nenhuma série cadastrada...");
            return;
            }

            foreach (var serie in lista)
            {
                var excluida = serie.retornaExcluido();

                if (excluida)
                {
                    Console.Write("**");
                }
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo ao DIO.Series");
            Console.WriteLine("Oque deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
