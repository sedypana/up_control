using Desktop.Models;
using ReactiveUI;

namespace Desktop.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public PostgresContext db = new PostgresContext();

    }
}
