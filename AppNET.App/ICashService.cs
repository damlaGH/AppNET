using AppNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.App
{
    public interface ICashService
    {
        decimal ShowBalance();

        //decimal FilterByDate(Invoice invoice);
    }
}
