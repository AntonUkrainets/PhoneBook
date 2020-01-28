using System;
using System.Collections.Generic;
using PhoneBook.LocalApp.Implement;
using PhoneBook.LocalApp.Service;
using PhoneBook.Model;
using NUnit.Framework;

namespace TestListView
{
    public class LocalTestApp
    {
        private ILocalApi<Contact> _localApi;
        private Contact _contact;
        [SetUp]
        public void Setup()
        {
            _localApi = LocalApi.GetInstance();
            _contact = new Contact { Name = "Anton", Phone = "380689263535", ProfileIcon = "man" };
        }

        [Test]
        public void GetAllContacts()
        {
            //Given
            var contacts = new List<Contact>();
            contacts.Add(_contact);
            contacts.Add(_contact);

            //When
            var actual = _localApi.GetContactsData();

            //Then
            Assert.AreEqual(contacts, actual);
        }

        [TestCase(0, false)]
        [TestCase(-1, true)]
        public void GetContact(int index, bool isExeption)
        {
            //Given
            Contact result;
            if (isExeption)
            {
                result = null;
            }
            else
            {
                result = _contact;
                _localApi.AddContact(_contact);
            }
            //When
            var actual = _localApi.GetContact(index);

            //Then
            Assert.AreEqual(result, actual);
        }

        [TestCase(0, true)]
        [TestCase(-1, false)]
        public void RemoveContactData(int index, bool result)
        {
            //Given
            _localApi.AddContact(_contact);

            //When
            var actual = _localApi.RemoveContact(index);

            //Then
            Assert.AreEqual(result, actual);
        }


        [Test]
        public void AddContactData()
        {
            //Given
            var contact = _contact;
            //When
            var actual = _localApi.AddContact(contact);

            //Then
            Assert.AreEqual(true, actual);
        }

    }
}