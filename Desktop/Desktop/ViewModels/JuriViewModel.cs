using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reactive;
using Desktop.Models;
using Microsoft.Extensions.Logging;
using ReactiveUI;

namespace Desktop.ViewModels
{
	public class JuriViewModel : ViewModelBase
	{
        private bool isvisiable;
        private bool isvisiable1;
        private List<Juri> juriList;
        public ReactiveCommand<Unit, object> NavigatetoLogin { get; }
        public ReactiveCommand<Unit, object> NavigatetoOrganize { get; }
        public JuriViewModel(MainWindowViewModel mvm, Organizer organizer) {
            NavigatetoLogin = ReactiveCommand.Create(() => mvm.CurrentView = new LoginViewModel(mvm));
            NavigatetoOrganize = ReactiveCommand.Create(() => mvm.CurrentView = new OrganizeViewModel(mvm, organizer));
            JuriList = db.Juris.Select(e => new Juri
            {
                NameFirst = e.NameFirst,
                Foto = e.Foto,
                NameLast = e.NameLast,
                Patronymic = e.Patronymic,
                NumberPhone = e.NumberPhone
            }).ToList();
            if (organizer == null)
            {
                Isvisiable = true;
                Isvisiable1 = false;
            }
            if (organizer != null)
            {
                Isvisiable = false;
                Isvisiable1 = true;
            }
        }

        public List<Juri> JuriList { get => juriList; set => this.RaiseAndSetIfChanged(ref juriList, value); }
        public bool Isvisiable { get => isvisiable; set => this.RaiseAndSetIfChanged(ref isvisiable, value); }
        public bool Isvisiable1 { get => isvisiable1; set => this.RaiseAndSetIfChanged(ref isvisiable1, value); }
    }
}