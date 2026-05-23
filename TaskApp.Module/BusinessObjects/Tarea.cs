using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;

namespace TaskApp.Module.BusinessObjects
{
    [DefaultProperty(nameof(Descripcion))]
    [ModelDefault("Caption", "Tarea")]
    [NavigationItem("Default")]
    public class Tarea : BaseObject
    {
        /// <summary>
        /// Descripción de la tarea
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(500)]
        [ModelDefault("Caption", "Descripción")]
        public virtual string Descripcion { get; set; } = string.Empty;

        /// <summary>
        /// Indica si la tarea está completada
        /// </summary>
        [ModelDefault("Caption", "Completada")]
        public virtual bool Completada { get; set; }

        /// <summary>
        /// Fecha de creación de la tarea
        /// </summary>
        [ModelDefault("Caption", "Creada en")]
        [ModelDefault("DisplayFormat", "G")]
        public virtual DateTime CreadaEn { get; set; }

        public Tarea()
        {
            CreadaEn = DateTime.Now;
            Completada = false;
            Descripcion = string.Empty;
        }

        /// <summary>
        /// Marca la tarea como completada
        /// </summary>
        public void MarcarComoCompletada()
        {
            Completada = true;
        }
    }
}
