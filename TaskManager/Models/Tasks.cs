using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace TaskManager.Models
{
    public class Tasks
    {
        public int ID { get; set; }

        [Display(Name = "Descripción.")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha de creación.")]
        public DateTime FechaDeCreacion { get; set; }

        public string Estado { get; set; }

        public int Prioridad { get; set; }


        [NotMapped]
        public List<SelectListItem> ListaDeEstados { get; set; }

        [NotMapped]
        public List<SelectListItem> ListaDePrioridades { get; set; }

        public Tasks()
        {
            ListaDeEstados = new List<SelectListItem>
            {
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "En Progreso", Text = "En Progreso" },
                new SelectListItem { Value = "Completado", Text = "Completado" },
                new SelectListItem { Value = "Cancelada", Text = "Cancelada" }
            }; 
            
            ListaDePrioridades = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "Baja"},
                new SelectListItem { Value = "1", Text = "Media" },
                new SelectListItem { Value = "2", Text = "Alta" },
                new SelectListItem { Value = "3", Text = "Urgente" }
            };
        }
    }
}
