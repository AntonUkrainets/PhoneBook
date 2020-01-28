namespace PhoneBook.Service
{
    public interface IViewContactProfile<T>
        where T : class
    {
        void SetContactView(T user);
    }
}