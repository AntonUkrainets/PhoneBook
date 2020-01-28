using PhoneBook.Model;
using System;
using UIKit;

namespace PhoneBook.iOS
{
    public partial class ContactCell : UITableViewCell
    {
        public ContactCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateCell(Contact contact)
        {
            _fNameContact.Text = contact.Name;
            _phoneContact.Text = contact.Phone;
            _contactImage.Image = UIImage.FromFile(contact.ProfileIcon);
        }
    }
}