namespace PersonClass001
{
	class Program
	{
		static void Main(string[] args)
		{
			// Instansiates the Person object with the ref nam personOne
			Person personOne = new Person();

			Console.Write("Indtast Navn: ");
			// Takes user input and sets it as the name of the Person instance
			personOne.Name = Console.ReadLine();

			Console.Write("Indtast Fødselsdato i format (DD/MM/YYYY: ");
			personOne.DoB = DateTime.Parse(Console.ReadLine());

			Console.Write("Indtast Email: ");
			personOne.Email =Console.ReadLine();
			

			Console.WriteLine("Indtast Password");
			personOne.Psw = Console.ReadLine();

            Console.WriteLine(personOne.Name);
            Console.WriteLine(personOne.DoB);
            Console.WriteLine(personOne.Email);
            Console.WriteLine(personOne.Psw);
			
        }
	}
}