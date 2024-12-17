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

    public delegate void SogliaSuperataHandler();

    internal class CSerbatoio
    {
        private double Livello;
        private const double Soglia = 100.0;

        private event SogliaSuperataHandler SogliaSuperata;

        public CSerbatoio()
        {
            Livello = 0.0;
        }
        public CSerbatoio(double val)
        {
            AggiungiLitri(val);
        }

        public string AggiungiLitri(double val)
        {
            string Messaggio = "";

            if(val <= 0.0)
            {
                Messaggio = "Errore nell'inserimento";
            }
            else
            {
                Livello += val;

                if(Livello > Soglia)
                {
                    SogliaSuperata?.Invoke();
                }

                Messaggio = $"Aggiunti {val} litri";
            }

            return Messaggio;
        }

        public string RimuoviLitri(double val)
        {
            string Messaggio = "";

            if (val <= 0.0)
            {
                Messaggio = "Errore nell'inserimento";
            }
            else
            {
                Livello -= val;
                Messaggio = $"Rimossi {val} litri";

                if (Livello < 0.0)
                {
                    Livello = 0.0;
                    Messaggio = "Serbatoio vuoto";
                }
            }

            return Messaggio;
        }
    }
}
