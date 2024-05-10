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
                Concluido = false
            },
            new TarefaModel
            {
                Id= 2,
                Descrição = "Limpar Quarto",
                Categoria = _categorias.FirstOrDefault(c => c.Id == 3),
                Concluido = false
            },
            new TarefaModel
            {
                Id= 3,
                Descrição = "Ler e-mails",
                Categoria = _categorias.FirstOrDefault(c => c.Id == 2),
                Concluido = false
            },

        };

        //----------------------------------------------------------------------------------------

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categorias = _categorias;
            return View();
        }

        [HttpPost]
        public IActionResult Create(TarefaModel tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefa.Id = _tarefas.Count > 0 ? _tarefas.Max(t => t.Id) + 1 : 1;
                // Atribuir a categoria selecionada à propriedade Categoria da TarefaModel
                tarefa.Categoria = _categorias.FirstOrDefault(c => c.Id == tarefa.Categoria.Id);
                _tarefas.Add(tarefa);
            }
            return RedirectToAction("Index");
        }

        //----------------------------------------------------------------------------------------

        public IActionResult Edit(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            ViewBag.Categorias = _categorias;
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Edit(TarefaModel tarefa)
        {
            if (ModelState.IsValid)
            {
                var existingTarefa = _tarefas.FirstOrDefault(t => t.Id == tarefa.Id);
                if (existingTarefa != null)
                {
                    existingTarefa.Descrição = tarefa.Descrição;
                    existingTarefa.Categoria = _categorias.FirstOrDefault(c => c.Id == tarefa.Categoria.Id);
                    existingTarefa.DataInicio = tarefa.DataInicio;
                    existingTarefa.DataConclusao = tarefa.DataConclusao;
                    existingTarefa.Concluido = tarefa.Concluido;
                }
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        //----------------------------------------------------------------------------------------

        public IActionResult Delete(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
            tarefa.Categoria = _categorias.FirstOrDefault(c => c.Id == tarefa.Categoria.Id);
            if (tarefa == null)
            {
                return NotFound();
            }
            _tarefas.Remove(tarefa);
            return RedirectToAction("Index");
        }

        //----------------------------------------------------------------------------------------

        public IActionResult Details(int id)
        {
            ViewBag.Categorias = _categorias;

            var tarefa = _tarefas.FirstOrDefault(t => t.Id==id);
            tarefa.Categoria = _categorias.FirstOrDefault(c => c.Id == tarefa.Categoria.Id);
            if(tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        //----------------------------------------------------------------------------------------

        [HttpPost]
        public IActionResult MarcarConcluida(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa != null)
            {
                tarefa.Concluido = true;
            }
            return RedirectToAction("Index");
        }

        //----------------------------------------------------------------------------------------

        public IActionResult Concluidas()
        {
            var tarefasConcluidas = _tarefas.Where(t => t.Concluido).ToList();
            return View(tarefasConcluidas);
        }

    }
}
