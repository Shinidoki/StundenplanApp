using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

//http://beta.der-onlinestundenplan.de/

namespace StundenplanApp
{
    [Activity(Label = "StundenplanApp", MainLauncher = true, Icon = "@drawable/logo", Theme = "@style/Theme.Custom")]
    public class MainActivity : Activity
    {
        string SelectedSchool;
        string SelectedClass;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            RestService test = new RestService();

            var testOut = test.getDataFromRest("");

            System.Diagnostics.Debug.WriteLine(testOut);

            // Get our button from the layout resource,
            // and attach an event to it
            Spinner spin = FindViewById<Spinner>(Resource.Id.spinner);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.schools, Android.Resource.Layout.SimpleSpinnerItem);


            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spin.Adapter = adapter;

            Button saveButton = FindViewById<Button>(Resource.Id.saveButton);

            saveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            Spinner schoolSpinner = FindViewById<Spinner>(Resource.Id.spinner);
            SelectedSchool = schoolSpinner.SelectedItem.ToString();

            TextView classText = FindViewById<TextView>(Resource.Id.classTextBox);
            SelectedClass = classText.Text;

            Toast.MakeText(this, "Daten wurden gespeichert", ToastLength.Short).Show();

            Toast.MakeText(this, string.Format("Schule: {0}; Klasse: {1}",SelectedSchool,SelectedClass), ToastLength.Short).Show();

        }


    }
}

