class Program
{
    static void Main(string[] Args)
    {
        Cadastro MeuCadastro = new Cadastro();

        // Procura o arquivo na pasta Dados que fica junto do programa
        string arquivo = Path.Combine(AppContext.BaseDirectory, "Dados", "products-100.csv");
        MeuCadastro.LêArquivo(arquivo);

        MeuCadastro.MostrarCadastro();
    }
}
