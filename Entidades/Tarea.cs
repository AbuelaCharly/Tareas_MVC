using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TareasMVC.Entidades
{
	public class Tarea
	{
		public int Id { get; set; } //EF lo considera Primary Key incrementable automaticamente

		[StringLength(250)]
		[Required]
		public string Titulo { get; set; }

		public string Descripcion { get; set; }

		public int Orden { get; set; }

		public DateTime FechaCreacion { get; set; }

		//Aqui colocamos el Id del usuario que a creado la tarea
		public string UsuarioCreacionId { get; set; }

		//Propiedades de navegacion
		public List<Paso> Paso { get; set; }
		public List<ArchivoAdjunto> ArchivosAdjuntos { get; set; }
		public IdentityUser UsuarioCreacion { get; set; }
	}
}

