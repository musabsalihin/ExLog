using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExLog;

public partial class NewRecord : ContentPage
{
    protected PersonalRecord PR;
    FirebaseHelper firebaseHelper = new FirebaseHelper();

    public NewRecord(PersonalRecord pr)
    {
        InitializeComponent();
        PR = pr;

        exerciseName.Text = PR.Name;
        exerciseIcon.Source = PR.Type;
    }

    private async void OnCancel(object sender, EventArgs e)
    {
        //Application.Current.MainPage.Navigation.PushModalAsync(new NewExercise());
        await Navigation.PopModalAsync();
    }
    async void OnSave(object sender, EventArgs e)
    {
        var saveDate = date.Date.ToString("dd/MM/yyyy");
        var saveRecord = Double.Parse(record.Text);

        await firebaseHelper.AddExerciseRecord(PR.Name, saveDate, saveRecord);
        await Navigation.PopModalAsync();

    }


    async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}