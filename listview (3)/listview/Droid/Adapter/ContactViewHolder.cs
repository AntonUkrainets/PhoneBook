using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using listview.Droid;

namespace PhoneBook.Droid.Adapter
{
    public class ContactViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; set; }
        public TextView Phone { get; set; }
        public ImageView ProfileIconImageView;
        public Button RemoveContact;

        public ContactViewHolder(View contactView, Action<int> listener) : base(contactView)
        {
            InitUIControllers(contactView);

           contactView.Click += delegate { listener(LayoutPosition); };
        }

        private void InitUIControllers(View contactView)
        {
            Name = contactView.FindViewById<TextView>(Resource.Id.ContactNameTextView);
            Phone = contactView.FindViewById<TextView>(Resource.Id.ContactPhoneTextView);
            ProfileIconImageView = contactView.FindViewById<ImageView>(Resource.Id.ContactProfileImageView);
            RemoveContact = contactView.FindViewById<Button>(Resource.Id.ContactRemoveButton);
        }
    }
}