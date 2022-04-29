using Google.Cloud.Firestore;

namespace test
{

    public partial class Form1 : Form
    {

        FirestoreDb db;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"maui-1aea6-firebase-adminsdk-drbke-e9e82c3973.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            db = FirestoreDb.Create("maui-1aea6");
        }
        void Add_Document_with_AutoID()
        {
            CollectionReference coll = db.Collection("Add_Document_Width_AutoID");
            Dictionary<string, object> data1 = new Dictionary<string, object>()
         {
        {"FirestName", "Kim" },
        {"LastName","Jinwon" },
        {"PhoneNumber", "010-1234-5678" }
         };
            coll.AddAsync(data1);
            MessageBox.Show("data added successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Document_with_AutoID();
        }
    }


}

