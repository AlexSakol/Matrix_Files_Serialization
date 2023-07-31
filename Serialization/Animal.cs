using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    internal abstract class Animal
    {
        readonly private string name = "Животное";
        private double weight;
        private double height;


        public Animal(double weight, double height)
        {
            Weight = weight;
            Height = height;

        }

        public Animal() : this(0, 0)
        {
        }

        public virtual string Meal()
        {
            return "Ест бактерии";
        }

        public abstract string Voice();
        public abstract string Action();

        protected double Weight { get => weight; set => weight = value; }
        public double Height { get => height; set => height = value; }

        public override string? ToString()
        {
            return $"{name} все {weight} рост {height} {Meal()}";
        }
    }

}
