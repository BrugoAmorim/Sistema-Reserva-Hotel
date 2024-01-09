using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class TbQuarto
{
    public int IdQuarto { get; set; }

    public string NrQuarto { get; set; } = null!;

    public bool BlDisponivel { get; set; }

    public bool BlVaranda { get; set; }

    public bool BlSuite { get; set; }

    public bool BlCafeManha { get; set; }

    public string DsQuarto { get; set; } = null!;

    public int IdHospedagem { get; set; }

    public virtual TbHospedagem IdHospedagemNavigation { get; set; } = null!;

    public virtual ICollection<TbCheckin> TbCheckins { get; set; } = new List<TbCheckin>();

    public virtual ICollection<TbClienteHospedagem> TbClienteHospedagems { get; set; } = new List<TbClienteHospedagem>();
}
