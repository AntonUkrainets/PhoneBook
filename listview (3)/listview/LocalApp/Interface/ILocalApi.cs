using System.Collections.Generic;

namespace PhoneBook.LocalApp.Service
{
    public interface ILocalApi<T>
        where T : class
    {
        List<T> GetContactsData();
        void MockDataList();
        bool AddContact(T user);
        T GetContact(int id);
        bool RemoveContact(int idx);
    }
}