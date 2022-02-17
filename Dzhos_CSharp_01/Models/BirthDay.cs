using System;

namespace Dzhos_CSharp_01.Model
{
    class BirthDay
    {
        #region Fields
        private DateTime _birthDay;
        private readonly string[] chineseZodiacArray = 
        { "Monkey", "Rooster", "Dog", 
          "Pig", "Rat", "Ox",
          "Tiger", "Rabbit", "Dragon", 
          "Snake", "Horse", "Sheep"
        };
        #endregion

        #region Properties
        public DateTime Date
        {
            get { return _birthDay; }
            set { _birthDay = value; }
        }
        #endregion

        public int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - _birthDay.Year;
            if (_birthDay.Date > today.AddYears(-age)) age--;
            return age;
        }

        public Boolean ValidateBirthDay()
        {
            var age = CalculateAge();
            if (age < 0) return false;
            if (age > 135) return false;
            return true;
        }

        public Boolean IsTodayBirthDay()
        {
            var today = DateTime.Today;
            return _birthDay.Month == today.Month && _birthDay.Day == today.Day;
        }

        public string ChineseZodiac()
        {
            var year = _birthDay.Year;
            return chineseZodiacArray[year % 12];
        }

        public string WesternZodiac()
        {
            var day = _birthDay.Day;
            var month = _birthDay.Month;
            switch (month) { 
                case 1:
                    if (day < 20) return "Capricorn";
                    else return "Aquarius";
                case 2:
                    if (day < 19) return "Aquarius";
                    else return "Pisces";
                case 3:
                    if (day < 21) return "Pisces";
                    else return "Aries";

                case 4:
                    if (day < 20) return "Aries";
                    else return "Taurus";
                case 5:
                    if (day < 21) return "Taurus";
                    else return "Gemini";
                case 6:
                    if (day < 21) return "Gemini";
                    else return "Cancer";

                case 7:
                    if (day < 23) return "Cancer";
                    else return "Leo";
                case 8:
                    if (day < 23) return "Leo";
                    else return "Virgo";
                case 9:
                    if (day < 23) return "Virgo";
                    else return "Libra";

                case 10:
                    if (day < 23) return "Libra";
                    else return "Scorpio";
                case 11:
                    if (day < 22) return "Scorpio";
                    else return "Sagittarius";
                case 12:
                    if (day < 22) return "Sagittarius";
                    else return "Capricorn";
                default:  return "Error";
            }
        }
    }
}
