namespace Locadora.Models
{
    public class Categoria
    {
        public static readonly string INSERTCATEGORIA =
            @"INSERT INTO tblCategorias (Nome, Descricao, Diaria) 
            VALUES (@Nome, @Descricao, @Diaria)";

        public static readonly string UPDATECATEGORIA =
            @"UPDATE tblCategorias 
            SET Nome = @Nome, 
            Descricao = @Descricao, 
            Diaria = @Diaria 
            WHERE CategoriaID = @CategoriaID";

        public int CategoriaID { get; private set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal Diaria { get; private set; }

        public Categoria(string? nome, string? descricao, decimal diaria)
        {
            Nome = nome;
            Descricao = descricao;
            Diaria = diaria;
        }

        public void SetCategoriaID(int categoriaID)
        {
            CategoriaID = categoriaID;
        }

        public override string? ToString()
        {
            return $"\nNome: {Nome}\nDescrição: {Descricao}\nDiária: {Diaria}";
        }
    }
}
