using Dzhos_CSharp_01.Model;
using Dzhos_CSharp_01.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dzhos_CSharp_01.ViewModels
{
    class BirthDayViewModel : INotifyPropertyChanged
    {
        #region Fields
        private BirthDay _birthDay = new BirthDay();
        private RelayCommand<object> _informationAboutBirthDayCommand;
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _age;
        private string _chineseZodiac;
        private string _westernZodiac;
        #endregion

        #region Properties
        public DateTime UpdateDate
        {
            get
            {
                return _birthDay.Date;
            }
            set
            {
                _birthDay.Date = value;
            }
        }

        public RelayCommand<object> InformationCommand
        {
            get
            {
                return _informationAboutBirthDayCommand ??= new RelayCommand<object>(_ => ChooseDate(), CanExecute);
            }
        }

        public string Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public string WesternZodiac
        {
            get
            {
                return _westernZodiac;
            }
            set
            {
                _westernZodiac = value;
                OnPropertyChanged("WesternZodiac");
            }
        }

        public string ChineseZodiac
        {
            get
            {
                return _chineseZodiac;
            }
            set
            {
                _chineseZodiac = value;
                OnPropertyChanged("ChineseZodiac");
            }
        }
        #endregion

        public void ChooseDate()
        {
            if (_birthDay.ValidateBirthDay())
            {
                var age = _birthDay.CalculateAge();
                if (_birthDay.IsTodayBirthDay())
                {
                    Age = $"Congratulations on your birthday.\nYour age: {age}";
                }
                else
                {
                    Age = $"Your age: {age}";
                }
                WesternZodiac = $"Western Zodiac: {_birthDay.WesternZodiac()}";
                ChineseZodiac = $"Chinese Zodiac: {_birthDay.ChineseZodiac()}";
            }
            else
            {
                BadBirthDay();
            }
        }

        private void BadBirthDay()
        {
            Age = "";
            WesternZodiac = "";
            ChineseZodiac = "";
            MessageBox.Show("You have entered an incorrect date of birth, please try again");
        }

        private bool CanExecute(object obj)
        {
            return _birthDay != null;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
