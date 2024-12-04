using System;
using System.Collections.Generic;

namespace ProyectoBackEnd.Models;

public partial class DatosPersonale
{
    public int DatosPersonalesId { get; set; }

    public int UsuarioId { get; set; }

    public string Direccion { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public string? Nacionalidad { get; set; }

    public string? EstadoCivil { get; set; }

    public string? Ocupacion { get; set; }

    public string Identificacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string UsuCreador { get; set; } = null!;

    public string? UsuModificador { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
