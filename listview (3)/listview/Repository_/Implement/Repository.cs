using System;
using System.Collections.Generic;
using listview.LocalApp.Implement;
using listview.LocalApp.Service;
using listview.Model;
using listview.Repository.Service;

namespace listview.Repository.Implement
{
    public class Repository : IRepositoriy<User>
    {
        private static ILocalDataBase<User> _localData;
        private static IRepositoriy<User> _repositoriy;

        public Repository(ILocalDataBase<User> localDataBase)
        {
            _localData = localDataBase;
        }

        public static IRepositoriy<User> GetInstance()
        {
            if (_repositoriy == null)
            {
                _repositoriy = new Repository(LocalDataBase.GetInstance());
                _localData.MockDataList();
            }
            return _repositoriy;
        }


        public bool AddData(User data)
        {
            return _localData.DataAdd(data);
        }

        public bool DropUser(int idx)
        {
            return _localData.DeleteUser(idx);
        }

        public List<User> GetAll()
        {
            return _localData.GetListData();
        }

        public User GetData(int idx)
        {
            return _localData.GetData(idx);
        }
    } 
}
