using System;
using System.Collections.Generic;

namespace ProyectoBackEnd.Models;

public partial class Autenticacion
{
    public int AutenticacionId { get; set; }

    public int UsuarioId { get; set; }

    public string Contrasena { get; set; } = null!;

    public int IntentosFallidos { get; set; }

    public bool Bloqueado { get; set; }

    public DateTime? FechaUltimoIntento { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string UsuCreador { get; set; } = null!;

    public string? UsuModificador { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
