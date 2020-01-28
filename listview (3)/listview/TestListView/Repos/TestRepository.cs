using System.Collections.Generic;
using PhoneBook.LocalApp.Service;
using PhoneBook.Model;
using PhoneBook.Repository.Interfaces;
using Moq;
using NUnit.Framework;

namespace TestListView.Repos
{
    public class TestRepository
    {
        private IRepository<Contact> _repository;
        private Mock<ILocalApi<Contact>> _localApiMock;
        private Contact _contact;

        [SetUp]
        public void Setup()
        {
            _localApiMock = new Mock<ILocalApi<Contact>>(MockBehavior.Strict);
            _repository = new PhoneBook.Repository.Implements.Repository(_localApiMock.Object);

            _contact = new Contact { Name = "Anton", Phone = "380689263535", ProfileIcon = "man" };
        }

        [Test]
        public void GetInstanceTest()
        {
            //When
            var actual = PhoneBook.Repository.Implements.Repository.GetInstance();

            //Then
            Assert.IsNotNull(actual);
        }

        [Test]
        public void GetAllTest()
        {
            //Given
            List<Contact> contacts = new List<Contact>();
            contacts.Add(_contact);
            _localApiMock.Setup(c => c.GetContactsData()).Returns(contacts);

            //When
            var actual = _repository.GetAll();
            //Then

            Assert.AreEqual(contacts, actual);
            _localApiMock.Verify(c => c.GetContactsData(), Times.Once);
        }

        [Test]
        public void GetContactDataTest()
        {
            //Given
            _localApiMock
                    .Setup(c => c.GetContact(1))
                    .Returns(_contact);

            //When
            var actual = _repository.GetContact(1);

            //Then
            Assert.AreEqual(_contact, actual);
            _localApiMock.Verify(c => c.GetContact(1), Times.Once);
        }

        [Test]
        public void RemoveContactTest()
        {
            //Given
            _localApiMock.Setup(c => c.RemoveContact(1)).Returns(true);

            //When
            var actual = _repository.RemoveContact(1);

            //Then
            Assert.IsTrue(actual);
            _localApiMock.Verify(c => c.RemoveContact(1), Times.Once);
        }
        [Test]
        public void AddContactDataTest()
        {
            //Given
            _localApiMock
                    .Setup(c => c.AddContact(_contact))
                    .Returns(true);

            //When
            var actual = _repository.AddContact(_contact);

            //Then
            Assert.IsTrue(actual);
            _localApiMock.Verify(c => c.AddContact(_contact), Times.Once);
        }
    }
}