using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using Avalonia.Media.Imaging;
using Desktop.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace Desktop.ViewModels
{
	public class RegisterViewModel : ViewModelBase
	{
        private Bitmap _image;
        private int idNumber;
        private string last_Name;
        private string first_Name;
        private string patronymic;
        private int pol;
        private int rol;
        private string email;
        private string phone;
        private EventsName selectEvent;
        private List<EventsName> eventList;
        private string message;
        private string password;
        private string password_confirm;
        private DateTime dr;
        private Role selectRole;
        private List<Role> roleList;
        private Gender selectGender;
        private List<Gender> genderList;
        private Country selectCountry;
        private List<Country> countryList;
        private bool isPasswordVisible;


        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }
        public ReactiveCommand<Unit, object> NavigatetoOrganize { get; }

        public RegisterViewModel(MainWindowViewModel mvm, Organizer organizer) {

            Image = new Bitmap("D:\\desktop\\Desktop\\Desktop\\Assets\\default.png");
            EventList = db.EventsNames.ToList();
            GenderList = db.Genders.ToList();
            RoleList = db.Roles.ToList();
            CountryList = db.Countries.ToList();
            RegisterCommand = ReactiveCommand.Create(Register);
            NavigatetoOrganize = ReactiveCommand.Create(() => mvm.CurrentView = new OrganizeViewModel(mvm, organizer));
        }
        public string PasswordChar => IsPasswordVisible ? "" : "*";
        public Bitmap Image { get => _image; set => this.RaiseAndSetIfChanged(ref _image, value); }
        public int IdNumber { get => idNumber; set => this.RaiseAndSetIfChanged(ref idNumber, value); }
        public string Last_Name { get => last_Name; set => this.RaiseAndSetIfChanged(ref last_Name, value); }
        public string First_Name { get => first_Name; set => this.RaiseAndSetIfChanged(ref first_Name, value); }
        public string Patronymic { get => patronymic; set => this.RaiseAndSetIfChanged(ref patronymic, value); }
        public int Pol { get => pol; set => this.RaiseAndSetIfChanged(ref pol, value); }
        public int Rol { get => rol; set => this.RaiseAndSetIfChanged(ref rol, value); }
        public string Email { get => email; set => this.RaiseAndSetIfChanged(ref email, value); }
        public string Phone { get => phone; set => this.RaiseAndSetIfChanged(ref phone, value); }
        public EventsName SelectEvent { get => selectEvent; set => this.RaiseAndSetIfChanged(ref selectEvent, value); }
        public List<EventsName> EventList { get => eventList; set => this.RaiseAndSetIfChanged(ref eventList, value); }
        public string Message { get => message; set => this.RaiseAndSetIfChanged(ref message, value); }
        public string Password { get => password; set => this.RaiseAndSetIfChanged(ref password, value); }
        public string Password_confirm { get => password_confirm; set => this.RaiseAndSetIfChanged(ref password_confirm, value); }
        public DateTime Dr { get => dr; set => this.RaiseAndSetIfChanged(ref dr, value); }
        public Role SelectRole { get => selectRole; set => this.RaiseAndSetIfChanged(ref selectRole, value); }
        public List<Role> RoleList { get => roleList; set => this.RaiseAndSetIfChanged(ref roleList, value); }
        public Gender SelectGender { get => selectGender; set => this.RaiseAndSetIfChanged(ref selectGender, value); }
        public List<Gender> GenderList { get => genderList; set => this.RaiseAndSetIfChanged(ref genderList, value); }
        public Country SelectCountry { get => selectCountry; set => this.RaiseAndSetIfChanged(ref selectCountry, value); }
        public List<Country> CountryList { get => countryList; set => this.RaiseAndSetIfChanged(ref countryList, value); }
        public bool IsPasswordVisible { get => isPasswordVisible; set { this.RaiseAndSetIfChanged(ref isPasswordVisible, value); this.RaisePropertyChanged(nameof(PasswordChar)); } }

        public void Register()
        {
            if (string.IsNullOrWhiteSpace(Last_Name) /*|| string.IsNullOrWhiteSpace(First_Name) || string.IsNullOrWhiteSpace(Patronymic) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Phone) || SelectEvent == null*/)
            {
                Message = "Все поля должны быть заполнены";
                return;
            }
            
            if (Password != Password_confirm)
            {
                Message = "Пароли не совпадают";
                return;
            }

            if (SelectRole.IdRole == 3)
            {
                int count = db.Juris.Count();
                Juri juri = new Juri
                {
                    IdJuri = count + 1,
                    NameFirst = First_Name,
                    NameLast = Last_Name,
                    Patronymic = Patronymic,
                    IdGender = SelectGender.IdGender,
                    Email = Email,
                    Dr = Dr,
                    IdCountry = SelectCountry.IdCountry,
                    NumberPhone = Phone,
                    IdNapravleniya = SelectEvent.IdEvent,
                    Password = Password,
                    Foto = "default.png",
                    IdRole = SelectRole.IdRole,
                };
                db.Juris.Add(juri);
                db.SaveChanges();
                Message = "Успех!";
            }
            if (SelectRole.IdRole == 4)
            {
                int count = db.Moders.Count();
                int napr = SelectEvent.IdEvent;
                Moder moder = new Moder
                {
                    IdModera = count+1,
                    NameFirst = First_Name,
                    NameLast = Last_Name,
                    Patronymic = Patronymic,
                    IdGender = SelectGender.IdGender,
                    Email = Email,
                    Dr = Dr,
                    IdCountry = SelectCountry.IdCountry,
                    NumberPhone = Phone,
                    IdNapravleniya = napr,
                    IdEvent = SelectEvent.IdEvent,
                    Password = Password,
                    Foto = "default.png",
                    IdRole = SelectRole.IdRole,
                };
                db.Moders.Add(moder);
                db.SaveChanges();
                Message = "Успех!";
            }
        }
    }
}