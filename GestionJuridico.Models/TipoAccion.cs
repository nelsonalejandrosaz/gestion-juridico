﻿using System.ComponentModel.DataAnnotations;

namespace GestionJuridico.Models;

public class TipoAccion
{
    public int Id { get; set; }

    [Required]
    [MaxLength(2)]
    public string Codigo { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; }

    //public ICollection<Accion> Acciones { get; set; }
}