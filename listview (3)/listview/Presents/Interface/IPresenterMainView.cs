namespace PhoneBook.ServicePresents.Service
{
    public interface IPresenterMainView
    {
        void InsertToDataView();
        void AddContact(string name, string phone);
        void RemoveContact(int id, bool isPlatform);
    }
}