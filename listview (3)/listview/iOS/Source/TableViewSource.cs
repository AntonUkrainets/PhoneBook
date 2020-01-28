using System;
using System.Collections.Generic;
using Foundation;
using PhoneBook.Model;
using UIKit;

namespace PhoneBook.iOS
{
    internal class TableViewSource : UITableViewSource
    {
        public event EventHandler<int> RemoveContact;
        public event EventHandler<int> ContactProfileView;
        private const string indentifier = "user_id";
        public List<Contact> Contacts { get; set; }

        public TableViewSource(List<Contact> contacts)
        {
            this.Contacts = contacts;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (ContactCell)tableView.DequeueReusableCell(indentifier, indexPath);
            var contact = Contacts[indexPath.Row];

            cell.UpdateCell(contact);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Contacts.Count;
        }

        public override void CommitEditingStyle(
            UITableView tableView,
            UITableViewCellEditingStyle editingStyle,
            NSIndexPath indexPath)
        {
            RemoveContact?.Invoke(this, indexPath.Row);
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            ContactProfileView?.Invoke(this, indexPath.Row);
        }
    }
}