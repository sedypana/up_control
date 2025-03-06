using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.Reflection;
using Desktop.Models;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using System.Reactive;

namespace Desktop.ViewModels
{
    public class OrganizeViewModel : ViewModelBase
    {
        public TimeSpan CurrentTime => DateTime.Now.TimeOfDay;
        TimeSpan utro_nachalo = new TimeSpan(9, 0, 0);
        TimeSpan utro_konec = new TimeSpan(11, 0, 0);
        TimeSpan den_nachalo = new TimeSpan(11, 1, 0);
        TimeSpan den_konec = new TimeSpan(18, 0, 0);
        TimeSpan vecher_nachalo = new TimeSpan(18, 1, 0);
        TimeSpan vecher_konec = new TimeSpan(24, 0, 0);

        public string Message { get => message; set => this.RaiseAndSetIfChanged(ref message, value); }
        private string message;
        public string Message2 { get => message2; set => this.RaiseAndSetIfChanged(ref message2, value); }
        public Bitmap Ava { get => ava; set => this.RaiseAndSetIfChanged(ref ava, value); }

        private string message2;
        Bitmap ava;
        public ReactiveCommand<Unit, object> NavigatetoProf { get; }
        public ReactiveCommand<Unit, object> NavigatetoEvent { get; }
        public ReactiveCommand<Unit, object> NavigatetoLogin { get; }
        public ReactiveCommand<Unit, object> NavigatetoRegister { get; }
        public ReactiveCommand<Unit, object> NavigatetoParticipant { get; }
        public ReactiveCommand<Unit, object> NavigatetoJuri { get; }

        public OrganizeViewModel(MainWindowViewModel mvm, Organizer organizer) {

            if (organizer.IdGender == 1)
            {
                Message2 = $"Mr. {organizer.NameLast} {organizer.Patronymic}";
            }
            else
            {
                Message2 = $"Mrs. {organizer.NameLast} {organizer.Patronymic}";
            }

            if (CurrentTime >= utro_nachalo && CurrentTime <= utro_konec)
            {
                Message = "Доброе утро!";

            }
            else if (CurrentTime >= den_nachalo && CurrentTime <= den_konec)
            {
                Message = "Добрый день!";
            }
            else if (CurrentTime >= vecher_nachalo && CurrentTime <= vecher_konec)
            {
                Message = "Добрый вечер!";
            }
            else
            {
                Message = "Доброй ночи!";
            }
            Ava = organizer.Image;
            NavigatetoProf = ReactiveCommand.Create(() => mvm.CurrentView = new OrganizeProfileViewModel(mvm, organizer));
            NavigatetoEvent = ReactiveCommand.Create(() => mvm.CurrentView = new MainViewModel(mvm, organizer));
            NavigatetoLogin = ReactiveCommand.Create(() => mvm.CurrentView = new LoginViewModel(mvm));
            NavigatetoRegister = ReactiveCommand.Create(() => mvm.CurrentView = new RegisterViewModel(mvm, organizer));
            NavigatetoParticipant = ReactiveCommand.Create(() => mvm.CurrentView = new ParticipantViewModel(mvm, organizer));
            NavigatetoJuri = ReactiveCommand.Create(() => mvm.CurrentView = new JuriViewModel(mvm, organizer));
        }
        
    }
}