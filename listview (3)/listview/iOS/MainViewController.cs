using PhoneBook.Model;
using PhoneBook.Presents.Implement;
using PhoneBook.Service;
using PhoneBook.ServicePresents.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace PhoneBook.iOS
{
    public partial class MainViewController : UITableViewController, IViewMain<Contact>
    {
        private IPresenterMainView _presenterMainView;
        private TableViewSource _tableViewSource;
        public MainViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitPresenterDependencies();
        }

        private void InitPresenterDependencies()
        {
            _presenterMainView = new PresenterMainView(this);
            _presenterMainView.InsertToDataView();
        }

        public void InitTableView(List<Contact> contacts)
        {
            _tableViewSource = new TableViewSource(contacts);
            _tableViewSource.ContactProfileView += NavigateToContactProfileView;
            _tableViewSource.RemoveContact += RemoveContact;
            ContactsTableView.Source = _tableViewSource;
        }

        public void ReloadTableView()
        {
            ContactsTableView.ReloadData();
        }

        private void RemoveContact(object sender, int index)
        {
            _presenterMainView.RemoveContact(index, false);
        }

        private void NavigateToContactProfileView(object sender, int index)
        {
            var contactProfileView = Storyboard.InstantiateViewController("ContactProfileViewController") as ContactProfileViewController;
            contactProfileView.Index = index;
            contactProfileView.ModalPresentationStyle = UIModalPresentationStyle.OverFullScreen;
            NavigationController.PushViewController(contactProfileView, true);
        }


        partial void AddNewContact(UIBarButtonItem sender)
        {
            var alert = UIAlertController.Create("New User", "", UIAlertControllerStyle.Alert);

            CreateAlertButton(alert, placeholder: "Enter Name");
            CreateAlertButton(alert, placeholder: "Enter Phone");

            var saveAction = UIAlertAction.Create("Save", UIAlertActionStyle.Default, (action) =>
            {
                var nameTextField = alert.TextFields.First().Text;
                var phoneTextField = alert.TextFields.Last().Text;
                _presenterMainView.AddContact(nameTextField, phoneTextField);
            });

            var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (action) => { });

            alert.AddAction(saveAction);
            alert.AddAction(cancelAction);

            PresentViewController(alert, animated: true, completionHandler: null);
        }

        private void CreateAlertButton(UIAlertController alert, string placeholder)
        {
            alert.AddTextField((fieldTextField) =>
            {
                fieldTextField.Placeholder = placeholder;
                fieldTextField.AutocorrectionType = UITextAutocorrectionType.No;
                fieldTextField.KeyboardType = UIKeyboardType.Default;
                fieldTextField.ReturnKeyType = UIReturnKeyType.Done;
                fieldTextField.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            });
        }
    }
}