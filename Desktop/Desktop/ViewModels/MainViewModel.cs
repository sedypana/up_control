using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reflection;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Desktop.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, object> NavigatetoLogin { get; }
        public ReactiveCommand<Unit, object> NavigatetoOrganize { get; }
        public List<Event> Events { get => events; set => this.RaiseAndSetIfChanged(ref events, value); }
        public bool Enabled { get => enabled; set => this.RaiseAndSetIfChanged(ref enabled, value); }

        private bool enabled;
        private bool enabled2;
        public bool Enabled2 { get => enabled2; set => this.RaiseAndSetIfChanged(ref enabled2, value); }

        List<Event> events;

        public MainViewModel(MainWindowViewModel mvm, Organizer organizer)
        {
            NavigatetoLogin = ReactiveCommand.Create(() => mvm.CurrentView = new LoginViewModel(mvm));
            NavigatetoOrganize = ReactiveCommand.Create(() => mvm.CurrentView = new OrganizeViewModel(mvm,organizer));
            Console.WriteLine("VM загрузка");
            LoadData();
            if (organizer == null)
            {
                Enabled = true;
            }
            else
            {
                Enabled = false;
            }
            if (Enabled == true)
            {
                Enabled2 = false;
            }
            else
            {
                Enabled2 = true;
            }
        }

        public void LoadData()
        {

            Events = db.Events.Select(e => new Event
            {
                Name = e.Name,
                Photo = e.Photo,
                Days = e.Days,
                DateStart = e.DateStart,
                City = e.City
            }).ToList();

        }
    }
}