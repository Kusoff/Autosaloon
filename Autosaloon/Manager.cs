using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosaloon
{
    class Manager
    {
        public string ФИО { get; set; }
        public string должность { get; set; }
        public string логин { get; set; }
        public string пароль { get; set; }

        public Manager(string _ФИО, DateTime _Дата_рождения,
                string _должность, string _логин, string _пароль)
        {
            ФИО = _ФИО;
            должность = _должность;
            логин = _логин;
            пароль = _пароль;
        }

        //прорверка пароля 
        public Manager(string _логин, string _пароль)
        {
            логин = _логин;
            пароль = _пароль;

        }
    }

}
