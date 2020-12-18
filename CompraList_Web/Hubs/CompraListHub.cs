using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using CompraList_Web.Models;
using CompraList_Web.Repositories;

namespace CompraList_Web.Hubs
{
    public class CompraListHub:Hub
    {

        CompraListRepository compraListRepository = new CompraListRepository();

        public async Task SyncronizeItems()
        {
            await Clients.All.SendAsync("ReceiveMessage", compraListRepository.GetItems());
        }

    }
}
