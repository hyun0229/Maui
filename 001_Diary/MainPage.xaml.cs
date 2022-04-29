namespace _001_Diary;
using Google.Cloud.Firestore;

public partial class MainPage : ContentPage
{

    FirestoreDb db;
    public MainPage()
	{
		InitializeComponent();
        string path = AppDomain.CurrentDomain.BaseDirectory + @"maui-1aea6-firebase-adminsdk-drbke-e9e82c3973.json";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

        db = FirestoreDb.Create("maui-1aea6");

    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        String xa = dP.Date.ToString();
        Add_Diary(xa, memo.Text);
    }

    private void btnLoad_Clicked(object sender, EventArgs e)
    {
        String xa = dP.Date.ToString();
        Load_Diary(xa);

    }

    private void dP_DateSelected(object sender, DateChangedEventArgs e)
    {
  

    }
    void Add_Diary(string a, string b)
    {
        DocumentReference DOC = db.Collection("Diary").Document(a);
        Dictionary<string, object> data1 = new Dictionary<string, object>()
    {
        {"Memo", b }
    };
        DOC.SetAsync(data1);

    }
    async void Load_Diary(string a)
    {
        DocumentReference docref = db.Collection("Diary").Document(a);
        DocumentSnapshot snap = await docref.GetSnapshotAsync();

        if (snap.Exists)
        {
            Dictionary<string, object> city = snap.ToDictionary();
            foreach (var item in city)
            {
                memo.Text = item.Value.ToString();

            }
        }
    }

}

