using TaskManagerApp;

namespace MauiAppKhasanov;

public partial class TaskDetailsPage : ContentPage
{
    private readonly TaskDatabase _database;
    private TaskItem _task;

    public TaskDetailsPage(TaskItem task)
    {
        InitializeComponent();
        _database = new TaskDatabase(System.IO.Path.Combine(FileSystem.AppDataDirectory, "tasks.db3"));
        _task = task;

        TitleEntry.Text = _task.Title;
        DescriptionEditor.Text = _task.Description;
        DueDatePicker.Date = _task.DueDate;
        PriorityPicker.SelectedIndex = _task.Priority - 1;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _task.Title = TitleEntry.Text;
        _task.Description = DescriptionEditor.Text;
        _task.DueDate = DueDatePicker.Date;
        _task.Priority = PriorityPicker.SelectedIndex + 1;

        _database.SaveTask(_task);
        await DisplayAlert("Успех", "Задача обновлена!", "OK");
        await Navigation.PopAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Удалить задачу", "Вы уверены, что хотите удалить эту задачу?", "Да", "Нет");
        if (result)
        {
            _database.DeleteTask(_task.Id);
            await DisplayAlert("Успех", "Задача удалена!", "OK");
            await Navigation.PopAsync();
        }
    }
}