namespace Locadora.Models;

public class Veiculo
{
    public static readonly string INSERTVEICULO =
        @"INSERT INTO tblVeiculos (CategoriaID, Placa, Marca, Modelo, Ano, StatusVeiculo) 
        VALUES (@CategoriaID, @Placa, @Marca, @Modelo, @Ano, @StatusVeiculo)";

    public static readonly string SELECTALLVEICULOS =
        @"SELECT VeiculoID, CategoriaID, Placa, Marca, Modelo, Ano, StatusVeiculo 
        FROM tblVeiculos";

    public static readonly string SELECTVEICULOBYPLACA =
        @"SELECT VeiculoID, CategoriaID, Placa, Marca, Modelo, Ano, StatusVeiculo 
        FROM tblVeiculos
        WHERE Placa = @Placa";

    public static readonly string UPDATESTATUSVEICULO =
        @"UPDATE tblVeiculos 
        SET StatusVeiculo = @StatusVeiculo 
        WHERE VeiculoID = @IdVeiculo";

    public static readonly string DELETEVEICULO =
        @"DELETE FROM tblVeiculos 
        WHERE VeiculoID = @IdVeiculo";

    public int VeiculoID { get; private set; }
    public int CategoriaID { get; private set; }
    public string? Placa { get; private set; }
    public string? Marca { get; private set; }
    public string? Modelo { get; private set; }
    public int Ano { get; private set; }
    public string? StatusVeiculo { get; private set; }

    public Veiculo(
        int categoriaId,
        string placa,
        string marca,
        string modelo,
        int ano,
        string statusVeiculo)
    {
        CategoriaID = categoriaId;
        Placa = placa;
        Marca = marca;
        Modelo = modelo;
        Ano = ano;
        StatusVeiculo = statusVeiculo;
    }

    public void SetVeiculoID(int veiculoID)
    {
        VeiculoID = veiculoID;
    }

    public void SetStatusVeiculo(string statusVeiculo)
    {
        StatusVeiculo = statusVeiculo;
    }

    public override string? ToString()
    {
        return $"Placa: {Placa}\nMarca: {Marca}\nModelo: {Modelo}\nAno: {Ano}\nStatus {StatusVeiculo}\n";
    }
}
