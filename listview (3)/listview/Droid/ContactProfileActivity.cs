using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using listview.Droid;
using PhoneBook.Model;
using PhoneBook.Presents.Implement;
using PhoneBook.Service;
using PhoneBook.ServicePresents.Service;

namespace PhoneBook.Droid
{
    [Activity(Label = "ContactProfileActivity")]
    public class ContactProfileActivity : Activity, IViewContactProfile<Contact>
    {
        private IPresenterContactProfile _presenterContactProfile;

        private TextView _nameTextView;
        private TextView _phoneTextView;
        private ImageView _profileImageView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ContactProfileView);

            InitUIControllers();

            GetPresenterDependencies();

            GetProfileViewData();
        }

        private void GetPresenterDependencies()
        {
            _presenterContactProfile = new PresenterContactProfile(this);
        }

        private void GetProfileViewData()
        {
            var index = int.Parse(Intent.GetStringExtra("id"));
            _presenterContactProfile?.InsertDataContact(index);
        }

        private void InitUIControllers()
        {
            _nameTextView = FindViewById<TextView>(Resource.Id.NameTextView);
            _phoneTextView = FindViewById<TextView>(Resource.Id.PhoneTextView);
            _profileImageView = FindViewById<ImageView>(Resource.Id.ProfileImageView);
        }

        public void SetContactView(Contact contact)
        {
            _profileImageView.SetImageResource((int)typeof(Resource.Drawable).GetField(contact.ProfileIcon).GetValue(null));
            _nameTextView.Text = contact.Name;
            _phoneTextView.Text = contact.Phone;
        }
    }
}