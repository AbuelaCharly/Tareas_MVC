using System;
using Microsoft.EntityFrameworkCore;

namespace TareasMVC.Entidades
{
	public class ArchivoAdjunto
	{
		public Guid Id { get; set; }

		public int TareaId { get; set; }
		public Tarea Tarea { get; set; }

		[Unicode] //De esta forma el dato será varchar y no nvarchar
		public string Url { get; set; }

		public string Titulo { get; set; }

		public int Orden { get; set; }

		public DateTime FechaCreacion { get; set; }
	}
}

