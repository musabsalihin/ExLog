using Syncfusion.Maui.Popup;

namespace ExLog;

public partial class Record : ContentPage
{

    FirebaseHelper firebaseHelper = new FirebaseHelper();
    protected PersonalRecord PR;

    public Record(PersonalRecord pr)
    {
        InitializeComponent();
        PR = pr;


        exerciseName.Text = PR.Name;
        exerciseIcon.Source = PR.Type;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        displayER.ItemsSource = await firebaseHelper.GetAllExerciseRecord(PR.Name);
    }
    private void OnCounterClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(new NewRecord(PR));
    }

    async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}