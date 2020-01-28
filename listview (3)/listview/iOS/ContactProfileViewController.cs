using PhoneBook.Model;
using PhoneBook.Presents.Implement;
using PhoneBook.Service;
using PhoneBook.ServicePresents.Service;
using System;
using UIKit;

namespace PhoneBook.iOS
{
    public partial class ContactProfileViewController : UIViewController, IViewContactProfile<Contact>
    {
        private IPresenterContactProfile _presenterContactProfile;
        public int Index { get; set; }
        public ContactProfileViewController (IntPtr handle) : base (handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _presenterContactProfile = new PresenterContactProfile(this);
            _presenterContactProfile.InsertDataContact(Index);
        }

        public void SetContactView(Contact contact)
        {
            _detalisUser.Text = contact.Name;
            _detalisPhone.Text = contact.Phone;
            _detalisImage.Image = UIImage.FromFile(contact.ProfileIcon);
        }
    }
}