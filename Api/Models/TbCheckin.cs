using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class TbCheckin
{
    public int IdCheckin { get; set; }

    public string NmCliente { get; set; } = null!;

    public string DsCpf { get; set; } = null!;

    public string NrQuarto { get; set; } = null!;

    public DateTime DtHoraCheckin { get; set; }

    public int IdCliente { get; set; }

    public int IdQuarto { get; set; }

    public virtual TbCliente IdClienteNavigation { get; set; } = null!;

    public virtual TbQuarto IdQuartoNavigation { get; set; } = null!;

    public virtual ICollection<TbCheckout> TbCheckouts { get; set; } = new List<TbCheckout>();
}
