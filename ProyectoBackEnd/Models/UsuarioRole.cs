using System;
using System.Collections.Generic;

namespace ProyectoBackEnd.Models;

public partial class UsuarioRole
{
    public int UsuarioRolId { get; set; }

    public int UsuarioId { get; set; }

    public int RolId { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public string UsuCreador { get; set; } = null!;

    public virtual Role Rol { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
