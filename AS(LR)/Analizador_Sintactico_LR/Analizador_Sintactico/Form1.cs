using System;

namespace Analizador_Sintactico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public const int ERROR = -1;
        public const int IDENTIFICADOR = 0;
        public const int SIMBOLO = 1;
        public const int SIGNOPESO = 2;
        public const int E = 3;
        public const int INICIAL = 5;
        class PilaElemen
        {
            public const int ERROR = -1;
            public const int IDENTIFICADOR = 0;
            public const int SIMBOLO = 1;
            public const int SIGNOPESO = 2;
            public const int E = 3;
            public const int INICIAL = 5;

            public int tipo;
            public String simbolo;

            public PilaElemen()
            {
                tipo = 5;
            }

            public String ToString()
            {
                return simbolo;
            }
        }
        class Terminal : PilaElemen
        {
            public Terminal(int id)
            {
                tipo = id;
                if (id == SIGNOPESO)
                {
                    simbolo = "$";
                }
            }

            public Terminal(int id, String sim)
            {
                tipo = id;
                simbolo = sim;
            }
        }
        class NoTerminal : PilaElemen
        {
            public NoTerminal(int id, String sim)
            {
                tipo = id;
                simbolo = sim;
            }
        }
        class Estado : PilaElemen
        {
            public Estado(int id, String estado)
            {
                tipo = id;
                simbolo = estado;
            }
        }

        static LinkedList<PilaElemen> listaPila = new LinkedList<PilaElemen>();
        class Pila
        {
            
            public Pila()
            {

            }

            public void push(PilaElemen x)
            {
                listaPila.AddLast(x);
            }

            public PilaElemen top()
            {
                return listaPila.First.Value;
            }

            public PilaElemen pop()
            {
                PilaElemen x = listaPila.First.Value;
                listaPila.Remove(x);

                return x;
            }

            public void vaciarPila()
            {
                listaPila.Clear();
            }

        }
        public void ejercicio1(string texto)
        {

            Pila pila = new Pila();
            pila.push(new NoTerminal(PilaElemen.SIMBOLO, "$0"));
            foreach (PilaElemen dato in listaPila)
            {
                Tbx2.AppendText(dato.ToString());
            }
            Tbx2.AppendText(Environment.NewLine);

            int estado = INICIAL;
            int d = 2;
            String lexema = "";
            Char c;

            for (int i = 0; i < texto.Length; i++)
            {
                c = texto[i];
                switch (estado)
                {
                    case INICIAL:
                        if (Char.IsLetter(c) || c == '_')
                        {
                            estado = IDENTIFICADOR;
                            lexema += c;
                        }
                        else if (c == '+')
                        {
                            pila.push(new Terminal(SIMBOLO, lexema + d));
                            d++;
                            estado = INICIAL;
                            lexema = "";

                            foreach (PilaElemen dato in listaPila)
                            {
                                Tbx2.AppendText(dato.ToString());
                            }
                            Tbx2.AppendText(Environment.NewLine);

                        }
                        else if (c == '$')
                        {
                            pila.vaciarPila();

                            Pila nuevaPila = new Pila();
                            nuevaPila.push(new Estado(E, "$0E1"));
                            foreach (PilaElemen dato in listaPila)
                            {
                                Tbx2.AppendText(dato.ToString());
                            }
                            Tbx2.AppendText(Environment.NewLine);
                        }
                        else
                        {
                            Tbx2.AppendText("ERROR");
                            return;
                        }
                        break;
                    case IDENTIFICADOR:
                        if (Char.IsLetterOrDigit(c) || c == '_')
                        {
                            estado = IDENTIFICADOR;
                            lexema += c;
                        }
                        else
                        {
                            pila.push(new Terminal(IDENTIFICADOR, lexema + d));
                            d++;
                            estado = INICIAL;
                            lexema = "";
                            i--;

                            foreach (PilaElemen dato in listaPila)
                            {
                                Tbx2.AppendText(dato.ToString());
                            }
                            Tbx2.AppendText(Environment.NewLine);
                        }
                        break;
                    default:
                        break;
                }
            }

        }
        public void ejercicio2(string texto)
        {
            Pila pila = new Pila();
            pila.push(new NoTerminal(PilaElemen.SIMBOLO, "$0"));
            foreach (PilaElemen dato in listaPila)
            {
                Tbx3.AppendText(dato.ToString());
            }
            Tbx3.AppendText(Environment.NewLine);

            int estado = INICIAL;
            int d2 = 2, d3 = 3;
            String lexema = "";
            Char c;

            for (int i = 0; i < texto.Length; i++)
            {
                c = texto[i];
                switch (estado)
                {
                    case INICIAL:
                        if (Char.IsLetter(c) || c == '_')
                        {
                            estado = IDENTIFICADOR;
                            lexema += c;
                        }
                        else if (c == '+')
                        {
                            pila.push(new Terminal(SIMBOLO, lexema + d3));
                            estado = INICIAL;
                            lexema = "";

                            foreach (PilaElemen dato in listaPila)
                            {
                                Tbx3.AppendText(dato.ToString());
                            }
                            Tbx3.AppendText(Environment.NewLine);
                        }
                        else if (c == '$')
                        {
                            pila.vaciarPila();

                            Pila nuevaPila = new Pila();
                            nuevaPila.push(new Estado(E, "$0E1"));
                            foreach (PilaElemen dato in listaPila)
                            {
                                Tbx3.AppendText(dato.ToString());
                            }
                            Tbx3.AppendText(Environment.NewLine);
                        }
                        else
                        {
                            Tbx3.AppendText("ERROR");
                            return;
                        }
                        break;
                    case IDENTIFICADOR:
                        if (Char.IsLetterOrDigit(c) || c == '_')
                        {
                            estado = IDENTIFICADOR;
                            lexema += c;
                        }
                        else
                        {
                            pila.push(new Terminal(IDENTIFICADOR, lexema + d2));
                            estado = INICIAL;
                            lexema = "";
                            i--;

                            foreach (PilaElemen dato in listaPila)
                            {
                                Tbx3.AppendText(dato.ToString());
                            }
                            Tbx3.AppendText(Environment.NewLine);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        private void Btton1_Click(object sender, EventArgs e)
        {
            ejercicio1("hola+mundo$");
            ejercicio2("a+b+c+d+e+f$");
        }
    }
}
