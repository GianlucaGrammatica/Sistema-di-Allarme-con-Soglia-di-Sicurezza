using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_di_Allarme_con_Soglia_di_Sicurezza
{
    /*
       Descrizione:Simula un sistema di monitoraggio di un serbatoio. Quando il livello del serbatoio supera una soglia di sicurezza, un evento deve attivare un allarme.

       Istruzioni:
       - Definisci un delegato SogliaSuperataHandler che non accetti parametri.

       - Crea una classe Serbatoio che:
           - Contenga una proprietà Livello (double).
           - Contenga un evento SogliaSuperata basato sul delegato.
           - Nel metodo AggiungiLitri(double litri), aggiorna il livello e solleva l'evento se la soglia viene superata.
           - Nel metodo RimuoviLitri(double litri), rimuove litri dal livello del serbatoio.
           - Verificare i valori in input dei metodi

       - Crea una classe Allarme con un metodo AttivaAllarme() che stampa un messaggio quando l'evento viene sollevato.
           - Sottoscrivi l'allarme all'evento del serbatoio.
           - Nel metodo Main, aggiungi litri al serbatoio e verifica se l'allarme si attiva.

       Output Esempio:
       Livello serbatoio: 80 litri
       Livello serbatoio: 110 litri
       [ALLARME] Soglia di sicurezza superata!
   */

    internal class Program
    {
        static CAllarme allarme = new CAllarme();

        static void Main(string[] args)
        {
            CSerbatoio serb = new CSerbatoio();
            serb.SogliaSuperata += SerbatoioPieno;

            while (true)
            {
                Console.WriteLine("1. Aggiungi  n litri\t2. Rimuovi n litri \t3. Esci");

                string input = Console.ReadLine();

                if(input == "1")
                {
                    Console.WriteLine("Litri da aggiungere: ");
                    input = Console.ReadLine();

                    if (double.TryParse(input, out var val))
                    {
                        Console.WriteLine(serb.AggiungiLitri(val));
                    }
                    else
                    {
                        Console.WriteLine("Errore di inserimento");
                    }
                }

                if (input == "2")
                {
                    Console.WriteLine("Litri da rimuovere: ");
                    input = Console.ReadLine();

                    if (double.TryParse(input, out var val))
                    {
                        Console.WriteLine(serb.RimuoviLitri(val));
                    }
                    else
                    {
                        Console.WriteLine("Errore di inserimento");
                    }
                }

                if (input == "3")
                {
                    break;
                }
            }
        }

        static void SerbatoioPieno()
        {
            allarme.AttivaAllarme();
        }
    }
}
