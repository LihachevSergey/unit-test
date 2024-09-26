using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp;
public class TodoService
{
    private readonly List<Todo> _todos = new List<Todo>();
    private int _nextId = 1;

    public Todo AddTodo(string title, string description)
    {
        var todo = new Todo
        {
            Id = _nextId++,
            Title = title,
            Description = description
        };
        _todos.Add(todo);
        return todo;
    }

    public List<Todo> GetAllTodos()
    {
        return _todos;
    }

    public bool DeleteTodoById(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo == null) return false;
        _todos.Remove(todo);
        return true;
    }

    public bool UpdateTodoById(int id, string title, string description)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo == null) return false;
        todo.Title = title;
        todo.Description = description;
        return true;
    }
}