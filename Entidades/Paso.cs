using System;
namespace TareasMVC.Entidades
{
	public class Paso
	{
		public Guid Id { get; set; } //Identificador global unico

		//LLAVE FORANEA
		public int TareaId { get; set; } //Con este nombre, por convencion, se formará la llave foránea
		public Tarea Tarea { get; set; } //Propiedad de navegacion

		public string Descripcion { get; set; }

		public bool Realizado { get; set; }

		public int Orden { get; set; }
	}
}

