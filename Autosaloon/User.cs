using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosaloon
{
    public class User
    {
        public int id_клиента { get; set; }
        public string ФИО { get; set; }
        public DateTime Дата_рождения { get; set; }
        public string логин { get; set; }
        public string пароль { get; set; }

        public User(int _id_клиента, string _ФИО, DateTime _Дата_рождения, string _логин,
                string _пароль)
        {
            id_клиента = _id_клиента;
            ФИО = _ФИО;
            Дата_рождения = _Дата_рождения;
            логин = _логин;
            пароль = _пароль;
        }

        //прорверка пароля 
        public User(string _логин, string _пароль)
        {
            логин = _логин;
            пароль = _пароль;

        }
    }
}
