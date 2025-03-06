using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks.Dataflow;
using Avalonia.Media.Imaging;
using Desktop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReactiveUI;

namespace Desktop.ViewModels
{
	public class OrganizeProfileViewModel : ViewModelBase
	{
        private string nameFirst;
        private string nameLast;
        private string patronymic;
        private string numberPhone;
        private Bitmap image;
        private DateTime dr;

        public string NameFirst { get => nameFirst; set => this.RaiseAndSetIfChanged(ref nameFirst, value); }
        public string NameLast { get => nameLast; set => this.RaiseAndSetIfChanged(ref nameLast, value); }
        public string Patronymic { get => patronymic; set => this.RaiseAndSetIfChanged(ref patronymic, value); }
        public string NumberPhone { get => numberPhone; set => this.RaiseAndSetIfChanged(ref numberPhone, value); }
        public Bitmap Image { get => image; set => this.RaiseAndSetIfChanged(ref image, value); }
        public DateTime Dr { get => dr; set => this.RaiseAndSetIfChanged(ref dr, value); }
        public ReactiveCommand<Unit, object> NavigatetoOrganize { get; }
        public ReactiveCommand<Unit, Unit> UpdateData { get; }
        public int Idorgan { get => idorgan; set => this.RaiseAndSetIfChanged(ref idorgan, value); }
        public Organizer Organizer_data { get => organizer_data; set => this.RaiseAndSetIfChanged(ref organizer_data, value); }

        Organizer organizer_data;

        private int idorgan;

        public OrganizeProfileViewModel(MainWindowViewModel mvm, Organizer organizer) {
			NameFirst = organizer.NameFirst;
            NameLast = organizer.NameLast;
            Patronymic = organizer.Patronymic;
            NumberPhone = organizer.NumberPhone;
            Image = organizer.Image;
            Dr = organizer.Dr;
            NavigatetoOrganize = ReactiveCommand.Create(() => mvm.CurrentView = new OrganizeViewModel(mvm,organizer));
            UpdateData = ReactiveCommand.Create(SaveData);
            Idorgan = organizer.IdOrganizer;
        }
        public void SaveData()
        {
            Save(Idorgan, NameFirst, NameLast, Patronymic, NumberPhone, Dr);
        }
        public void Save(int idorgan, string name, string last, string patronymic, string number, DateTime dr) {
            organizer_data = db.Organizers.FirstOrDefault(o=> o.IdOrganizer == idorgan);
            if (organizer_data != null)
            {
                organizer_data.NameFirst = name;
                organizer_data.NameLast = last;
                organizer_data.Patronymic = patronymic;
                organizer_data.NumberPhone = number;
                organizer_data.Dr = dr;
                db.SaveChanges();
            }
        }
	}
}