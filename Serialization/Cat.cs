using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    internal class Cat : Animal
    {
        readonly string name = "Кошка";
        public Cat(double weight, double height) : base(weight, height)
        {
        }

        public override string Action()
        {
            return "Бегает";
        }

        public override string Meal()
        {
            return "Ест мышей";
        }

        public override string Voice()
        {
            return "Мяукает";
        }

        public override string? ToString()
        {
            return $"{name} вес {Weight} г. рост {Height} см. {Meal()} {Voice()} {Action()}"; ;
        }

        static public void SaveClass(string filename)
        {
            Type type = typeof(Cat);
            StreamWriter f = new StreamWriter(filename);
            f.WriteLine("Полное имя класса:" + type.FullName);
            if (type.IsAbstract) f.WriteLine("Абстрактный класс");
            if (type.IsClass) f.WriteLine("Обычный класс");
            if (type.IsInterface) f.WriteLine("Интерфейс");
            if (type.IsEnum) f.WriteLine("Перечисление");
            if (type.IsSealed) f.WriteLine("Закрыт для наследования");
            f.WriteLine("Базовый класс - " + type.BaseType);
            FieldInfo[] fields = type.GetFields();
            if (fields.Count() > 0)
                f.WriteLine("*** Поля класса: ***");
            foreach (var field in fields)
            {
                f.WriteLine(field);
            }
            PropertyInfo[] properties = type.GetProperties();
            if (properties.Count() > 0)
                f.WriteLine("*** Свойства класса: ***");
            foreach (var property in properties)
            {
                f.WriteLine(property);
            }
            MethodInfo[] methods = type.GetMethods();
            if (methods.Count() > 0)
                f.WriteLine("*** Методы класса: ***");
            foreach (var method in methods)
            {
                f.WriteLine(method);
            }
            f.Close();
        }

        public void SaveObject(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(Weight);
            bw.Write(Height);
            fs.Close();
        }

        public static Cat LoadObject(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            double x = br.ReadDouble();
            double y = br.ReadDouble();
            fs.Close();
            return new Cat(x, y);
        }


        public void Serialize(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, this);
            fs.Close();
        }

        public static Cat Deserialize(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            Cat cat = (Cat)formatter.Deserialize(fs);
            fs.Close();
            return cat;
        }

    }

}
