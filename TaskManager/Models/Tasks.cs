using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI.WebControls;
namespace TaskManager.Models
{
    public class Tasks
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string Estado { get; set; }
        public int Prioridad { get; set; }
    }
}
