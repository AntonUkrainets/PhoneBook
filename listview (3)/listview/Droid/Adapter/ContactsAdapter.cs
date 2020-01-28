using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using listview.Droid;
using PhoneBook.Model;

namespace PhoneBook.Droid.Adapter
{
    public class ContactsAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> NavigationToContactProfileView;
        public event EventHandler<int> RemoveContact;
        public  List<Contact> _contacts { get; set; }

        public ContactsAdapter(List<Contact> contacts)
        {
            _contacts = contacts;
        }

        public override int ItemCount => _contacts.Count;

        private void NavigateToContactProfileView(int position) 
        {
            NavigationToContactProfileView?.Invoke(this, position);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var contact = _contacts[position];

            var contactHolder = holder as ContactViewHolder;
            contactHolder.Name.Text = contact.Name;
            contactHolder.Phone.Text = contact.Phone;

            var resId = (int)typeof(Resource.Drawable)
                    .GetField(contact.ProfileIcon)
                    .GetValue(null);

            contactHolder.ProfileIconImageView.SetImageResource(resId);
            contactHolder.RemoveContact.Click += delegate { RemoveContact?.Invoke(this, position); };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var contactView = LayoutInflater
                    .From(parent.Context)
                    .Inflate(Resource.Layout.Model, parent, false);

            return new ContactViewHolder(contactView, NavigateToContactProfileView);
        }
    }
}