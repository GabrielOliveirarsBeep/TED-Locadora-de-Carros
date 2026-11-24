namespace LocadoraCarros;

class Carro
{
    public int Codigo;
    public string Modelo;
    public int Categoria;
    public double Diaria;

    public Carro(int codigo, string modelo, int categoria, double diaria)
    {
        Codigo = codigo;
        Modelo = modelo;
        Categoria = categoria;
        Diaria = diaria;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Carro[] Locadora = CriarLocadora();

        bool exibirMenu = true;

        do
        {
            Console.Clear();
            Console.WriteLine("--=[ Locadora de Carros ]=--");
            Console.WriteLine("1. Alugar carro");
            Console.WriteLine("2. Ver Locadora ordenada");
            Console.WriteLine("3. Buscar carro");
            Console.WriteLine("0. Sair");
            Console.WriteLine();
            Console.Write("Selecione a opção desejada => ");
            int opcaoMenu = int.Parse(Console.ReadLine());

            switch(opcaoMenu)
            {
                case 1:
                    string nomeUsuario = "";
                    string carroEscolhido = "";
                    double valorDaDiaria = 0.00;
                    int qtdDeDiarias = 0;
                    bool seguroOpcional = false;
                    double adicionalSeguro = 0.00;
                    string optouPorSeguro = "Não";
                    string classificacaoAluguel = "Reserva de curto prazo";
                    double valorTotal = 0.00;
                    int qtdDePagamentos = 1;
                    string pagamentoEscolhido = "";

                    Console.Clear();
                    Console.Write("Informe seu nome => ");
                    nomeUsuario = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("--=[ Categorias de carros ]=--");
                    Console.WriteLine("1. Compacto");
                    Console.WriteLine("2. Sedan");
                    Console.WriteLine("3. SUV");
                    Console.WriteLine("4. Picape");
                    Console.WriteLine();
                    Console.Write("Escolha a categoria desejada (1-4) => ");
                    int opcaoCategoria = int.Parse(Console.ReadLine());

                    if (opcaoCategoria < 1 || opcaoCategoria > 4)
                    {
                        Console.WriteLine("Seleção inválida. Assumindo categoria 1 por padrão");
                        opcaoCategoria = 1;
                    }

                    Carro[] opcoes = SelecionarPorCategoria(Locadora, opcaoCategoria);

                    BubbleSortPorDiaria(opcoes);

                    Console.Clear();
                    Console.WriteLine("--=[ Carros disponíveis na categoria ]=--");
                    ExibirCarros(opcoes);
                    Console.WriteLine();
                    Console.Write("Digite o código do carro desejado => ");
                    int codigoDigitado = int.Parse(Console.ReadLine());

                    int posicao = BuscaBinariaPorCodigo(Locadora, codigoDigitado);
                    Carro carroSelecionado;

                    if (posicao != -1 && Locadora[posicao].Categoria == opcaoCategoria)
                    {
                        carroSelecionado = Locadora[posicao];
                    }
                    else
                    {
                        Console.WriteLine("Código inválido para esta categoria. Assumindo o mais barato por padrão");
                        carroSelecionado = opcoes[0];
                    }

                    carroEscolhido = carroSelecionado.Modelo;
                    valorDaDiaria = carroSelecionado.Diaria;

                    Console.Clear();
                    Console.Write("Informe a quantidade de diárias: ");
                    qtdDeDiarias = int.Parse(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("Deseja contratar o seguro opcional?");
                    Console.WriteLine("1. Sim (+R$ 150,00)");
                    Console.WriteLine("2. Não");
                    Console.WriteLine();
                    Console.Write("Responda com a opção desejada (1-2) => ");
                    int opcaoSeguro = int.Parse(Console.ReadLine());

                    switch(opcaoSeguro)
                    {
                        case 1:
                            Console.WriteLine("Seguro opcional será contratado");
                            seguroOpcional = true;
                            adicionalSeguro = 150.00;
                            break;
                        case 2:
                            Console.WriteLine("Seguro opcional não será contratado");
                            break;
                        default:
                            Console.WriteLine("Seleção inválida. Negando o seguro opcional por padrão");
                            break;
                    }

                    valorTotal = (valorDaDiaria * qtdDeDiarias) + adicionalSeguro;

                    if(opcaoCategoria != 1 && qtdDeDiarias >= 7)
                    {
                        valorTotal = valorTotal - (valorTotal * 0.10);
                    }

                    if(qtdDeDiarias >= 30)
                    {
                        classificacaoAluguel = "Reserva de longo prazo";
                    }

                    Console.Clear();
                    Console.WriteLine($"O valor total é de {valorTotal:C}");
                    Console.WriteLine();
                    Console.WriteLine("Escolha o método de pagamento:");
                    Console.WriteLine("1. À vista/Pix");
                    Console.WriteLine("2. Parcelado (2-4x)");
                    Console.WriteLine();
                    Console.Write("Escolha a opção desejada (1-2) => ");
                    int opcaoPagamento = int.Parse(Console.ReadLine());

                    switch (opcaoPagamento)
                    {
                        case 1:
                            Console.WriteLine("Escolhido: pagamento à vista");
                            break;
                        case 2:
                            Console.Write("Selecione quantas parcelas (2-4) => ");
                            int opcaoParcelas = int.Parse(Console.ReadLine());

                            switch(opcaoParcelas)
                            {
                                case 2:
                                    qtdDePagamentos = 2;
                                    valorTotal = valorTotal / 2;
                                    break;
                                case 3:
                                    qtdDePagamentos = 3;
                                    valorTotal = valorTotal / 3;
                                    break;
                                case 4:
                                    qtdDePagamentos = 4;
                                    valorTotal = valorTotal / 4;
                                    break;
                                default:
                                    Console.WriteLine("Seleção inválida. Assumindo pagamento à vista por padrão");
                                    break;
                            }

                            if(qtdDePagamentos != 1)
                            {
                                Console.WriteLine($"Escolhido: Pagamento parcelado em {qtdDePagamentos} vezes");
                            }

                            break;
                        default:
                            Console.WriteLine("Seleção inválida. Assumindo pagamento à vista por padrão");
                            break;
                    }

                    if(seguroOpcional == true)
                    {
                        optouPorSeguro = "Sim";
                    }

                    if(qtdDePagamentos != 1)
                    {
                        pagamentoEscolhido = $"Parcelado em {qtdDePagamentos} pagamentos de {valorTotal:C}";
                    }
                    else
                    {
                        pagamentoEscolhido = $"{valorTotal:C} à vista ou no Pix";
                    }

                    Console.Clear();
                    Console.WriteLine("--=[ Resumo do aluguel ]=--");
                    Console.WriteLine();
                    Console.WriteLine($"Nome do cliente: {nomeUsuario}");
                    Console.WriteLine($"Carro escolhido: {carroEscolhido}");
                    Console.WriteLine($"Quantidade de diárias: {qtdDeDiarias}");
                    Console.WriteLine($"Classificação da reserva: {classificacaoAluguel}");
                    Console.WriteLine($"Seguro opcional? {optouPorSeguro}");
                    Console.WriteLine($"Modalidade de pagamento: {pagamentoEscolhido}");

                    Console.WriteLine();
                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("--=[ Ver Locadora ordenada ]=--");
                    Console.WriteLine("1. Por valor da diária (Bubble Sort)");
                    Console.WriteLine("2. Por modelo, de A a Z (Selection Sort)");
                    Console.WriteLine();
                    Console.Write("Escolha a opção desejada (1-2) => ");
                    int opcaoOrdenacao = int.Parse(Console.ReadLine());

                    Carro[] copiaLocadora = CopiarLocadora(Locadora);

                    Console.Clear();
                    if (opcaoOrdenacao == 1)
                    {
                        BubbleSortPorDiaria(copiaLocadora);
                        Console.WriteLine("--=[ Locadora ordenada por diária ]=--");
                        ExibirCarros(copiaLocadora);
                    }
                    else if (opcaoOrdenacao == 2)
                    {
                        SelectionSortPorModelo(copiaLocadora);
                        Console.WriteLine("--=[ Locadora ordenada por modelo ]=--");
                        ExibirCarros(copiaLocadora);
                    }
                    else
                    {
                        Console.WriteLine("Seleção inválida.");
                    }

                    Console.WriteLine();
                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("--=[ Buscar carro ]=--");
                    Console.WriteLine("1. Por modelo (Busca Sequencial)");
                    Console.WriteLine("2. Por código (Busca Binária)");
                    Console.WriteLine();
                    Console.Write("Escolha a opção desejada (1-2) => ");
                    int opcaoBusca = int.Parse(Console.ReadLine());

                    int indiceEncontrado = -1;

                    if (opcaoBusca == 1)
                    {
                        Console.Write("Digite o modelo => ");
                        string modeloBuscado = Console.ReadLine();
                        indiceEncontrado = BuscaSequencialPorModelo(Locadora, modeloBuscado);
                    }
                    else if (opcaoBusca == 2)
                    {
                        Console.Write("Digite o código => ");
                        int codigoBuscado = int.Parse(Console.ReadLine());
                        indiceEncontrado = BuscaBinariaPorCodigo(Locadora, codigoBuscado);
                    }
                    else
                    {
                        Console.WriteLine("Seleção inválida.");
                    }

                    if (opcaoBusca == 1 || opcaoBusca == 2)
                    {
                        Console.WriteLine();
                        if (indiceEncontrado != -1)
                        {
                            Console.WriteLine("Carro encontrado!");
                            Console.WriteLine($"Código: {Locadora[indiceEncontrado].Codigo}");
                            Console.WriteLine($"Modelo: {Locadora[indiceEncontrado].Modelo}");
                            Console.WriteLine($"Categoria: {Locadora[indiceEncontrado].Categoria}");
                            Console.WriteLine($"Diária: {Locadora[indiceEncontrado].Diaria:C}");
                        }
                        else
                        {
                            Console.WriteLine("Carro não encontrado.");
                        }
                    }

                    Console.WriteLine();
                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                case 0:
                    exibirMenu = false;

                    Console.Clear();
                    Console.Write("Saindo do programa. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                default:
                    Console.Clear();
                    Console.Write("Opção inválida! Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();

                    break;
            }
        }
        while(exibirMenu == true);
    }

    static Carro[] CriarLocadora()
    {
        Carro[] Locadora = new Carro[12];

        Locadora[0] = new Carro(1, "Kwid", 1, 50.00);
        Locadora[1] = new Carro(2, "Onix Plus", 2, 150.00);
        Locadora[2] = new Carro(3, "T-Cross", 3, 250.00);
        Locadora[3] = new Carro(4, "Strada", 4, 350.00);
        Locadora[4] = new Carro(5, "Mobi", 1, 55.00);
        Locadora[5] = new Carro(6, "Virtus", 2, 170.00);
        Locadora[6] = new Carro(7, "Creta", 3, 270.00);
        Locadora[7] = new Carro(8, "Toro", 4, 380.00);
        Locadora[8] = new Carro(9, "Up", 1, 60.00);
        Locadora[9] = new Carro(10, "Cronos", 2, 160.00);
        Locadora[10] = new Carro(11, "Kicks", 3, 260.00);
        Locadora[11] = new Carro(12, "Hilux", 4, 450.00);

        return Locadora;
    }

    static Carro[] CopiarLocadora(Carro[] origem)
    {
        Carro[] copia = new Carro[origem.Length];

        for (int i = 0; i < origem.Length; i++)
        {
            copia[i] = origem[i];
        }

        return copia;
    }

    static void ExibirCarros(Carro[] vetor)
    {
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.WriteLine($"[{vetor[i].Codigo}] {vetor[i].Modelo} - Categoria {vetor[i].Categoria} - {vetor[i].Diaria:C}/dia");
        }
    }

    static Carro[] SelecionarPorCategoria(Carro[] Locadora, int categoria)
    {
        int quantidade = 0;
        for (int i = 0; i < Locadora.Length; i++)
        {
            if (Locadora[i].Categoria == categoria)
            {
                quantidade++;
            }
        }

        Carro[] selecionados = new Carro[quantidade];
        int posicao = 0;

        for (int i = 0; i < Locadora.Length; i++)
        {
            if (Locadora[i].Categoria == categoria)
            {
                selecionados[posicao] = Locadora[i];
                posicao++;
            }
        }

        return selecionados;
    }

    static void BubbleSortPorDiaria(Carro[] vetor)
    {
        for (int i = 0; i < vetor.Length - 1; i++)
        {
            for (int j = 0; j < vetor.Length - 1 - i; j++)
            {
                if (vetor[j].Diaria > vetor[j + 1].Diaria)
                {
                    Carro temporario = vetor[j];
                    vetor[j] = vetor[j + 1];
                    vetor[j + 1] = temporario;
                }
            }
        }
    }

    static void SelectionSortPorModelo(Carro[] vetor)
    {
        for (int i = 0; i < vetor.Length - 1; i++)
        {
            int menor = i;

            for (int j = i + 1; j < vetor.Length; j++)
            {
                if (string.Compare(vetor[j].Modelo, vetor[menor].Modelo) < 0)
                {
                    menor = j;
                }
            }

            if (menor != i)
            {
                Carro temporario = vetor[i];
                vetor[i] = vetor[menor];
                vetor[menor] = temporario;
            }
        }
    }

    static int BuscaSequencialPorModelo(Carro[] vetor, string modelo)
    {
        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i].Modelo.ToLower() == modelo.Trim().ToLower())
            {
                return i;
            }
        }

        return -1;
    }

    static int BuscaBinariaPorCodigo(Carro[] vetor, int codigo)
    {
        int inicio = 0;
        int fim = vetor.Length - 1;

        while (inicio <= fim)
        {
            int meio = (inicio + fim) / 2;

            if (vetor[meio].Codigo == codigo)
            {
                return meio;
            }
            else if (vetor[meio].Codigo < codigo)
            {
                inicio = meio + 1;
            }
            else
            {
                fim = meio - 1;
            }
        }

        return -1;
    }
}