using System;
using System.Collections.Generic;

namespace listview.Repository.Service
{
    public interface IRepositoriy<T>
    {
        List<T> GetAll();
        bool AddData(T data);
        T GetData(int idx);
        bool DropUser(int idx);
    }
}
