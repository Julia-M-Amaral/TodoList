namespace TodoList.Controllers
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string? Descrição { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataConclusao { get; set; }
        public bool Concluido { get; set; }
    }
}
