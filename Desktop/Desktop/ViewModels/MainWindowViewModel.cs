using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Reactive;
using Avalonia;

namespace Desktop.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private object currentView;

        public object CurrentView { get => currentView; set => this.RaiseAndSetIfChanged(ref currentView, value); }

        public ReactiveCommand<Unit, object> NavigatetoLogin { get; }
        public ReactiveCommand<Unit, object> NavigatetoMain { get; }
        public ReactiveCommand<Unit, object> NavigatetoRegister { get; }
        public ReactiveCommand<Unit, object> NavigatetoOrganize { get; }
        public MainWindowViewModel()
        {
            NavigatetoLogin = ReactiveCommand.Create(() => CurrentView = new LoginViewModel(this));
            NavigatetoMain = ReactiveCommand.Create(() => CurrentView = new MainViewModel(this, null));
            NavigatetoRegister = ReactiveCommand.Create(() => CurrentView = new RegisterViewModel(this,null));
            CurrentView = new MainViewModel(this, null);
        }
    }
}
