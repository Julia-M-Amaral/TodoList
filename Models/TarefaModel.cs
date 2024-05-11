namespace TodoList.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Descrição { get; set; }
        public CategoriaModel? Categoria { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime DataConclusao { get; set; } = DateTime.Now;
        public bool Concluido { get; set; }
    }
}
