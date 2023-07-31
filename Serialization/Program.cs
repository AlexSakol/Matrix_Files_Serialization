using Serialization;

Cat cat1 = new Cat(3000, 34);
Console.WriteLine(cat1);


Cat.SaveClass("D:\\10.txt");
cat1.SaveObject("D:\\20.bin");
Cat cat2 = Cat.LoadObject("D:\\20.bin");
Console.WriteLine(cat2);
cat1.Serialize("d:\\220.bin");
Cat cat3 = Cat.Deserialize("d:\\220.bin");
Console.WriteLine("Восстановился объект:");
Console.WriteLine(cat3);
Console.ReadKey();
