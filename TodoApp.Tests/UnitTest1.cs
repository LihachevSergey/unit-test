namespace TodoApp.Tests;

public class TodoServiceTests
{
    private TodoService _todoService;

    public TodoServiceTests()
    {
        _todoService = new TodoService();
    }

    [Fact]
    public void AddTodo_ShouldAddTodoToList()
    {
        var todo = _todoService.AddTodo("Test Title", "Test Description");

        Assert.Single(_todoService.GetAllTodos());
        Assert.Equal("Test Title", todo.Title);
        Assert.Equal("Test Description", todo.Description);
    }

    [Fact]
    public void GetAllTodos_ShouldReturnCorrectTodoList()
    {
        _todoService.AddTodo("Title 1", "Description 1");
        _todoService.AddTodo("Title 2", "Description 2");

        var todos = _todoService.GetAllTodos();

        Assert.Equal(2, todos.Count);
        Assert.Contains(todos, t => t.Title == "Title 1" && t.Description == "Description 1");
        Assert.Contains(todos, t => t.Title == "Title 2" && t.Description == "Description 2");
    }

    [Fact]
    public void DeleteTodoById_ShouldRemoveTodoFromList()
    {
        var todo = _todoService.AddTodo("Title", "Description");

        var result = _todoService.DeleteTodoById(todo.Id);

        Assert.True(result);
        Assert.Empty(_todoService.GetAllTodos());
    }

    [Fact]
    public void DeleteTodoById_ShouldReturnFalseIfTodoNotFound()
    {
        var result = _todoService.DeleteTodoById(999);

        Assert.False(result);
    }

    [Fact]
    public void UpdateTodoById_ShouldUpdateTodoDetails()
    {
        var todo = _todoService.AddTodo("Old Title", "Old Description");

        var result = _todoService.UpdateTodoById(todo.Id, "New Title", "New Description");

        Assert.True(result);
        var updatedTodo = _todoService.GetAllTodos().FirstOrDefault(t => t.Id == todo.Id);
        Assert.Equal("New Title", updatedTodo.Title);
        Assert.Equal("New Description", updatedTodo.Description);
    }

    [Fact]
    public void UpdateTodoById_ShouldReturnFalseIfTodoNotFound()
    {
        var result = _todoService.UpdateTodoById(999, "New Title", "New Description");

        Assert.False(result);
    }
}