namespace Analizador_lexico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            AnalizarLexico();
        }
        private void AnalizarLexico()
        {
            int i = 0;
            int estado = 0;
            int numero = 0;
            string token = "";
            string conca = "";
            char[] cadena = tbx1.Text.ToCharArray();
            char newElement = '$';
            Array.Resize(ref cadena, cadena.Length + 1);
            cadena[cadena.Length - 1] = newElement;
            while (i < cadena.Length - 1 && estado == 0)
            {
                while (i < cadena.Length - 1 && estado != 20)
                {
                    if (estado == 0)
                    {
                        if (cadena[i] == ' ')
                            estado = 0;
                        else if (cadena[i] == '\n')
                            estado = 0;
                        else if (char.IsLetter(cadena[i]) || cadena[i] == '_')
                        {
                            estado = 1;
                            numero = 0;
                            conca = conca + cadena[i];
                            token = "Identificador";
                        }
                        else if (char.IsDigit(cadena[i]))
                        {
                            estado = 2;
                            token = "Entero";
                            numero = 1;
                            conca = conca + cadena[i];
                        }
                        else if (cadena[i] == '$')
                        {
                            estado = 20;
                            numero = 23;
                            conca = conca + cadena[i];
                            token = "Dinero";
                        }
                        else if (cadena[i] == '('
                            || cadena[i] == ')'
                            || cadena[i] == '{'
                            || cadena[i] == '}'
                            || cadena[i] == ','
                            || cadena[i] == ';')
                        {
                            switch (cadena[i])
                            {
                                case '(':
                                    token = "Parentesis de inicio";
                                    numero = 14;
                                    break;
                                case ')':
                                    token = "Parentesis de cerrado";
                                    numero = 15;
                                    break;
                                case '{':
                                    token = "Llave de inicio";
                                    numero = 16;
                                    break;
                                case '}':
                                    token = "Llave de cerrado";
                                    numero = 17;
                                    break;
                                case ',':
                                    token = "Coma";
                                    numero = 13;
                                    break;
                                case ';':
                                    token = "Punto y coma";
                                    numero = 12;
                                    break;
                            }
                            estado = 20;
                            conca = conca + cadena[i];
                        }
                        else if (cadena[i] == '='
                            || cadena[i] == '<'
                            || cadena[i] == '>'
                            || cadena[i] == '!')
                        {
                            switch (cadena[i])
                            {
                                case '=':
                                    token = "Asignación";
                                    numero = 18;
                                    break;
                                case '<':
                                    token = "OpRelac";
                                    numero = 7;
                                    break;
                                case '>':
                                    token = "OpRelac";
                                    numero = 7;
                                    break;
                                case '!':
                                    token = "OpNot";
                                    numero = 10;
                                    break;
                            }
                            estado = 3;
                            conca = conca + cadena[i];
                        }
                        else if (cadena[i] == '|' || cadena[i] == '&')
                        {
                            switch (cadena[i])
                            {
                                case '|':
                                    token = "Error";
                                    numero = -1;
                                    break;
                                case '&':
                                    token = "Error";
                                    numero = -1;
                                    break;
                            }
                            estado = 4;
                            conca = conca + cadena[i];
                        }
                        else if (cadena[i] == '+' || cadena[i] == '-')
                        {
                            conca = conca + cadena[i];
                            token = "OpSuma";
                            numero = 5;
                            estado = 20;
                        }
                        else if (cadena[i] == '*' || cadena[i] == '/')
                        {
                            conca = conca + cadena[i];
                            token = "opMultiplicacíon";
                            numero = 6;
                            estado = 20;
                        }
                        else
                        {
                            estado = 20;
                            token = "Error";
                            numero = -1;
                            conca = conca + cadena[i];
                        }
                        i++;
                    }
                    if (estado == 1)//Letras
                    {
                        if (Char.IsLetter(cadena[i]) || cadena[i] == '_' || Char.IsDigit(cadena[i]))
                        {
                            estado = 1;
                            conca = conca + cadena[i];
                            token = "Identificador";
                            i++;
                        }
                        else
                        {
                            estado = 20;
                        }
                    }
                    else if (estado == 2)//numeros o constantes
                    {
                        if (Char.IsDigit(cadena[i]))
                        {
                            estado = 2;
                            conca = conca + cadena[i];
                            token = "Entero";
                            i++;
                        }
                        if (cadena[i] == '.')
                        {
                            estado = 5;
                            conca = conca + cadena[i];
                            token = "Real";
                            i++;
                        }
                        else
                        {
                            estado = 20;
                        }
                    }
                    else if (estado == 3)//Operadores relacionales
                    {
                        if (cadena[i] != '=')
                        {
                            estado = 20;
                        }
                        else
                        {
                            conca = conca + cadena[i];
                            token = "OpRelac";
                            numero = 7;
                            i++;
                        }
                    }
                    else if (estado == 4)//operador logico
                    {
                        if (cadena[i] == '|')
                        {
                            conca = conca + cadena[i];
                            token = "OpOr";
                            numero = 8;
                            i++;
                        }
                        else if (cadena[i] == '&')
                        {
                            conca = conca + cadena[i];
                            token = "OpAnd";
                            numero = 9;
                            i++;
                        }
                        else
                        {
                            estado = 20;
                        }
                    }
                    else if (estado == 5)
                    {
                        if (Char.IsDigit(cadena[i]))
                        {
                            estado = 5;
                            numero = 2;
                            conca = conca + cadena[i];
                            token = "Real";
                            i++;
                        }
                        else
                        {
                            estado = 20;
                        }
                    }
                }
                if (conca == "int" || conca == "float" || conca == "char" || conca == "void")
                {
                    token = "Tipo";
                    numero = 4;
                }
                else if (conca == "if" || conca == "else" || conca == "while" || conca == "return")
                    PR(conca);
                else
                    Incertar(token, conca, numero);
                estado = 0;
                conca = "";
            }
        }
        private void PR(string conca)
        {
            switch (conca)
            {
                case "while":
                    Incertar("Ciclo", conca, 20);
                    break;
                case "return":
                    Incertar("Retornar valor", conca, 21);
                    break;
                case "else":
                    Incertar("Sino", conca, 22);
                    break;
                case "if":
                    Incertar("condicional SI", conca, 19);
                    break;
            }
        }
        private void Incertar(string token, string lexema, int numero)
        {
            int n = dgv1.Rows.Add();
            dgv1.Rows[n].Cells[0].Value = token;
            dgv1.Rows[n].Cells[1].Value = lexema;
            dgv1.Rows[n].Cells[2].Value = numero;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}