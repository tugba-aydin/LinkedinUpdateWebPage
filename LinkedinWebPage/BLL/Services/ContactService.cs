using BLL.Interfaces;
using DAL.Models;
using DAL.Repository;
using DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> repository;
        private readonly IUnitofWork unitofWork;
        public ContactService(IRepository<Contact> _repository,IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }
        public void AddContact(Contact contact)
        {
            repository.Add(contact);
            unitofWork.saveChanges();
        }

        public void DeleteContact(int id)
        {
            repository.Delete(id);
            unitofWork.saveChanges();
        }

        public List<Contact> GetAllContact()
        {
            var contacts = repository.GetAll();
            return contacts;
        }

        public Contact GetContactById(int id)
        {
            var contact = repository.GetById(id);
            return contact;
        }

        public void UpdateContact(Contact contact)
        {
            repository.Update(contact);
            unitofWork.saveChanges();
        }
    }
}
