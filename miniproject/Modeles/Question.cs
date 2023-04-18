using System;
using System.Collections.Generic;

namespace WebApiMiniPj.Modeles;

public partial class Question
{
    public int QuestionId { get; set; }

    public int Levels { get; set; }

    public decimal Weights { get; set; }

    public int? Duration { get; set; }

    public string Comment { get; set; } = null!;

    public byte IsActive { get; set; }

    public byte IsDeleted { get; set; }
}
