using System.Data;
using System.Diagnostics;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mini_Generador_Léxico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabla.Columns.Add("ID", "ID");
            tabla.Columns.Add("Lexema", "Lexema");
            tabla.Columns.Add("Token", "Token");
        }
      
        void analizar(string palabra)
        {
            string frase = palabra;
            int indice = 0;
            int estado = 0;
            int estadoFinal = -1;
            string lexema = "";
            string token;
           
            while ((indice <= (frase.Length - 1)) && (estadoFinal == -1))
            {
                lexema = " ";
                token = "error";
                while ((indice <= (frase.Length - 1)) && (estadoFinal != 25))
                {
                    if (estadoFinal == -1)
                    {
                        if (char.IsWhiteSpace(frase[indice]))
                        {
                            estadoFinal = -1;
                        }
                        else if (char.IsLetter(frase[indice]) || frase[indice] == '_')
                        {
                            estado = 0;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "identificador";
                        }
                        else if (char.IsDigit(frase[indice]))
                        {
                            estado = 1;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "entero";
                        }
                        else
                        {
                            estadoFinal = 25;
                            lexema = frase[indice].ToString();
                            token = "error";
                        }
                        indice++;
                    }
                    else if (estadoFinal == -1)
                    {
                        estadoFinal = 25; 
                    }
                    else if (estadoFinal == 0)
                    {
                        if (char.IsLetter(frase[indice]) || frase[indice] == '_')
                        {
                            estado = 0;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "identificador";
                            indice++;
                        }
                        else if (char.IsDigit(frase[indice]))
                        {
                            estado = 0;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "identificador";
                            indice++;
                        }
                        else
                        {
                            estadoFinal = 25;
                        }
                    }
                    else if (estadoFinal == 1)
                    {
                        if (char.IsDigit(frase[indice]))
                        {
                            estado = 1;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "entero";
                            indice++;
                        }
                        else if (frase[indice] == '.')
                        {
                            estado = 24;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "punto";
                            indice++;
                        }
                        else
                        {
                            estadoFinal = 25;
                        }
                    }
                    else if (estadoFinal == 24)
                    {
                        if (char.IsDigit(frase[indice]))
                        {
                            estado = 2;
                            estadoFinal = estado;
                            lexema += frase[indice];
                            token = "Numero real";
                            indice++;
                        }
                        else
                        {
                            estadoFinal = 25;
                        }
                    }

                }
                tabla.Rows.Add(estado, lexema, token);
                estadoFinal = -1;
            }
        }
        private void Bttn1_Click(object sender, EventArgs e)
        {
            string palabra = Tbx1.Text;
            analizar(palabra);
        }
    }
}