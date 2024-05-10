namespace TodoList.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Descrição { get; set; }
        public CategoriaModel Categoria { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateOnly? DataConclusao { get; set; }
        public bool Concluido { get; set; }
    }
}
