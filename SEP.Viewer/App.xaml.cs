using System.Windows;
using SEP.Database;

namespace SEP.Viewer
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Создаем базу данных при запуске программы
            using var db = new DatabaseContext();

            // При желании здесь позже можно будет выполнить
            // заполнение начальными данными.
        }
    }
}