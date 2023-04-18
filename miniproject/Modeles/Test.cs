using System;
using System.Collections.Generic;

namespace WebApiMiniPj.Modeles;

public partial class Test
{
    public int TestId { get; set; }

    public string Comment { get; set; } = null!;

    public byte IsActive { get; set; }

    public byte IsDeleted { get; set; }
}
