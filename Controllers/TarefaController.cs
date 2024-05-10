using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TarefaController : Controller
    {
        public IActionResult Index()
        {
            return View(_tarefas);
        }

        //----------------------------------------------------------------------------------------

        private static List<CategoriaModel> _categorias = new List<CategoriaModel>()
        {
            new CategoriaModel
            {
                Id = 1,
                Nome = "Faculdade"
            },
            new CategoriaModel
            {
                Id = 2,
                Nome = "Trabalho"
            },
            new CategoriaModel
            {
                Id = 3,
                Nome = "Limpeza"
            },
            new CategoriaModel
            {
                Id = 4,
                Nome = "Mercado"
            },
            new CategoriaModel
            {
                Id = 5,
                Nome = "Estudos"
            },
            new CategoriaModel
            {
                Id = 6,
                Nome = "Compras"
            }
        };

        private static List<TarefaModel> _tarefas = new List<TarefaModel>()
        {
            new TarefaModel
            {
                Id= 1,
                Descrição = "Estudar Linq",
                Categoria = _categorias.FirstOrDefault(c => c.Id == 5),
                DataInicio = new DateOnly(2024, 5, 10),
                //DataConclusao = new DateOnly(2024, 5, 15),
                Concluido = false
            },
            new TarefaModel
            {
                Id= 2,
                Descrição = "Limpar Quarto",
                Categoria = _categorias.FirstOrDefault(c => c.Id == 3),
                DataInicio = new DateOnly(2023, 12, 31),
                //DataConclusao = new DateOnly(2027, 2, 03),
                Concluido = false
            },
            new TarefaModel
            {
                Id= 3,
                Descrição = "Ler e-mails",
                Categoria = _categorias.FirstOrDefault(c => c.Id == 2),
                DataInicio = new DateOnly(2024, 12, 20),
                //DataConclusao = new DateOnly(2025, 3, 1),
                Concluido = false
            },

        };
    }
}
