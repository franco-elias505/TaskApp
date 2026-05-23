using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using TaskApp.Module.BusinessObjects;

namespace TaskApp.Module.Services
{
    /// <summary>
    /// Servicio para inicializar datos de seguridad y roles
    /// </summary>
    public class SecurityInitializationService
    {
        /// <summary>
        /// Inicializa los roles y permisos de seguridad
        /// </summary>
        public static void InitializeSecurityData(IObjectSpace objectSpace)
        {
            // Crear el rol "TaskManager"
            var taskManagerRole = objectSpace.FirstOrDefault<PermissionPolicyRole>(r => r.Name == "TaskManager");

            if (taskManagerRole == null)
            {
                taskManagerRole = objectSpace.CreateObject<PermissionPolicyRole>();
                taskManagerRole.Name = "TaskManager";
                taskManagerRole.IsAdministrative = false;
                objectSpace.CommitChanges();
            }

            // Crear el rol "Admin" si no existe
            var adminRole = objectSpace.FirstOrDefault<PermissionPolicyRole>(r => r.Name == "Admin");
            if (adminRole == null)
            {
                adminRole = objectSpace.CreateObject<PermissionPolicyRole>();
                adminRole.Name = "Admin";
                adminRole.IsAdministrative = true;
                objectSpace.CommitChanges();
            }

            // Crear usuario administrativo por defecto
            var adminUser = objectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == "admin");
            if (adminUser == null)
            {
                adminUser = objectSpace.CreateObject<ApplicationUser>();
                adminUser.UserName = "admin";
                adminUser.SetPassword("admin123");
                adminUser.Roles.Add(adminRole);
                objectSpace.CommitChanges();
            }
        }
    }
}
