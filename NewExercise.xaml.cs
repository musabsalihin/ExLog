namespace ExLog;

public partial class NewExercise : ContentPage
{
    FirebaseHelper firebaseHelper = new FirebaseHelper();
    public NewExercise()
    {
        InitializeComponent();
    }
    private async void OnCancel(object sender, EventArgs e)
    {
        //Application.Current.MainPage.Navigation.PushModalAsync(new NewExercise());
        await Navigation.PopModalAsync();
    }

    async void OnAdd(object sender, EventArgs e)
    {
        //Application.Current.MainPage.Navigation.PushModalAsync(new NewExercise());

        var saveName = name.Text;
        var saveType = type.SelectedItem.ToString();
        var saveIcon = "";
        if(saveType == "Weightlifting")
        {
            saveIcon = "wl_icon.png";
        }
        else
        {
            saveIcon = "cardio_icon.png";
        }
        var saveDate = date.Date.ToString("dd MMMM, yyyy");
        var exSaveDate = date.Date.ToString("dd/MM/yyyy");
        var saveRecord = Double.Parse(record.Text);
        var saveUnit = unit.SelectedItem.ToString();

        await firebaseHelper.AddRecord(saveName, saveIcon, saveDate, saveRecord, saveUnit);
        await firebaseHelper.AddExerciseRecord(saveName, exSaveDate, saveRecord);

        await Navigation.PopModalAsync();
    }


}