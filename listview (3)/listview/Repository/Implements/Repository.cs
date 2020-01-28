using PhoneBook.LocalApp.Implement;
using PhoneBook.LocalApp.Service;
using PhoneBook.Model;
using PhoneBook.Repository.Interfaces;
using System.Collections.Generic;

namespace PhoneBook.Repository.Implements
{
    public class Repository : IRepository<Contact>
    {
        private static ILocalApi<Contact> _localApi;
        private static IRepository<Contact> _repository;

        public Repository(ILocalApi<Contact> localApi)
        {
            _localApi = localApi;
        }

        public static IRepository<Contact> GetInstance()
        {
            if (_repository == null)
            {
                _repository = new Repository(LocalApi.GetInstance());
                _localApi.MockDataList();
            }

            return _repository;
        }

        public bool AddContact(Contact contact)
        {
            return _localApi.AddContact(contact);
        }

        public bool RemoveContact(int index)
        {
            return _localApi.RemoveContact(index);
        }

        public List<Contact> GetAll()
        {
            return _localApi.GetContactsData();
        }

        public Contact GetContact(int index)
        {
            return _localApi.GetContact(index);
        }
    }
}
