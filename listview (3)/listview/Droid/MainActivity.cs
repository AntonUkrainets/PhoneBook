using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Android.Content;
using PhoneBook.ServicePresents.Service;
using PhoneBook.Droid.Adapter;
using PhoneBook.Model;
using PhoneBook.Service;
using System.Collections.Generic;
using PhoneBook.Presents.Implement;
using listview.Droid;

namespace PhoneBook.Droid
{
    [Activity(Label = "listview", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, IViewMain<Contact>
    {
        private RecyclerView _contactsRecyclerView;
        private ContactsAdapter _contactsAdapter;
        private IPresenterMainView _presenterMainView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);

            InitContactsRecyclerView();
            _presenterMainView = new PresenterMainView(this);
            _presenterMainView.InsertToDataView();
        }

        public void InitTableView(List<Contact> users)
        {
            _contactsAdapter = new ContactsAdapter(users);
            _contactsAdapter.NavigationToContactProfileView += NavigationToContactProfileView;
            _contactsAdapter.RemoveContact += RemoveContact;
            _contactsRecyclerView.SetAdapter(_contactsAdapter);
        }

        private void InitContactsRecyclerView()
        {
            _contactsRecyclerView = FindViewById<RecyclerView>(Resource.Id.ContactsRecyclerView);
            _contactsRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            _contactsRecyclerView.SetItemAnimator(new DefaultItemAnimator());
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.user_add_phone, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //if (item.ItemId != Resource.Drawable.add)
            //    return false;

            ShowAlertMessageButton();
            return true;
        }

        private void ShowAlertMessageButton()
        {
            var builder = new Android.Support.V7.App.AlertDialog.Builder(this);
            builder.SetTitle("Create new contact");

            var currentContext = Application.Context;
            var alertLayout = new LinearLayout(currentContext)
            {
                Orientation = Orientation.Vertical
            };

            builder.SetView(alertLayout);
            var dialog = builder.Show();

            var nameEditText = CreateEditText(currentContext, hint: "Name");
            var phoneEditText = CreateEditText(currentContext, hint: "Phone");
            var addButton = CreateAddAlertButton();

            alertLayout.AddView(nameEditText);
            alertLayout.AddView(phoneEditText);
            alertLayout.AddView(addButton);

            addButton.Click += delegate
            {
                _presenterMainView.AddContact(nameEditText.Text, phoneEditText.Text);

                dialog.Dismiss();
            };
        }

        private EditText CreateEditText(Context context, string hint)
        {
            var fieldEditText = new EditText(context)
            {
                Hint = hint
            };

            return fieldEditText;
        }

        private Button CreateAddAlertButton()
        {
            var addButton = new Button(this)
            {
                Text = "Add"
            };

            return addButton;
        }

        private void NavigationToContactProfileView(object sender, int position)
        {
            var contactProfileIntent = new Intent(this, typeof(ContactProfileActivity));
            contactProfileIntent.PutExtra("id", $"{position}");
            StartActivity(contactProfileIntent);
        }

        private void RemoveContact(object sender, int idx)
        {
            _presenterMainView.RemoveContact(idx, true);
        }

        public void ReloadTableView()
        {
            _contactsAdapter.NotifyDataSetChanged();
        }
    }
}