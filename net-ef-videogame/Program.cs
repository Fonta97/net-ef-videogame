using net_ef_videogame.Migrations;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string scelta = "";
            while (scelta != "0")
            {
                Console.WriteLine("Seleziona l'azione:");
                Console.WriteLine("1. Inserisci un videogioco");
                Console.WriteLine("2. Inserisci una Software House");
                Console.WriteLine("3. Visualizza il videogioco tramite id");
                Console.WriteLine("4. Visualizza il videogioco tramite nome");
                Console.WriteLine("5. Elimina un videogioco");
                Console.WriteLine("0. Esci dal programma");

                scelta = Console.ReadLine();

                if (scelta == "1")
                {
                    Console.WriteLine("Inserisci il nome del videogioco:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Inserisci la descrizione del videogioco:");
                    string description = Console.ReadLine();

                    Console.WriteLine("Inserisci la data di rilascio del videogioco (YYYY-MM-DD):");
                    DateTime release = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Inserisci l'ID della software house per collegarlo:");
                    if (!int.TryParse(Console.ReadLine(), out int softwareHouseId) || !VideogameManager.VerificaEsistenzaSoftwareHouse(softwareHouseId))
                    {
                        Console.WriteLine("L'ID inserito non è valido. Riprova.");
                        continue;
                    }

                    Videogame nuovoVideogame = new Videogame()
                    {
                        _name = name,
                        _description = description,
                        _release = release,
                        SoftwareHouseID = softwareHouseId
                    };

                    VideogameManager.CreaVideogioco(nuovoVideogame);
                    Console.WriteLine("Videogioco creato con successo!");
                }
                else if (scelta == "2")
                {
                    Console.WriteLine("Inserisci il nome della software house:");
                    string houseName = Console.ReadLine();

                    Console.WriteLine("Inserisci il tax ID della software house:");
                    string taxID = Console.ReadLine();

                    Console.WriteLine("Inserisci la città della software house:");
                    string city = Console.ReadLine();

                    Console.WriteLine("Inserisci il paese della software house:");
                    string country = Console.ReadLine();

                    Software_House nuovaSoftwareHouse = new Software_House()
                    {
                        _name = houseName,
                        _tax_id = taxID,
                        _city = city,
                        _country = country
                    };

                    VideogameManager.CreaSoftwareHouse(nuovaSoftwareHouse);
                    Console.WriteLine("Software House creata con successo!");
                }
                else if (scelta == "3")
                {
                    Console.WriteLine("Inserisci un numero ID:");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        Videogame videogame = VideogameManager.GetVideogameById(id);

                        if (videogame != null)
                        {
                            Console.WriteLine($"ID: {videogame.VideogameID}");
                            Console.WriteLine($"Nome: {videogame._name}");
                            Console.WriteLine($"Descrizione: {videogame._description}");
                            Console.WriteLine($"Data di rilascio: {videogame._release}");
                        }
                        else
                        {
                            Console.WriteLine($"Nessun videogioco trovato con ID {id}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("L'ID inserito non è valido. Assicurati di inserire un numero intero.");
                    }
                }
                else if (scelta == "4")
                {
                    Console.WriteLine("Inserisci il nome del videogioco:");
                    string name = Console.ReadLine();

                    Videogame videogame = VideogameManager.GetVideogameByName(name);

                    if (videogame != null)
                    {
                        Console.WriteLine($"ID: {videogame.VideogameID}");
                        Console.WriteLine($"Nome: {videogame._name}");
                        Console.WriteLine($"Descrizione: {videogame._description}");
                        Console.WriteLine($"Data di rilascio: {videogame._release}");
                    }
                    else
                    {
                        Console.WriteLine($"Nessun videogioco trovato con il nome '{name}'");
                    }
                }
                else if (scelta == "5")
                {
                    Console.WriteLine("Inserisci l'ID del videogioco da eliminare:");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        bool delete = VideogameManager.Delete(id);
                        if (delete)
                        {
                            Console.WriteLine($"Il videogioco con ID {id} è stato eliminato con successo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("L'ID inserito non è valido. Assicurati di inserire un numero intero.");
                    }
                }

                Console.WriteLine("Arrivederci!");
            }

        }
    }
}