using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reactive;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Desktop.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using SkiaSharp;
using System.Drawing.Imaging;
using Avalonia.Controls;

namespace Desktop.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
        public ReactiveCommand<Unit, object> NavigatetoMain { get; }
        public ReactiveCommand<Unit, object> NavigatetoRegister { get; }
        public ReactiveCommand<Unit, Unit> LoginCom { get; }
        public ReactiveCommand<Unit, object> NavigatetoParticipant { get; }
        public ReactiveCommand<Unit, object> NavigatetoJuri { get; }

        public string email;
        private string password;
        private string message;
        public MainWindowViewModel _mvm;
        private string captcha_gen;
        private string captcha;
        public string EmailUser { get => email; set => this.RaiseAndSetIfChanged(ref email, value); }
        public string PasswordUser { get => password; set => this.RaiseAndSetIfChanged(ref password, value); }
        public string Message { get => message; set => this.RaiseAndSetIfChanged(ref message, value); }
        public string Captcha_gen { get => captcha_gen; set => this.RaiseAndSetIfChanged(ref captcha_gen, value); }
        public string Captcha { get => captcha; set => this.RaiseAndSetIfChanged(ref captcha, value); }

        public LoginViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            NavigatetoMain = ReactiveCommand.Create(() => mvm.CurrentView = new MainViewModel(mvm,null));
            NavigatetoParticipant = ReactiveCommand.Create(() => mvm.CurrentView = new ParticipantViewModel(mvm,null));
            NavigatetoJuri = ReactiveCommand.Create(() => mvm.CurrentView = new JuriViewModel(mvm, null));
            LoginCom = ReactiveCommand.Create(Login);
            Captcha_gen = GenerateRandomText(6);
        }

        public void Login()
        {
            Organizer organizer = db.Organizers.FirstOrDefault(o => o.Password == PasswordUser && o.Email == EmailUser);
            if (organizer != null && Captcha.Equals(Captcha_gen, StringComparison.InvariantCultureIgnoreCase))
            {
                _mvm.CurrentView = new OrganizeViewModel(_mvm, organizer);
                return;
            }

            Moder moder = db.Moders.FirstOrDefault(o => o.Password == PasswordUser && o.Email == EmailUser);
            if (moder != null && Captcha.Equals(Captcha_gen, StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            Juri juri = db.Juris.FirstOrDefault(o => o.Password == PasswordUser && o.Email == EmailUser);
            if (juri != null && Captcha.Equals(Captcha_gen, StringComparison.InvariantCultureIgnoreCase))
            {
                _mvm.CurrentView = new JuriViewModel(_mvm, null);
                return;
            }

            Participant participant = db.Participants.FirstOrDefault(o => o.Password == PasswordUser && o.Email == EmailUser);
            if (participant != null && Captcha.Equals(Captcha_gen, StringComparison.InvariantCultureIgnoreCase))
            {
                _mvm.CurrentView = new ParticipantViewModel(_mvm, null);
                return;
            }

            else if (!Captcha.Equals(Captcha_gen, StringComparison.InvariantCultureIgnoreCase))
            {
                Message = "Неправильно введена капча";
            }

            else
            {
                Message = "Неправильный логин или пароль";
                return;
            }
        }
        private static Random random = new Random();

        private static string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}