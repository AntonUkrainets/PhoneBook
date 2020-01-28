using System.Collections.Generic;

namespace PhoneBook.Repository.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        List<T> GetAll();
        bool AddContact(T contact);
        T GetContact(int index);
        bool RemoveContact(int index);
    }
}