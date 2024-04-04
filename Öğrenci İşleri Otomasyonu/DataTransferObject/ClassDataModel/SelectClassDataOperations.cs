using Microsoft.EntityFrameworkCore;
using Öğrenci_İşleri_Otomasyonu.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.ClassDataModel
{
    public static class SelectClassDataOperations
    {
        public static Dictionary<string, int> getAllClass()
        {
            return (from item in (new MainContext()).StudentManagementContext.Classes
                    select new
                    {
                        item.Id,
                        item.Name,
                       item.Number
                    })
                     .AsEnumerable()
                    .ToDictionary(
                        x => x.Name,   
                        x => x.Number 
                    );
        }
    }
}
