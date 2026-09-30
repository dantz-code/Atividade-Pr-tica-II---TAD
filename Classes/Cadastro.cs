using System.Data;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

class Cadastro
{
    private Product[] CadProdutos;
    private int cont;

    public Cadastro()
    {
        CadProdutos = new Product[100];
        cont = 0;
    }

    public void LêArquivo(string NomeArquivo)
    {
        // Confere se o arquivo existe antes de tentar ler
        if (File.Exists(NomeArquivo))
        {
            // Abre o arquivo para ler. O using fecha ele sozinho no final desse bloco
            using var Leitor = new TextFieldParser(NomeArquivo);
            // Avisa que os dados do arquivo são separados por um caractere
            Leitor.TextFieldType = FieldType.Delimited;
            // Nesse arquivo, o que separa os dados é a vírgula
            Leitor.SetDelimiters(",");
            // Se tiver vírgula dentro de aspas, ela faz parte do texto
            Leitor.HasFieldsEnclosedInQuotes = true;

            string Linha = Leitor.ReadLine();       // Lê a primeira linha, que só tem os nomes das colunas

            Console.WriteLine("\nAguarde... Lendo o Arquivo...");

            // Começa a guardar os produtos na posição 0 do vetor
            cont = 0;

            // Continua enquanto tiver dados no arquivo e espaço no vetor
            while (!Leitor.EndOfData && cont < CadProdutos.Length)
            {
                // Lê um registro e separa os dados, respeitando as aspas
                string[] LinhaProduto = Leitor.ReadFields();

                // Usa os dados lidos para montar um produto
                Product P = CriaProduto(LinhaProduto);

                // Guarda o produto no vetor e passa para a próxima posição
                CadProdutos[cont] = P;
                cont++;
            }
        }

        else
        {
            // Avisa que não achou o arquivo e espera apertar uma tecla
            Console.WriteLine("\nERRO: Arquivo não existe!!");

            Console.ReadKey();
        }
    }

    private Product CriaProduto(string[] LinhaProduto)
    {
        Product P = new Product();

        P.Index = int.Parse(LinhaProduto[0]);
        P.Name = LinhaProduto[1];
        P.Description = LinhaProduto[2];
        P.Brand = LinhaProduto[3];
        P.Category = LinhaProduto[4];
        P.Price = double.Parse(LinhaProduto[5]);
        P.Currency = LinhaProduto[6];
        P.Stock = int.Parse(LinhaProduto[7]);
        P.EAN = LinhaProduto[8];
        P.Color = LinhaProduto[9];
        P.Size = LinhaProduto[10];
        P.Availability = LinhaProduto[11];
        P.internalID = LinhaProduto[12];

        return P;
    }

    public void MostrarCadastro()
    {
        Console.Clear();

        foreach (Product P in CadProdutos)
        {
            if (P != null)
            {
                Console.WriteLine($"{P.Index} - {P.Name} {P.Description}");
                Console.WriteLine($"{P.Brand} - {P.Category} - {P.Price} - {P.Currency} - {P.Stock}");
                Console.WriteLine($"{P.EAN} - {P.Color} - {P.Size} - {P.Availability} - {P.internalID}");
            }
            else
            {
                Console.WriteLine("Posição vazia");
            }
            // index,Name,Description,Brand,Category,Price,Currency,Stock,EAN,Color,Size,Availability,Internal ID
        }

        Console.ReadKey();
    }

    public void Inserir(Product x)
    {
        if (cont < CadProdutos.Length)
        {
            CadProdutos[cont] = x;
            cont++;
        }

        else
        {
            Console.WriteLine("Cadastro cheio");
        }
    }

    public void Remover(Product x)
    {
        for (int i = 0; i < CadProdutos.Length; i++)
        {
            if (CadProdutos[i] == x)
            {
                CadProdutos[i] = null;
                break;
            }
        }
    }
}

