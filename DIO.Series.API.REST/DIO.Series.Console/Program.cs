using System;
using DIO.Series; 

namespace DIO.Series.Console
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
                        System.Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                 }
                 opcaoUsuario = ObterOpcaoUsuario();
            }            
            System.Console.WriteLine("Obrigado por utilizar o DIO.Series!");
        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Visualizar série");

            System.Console.Write("Digite o ID da série: ");
            int entradaId = int.Parse(System.Console.ReadLine());

            var serie = repositorio.RetornaPorId(entradaId);
            System.Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Excluir série");

            System.Console.Write("Digite o ID da série: ");
            int entradaId = int.Parse(System.Console.ReadLine());
            
            System.Console.Write("Deseja realmente excluir (S/N): ");            
            string entradaConfirmacao = System.Console.ReadLine().ToUpper();

            if (entradaConfirmacao == "S")
            {
                repositorio.Exclui(entradaId);
            }
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Atualizar série");

            System.Console.Write("Digite o ID da série: ");
            int entradaId = int.Parse(System.Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }
            System.Console.Write("Digite o gênero de acordo com as opções acima: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());
            
            System.Console.Write("Digite o título da série: ");
            string entradaTitulo = System.Console.ReadLine();

            System.Console.Write("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(System.Console.ReadLine());
            
            System.Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = System.Console.ReadLine();

            Serie atualizaSerie = new Serie(id: entradaId,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao );

            repositorio.Atualiza(entradaId, atualizaSerie);
        }

        private static void InserirSerie()
        {            
            System.Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            System.Console.Write("Digite o gênero de acordo com as opções acima: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());
            
            System.Console.Write("Digite o título da série: ");
            string entradaTitulo = System.Console.ReadLine();

            System.Console.Write("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(System.Console.ReadLine());
            
            System.Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = System.Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao );

            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {            
            System.Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {                
            System.Console.WriteLine("Nenhuma série cadastrada...");
            return;
            }

            foreach (var serie in lista)
            {
                var excluida = serie.retornaExcluido();

                if (excluida)
                {
                    System.Console.Write("**");
                }
                System.Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Bem-vindo ao DIO.Series");
            System.Console.WriteLine("Oque deseja fazer?");
            System.Console.WriteLine();
            System.Console.WriteLine("1 - Listar séries");
            System.Console.WriteLine("2 - Inserir nova série");
            System.Console.WriteLine("3 - Atualizar série");
            System.Console.WriteLine("4 - Excluir série");
            System.Console.WriteLine("5 - Visualizar série");
            System.Console.WriteLine("C - Limpar tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string opcaoUsuario = System.Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
