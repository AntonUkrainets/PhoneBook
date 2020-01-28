using System.Collections.Generic;
using PhoneBook.LocalApp.Service;
using PhoneBook.Model;

namespace PhoneBook.LocalApp.Implement
{
    public class LocalApi : ILocalApi<Contact>
    {
        private static ILocalApi<Contact> _localApi;
        private static List<Contact> _contacts;

        public static ILocalApi<Contact> GetInstance()
        {
            if (_localApi == null)
            {
                _localApi = new LocalApi();
                _contacts = new List<Contact>();
            }

            return _localApi;
        }

        public List<Contact> GetContactsData()
        {
            return _contacts;
        }

        public Contact GetContact(int index)
        {
            try
            {
                return _contacts[index];
            }
            catch
            {
                return null;
            }
        }

        public bool AddContact(Contact contact)
        {
            try
            {
                _contacts.Insert(0, contact);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveContact(int index)
        {
            try
            {
                _contacts.RemoveAt(index);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void MockDataList()
        {
            _contacts.Add(new Contact { Name = "Anton", Phone = "380689263535", ProfileIcon = "man" });
            _contacts.Add(new Contact { Name = "Sara", Phone = "380675673965", ProfileIcon = "worker" });
            _contacts.Add(new Contact { Name = "John", Phone = "380839105627", ProfileIcon = "userSecond" });
            _contacts.Add(new Contact { Name = "Craig", Phone = "3808342801759", ProfileIcon = "userFirst" });
            _contacts.Add(new Contact { Name = "Lola", Phone = "380123456789", ProfileIcon = "man" });
        }
    }
}