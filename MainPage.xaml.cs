namespace ExLog
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        FirebaseHelper firebaseHelper = new FirebaseHelper();

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            displayPR.ItemsSource = await firebaseHelper.GetAllPersonalRecord();

            
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new NewExercise());
        }

        void OnExercise(object sender, EventArgs e)
        {
            var frame = (Frame)sender;
            var item = (PersonalRecord)frame.BindingContext;
            var pr = item;
            if (pr.Type == "wl_icon.png")
            {
                pr.Type = "wl_icon_white.png";
            }
            else
            {
                pr.Type = "cardio_icon_white.png";
            }
            Application.Current.MainPage.Navigation.PushModalAsync(new Record(pr));
        }
    }

}
