// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PhoneBook.iOS
{
    [Register ("ContactCell")]
    partial class ContactCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _contactImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _fNameContact { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _phoneContact { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_contactImage != null) {
                _contactImage.Dispose ();
                _contactImage = null;
            }

            if (_fNameContact != null) {
                _fNameContact.Dispose ();
                _fNameContact = null;
            }

            if (_phoneContact != null) {
                _phoneContact.Dispose ();
                _phoneContact = null;
            }
        }
    }
}