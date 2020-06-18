using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;
using Android.Views;

namespace SpinnerDialog.Droid
{
    [Activity(Label = "SpinnerDialog", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, View.IOnClickListener
    {
        int count = 1;

        Spinner spinnerControl;
        RelativeLayout spinnerRl;

        List<Combo> combos;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            spinnerControl = FindViewById<Spinner>(Resource.Id.spinnerControl);
            spinnerRl = FindViewById<RelativeLayout>(Resource.Id.spinnerRl);

            LoadComboValues();
            AssignSpinner();
            spinnerControl.SetSelection(0);
            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.myButton);

            //button.Click += delegate { button.Text = $"{count++} clicks!"; };
        }

        void AssignSpinner()
        {
            var adapter = new CustomAdapter<Combo>(this, Android.Resource.Layout.SimpleSpinnerItem, combos);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleListItemSingleChoice);
            spinnerControl.Adapter = adapter;

            spinnerControl.ItemSelected += SpinnerControlItemSelected;
        }

        private void SpinnerControlItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if(e!=null)
            Constants.Position = e.Position;
        }

        void LoadComboValues()
        {
            combos = new List<Combo>();

            combos.Add(new Combo() { Id = 1, Title = "Bus" }) ;

            combos.Add(new Combo() { Id = 2, Title = "Flight" });

            combos.Add(new Combo() { Id = 3, Title = "Train" });

            combos.Add(new Combo() { Id = 4, Title = "Car" });

            combos.Add(new Combo (){ Id = 5, Title = "Auto" });

            combos.Add(new Combo() { Id = 6, Title = "Bike" });

        }

        public   void OnClick(View v)
        {
            switch(v.Id)
            {
                case Resource.Id.spinnerRl:
                    spinnerControl.PerformClick();
                    break;
            }
        }
    }

    public class Combo:IComboValue
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }

   interface IComboValue
    {
        int Id { get; set; }
        string Title { get; set; }
    }
}

