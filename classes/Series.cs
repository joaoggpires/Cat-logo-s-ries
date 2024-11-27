using Criando_um_APP_Simples_de_Cadastro_de_Séries_em_.NET.Enum;

namespace Criando_um_APP_Simples_de_Cadastro_de_Séries_em_.NET.classes
{
    public class Series : EntidadeBase
    {
        private Genero genero { get; set; }
        private string titulo { get; set; }
        private string descricao { get; set; }
        private int ano { get; set; }
        private bool excluido { get; set; }

        public Series(int id, Genero genero, string? titulo, string? descricao, int ano)
        {
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.excluido = false;
        }



        public override string ToString()
        {
            string retorno = "";
            retorno += "ID: " + this.id + Environment.NewLine;
            retorno += "Gênero: " + this.genero + Environment.NewLine;
            retorno += "Título: " + this.titulo + Environment.NewLine;
            retorno += "Descrição: " + this.descricao + Environment.NewLine;
            retorno += "Ano: " + this.ano + Environment.NewLine;
            retorno += "Excluida: "+this.excluido;
            return retorno;
        }

        public string retornatitulo()
        {
            return this.titulo;
        }

        public int retornaid()
        {
            return this.id;
        }

        public void excluir(){
            this.excluido=true;
        }

        public bool retornaexcluido(){
            return this.excluido;
        }
    }
}