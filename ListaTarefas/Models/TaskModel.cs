using System.ComponentModel.DataAnnotations;

namespace ListaTarefas.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo não pode estar vazio")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O campo não pode estar vazio")]
        [Display(Name = "Tarefa")]
        public string? TaskName { get; set;}

        public string? Status { get; set; } = "Em andamento";
        
        [Display(Name = "Data Início")]
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Display(Name = "Data Conclusão")]
        public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}
