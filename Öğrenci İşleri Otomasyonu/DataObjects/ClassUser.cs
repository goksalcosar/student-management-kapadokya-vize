using System;
using System.Collections.Generic;

namespace Öğrenci_İşleri_Otomasyonu.DataObjects;

public partial class ClassUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
