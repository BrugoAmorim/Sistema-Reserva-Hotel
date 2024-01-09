using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class TbCheckout
{
    public int IdCheckout { get; set; }

    public string NmCliente { get; set; } = null!;

    public string NrQuarto { get; set; } = null!;

    public DateTime DtHoraCheckout { get; set; }

    public int IdCheckin { get; set; }

    public virtual TbCheckin IdCheckinNavigation { get; set; } = null!;
}
