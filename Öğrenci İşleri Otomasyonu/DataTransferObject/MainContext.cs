using Öğrenci_İşleri_Otomasyonu.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject
{
    public class MainContext : IDisposable
    {
        public StudentManagementContext StudentManagementContext { get; set; }

        public MainContext()
        {
            StudentManagementContext = new StudentManagementContext();
        }

        public void Dispose()
        {
        }
    }
}
