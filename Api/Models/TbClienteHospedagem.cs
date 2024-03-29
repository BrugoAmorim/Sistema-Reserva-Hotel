﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Models;

public partial class TbClienteHospedagem
{
    public int IdClienteHospedagem { get; set; }

    public DateTime DtEstadia { get; set; }

    public int QtdDias { get; set; }

    public int IdCliente { get; set; }

    public int IdQuarto { get; set; }

    public virtual TbCliente IdClienteNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual TbQuarto IdQuartoNavigation { get; set; } = null!;
}
