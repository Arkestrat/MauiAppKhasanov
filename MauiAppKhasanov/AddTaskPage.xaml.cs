namespace MauiAppKhasanov;

public partial class AddTaskPage : ContentPage
{
    private readonly TaskDatabase _database;

    public AddTaskPage()
    {
        InitializeComponent();
        _database = new TaskDatabase(System.IO.Path.Combine(FileSystem.AppDataDirectory, "tasks.db3"));
    }

    private async void OnSaveTaskClicked(object sender, EventArgs e)
    {
        var task = new TaskItem
        {
            Title = TitleEntry.Text,
            Description = DescriptionEditor.Text,
            DueDate = DueDatePicker.Date,
            Priority = PriorityPicker.SelectedIndex + 1
        };

        _database.SaveTask(task);
        await DisplayAlert("Успех", "Задача добавлена!", "OK");
        await Navigation.PopAsync();
    }
}