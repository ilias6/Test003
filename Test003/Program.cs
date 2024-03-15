using System;
using System.Collections.Generic;
using System.Numerics;

namespace Test003
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ReflectionClass<MyClass>> reflectors = new List<ReflectionClass<MyClass>>();

            for (int i = 0; i < 1000; i++)
            {
                MyClass myClass = new MyClass();
                ReflectionClass<MyClass> reflectionClass = new ReflectionClass<MyClass>(myClass);
                reflectors.Add(reflectionClass);
            }

            Random random = new Random();
            Vector3 v3 = new Vector3(10, 0, 0);
            Quaternion q = new Quaternion(10, 0, 10, 0);
            
            for (int k = 0; k < reflectors.Count; k++)
            {
                int width = (int)reflectors[k].GetValue("width");
                int height = (int)reflectors[k].GetValue("height");
                Vector3 position = (Vector3)reflectors[k].GetValue("position");
                Quaternion quaternion = (Quaternion)reflectors[k].GetValue("rotation");
                for (int i = 0; i < 1000; i++)
                {
                    width += random.Next();
                    height += random.Next();
                    position += v3;
                    quaternion += q;
                }
                reflectors[k].SetValue("width", width);
                reflectors[k].SetValue("height", height);
                reflectors[k].SetValue("position", position);
                reflectors[k].SetValue("rotation", quaternion);
            }
        }
    }
}
