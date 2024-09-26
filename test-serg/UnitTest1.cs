using System;
using System.Linq;
using Xunit;

public class TodoServiceTests
{
    private readonly TodoService _todoService;

    public TodoServiceTests()
    {
        _todoService = new TodoService();
    }

    [Fact]
    public void AddTodo_ShouldAddTodoCorrectly()
    {
        // Arrange
        var title = "New Task";
        var description = "Task description";

        // Act
        _todoService.AddTodo(title, description);
        var todos = _todoService.GetTodos();

        // Assert
        Assert.Single(todos);
        Assert.Equal(title, todos.First().Title);
        Assert.Equal(description, todos.First().Description);
    }

    [Fact]
    public void GetTodos_ShouldReturnCorrectTodos()
    {
        // Arrange
        _todoService.AddTodo("Task 1", "Description 1");
        _todoService.AddTodo("Task 2", "Description 2");

        // Act
        var todos = _todoService.GetTodos();

        // Assert
        Assert.Equal(2, todos.Count);
        Assert.Equal("Task 1", todos[0].Title);
        Assert.Equal("Task 2", todos[1].Title);
    }

    [Fact]
    public void DeleteTodoById_ShouldDeleteTodoCorrectly()
    {
        // Arrange
        _todoService.AddTodo("Task to Delete", "Description");
        var todo = _todoService.GetTodos().First();

        // Act
        var result = _todoService.DeleteTodoById(todo.Id);

        // Assert
        Assert.True(result);
        Assert.Empty(_todoService.GetTodos());
    }

    [Fact]
    public void DeleteTodoById_ShouldReturnFalseWhenTodoNotFound()
    {
        // Act
        var result = _todoService.DeleteTodoById(Guid.NewGuid());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UpdateTodoById_ShouldUpdateTodoCorrectly()
    {
        // Arrange
        _todoService.AddTodo("Old Title", "Old Description");
        var todo = _todoService.GetTodos().First();
        var newTitle = "New Title";
        var newDescription = "New Description";

        // Act
        var result = _todoService.UpdateTodoById(todo.Id, newTitle, newDescription);

        // Assert
        Assert.True(result);
        var updatedTodo = _todoService.GetTodos().First();
        Assert.Equal(newTitle, updatedTodo.Title);
        Assert.Equal(newDescription, updatedTodo.Description);
    }

    [Fact]
    public void UpdateTodoById_ShouldReturnFalseWhenTodoNotFound()
    {
        // Act
        var result = _todoService.UpdateTodoById(Guid.NewGuid(), "New Title", "New Description");

        // Assert
        Assert.False(result);
    }
}
