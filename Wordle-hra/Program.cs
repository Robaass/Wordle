namespace Wordle_hra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int MaxPokus = 6;
            bool Opakovat = true;
            while (Opakovat)
            {
                try
                {
                    List<string> SeznamSlov = new List<string>() //vytvoření seznamu možných řešení, instance třídy list, jako objekt "SeznamSlov"
                    {
                        "AHOJ", "SVET", "MRAK", "DOMU", "OKNO", "STUL", "PYSK", "DUHA"
                    };

                    Random random = new Random(); //vygenerování náhodného čísla, uložení tohoto čísla do proměnné "random"
                    string Slovo = SeznamSlov[random.Next(SeznamSlov.Count)]; //1. spočítá počet prvků v "seznamslov" metodou ".Count"; 2. nastaví hranici pro random (random.Next) jako počet prvků v "seznamSlov"; 3. uloží slovo odpovídající náhodnému číslu jako "slovo" 

                    int Pokus = 1;
                    for (; Pokus <= MaxPokus; Pokus++) //smyčka bude pokračovat dokud "Pokus" bude menší než "MaxPokus" a na konci každé smyčky se do proměnné "Pokus" přidá +1
                    {
                        Console.Write($"{Pokus}/{MaxPokus} pokusů, zadejte své slovo: ");
                        string Input = Console.ReadLine().ToUpper();

                        if (Input.Length != 4)
                        {
                            Console.WriteLine("Chyba, délka slova musí být 4");
                            Pokus--;
                        }
                        else if (Input == Slovo)
                        {
                            Console.ForegroundColor = ConsoleColor.Green; //Nastaví zelenou barvu
                            Console.WriteLine(Input); //Vypíše input
                            Console.WriteLine("Správně, slovo jste uhádli");
                            Console.ResetColor(); //Resetuje barvu

                            Opakovat = false;
                            break;
                        }
                        else
                        {
                            for (int i = 0; i < Slovo.Length; i++) //Prochází každé písmeno vstupu dokud bude i menší než délka hádaného slova, na konci každé smyčky se do i přidá +1
                            {
                                if (Input[i] == Slovo[i]) //Pokud je písmeno na správném místě
                                {
                                    Console.ForegroundColor = ConsoleColor.Green; //Nastaví zelenou barvu
                                    Console.Write(Input[i]); //Vypíše správné písmeno na správné místo
                                }
                                else if (Slovo.Contains(Input[i])) //Pokud je písmeno ve slově, ale na špatném místě
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow; //Nastaví žlutou barvu
                                    Console.Write(Input[i]); //Vypíše správné písmeno na špatné místo
                                }
                                else //Písmeno není ve slově
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray; //Nastaví šedou barvu
                                    Console.Write(Input[i]); //Vypíše písmeno, které není ve slově
                                }
                                Console.ResetColor(); //Resetuje barvu na standardní po každém písmeni
                            }
                            Console.WriteLine(); //Nový řádek po každém pokusu
                        }
                        if (Pokus == MaxPokus) //dosažení maximálního počtu pokusů
                        {
                            Console.WriteLine("Hra skončila, správné slovo bylo: " + Slovo);
                            Opakovat = false;
                            break;
                        }
                    }

                }
                catch (FormatException) //musí být dodržen datový typ proměnné
                {
                    Console.WriteLine("Neplatný vstup, zadejte platné slovo");
                }
                Opakovat = false;
            }
        }
    }
}
