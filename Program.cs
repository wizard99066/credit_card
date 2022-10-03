namespace credit_card
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCard card = new CreditCard(300);
            Client client = new Client();
            card.RegisterHandler(client.PrintMessage);
            card.Put(100);
            card.Get(200);
            card.Get(1000);

            Console.WriteLine();

            //анонимный метод
            card.RegisterHandler(delegate (string message) { Console.WriteLine(message); });
            card.Put(100);
            card.Get(200);
            card.Get(1000);

            Console.WriteLine();

            //лямбда-выражение
            card.RegisterHandler(message => Console.WriteLine(message));
            card.Put(100);
            card.Get(200);
            card.Get(1000);

            Console.WriteLine();

            //событие
            cr_card card1 = new cr_card(300);           
            card1.Notify += client.PrintMessage;
            card1.Put(100);
            card1.Get(200);
            card1.Get(1000);

            Console.WriteLine();

            //анонимный метод
            card1.Notify -= client.PrintMessage;
            card1.Notify += delegate (string message) { Console.WriteLine(message); };
            card1.Put(100);
            card1.Get(200);
            card1.Get(1000);

            Console.WriteLine();

            //лямбда-выражение
            card1.Notify += message => Console.WriteLine(message);
            card1.Put(100);
            card1.Get(200);
            card1.Get(1000);

            //аннонимные методы и лямбда-выроженияи нельзя отписать из события
        }
    }
    
}