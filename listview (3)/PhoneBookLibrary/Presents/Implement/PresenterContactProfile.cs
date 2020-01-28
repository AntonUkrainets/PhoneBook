using PhoneBook.Model;
using PhoneBook.Service;
using PhoneBook.ServicePresents.Service;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.Presents.Implement
{
    public class PresenterContactProfile : IPresenterContactProfile
    {
        private IRepository<Contact> _contactData;
        private IViewContactProfile<Contact> _contactProfileView;
        public PresenterContactProfile(IViewContactProfile<Contact> contactProfileView)
        {
            _contactData = Repository.Implements.Repository.GetInstance();
            _contactProfileView = contactProfileView;
        }

        public void InsertDataContact(int index)
        {
            var contact = _contactData.GetContact(index);
            _contactProfileView.SetContactView(contact);
        }
    }
}