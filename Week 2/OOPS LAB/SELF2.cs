using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projects
{
    internal class task2
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("ENTER a");
            float a=float.Parse(Console.ReadLine());
            Console.WriteLine("ENTER b");
            float b = float.Parse(Console.ReadLine());
            Calculater cal =new Calculater();
            Console.WriteLine("ADDITION : "+cal.addition(a,b));
            Console.WriteLine("Substration : " + cal.subtractition(a, b));
            Console.WriteLine("multiply : " + cal.multiply(a, b));
            Console.WriteLine("divide : " + cal.divide(a, b));


        }


        public class Calculater
        {
            public float result;
            public float a=0f;
            public float b=0f;
            public Calculater() 
            {
                result = 0f;
            }
            public float addition(float ad,float bd)
            {
                return result = ad + bd;
            }
            public float subtractition(float ad,float bd)
                
            {
                return result = ad - bd;
            }
            public float multiply(float ab,float bd) 
            {
               return result = ab * bd;
            }
            public float divide(float ad,float bd) 
            {
                if (bd == 0f)
                {
                    Console.WriteLine("b must not be zero");
                }
                else
                {
                    result = ad / bd;
                }
                return result;
            }
        }


    }
}
