namespace CommonLibrary.Models;

public class ToDoItem
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }
    public DateTime DateCreated { get; set; }
}