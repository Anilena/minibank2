using System;
using System.Collections.Generic;
using System.Linq;
using minibank_client_api.Controllers;
using minibank_client_api.Models;

namespace minibank_test
{
    public class ClientControllerFake : IClientRepository
    {
        private readonly List<ShoppingItem> _shoppingCart;

        public ClientControllerFake()
        {
            _shoppingCart = new List<ShoppingItem>()
            {
                new ShoppingItem() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Name = "Orange Juice", Manufacturer="Orange Tree", Price = 5.00M },
                new ShoppingItem() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Name = "Diary Milk", Manufacturer="Mad Cow", Price = 4.00M },
                new ShoppingItem() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Name = "Frozen Pizza", Manufacturer="Uncle Mickey's", Price = 12.00M }
            };
        }

        public IEnumerable<ShoppingItem> GetAllItems()
        {
            return _shoppingCart;
        }

        public ShoppingItem Add(ShoppingItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            _shoppingCart.Add(newItem);
            return newItem;
        }

        public ShoppingItem GetById(Guid id)
        {
            return _shoppingCart.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            var existing = _shoppingCart.First(a => a.Id == id);
            _shoppingCart.Remove(existing);
        }


        ClientDb? IClientRepository.GetByUserName(string username)
        {
            throw new NotImplementedException();
        }

        ClientDb? IClientRepository.Add(ClientDb item)
        {
            throw new NotImplementedException();
        }

        ClientDb? IClientRepository.Update(ClientDb item)
        {
            throw new NotImplementedException();
        }

        bool IClientRepository.Remove(ClientDb item)
        {
            throw new NotImplementedException();
        }
    }
}