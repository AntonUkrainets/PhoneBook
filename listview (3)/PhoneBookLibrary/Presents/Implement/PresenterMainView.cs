using System;
using System.Collections.Generic;
using PhoneBook.Model;
using PhoneBook.Repository.Interfaces;
using PhoneBook.Service;
using PhoneBook.ServicePresents.Service;

namespace PhoneBook.Presents.Implement
{
    public class PresenterMainView : IPresenterMainView
    {
        private IRepository<Contact> _contactsRepo;
        private IViewMain<Contact> _mainView;

        private List<string> _resourceIcon;
        private Random _random;

        public PresenterMainView(IViewMain<Contact> mainView)
        {
            _random = new Random();
            InitResourcesIconProfiles();

            _contactsRepo = Repository.Implements.Repository.GetInstance();
            _mainView = mainView;
        }

        public void RemoveContact(int id , bool isPlatform)
        {
            if (_contactsRepo.RemoveContact(id))
            {
                //if(isPlatform)
                    _mainView.ReloadTableView();
            }
        }

        public void InsertToDataView()
        {
            var contacts = _contactsRepo.GetAll();
            _mainView.InitTableView(contacts);
        }

        public void AddContact(string name, string phone)
        {
            int index = _random.Next(minValue: 0, maxValue: 4);
            var user = new Contact
            {
                Name = name,
                Phone = phone,
                ProfileIcon = _resourceIcon[index]
            };

            if (_contactsRepo.AddContact(user))
            {
                _mainView.ReloadTableView();
            }
        }

        private void InitResourcesIconProfiles()
        {
            _resourceIcon = new List<string>
            {
                "man",
                "userFirst",
                "userSecond",
                "worker"
            };
        }
    }
}
