namespace MauiAppKhasanov;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnViewTasksClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TasksListPage()); 
    }

    private async void OnAddTaskClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTaskPage()); 
    }

    private async void OnStatisticsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Статистика", "Статистика пока не реализована.", "OK");
    }

    private async void OnSettingsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Настройки", "Настройки пока не реализованы.", "OK");
    }
}