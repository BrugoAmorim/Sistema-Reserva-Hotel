using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class TbHospedagem
{
    public int IdHospedagem { get; set; }

    public string DsTipoHospedagem { get; set; } = null!;

    public decimal VlDiaria { get; set; }

    public decimal VlMultaHora { get; set; }

    public virtual ICollection<TbQuarto> TbQuartos { get; set; } = new List<TbQuarto>();
}
