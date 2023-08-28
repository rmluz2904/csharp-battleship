using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

//Criação da lista de embarcações disponíveis.

class batalha_naval
{
    public static void Main(string[] args)
    {
        List<string> embarcacoes = new List<string>();
        embarcacoes.Add("Submarino nº1");
        embarcacoes.Add("Submarino nº2");
        embarcacoes.Add("Submarino nº3");
        embarcacoes.Add("Corveta nº1");
        embarcacoes.Add("Corveta nº2");
        embarcacoes.Add("Fragata nº1");
        embarcacoes.Add("Fragata nº2");
        embarcacoes.Add("Porta-aviões");

        //Definição dos 8 tabuleiros:
        string[,] tabuleiro1, tabuleiro2, invisivelpc, invisivelvspc, tabuleiroVSPC, tabuleiroPC, tabuleiroTiros1, tabuleiroTiros2, tabuleiroTirosVSPC, tabuleiroTirosPC;

        int jogadas1 = 0, jogadas2 = 0, jogadasvspc = 0, jogadaspc = 0;

        int jogadasVencedor = 0;

        Random aleatorio = new Random();

        void MostrarTabuleiro1(int tamanho)
        {
            Console.Clear();
            tabuleiro1 = new string[tamanho, tamanho];
            Console.Write("\n");
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    tabuleiro1[i, j] = "[-]";
                    Console.Write($"{tabuleiro1[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        void MostrarTabuleiro2(int tamanho)
        {
            Console.Clear();
            tabuleiro2 = new string[tamanho, tamanho];
            Console.Write("\n");
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    tabuleiro2[i, j] = "[-]";
                    Console.Write($"{tabuleiro2[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        void MostrarTabuleiroVSPC(int tamanho)
        {
            Console.Clear();
            tabuleiroVSPC = new string[tamanho, tamanho];
            Console.Write("\n");
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    tabuleiroVSPC[i, j] = "[-]";
                    Console.Write($"{tabuleiroVSPC[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        void MostrarTabuleiroPC(int tamanho)
        {
            Console.Clear();
            tabuleiroPC = new string[tamanho, tamanho];
            Console.Write("\n");
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    tabuleiroPC[i, j] = "[-]";
                    Console.Write($"{tabuleiroPC[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        void PosicionarEmbarcacoes1(List<string> embarcacoes, string[,] tabuleiro, int tamanho, int jogadorAtual)
        {
            foreach (string embarcacao in embarcacoes)
            {
                Console.WriteLine($"\nJogador {jogadorAtual}, onde deseja colocar o/a {embarcacao}?\n");
                bool posicaoValida = false;

                while (!posicaoValida)
                {
                    Console.Write("Linha:");
                    int linha = int.Parse(Console.ReadLine());
                    Console.Write("Coluna: ");
                    int coluna = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Qual a orientação do/a {embarcacao}? Insira 'h' para horizontal ou 'v' para vertical:");
                    string orientacao = Console.ReadLine().ToLower();

                    int tamanhoEmbarcacao = 1;
                    switch (embarcacao)
                    {
                        case "Corveta nº1":
                            tamanhoEmbarcacao = 2;
                            break;
                        case "Corveta nº2":
                            tamanhoEmbarcacao = 2;
                            break;
                        case "Fragata nº1":
                            tamanhoEmbarcacao = 3;
                            break;
                        case "Fragata nº2":
                            tamanhoEmbarcacao = 3;
                            break;
                        case "Porta-aviões":
                            tamanhoEmbarcacao = 4;
                            break;
                        default:
                            break;
                    }

                    posicaoValida = ValidarPosicionamento(linha, coluna, orientacao, tamanhoEmbarcacao, tabuleiro);

                    if (posicaoValida)
                    {
                        for (int i = 0; i < tamanhoEmbarcacao; i++)
                        {
                            if (orientacao == "h")
                            {
                                tabuleiro[linha, coluna + i] = "[B]";
                            }
                            else if (orientacao == "v")
                            {
                                tabuleiro[linha + i, coluna] = "[B]";
                            }
                        }
                        MostrarTabuleiroBarcos1(tamanho);
                    }
                    else
                    {
                        Console.WriteLine("Posição inválida. Tente novamente.");
                    }
                }
            }
        }

        void PosicionarEmbarcacoes2(List<string> embarcacoes, string[,] tabuleiro, int tamanho, int jogadorAtual)
        {
            foreach (string embarcacao in embarcacoes)
            {
                Console.WriteLine($"\nJogador {jogadorAtual}, onde deseja colocar o/a {embarcacao}?\n");
                bool posicaoValida = false;

                while (!posicaoValida)
                {
                    Console.Write("Linha:");
                    int linha = int.Parse(Console.ReadLine());
                    Console.Write("Coluna: ");
                    int coluna = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Qual a orientação do/a {embarcacao}? Insira 'h' para horizontal ou 'v' para vertical:");
                    string orientacao = Console.ReadLine().ToLower();

                    int tamanhoEmbarcacao = 1;
                    switch (embarcacao)
                    {
                        case "Corveta nº1":
                            tamanhoEmbarcacao = 2;
                            break;
                        case "Corveta nº2":
                            tamanhoEmbarcacao = 2;
                            break;
                        case "Fragata nº1":
                            tamanhoEmbarcacao = 3;
                            break;
                        case "Fragata nº2":
                            tamanhoEmbarcacao = 3;
                            break;
                        case "Porta-aviões":
                            tamanhoEmbarcacao = 4;
                            break;
                        default:
                            break;
                    }

                    posicaoValida = ValidarPosicionamento(linha, coluna, orientacao, tamanhoEmbarcacao, tabuleiro);

                    if (posicaoValida)
                    {
                        for (int i = 0; i < tamanhoEmbarcacao; i++)
                        {
                            if (orientacao == "h")
                            {
                                tabuleiro[linha, coluna + i] = "[B]";
                            }
                            else if (orientacao == "v")
                            {
                                tabuleiro[linha + i, coluna] = "[B]";
                            }
                        }
                        MostrarTabuleiroBarcos2(tamanho);
                    }
                    else
                    {
                        Console.WriteLine("Posição inválida. Tente novamente.");
                    }
                }
            }
        }

        void PosicionarEmbarcacoesVSPC(List<string> embarcacoes, string[,] tabuleiro, int tamanho, int jogadorAtual)
        {
            foreach (string embarcacao in embarcacoes)
            {
                Console.WriteLine($"\nJogador {jogadorAtual}, onde deseja colocar o/a {embarcacao}?\n");
                bool posicaoValida = false;

                while (!posicaoValida)
                {
                    Console.Write("Linha:");
                    int linha = int.Parse(Console.ReadLine());
                    Console.Write("Coluna: ");
                    int coluna = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Qual a orientação do/a {embarcacao}? Insira 'h' para horizontal ou 'v' para vertical:");
                    string orientacao = Console.ReadLine().ToLower();

                    int tamanhoEmbarcacao = 1;
                    switch (embarcacao)
                    {
                        case "Corveta nº1":
                            tamanhoEmbarcacao = 2;
                            break;
                        case "Corveta nº2":
                            tamanhoEmbarcacao = 2;
                            break;
                        case "Fragata nº1":
                            tamanhoEmbarcacao = 3;
                            break;
                        case "Fragata nº2":
                            tamanhoEmbarcacao = 3;
                            break;
                        case "Porta-aviões":
                            tamanhoEmbarcacao = 4;
                            break;
                        default:
                            break;
                    }

                    posicaoValida = ValidarPosicionamento(linha, coluna, orientacao, tamanhoEmbarcacao, tabuleiro);

                    if (posicaoValida)
                    {
                        for (int i = 0; i < tamanhoEmbarcacao; i++)
                        {
                            if (orientacao == "h")
                            {
                                tabuleiro[linha, coluna + i] = "[B]";
                            }
                            else if (orientacao == "v")
                            {
                                tabuleiro[linha + i, coluna] = "[B]";
                            }
                        }
                        MostrarTabuleiroBarcosVSPC(tamanho);
                    }
                    else
                    {
                        Console.WriteLine("Posição inválida. Tente novamente.");
                    }
                }
            }
        }

        void PosicionarEmbarcacoesPC(List<string> embarcacoes, string[,] tabuleiro, int tamanho, int jogadorAtual)
        {
            foreach (string embarcacao in embarcacoes)
            {
                bool posicaoValida = false;

                while (!posicaoValida)
                {
                    int linha = aleatorio.Next(0, 10);
                    int coluna = aleatorio.Next(0, 10);
                    string orientacao;

                    if (aleatorio.Next(2) == 0)
                    {
                        orientacao = "h";
                    }
                    else
                    {
                        orientacao = "v";
                    }


                    int tamanhoEmbarcacao = 1;
                    switch (embarcacao)
                    {
                        case "Corveta nº1":
                            tamanhoEmbarcacao = 2;
                            break;
                        case "Corveta nº2":
                            tamanhoEmbarcacao = 2;
                            break;
                        case "Fragata nº1":
                            tamanhoEmbarcacao = 3;
                            break;
                        case "Fragata nº2":
                            tamanhoEmbarcacao = 3;
                            break;
                        case "Porta-aviões":
                            tamanhoEmbarcacao = 4;
                            break;
                        default:
                            break;
                    }

                    posicaoValida = ValidarPosicionamento(linha, coluna, orientacao, tamanhoEmbarcacao, tabuleiro);

                    if (posicaoValida)
                    {
                        for (int i = 0; i < tamanhoEmbarcacao; i++)
                        {
                            if (orientacao == "h")
                            {
                                tabuleiro[linha, coluna + i] = "[B]";
                            }
                            else if (orientacao == "v")
                            {
                                tabuleiro[linha + i, coluna] = "[B]";
                            }
                        }
                        MostrarTabuleiroBarcosPC(tamanho);
                    }
                    else
                    {
                        Console.WriteLine("Posição inválida. Tente novamente.");
                    }
                }
            }
        }

        bool ValidarPosicionamento(int linha, int coluna, string orientacao, int tamanhoEmbarcacao, string[,] tabuleiro)
        {
            if (linha < 0 || coluna < 0)
            {
                return false;
            }

            if (orientacao == "h")
            {
                if (coluna + tamanhoEmbarcacao > tabuleiro.GetLength(1))
                {
                    return false;
                }
                for (int i = 0; i < tamanhoEmbarcacao; i++)
                {
                    if (linha >= tabuleiro.GetLength(0) || tabuleiro[linha, coluna + i] != "[-]")
                    {
                        return false;
                    }
                }
            }
            else if (orientacao == "v")
            {
                if (linha + tamanhoEmbarcacao > tabuleiro.GetLength(0))
                {
                    return false;
                }
                for (int i = 0; i < tamanhoEmbarcacao; i++)
                {
                    if (coluna >= tabuleiro.GetLength(1) || tabuleiro[linha + i, coluna] != "[-]")
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        void MostrarTabuleiroBarcos1(int tamanho)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Tabuleiro de barcos do Jogador 1:\n");
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    if (tabuleiro1[i, j] == "[B]")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (tabuleiro1[i, j] == "[X]")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (tabuleiro1[i, j] == "[~]")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(tabuleiro1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        void MostrarTabuleiroBarcos2(int tamanho)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Tabuleiro de barcos do Jogador 2:\n");
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    if (tabuleiro2[i, j] == "[B]")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (tabuleiro2[i, j] == "[X]")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (tabuleiro2[i, j] == "[~]")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(tabuleiro2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        void MostrarTabuleiroBarcosVSPC(int tamanho)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Tabuleiro de barcos do Jogador 1:\n");
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    if (tabuleiroVSPC[i, j] == "[B]")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (tabuleiroVSPC[i, j] == "[X]")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (tabuleiroVSPC[i, j] == "[~]")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(tabuleiroVSPC[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        void MostrarTabuleiroBarcosPC(int tamanho)
        {
            Console.WriteLine();
            Console.WriteLine("Tabuleiro de barcos do Computador:\n");
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    if (tabuleiroPC[i, j] == "[B]")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (tabuleiroPC[i, j] == "[X]")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (tabuleiroPC[i, j] == "[~]")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(tabuleiroPC[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        void MostrarTabuleiroTiros1(int tamanho)
        {
            Console.WriteLine($"O seu tabuleiro de tiros, jogador 1:");
            tabuleiroTiros1 = new string[tamanho, tamanho];
            Console.Write("\n");
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    tabuleiroTiros1[i, j] = "[-]";
                    {
                        if (tabuleiro2[i, j] == "[X]")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            tabuleiroTiros1[i, j] = "[X]";
                        }
                        else if (tabuleiroTiros1[i, j] == "[-]")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (tabuleiroTiros1[i, j] == "[-]" && tabuleiro2[i, j] == "[~]")
                        {
                            tabuleiroTiros1[i, j] = "[~]";
                        }
                        else if (tabuleiroTiros1[i, j] == "[~]")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        Console.Write($"{tabuleiroTiros1[i, j]} ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        void MostrarTabuleiroTiros2(int tamanho)
        {
            Console.WriteLine($"O seu tabuleiro de tiros, jogador 2:");
            tabuleiroTiros2 = new string[tamanho, tamanho];
            Console.Write("\n");
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    tabuleiroTiros2[i, j] = "[-]";
                    {
                        if (tabuleiro1[i, j] == "[X]")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            tabuleiroTiros2[i, j] = "[X]";
                        }
                        else if (tabuleiroTiros2[i, j] == "[-]")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (tabuleiroTiros2[i, j] == "[-]" && tabuleiro1[i, j] == "[~]")
                        {
                            tabuleiroTiros2[i, j] = "[~]";
                        }
                        else if (tabuleiroTiros2[i, j] == "[~]")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        Console.Write($"{tabuleiroTiros2[i, j]} ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        void MostrarTabuleiroTirosVSPC(int tamanho)
        {
            Console.WriteLine($"O seu tabuleiro de tiros, jogador 1:");
            tabuleiroTirosVSPC = new string[tamanho, tamanho];
            Console.Write("\n");
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    tabuleiroTirosVSPC[i, j] = "[-]";
                    {
                        if (tabuleiroPC[i, j] == "[X]")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            tabuleiroTirosVSPC[i, j] = "[X]";
                        }
                        else if (tabuleiroTirosVSPC[i, j] == "[-]")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (tabuleiroTirosVSPC[i, j] == "[-]" && tabuleiroPC[i, j] == "[~]")
                        {
                            tabuleiroVSPC[i, j] = "[~]";
                        }
                        else if (tabuleiroTirosVSPC[i, j] == "[~]")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        Console.Write($"{tabuleiroTirosVSPC[i, j]} ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        void MostrarTabuleiroTirosPC(int tamanho)
        {
            Console.WriteLine($"O tabuleiro de tiros do computador:");
            tabuleiroTirosPC = new string[tamanho, tamanho];
            Console.Write("\n");
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    tabuleiroTirosPC[i, j] = "[-]";
                    {
                        if (tabuleiroVSPC[i, j] == "[X]")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            tabuleiroTirosPC[i, j] = "[X]";
                        }
                        else if (tabuleiroTirosPC[i, j] == "[-]")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (tabuleiroTirosPC[i, j] == "[-]" && tabuleiroVSPC[i, j] == "[~]")
                        {
                            tabuleiroTirosPC[i, j] = "[~]";
                        }
                        else if (tabuleiroTirosPC[i, j] == "[~]")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        Console.Write($"{tabuleiroTirosPC[i, j]} ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        void JogarPC(int tamanho)

        {
            int jogadorAtual = 1;
            bool jogoAcabouPC = JogoAcabouPC(jogadasVencedor, jogadaspc, jogadaspc, jogadorAtual);
            while (!jogoAcabouPC)
            {
                if (jogadorAtual == 1)
                {
                    Console.WriteLine($"\n\nJogador {jogadorAtual}, é a sua vez de jogar!\n\n");
                    MostrarTabuleiroBarcosVSPC(tamanho);
                    Console.WriteLine("\n\n");
                    MostrarTabuleiroTirosVSPC(tamanho);

                    Console.WriteLine("\nEscolha a posição para atirar:");
                    // Ler posição do tiro
                    int linhaTiro, colunaTiro;
                    do
                    {
                        Console.Write("Linha: ");
                        linhaTiro = int.Parse(Console.ReadLine());
                        Console.Write("Coluna: ");
                        colunaTiro = int.Parse(Console.ReadLine());
                        if (linhaTiro < 0 || linhaTiro >= tamanho || colunaTiro < 0 || colunaTiro >= tamanho)
                        {
                            Console.WriteLine("\n A posição que escolheste está fora do mapa, escolha outra (entre 0 e 9).\n");
                        }
                        else if (tabuleiroPC[linhaTiro, colunaTiro] != "[-]" && tabuleiroPC[linhaTiro, colunaTiro] != "[B]")
                        {
                            Console.WriteLine("\nJá jogaste nessa posição. Escolhe outra.\n");
                        }
                    } while (linhaTiro < 0 || linhaTiro >= tamanho || colunaTiro < 0 || colunaTiro >= tamanho || tabuleiroPC[linhaTiro, colunaTiro] != "[-]" && tabuleiroPC[linhaTiro, colunaTiro] != "[B]");

                    if (tabuleiroPC[linhaTiro, colunaTiro] == "[B]")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        tabuleiroPC[linhaTiro, colunaTiro] = "[X]";
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        tabuleiroPC[linhaTiro, colunaTiro] = "[~]";
                        Console.ResetColor();
                    }
                    jogadasvspc++;
                    jogadorAtual = 2;
                }
                else
                {
                    Console.WriteLine($"\n\nÉ a vez do computador jogar!\n\n");
                    MostrarTabuleiroBarcosPC(tamanho);
                    Console.WriteLine("\n\n");
                    MostrarTabuleiroTirosPC(tamanho);
                    int linhaTiro, colunaTiro;
                    do
                    {
                        linhaTiro = aleatorio.Next(0, 10);
                        Console.WriteLine($"\nLinha gerada: {linhaTiro}\n");
                        colunaTiro = aleatorio.Next(0, 10);
                        Console.WriteLine($"\nColuna gerada: {colunaTiro}\n");
                    } while (linhaTiro < 0 || linhaTiro >= tamanho || colunaTiro < 0 || colunaTiro >= tamanho || tabuleiroVSPC[linhaTiro, colunaTiro] != "[-]" && tabuleiroVSPC[linhaTiro, colunaTiro] != "[B]");

                    if (tabuleiroVSPC[linhaTiro, colunaTiro] == "[B]")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        tabuleiroVSPC[linhaTiro, colunaTiro] = "[X]";
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        tabuleiroVSPC[linhaTiro, colunaTiro] = "[~]";
                    }
                    Console.ResetColor();
                    jogadaspc++;
                    jogoAcabouPC = JogoAcabouPC(jogadasVencedor, jogadas1, jogadas2, jogadorAtual);
                    jogadorAtual = 1;
                }
                if (jogadorAtual == 1)
                { jogadasVencedor = jogadasvspc; }
                else
                { jogadasVencedor = jogadaspc; }
            }
        }

        bool JogoAcabouPC(int jogadasVencedor, int jogadas1, int jogadas2, int jogadorAtual)
        {
            int numEmbarcacoesvspc = 0;
            int numEmbarcacoespc = 0;

            // Conta o número de embarcações restantes em cada tabuleiro
            for (int i = 0; i < tabuleiroVSPC.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiroPC.GetLength(1); j++)
                {
                    if (tabuleiroVSPC[i, j] == "[B]")
                    {
                        numEmbarcacoesvspc++;
                    }

                    if (tabuleiroPC[i, j] == "[B]")
                    {
                        numEmbarcacoespc++;
                    }
                }
            }

            // Verifica se algum dos tabuleiros ficou sem navios
            if (numEmbarcacoesvspc == 0)
            {
                Console.WriteLine("O Computador ganhou!");
                return true;
            }

            if (numEmbarcacoespc == 0)
            {
                Console.WriteLine("Parabéns, ganhaste!");
                return true;
            }

            return false;
        }

        void Jogar(int tamanho)
        {
            int jogadorAtual = 1;
            bool jogoAcabou = JogoAcabou(jogadasVencedor, jogadas1, jogadas2, jogadorAtual);

            while (!jogoAcabou)
            {
                if (jogadorAtual == 1)
                {
                    Console.WriteLine($"\n\nJogador {jogadorAtual}, é a sua vez de jogar!\n\n");
                    MostrarTabuleiroBarcos1(tamanho);
                    Console.WriteLine("\n\n");
                    MostrarTabuleiroTiros1(tamanho);
                    Console.WriteLine("\nEscolhe a posição para disparar:");
                    // Ler posição do tiro
                    int linhaTiro, colunaTiro;
                    do
                    {
                        Console.Write("Linha: ");
                        linhaTiro = int.Parse(Console.ReadLine());
                        Console.Write("Coluna: ");
                        colunaTiro = int.Parse(Console.ReadLine());
                        if (linhaTiro < 0 || linhaTiro >= tamanho || colunaTiro < 0 || colunaTiro >= tamanho)
                        {
                            Console.WriteLine("\n A posição que escolheste está fora do mapa, escolha outra (entre 0 e 9).\n");
                        }
                        else if (tabuleiro2[linhaTiro, colunaTiro] != "[-]" && tabuleiro2[linhaTiro, colunaTiro] != "[B]")
                        {
                            Console.WriteLine("\nJá jogaste nessa posição. Escolhe outra.\n");
                        }
                    } while (linhaTiro < 0 || linhaTiro >= tamanho || colunaTiro < 0 || colunaTiro >= tamanho || tabuleiro2[linhaTiro, colunaTiro] != "[-]" && tabuleiro2[linhaTiro, colunaTiro] != "[B]");

                    if (tabuleiro2[linhaTiro, colunaTiro] == "[B]")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        tabuleiro2[linhaTiro, colunaTiro] = "[X]";
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        tabuleiro2[linhaTiro, colunaTiro] = "[~]";
                        Console.ResetColor();
                    }
                    jogadas1++;
                    jogadorAtual = 2;
                }
                else
                {
                    Console.WriteLine($"\n\n{jogadorAtual}, é a tua vez de jogar!\n\n");
                    MostrarTabuleiroBarcos2(tamanho);
                    Console.WriteLine("\n\n");
                    MostrarTabuleiroTiros2(tamanho);

                    Console.WriteLine("\nEscolhe a posição para disparar:\n");
                    // Ler posição do tiro
                    int linhaTiro, colunaTiro;
                    do
                    {
                        Console.Write("Linha: ");
                        linhaTiro = int.Parse(Console.ReadLine());
                        Console.Write("Coluna: ");
                        colunaTiro = int.Parse(Console.ReadLine());
                        if (linhaTiro < 0 || linhaTiro >= tamanho || colunaTiro < 0 || colunaTiro >= tamanho)
                        {
                            Console.WriteLine("\nA posição que escolheste está fora do mapa, escolha outra (entre 0 e 9).\n");
                        }
                        else if (tabuleiro1[linhaTiro, colunaTiro] != "[-]" && tabuleiro1[linhaTiro, colunaTiro] != "[B]")
                        {
                            Console.WriteLine("\nJá jogaste nessa posição. Escolhe outra.\n");
                        }
                    } while (linhaTiro < 0 || linhaTiro >= tamanho || colunaTiro < 0 || colunaTiro >= tamanho || tabuleiro1[linhaTiro, colunaTiro] != "[-]" && tabuleiro1[linhaTiro, colunaTiro] != "[B]");

                    if (tabuleiro1[linhaTiro, colunaTiro] == "[B]")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        tabuleiro1[linhaTiro, colunaTiro] = "[X]";
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        tabuleiro1[linhaTiro, colunaTiro] = "[~]";
                        Console.ResetColor();
                    }
                    jogadas2++;
                    jogoAcabou = JogoAcabou(jogadasVencedor, jogadas1, jogadas2, jogadorAtual);
                    jogadorAtual = 1;
                }
                if (jogadorAtual == 1)
                { jogadasVencedor = jogadas1; }
                else
                { jogadasVencedor = jogadas2; }
            }
        }

        bool JogoAcabou(int jogadasVencedor, int jogadas1, int jogadas2, int jogadorAtual)
        {
            int numEmbarcacoes1 = 0;
            int numEmbarcacoes2 = 0;

            // Conta o número de embarcações restantes em cada tabuleiro
            for (int i = 0; i < tabuleiro1.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiro1.GetLength(1); j++)
                {
                    if (tabuleiro1[i, j] == "[B]")
                    {
                        numEmbarcacoes1++;
                    }

                    if (tabuleiro2[i, j] == "[B]")
                    {
                        numEmbarcacoes2++;
                    }
                }
            }

            // Verifica se algum dos tabuleiros ficou sem navios
            if (numEmbarcacoes1 == 0)
            {
                Console.WriteLine("O jogador 2 ganhou!");
                return true;
            }

            if (numEmbarcacoes2 == 0)
            {
                Console.WriteLine("O jogador 1 ganhou!");
                return true;
            }

            return false;
        }

        static void Highscores(int jogadasVencedor)
        {
            Console.Clear();
            string highscoresFilePath = @"C:\ficheiros\highscores.txt";

            // Verifica se o diretório existe, se não existir, cria o diretório
            if (!Directory.Exists(Path.GetDirectoryName(highscoresFilePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(highscoresFilePath));
            }

            // Pede o nome do jogador
            Console.Write("Como te chamas?\n");
            string nome = Console.ReadLine();

            // Adiciona a nova pontuação à lista de pontuações gravadas
            List<string> pontuacoes = new List<string>();
            pontuacoes.Add($"Nome: {nome} ---> Melhor pontuação: {jogadasVencedor} jogadas");

            // Carrega as pontuações antigas do arquivo, se ele existir
            if (File.Exists(highscoresFilePath))
            {
                StreamReader leitura = new StreamReader(highscoresFilePath);
                string linha = null;

                while ((linha = leitura.ReadLine()) != null)
                {
                    pontuacoes.Add(linha);
                }
                leitura.Close();
            }

            // Ordena a lista de pontuações pelo número mínimo de jogadas
            pontuacoes = pontuacoes.OrderBy(pontuacao =>
            {
                int jogadas = Int32.Parse(pontuacao.Split(':')[2].Split(' ')[1]);
                return jogadas;
            }).ToList();

            // Grava a lista de pontuações no ficheiro
            StreamWriter escrita = new StreamWriter(highscoresFilePath, false);
            foreach (string pontuacao in pontuacoes)
            {
                escrita.WriteLine(pontuacao);
            }
            escrita.Close();

            Console.WriteLine("Dados guardados com sucesso!\n");
            Console.WriteLine("\nHighscores:\n");

            // Apresenta a lista de pontuações ordenada
            foreach (string pontuacao in pontuacoes)
            {
                Console.WriteLine(pontuacao);
            }
        }

        while (true)
        {
            Console.WriteLine("\nBem-vindo ao Batalha Naval. Selecione a opção pretendida:\n\n 1- Ler as regras.\n 2- Jogar.\n");
            int primeira_opcao = int.Parse(Console.ReadLine());

            switch (primeira_opcao)
            {
                case 1:
                    Console.WriteLine("\nAqui estão as regras para o batalha naval:\n\n" +
                        "Embarcações disponíveis:\n" +
                        "3 Submarinos\n" +
                        "2 Corvetas\n" +
                        "2 Fragatas\n" +
                        "1 Porta-aviões\n\n" +
                        "Preparação do jogo:\n\n" +
                        "1. Cada jogador distribui as suas embarcações pelo tabuleiro. A distribuição é feita indicando a linha e a coluna onde pretende colocar as embarcações.\n" +
                        "2. O jogador não deve revelar ao adversário as localizações das suas embarcações.\n\n" +
                        "Durante o jogo:\n" +
                        "Cada jogador, na sua vez de jogar, deverá seguir estes passos:\n" +
                        "1. Disparar 1 tiro, indicando a coordenadas pretendida através do número da linha e coluna que definem a posição. " +
                        "Para que o jogador tenha controlo dos tiros disparados, a aplicação guarda essa informação num tabuleiro separado e mostra se acertou numa embarcação ou não.\n" +
                        "3. A cada tiro disparado, a aplicação guarda essa informação no tabuleiro adversário.\n" +
                        "4. Uma embarcação é afundada quando todas as posições que a formam forem atingidas.\n" +
                        "5. Após cada tiro, a vez de jogar passa para o outro jogador.\n" +
                        "O jogo termina quando um dos jogadores afundar todas as embarcações do seu adversário.");
                    continue;
                case 2:
                    while (true)
                    {
                        Console.WriteLine("\nPretende jogar:\n\n1- VS jogador.\n2- VS computador.\n");
                        int modo_jogo = int.Parse(Console.ReadLine());

                        switch (modo_jogo)
                        {
                            case 1:
                                while (true)
                                {
                                    Console.WriteLine("\nSelecione a dificuldade em que pretende jogar:\n\n 1. FÁCIL - Tabuleiro 10x10\n 2. MÉDIO - Tabuleiro 15x15\n 3. DIFÍCIL - Tabuleiro 20x20\n");
                                    int opcao = int.Parse(Console.ReadLine());

                                    switch (opcao) // Seleção de dificuldade.
                                    {
                                        case 1:
                                            MostrarTabuleiro1(10);
                                            PosicionarEmbarcacoes1(embarcacoes, tabuleiro1, 10, 1);
                                            MostrarTabuleiroBarcos1(10);
                                            MostrarTabuleiro2(10);
                                            PosicionarEmbarcacoes2(embarcacoes, tabuleiro2, 10, 2);
                                            MostrarTabuleiroBarcos2(10);
                                            Jogar(10);
                                            Console.WriteLine("\n\nPretendes guardar o teu resultado?\n\n1- Sim\n2- Não\n\n");
                                            int opcao_resultado = int.Parse(Console.ReadLine());
                                            switch (opcao_resultado)
                                            {
                                                case 1:
                                                    Highscores(jogadasVencedor);
                                                    break;
                                                case 2:
                                                    Console.WriteLine("\nObrigado por teres jogado ao batalha naval.\n\n");
                                                    break;
                                                default:
                                                    Console.WriteLine("\nInsira uma opção válida.\n");
                                                    continue;
                                            }
                                            break;
                                        case 2:
                                            MostrarTabuleiro1(15);
                                            PosicionarEmbarcacoes1(embarcacoes, tabuleiro1, 15, 1);
                                            MostrarTabuleiroBarcos1(15);
                                            MostrarTabuleiro2(15);
                                            PosicionarEmbarcacoes2(embarcacoes, tabuleiro2, 15, 2);
                                            MostrarTabuleiroBarcos2(15);
                                            Jogar(15);
                                            Console.WriteLine("\n\nPretendes guardar o teu resultado?\n\n1- Sim\n2- Não\n\n");
                                            int opcao_resultado2 = int.Parse(Console.ReadLine());
                                            switch (opcao_resultado2)
                                            {
                                                case 1:
                                                    Highscores(jogadasVencedor);
                                                    break;
                                                case 2:
                                                    Console.WriteLine("\nObrigado por teres jogado ao batalha naval.\n\n");
                                                    break;
                                                default:
                                                    Console.WriteLine("\nInsira uma opção válida.\n");
                                                    continue;
                                            }
                                            break;
                                        case 3:
                                            MostrarTabuleiro1(20);
                                            PosicionarEmbarcacoes1(embarcacoes, tabuleiro1, 20, 1);
                                            MostrarTabuleiroBarcos1(20);
                                            MostrarTabuleiro2(20);
                                            PosicionarEmbarcacoes2(embarcacoes, tabuleiro2, 20, 2);
                                            MostrarTabuleiroBarcos2(20);
                                            Jogar(20);
                                            Console.WriteLine("\n\nPretendes guardar o teu resultado?\n\n1- Sim\n2- Não\n\n");
                                            int opcao_resultado3 = int.Parse(Console.ReadLine());
                                            switch (opcao_resultado3)
                                            {
                                                case 1:
                                                    Highscores(jogadasVencedor);
                                                    break;
                                                case 2:
                                                    Console.WriteLine("\nObrigado por teres jogado ao batalha naval.\n\n");
                                                    break;
                                                default:
                                                    Console.WriteLine("\nInsira uma opção válida.\n");
                                                    continue;
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("\nInsira uma opção válida.\n");
                                            continue;
                                    }
                                    break;
                                }
                                break;
                            case 2:
                                while (true)
                                {
                                    Console.WriteLine("\nSelecione a dificuldade em que pretende jogar:\n\n 1. FÁCIL - Tabuleiro 10x10\n 2. MÉDIO - Tabuleiro 15x15\n 3. DIFÍCIL - Tabuleiro 20x20");
                                    int opcao = int.Parse(Console.ReadLine());

                                    switch (opcao)
                                    {
                                        case 1:
                                            MostrarTabuleiroVSPC(10);
                                            PosicionarEmbarcacoesVSPC(embarcacoes, tabuleiroVSPC, 10, 1);
                                            MostrarTabuleiroBarcosVSPC(10);
                                            MostrarTabuleiroPC(10);
                                            PosicionarEmbarcacoesPC(embarcacoes, tabuleiroPC, 10, 2);
                                            MostrarTabuleiroBarcosPC(10);
                                            JogarPC(10);
                                            break;
                                        case 2:
                                            MostrarTabuleiroVSPC(15);
                                            PosicionarEmbarcacoesVSPC(embarcacoes, tabuleiroVSPC, 15, 1);
                                            MostrarTabuleiroBarcosVSPC(15);
                                            MostrarTabuleiroPC(15);
                                            PosicionarEmbarcacoesPC(embarcacoes, tabuleiroPC, 15, 2);
                                            MostrarTabuleiroBarcosPC(15);
                                            JogarPC(15);

                                            break;
                                        case 3:
                                            MostrarTabuleiroVSPC(20);
                                            PosicionarEmbarcacoesVSPC(embarcacoes, tabuleiroVSPC, 20, 1);
                                            MostrarTabuleiroBarcosVSPC(20);
                                            MostrarTabuleiroPC(20);
                                            PosicionarEmbarcacoesPC(embarcacoes, tabuleiroPC, 20, 2);
                                            MostrarTabuleiroBarcosPC(20);
                                            JogarPC(20);

                                            break;
                                        default:
                                            Console.WriteLine("\nInsira uma opção válida.\n");
                                            continue;
                                    }
                                    break;
                                }
                                break;
                            default:
                                Console.WriteLine("\nInsira uma opção válida.\n");
                                continue;
                        }
                        break;
                    }
                    break;
                default:
                    Console.WriteLine("\nInsira uma opção válida.\n");
                    continue;
            }
            break;
        }
    }
}