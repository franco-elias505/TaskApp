using DevExpress.EntityFrameworkCore.Security;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.EFCore;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Updating;
using Microsoft.EntityFrameworkCore;
using TaskApp.Module.BusinessObjects;

namespace TaskApp.Blazor.Server
{
    public class TaskAppBlazorApplication : BlazorApplication
    {
        public TaskAppBlazorApplication()
        {
            ApplicationName = "TaskApp";
            CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
            DatabaseVersionMismatch += TaskAppBlazorApplication_DatabaseVersionMismatch;
        }
        protected override void OnSetupStarted()
        {
            base.OnSetupStarted();

#if DEBUG
            // En DEBUG, siempre actualizar la BD automáticamente
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
#endif
        }
        void TaskAppBlazorApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e)
        {
#if DEBUG
            // En DEBUG, siempre actualizar la BD automáticamente (incluyendo BD en memoria)
            e.Updater.Update();
            e.Handled = true;
#elif EASYTEST
            e.Updater.Update();
            e.Handled = true;
#else
            string message = "The application cannot connect to the specified database, " +
                "because the database doesn't exist, its version is older " +
                "than that of the application or its schema does not match " +
                "the ORM data model structure. To avoid this error, use one " +
                "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

            if (e.CompatibilityError != null && e.CompatibilityError.Exception != null)
            {
                message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
            }
            throw new InvalidOperationException(message);
#endif
        }
    }
}
