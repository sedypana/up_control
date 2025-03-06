using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using Desktop.Models;
using ReactiveUI;

namespace Desktop.ViewModels
{
	public class ParticipantViewModel : ViewModelBase
	{
        private List<Participant> participants;
        private bool isvisiable;
        private bool isvisiable1;
        public ReactiveCommand<Unit, object> NavigatetoLogin { get; }
        public ReactiveCommand<Unit, object> NavigatetoOrganize { get; }
        public ParticipantViewModel(MainWindowViewModel mvm, Organizer organizer) {
            NavigatetoLogin = ReactiveCommand.Create(() => mvm.CurrentView = new LoginViewModel(mvm));
            NavigatetoOrganize = ReactiveCommand.Create(() => mvm.CurrentView = new OrganizeViewModel(mvm, organizer));
            Participants = db.Participants.Select(e => new Participant
            {
                NameFirst = e.NameFirst,
                Photo = e.Photo,
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

        public List<Participant> Participants { get => participants; set => this.RaiseAndSetIfChanged(ref participants, value); }
        public bool Isvisiable { get => isvisiable; set => this.RaiseAndSetIfChanged(ref isvisiable, value); }
        public bool Isvisiable1 { get => isvisiable1; set => this.RaiseAndSetIfChanged(ref isvisiable1, value); }
    }
}