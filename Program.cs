using System;
using Criando_um_APP_Simples_de_Cadastro_de_Séries_em_.NET.classes;
using Criando_um_APP_Simples_de_Cadastro_de_Séries_em_.NET.Enum;

class Program
{
    static SerieRepositorio repositorio = new SerieRepositorio();

    static void Main(string[] args)
    {
        string opc = ObterOpcaoUsuario();
        while (opc.ToUpper() != "X")
        {
            switch (opc)
            {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSeries();
                    break;
                case "3":
                    AtualizarSeries();
                    break;
                case "4":
                    ExcluirSeries();
                    break;
                case "5":
                    VisualizarSeries();
                    break;
                case "C":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
            opc = ObterOpcaoUsuario();
        }

        Console.WriteLine("Obrigado por usar o sistema!");
    }

    private static void ListarSeries()
    {
        Console.WriteLine("Listar séries");
        var lista = repositorio.Lista();

        if (lista.Count == 0)
        {
            Console.WriteLine("Não há séries cadastradas.");
            return;
        }

        foreach (var serie in lista)
        {
            var excluido = serie.retornaexcluido();

            Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaid(), serie.retornatitulo(),excluido ? "Excluido" : "Disponível");
        }
    }

    private static void InserirSeries()
    {
        Console.WriteLine("Inserir nova série");

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
        }

        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o título da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de início da série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        Series novaSerie = new Series(
            id: repositorio.proximoID(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);

        repositorio.Insere(novaSerie);
    }

    private static void AtualizarSeries()
    {
        Console.Write("Digite o ID da série a ser atualizada: ");
        int idSerie = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
        }

        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o título da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de início da série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        Series atualizaSerie = new Series(
            id: idSerie,
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);

        repositorio.Atualiza(idSerie, atualizaSerie);
    }

    private static void ExcluirSeries()
    {
        Console.Write("Digite o ID da série a ser excluída: ");
        int idSerie = int.Parse(Console.ReadLine());

        repositorio.Exclui(idSerie);
    }

    private static void VisualizarSeries()
    {
        Console.Write("Digite o ID da série a ser visualizada: ");
        int idSerie = int.Parse(Console.ReadLine());

        var serie = repositorio.RetornaporID(idSerie);

        Console.WriteLine(serie);
    }

    private static string ObterOpcaoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("Sistema de Cadastro de Séries");
        Console.WriteLine("Informe a opção desejada:");

        Console.WriteLine("1 - Listar séries");
        Console.WriteLine("2 - Inserir nova série");
        Console.WriteLine("3 - Atualizar série");
        Console.WriteLine("4 - Excluir série");
        Console.WriteLine("5 - Visualizar série");
        Console.WriteLine("C - Limpar tela");
        Console.WriteLine("X - Sair");
        Console.WriteLine();

        string opc = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opc;
    }
}
