using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosaloon
{
    class Car
    {
        public int id_автомобиля { get; set; }
        public string Марка { get; set; }
        public int Год_выпуска { get; set; }
        public int Цена { get; set; }


        public Car(int _id_автомобиля, string _Марка, int _Год_выпуска, int _Цена)
        {
            id_автомобиля = _id_автомобиля;
            Марка = _Марка;
            Год_выпуска = _Год_выпуска;
            Цена = _Цена;
        }
    }
}
