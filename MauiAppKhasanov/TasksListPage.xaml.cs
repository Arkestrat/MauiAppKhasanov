using MauiAppKhasanov;
using SQLite;
namespace MauiAppKhasanov;
    public class TaskDatabase
{
    private readonly SQLiteConnection _database;

    public TaskDatabase(string dbPath)
    {
        _database = new SQLiteConnection(dbPath);
        _database.CreateTable<TaskItem>(); 
    }

    public List<TaskItem> GetTasks()
    {
        return _database.Table<TaskItem>().OrderBy(t => t.DueDate).ToList();
    }

    public TaskItem GetTask(int id)
    {
        return _database.Table<TaskItem>().FirstOrDefault(t => t.Id == id);
    }

    public int SaveTask(TaskItem task)
    {
        if (task.Id != 0)
        {
            return _database.Update(task);
        }
        else
        {
            return _database.Insert(task);
        }
    }

    public int DeleteTask(int id)
    {
        return _database.Delete<TaskItem>(id);
    }
}