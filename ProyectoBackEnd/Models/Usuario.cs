using System;
using System.Collections.Generic;

namespace ProyectoBackEnd.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string UsuCreador { get; set; } = null!;

    public string? UsuModificador { get; set; }

    public virtual ICollection<Autenticacion> Autenticacions { get; set; } = new List<Autenticacion>();

    public virtual ICollection<DatosPersonale> DatosPersonales { get; set; } = new List<DatosPersonale>();

    public virtual ICollection<UsuarioRole> UsuarioRoles { get; set; } = new List<UsuarioRole>();
}
