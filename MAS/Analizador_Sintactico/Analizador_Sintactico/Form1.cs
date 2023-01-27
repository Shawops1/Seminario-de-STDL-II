using System;

namespace Analizador_Sintactico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[,] tablaLR = new int[5, 4] { { 2, 0, 0, 1 },
                                         { 0, 0, -1, 0 },
                                         { 0, 3, 0, 0 },
                                         { 4, 0, 0, 0 },
                                         { 0, 0, -2, 0 } };

        int[,] tablaLR_E2 = new int[5, 4] { { 2, 0, 0, 1 },
                                            { 0, 0, -1, 0 },
                                            { 0, 3, -3, 0 },
                                            { 2, 0, 0, 4 },
                                            { 0, 0, -2, 0 } };

        public void ejercicio1()
        {
            string entrada = "a+b$";
            Stack<string> pila = new Stack<string>();

            int fila = 0;
            int columna = 0;
            int accion = 10;

            pila.Push("$");
            pila.Push("0");

            foreach (char s in entrada)
            {
                if (accion == 0)
                {
                    Tbx2.AppendText("Error de sintaxis" + Environment.NewLine);
                    pila.Clear();
                    break;
                }
                if (char.IsLetter(s))
                    columna = 0;
                else if (s == '+')
                    columna = 1;
                else if (s == '$')
                    columna = 2;

                accion = tablaLR[fila, columna];

                if (accion > 0)
                {
                    pila.Push(s.ToString());
                    pila.Push(accion.ToString());
                }
                else
                {
                    if (s == '$')
                    {
                        accion = tablaLR[Math.Abs(accion), 2];
                        Tbx2.AppendText("Cadena aceptada" + Environment.NewLine);
                    }
                    else
                    {
                        Tbx2.AppendText("Error sintáctico" + Environment.NewLine);
                        pila.Clear();
                    }
                }

                fila = accion;
            }
            Tbx2.AppendText("Pila" + Environment.NewLine);
            while (pila.Count > 0)
            {
                Tbx2.AppendText(pila.Peek());
                pila.Pop();
            }

        }
        public void ejercicio2()
        {
            string entrada = "a+b+c+d+e+f$";
            Stack<string> pila = new Stack<string>();

            int fila = 0;
            int columna = 0;
            int accion = 10;

            pila.Push("$");
            pila.Push("0");

            foreach (char s in entrada)
            {
                if (accion == 0)
                {
                    Console.WriteLine("Error de sintaxis" + Environment.NewLine);
                    pila.Clear();
                    break;
                }
                if (char.IsLetter(s))
                    columna = 0;
                else if (s == '+')
                    columna = 1;
                else if (s == '$')
                    columna = 2;

                accion = tablaLR_E2[fila, columna];

                if (accion > 0)
                {
                    pila.Push(s.ToString());
                    pila.Push(accion.ToString());
                }
                else
                {
                    if (s == '$')
                    {
                        accion = tablaLR[Math.Abs(accion), 2];
                        Tbx3.AppendText("Cadena aceptada" + Environment.NewLine);
                    }
                    else
                    {
                        Tbx3.AppendText("Error de sintaxis" + Environment.NewLine);
                        pila.Clear();
                    }
                }
                fila = accion;
            }
            Tbx3.AppendText("Pila" + Environment.NewLine);
            while (pila.Count > 0)
            {
                Tbx3.AppendText(pila.Peek());
                pila.Pop();
            }
        }
        private void Btton1_Click(object sender, EventArgs e)
        {
            ejercicio1();
            ejercicio2();
        }
    }
}
