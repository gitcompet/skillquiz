using System;
using System.Collections.Generic;

namespace WebApiMiniPj.Modeles;

public partial class Quiz
{
    public int QuizId { get; set; }

    public decimal Weights { get; set; }

    public string Comment { get; set; } = null!;

    public byte IsActive { get; set; }

    public byte IsDeleted { get; set; }
}
