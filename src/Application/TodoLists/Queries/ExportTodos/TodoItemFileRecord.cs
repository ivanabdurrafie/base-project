using todo_api.Application.Common.Mappings;
using todo_api.Domain.Entities;

namespace todo_api.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}