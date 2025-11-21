namespace Locadora.Models
{
    public class Categoria
    {
        public static readonly string INSERTCATEGORIA =
            @"EXEC sp_INSERIRCATEGORIA @Nome, @Descricao, @Diaria";

        public static readonly string UPDATECATEGORIA =
            @"UPDATE tblCategorias 
            SET Nome = @Nome, 
            Descricao = @Descricao, 
            Diaria = @Diaria 
            WHERE CategoriaID = @CategoriaID";

        public static readonly string SELECTNOMECATEGORIAPORID = 
            @"SELECT Nome
            FROM tblCategorias 
            WHERE CategoriaID = @Id";

        public int CategoriaID { get; private set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal Diaria { get; private set; }

        public Categoria(
            string? nome, 
            decimal diaria)
        {
            Nome = nome;
            Diaria = diaria;
        }

        public Categoria(string? nome, decimal diaria, string? descricao) : this(nome, diaria)
        {
            Descricao = descricao;
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
