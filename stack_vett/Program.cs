

using System;

namespace stack_vett
{
    // classe Stack
    //commit1
    //commit2
    class Stack
    {
        // dati globali della classe
        private int[] dati;
        private int sp;

        // costruttore generico
        public Stack()
        {
            dati = new int[10];
            sp = -1;
        }

        // costruttore con specifica dello spazio
        // dedicato allo stack
        public Stack(int sz)
        {
            dati = new int[sz];
            sp = -1;
        }

        // metodo che controlla se lo stack e' vuoto
        public bool vuoto()
        {
            if (sp == -1)
                return true;
            else
                return false;
        }

        // metodo che controlla se lo stack e' pieno
        public bool pieno()
        {
            if (sp == dati.Length - 1)
                return true;
            else
                return false;
        }

        // estrazione di un elemento dallo stack
        public int pop()
        {
            int dato;

            if (!vuoto())
            {
                dato = dati[sp];
                sp--;
                return dato;
            }
            else
                throw (new IndexOutOfRangeException());                
        }

        // inserimento di un elemento nello stack
        public void push(int n)
        {
            if (!pieno())
            {
                sp++;
                dati[sp] = n;
            }
            else
                throw (new IndexOutOfRangeException());
        }

        // numero elementi nello stack
        public int num_ele()
        {
            return sp + 1;
        }

        // legge l'elemento sulla cima senza rimozione
        public int leggi_cima()
        {
            return dati[sp];
        }

        // svuotamento generale dello stack
        public void reset()
        {
            sp = -1;
        }

        // stampa dei contenuto dello stack
        public void stampa_stack()
        {
            int i;

            if (!vuoto())
                for (i = sp; i >= 0; i--)
                    Console.WriteLine(dati[i]);
            else
                Console.WriteLine("(Stack vuoto)");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack stk = new Stack();
            char sele;
            int n;

            // menu' per applicazione delle principali operazioni sullo stack
            do
            {
                // voci di menu
                Console.WriteLine();
                Console.WriteLine("Possibili operazioni sullo stack");
                Console.WriteLine("i - inserimento di un elemento");
                Console.WriteLine("e - estrazione di un elemento");
                Console.WriteLine("n - numero di elementi nello stack");
                Console.WriteLine("s - stampa dello stack");
                Console.WriteLine("r - reset dello stack");
                Console.WriteLine("x - esci");

                // lettura di un carattere per la selezione della voce
                Console.Write("Indica selezione:  ");
                sele = Console.ReadKey().KeyChar;
                Console.WriteLine();
                sele = Char.ToLower(sele);

                // operazioni in base alla selezione effettuata
                switch (sele)
                {
                    // inserimento di un elemento
                    case 'i':
                        Console.Write("Inserisci elemento:  ");
                        n = int.Parse(Console.ReadLine());
                        try {
                           stk.push(n);
                        }
                        catch(IndexOutOfRangeException ior)
                        {
                            Console.WriteLine("Stack pieno. Inserimento impossibile.");
                        }
                        break;

                    // estrazione di un elemento
                    case 'e':
                        try 
                        {
                            n = stk.pop();
                            Console.WriteLine("Elemento estratto:  " + n);
                        }
                        catch(IndexOutOfRangeException ior)
                        {
                            Console.WriteLine("Stack vuoto. Lettura impossibile.");
                        }
                        break;

                    // numero di elementi sullo stack
                    case 'n':
                        n = stk.num_ele();
                        Console.WriteLine("Numero elementi nello stack:  " + n);
                        break;
                        
                    // stampa dei contenuti dello stack
                    case 's':
                        stk.stampa_stack();
                        break;

                    // svuotamento dello stack
                    case 'r':
                        stk.reset();
                        break;

                    // uscita dal programma
                    case 'x': break;

                    default:
                        Console.WriteLine("Selezione inesistente.");
                        break;
                }

            } while (sele != 'x');   // ciclo relativo alle operazioni proposte dal menu'

        }
    }
}
