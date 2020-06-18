
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SpinnerDialog.Droid
{
    public class CustomAdapter<T> : ArrayAdapter<T>
    {
        public CustomAdapter(Android.Content.Context context,int id,IList<T> items):base(context,id,items)
        {

        }

        public override View GetDropDownView(int position, View convertView, ViewGroup parent)
        {
            View v = null;
            v= base.GetDropDownView(position, convertView, parent);
            if (Constants.Position == position)
                v.SetBackgroundColor(Color.Brown);
            else
                v.SetBackgroundColor(Color.White);
            return v;
        }
    }
}
