using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class TbCliente
{
    public int IdCliente { get; set; }

    public string NmCliente { get; set; } = null!;

    public string DsCpf { get; set; } = null!;

    public string NrCelular { get; set; } = null!;

    public string DsEmail { get; set; }

    public DateTime DtNascimento { get; set; }

    public string DsNacionalidade { get; set; } = null!;

    public virtual ICollection<TbCheckin> TbCheckins { get; set; } = new List<TbCheckin>();

    public virtual ICollection<TbClienteHospedagem> TbClienteHospedagems { get; set; } = new List<TbClienteHospedagem>();
}
