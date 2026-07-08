// Representação de uma Tarefa
// Boa prática criar no início para leitura humana. Define o que é uma tarefa e suas propriedades.
// Se for 'public', qualquer parte do sistema vê. Se omitido, vira 'internal' (visível na mesma pasta/projeto).
namespace Ondoro
{
    public class TaskItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Category { get; set; }
        public bool IsCompleted { get; set; }
    }
}