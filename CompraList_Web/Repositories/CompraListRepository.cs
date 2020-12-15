using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompraList_Web.Models;
namespace CompraList_Web.Repositories
{
    public class CompraListRepository
    {

        compralistContext compralistContext = new compralistContext();


        public IEnumerable<Item> GetItems()
        {
            return compralistContext.Item;
        }

        public void AddItem(Item item)
        {
            compralistContext.Add(item);
            compralistContext.SaveChanges();
        }

        public void ChageStatusItem(int id)
        {
            Item item = compralistContext.Item.FirstOrDefault(x => x.Id == id);
            item.Listo = !item.Listo;
            compralistContext.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            Item item = compralistContext.Item.FirstOrDefault(x => x.Id == id);
            compralistContext.Remove(item);
        }

        public List<string> ValidateItem(Item item)
        {
            List<string> listErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(item.Nombre))
            {
                listErrors.Add("El nombre es necesario");
            }
            if (compralistContext.Item.Any(x=>x.Nombre == item.Nombre))
            {
                listErrors.Add("Ya existe un item con este nombre");
            }
            return listErrors;
        }

        public List<string> ValidateItemStatus(int id)
        {
            List<string> listErrors = new List<string>();
            Item item = compralistContext.Find<Item>(id);
            
            if (item == null)
            {
                listErrors.Add("El Item no existe");
            }
            if (compralistContext.Item.Any(x => x.Nombre == item.Nombre && x.Id != item.Id))
            {
                listErrors.Add("Ya existe un item con este nombre");

            }
            if (listErrors.Count > 0)
            {
                return listErrors;
            }
            else
            {
                return null;
            }
        }

        public List<string> ValidateItemRemove(int id)
        {
            List<string> listErrors = new List<string>();
            Item item = compralistContext.Find<Item>(id);
            if (item == null)
            {
                listErrors.Add("El Item que desea eliminar no existe");
            }
            if (listErrors.Count > 0)
            {
                return listErrors;
            }
            else
            {
                return null;
            }
        }
    }
}
