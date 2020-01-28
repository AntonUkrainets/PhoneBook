using System;
using PhoneBook.Model;
using PhoneBook.Service;
using PhoneBook.ServicePresents.Service;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.Presents.Implement
{
    public class PresenterContactProfile : IPresenterContactProfile
    {
        private IRepository<Contact> _dataUser;
        private IViewContactProfile<Contact> _viewDetalisPage;
        public PresenterContactProfile(IViewContactProfile<Contact> viewDetalisPage)
        {
            _dataUser = Repository.Implements.Repository.GetInstance();
            _viewDetalisPage = viewDetalisPage;

        }

        public void InsertDataContact(int idx)
        {
            var user = _dataUser.GetContact(idx);
            _viewDetalisPage.SetContactView(user);
        }
    }
}
