namespace PersonClass001
{
	class Program
	{
		static void Main(string[] args)
		{
			bool catcher = true;
			// Instansiates the Person object with the ref nam personOne
			Person personOne = new Person();
            Person personTwo = new Person();

			Console.Write("Indtast Navn: ");
			// Takes user input and sets it as the name of the Person instance
			personOne.Name = Console.ReadLine();

			Console.Write("Indtast Fødselsdato i format (DD/MM/YYYY: ");
			do {
				try
				{
					personOne.DoB = DateTime.Parse(Console.ReadLine());
					catcher = false;
				}
				catch (FormatException)
				{
					Console.WriteLine("Fejl i indtastnings format. Prøv Igen");
				}
			} while (catcher);

			Console.Write("Indtast Email: ");
			personOne.Email = Console.ReadLine();


			Console.WriteLine("Indtast Password");
			personOne.Psw = Console.ReadLine();

			Console.WriteLine("Person 1:");
			Console.WriteLine(personOne.Name);
			Console.WriteLine(personOne.Age);
			Console.WriteLine(personOne.Email);
			Console.WriteLine(personOne.Psw);

			personTwo.Name = "Arne";
			personTwo.DoB = DateTime.Parse("22/04/2002");
			personTwo.Email = "ArneOlesen@gmail.com";
			personTwo.Psw = "ab!#DV12";

			Console.WriteLine("\nPerson 2: ");
			Console.WriteLine(personTwo.Name);
			Console.WriteLine(personTwo.Age);
			Console.WriteLine(personTwo.Email);
			Console.WriteLine(personTwo.Psw);

		}
	}
}