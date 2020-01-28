using System.Collections.Generic;

namespace PhoneBook.Service
{
    public interface IViewMain<T>
        where T : class
    {
        void InitTableView(List<T> contacts);
        void ReloadTableView();
    }
}