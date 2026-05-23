using DevExpress.ExpressApp;
using TaskApp.Module.BusinessObjects;

namespace TaskApp.Module.Controllers
{
    /// <summary>
    /// Controlador para manejar la lógica de negocio de Tareas en vista de lista
    /// </summary>
    public class TareaListViewController : ObjectViewController<ListView, Tarea>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            // Aquí se pueden agregar lógicas cuando se activa la vista de lista de tareas
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }

    /// <summary>
    /// Controlador para manejar la lógica de negocio de Tareas en vista detallada
    /// </summary>
    public class TareaDetailViewController : ObjectViewController<DetailView, Tarea>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            // Lógica para la vista detallada
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }
}
