using System.Data;
using System.Text;

namespace Analisador_Sintactico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        class Pila
        {
            public LinkedList<ElementoPila> listaPila = new LinkedList<ElementoPila>();

            public Pila()
            {

            }

            public void push(ElementoPila x)
            {
                listaPila.AddLast(x);
            }

            public ElementoPila top()
            {
                return listaPila.First.Value;
            }

            public ElementoPila pop()
            {
                ElementoPila x = listaPila.First.Value;
                listaPila.Remove(x);

                return x;
            }

            public void vaciarPila()
            {
                listaPila.Clear();
            }

            public void mostrarPila()
            {
                foreach (ElementoPila dato in listaPila)
                {
                    Console.Write(dato.simbolo + dato.tipo);
                }
                Console.WriteLine("\n");
            }
        }
        
        class AnalizadorLexico
        {
            //Símbolos
            public const int ERROR = -1;
            public const int INICIAL = 55;
            public const int IDENTIFICADOR = 0;
            public const int ENTERO = 1;
            public const int REAL = 2;
            public const int CADENA = 3;
            public const int TIPO = 4;
            public const int OPSUMA = 5;
            public const int OPMUL = 6;
            public const int OPRELAC = 7;
            public const int OPOR = 8;
            public const int OPAND = 9;
            public const int OPNOT = 10;
            public const int OPIGUALDAD = 11;
            public const int PUNTOCOMA = 12;
            public const int COMA = 13;
            public const int ABREPARENTESIS = 14;
            public const int CIERRAPARENTESIS = 15;
            public const int ABRELLAVE = 16;
            public const int CIERRALLAVE = 17;
            public const int IGUAL = 18;
            public const int IF = 19;
            public const int WHILE = 20;
            public const int RETURN = 21;
            public const int ELSE = 22;
            public const int SIGNOPESOS = 23;

            public String[] tipoDatos = new String[] { "int", "float", "void" };
            public String[] reservadas = new String[] { "if", "while", "return", "else" };


            List<String> listaErrores;
            List<String> listaTokens;
            List<String> listaSintactico;
            List<String> salidaSintactico;
            List<Reglas> listaReglas;

            Pila pila;
            int[,] matriz = new int[95, 45];

            int cont;

            public AnalizadorLexico()
            {
                listaErrores = new List<String>();
                listaTokens = new List<String>();
                listaSintactico = new List<String>();
                salidaSintactico = new List<String>();
                listaReglas = new List<Reglas>();

                pila = new Pila();
                cargarMatriz();
                cargarReglas();
                cont = 0;
            }

            public void cargarMatriz()
            {
                int delimitador = 9;
                char _dem = Convert.ToChar(delimitador);
                String[] lineas = File.ReadAllLines(@"D:\Escuela\Semestre 2023 A\SEMINARIO DE SOLUCION DE PROBLEMAS DE TRADUCTORES DE LENGUAJES II\05.2\Analisador_Sintactico\Analisador_Sintactico\compilador.lr", Encoding.Default);
                for (int i = 0; i < lineas.Count(); i++)
                {
                    for (int j = 0; j < 45; j++)
                    {
                        matriz[i, j] = Convert.ToInt32(lineas[i].Split(_dem)[j]);
                    }
                }
            }

            public void cargarReglas()
            {
                int delimitador = 9;
                char _dem = Convert.ToChar(delimitador);
                string[] lineas = File.ReadAllLines(@"D:\Escuela\Semestre 2023 A\SEMINARIO DE SOLUCION DE PROBLEMAS DE TRADUCTORES DE LENGUAJES II\05.2\Analisador_Sintactico\Analisador_Sintactico\reglas.txt", Encoding.Default);
                foreach (string linea in lineas)
                {
                    string[] partes = linea.Split(_dem);
                    listaReglas.Add(new Reglas(Convert.ToInt32(partes[0]), Convert.ToInt32(partes[1]), partes[2]));
                }
            }

            public void agregaToken(String lexema, int tipo)
            {
                //Añade nuevo token
                String nuevoToken;
                switch (tipo)
                {
                    case IDENTIFICADOR:
                        nuevoToken = lexema + " es un identificador" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case ENTERO:
                        nuevoToken = lexema + " es un entero" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case REAL:
                        nuevoToken = lexema + " es un número real" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case CADENA:
                        nuevoToken = lexema + " es una cadena" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case TIPO:
                        nuevoToken = lexema + " es un tipo de dato" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case OPSUMA:
                        if (lexema == "+")
                        {
                            nuevoToken = lexema + " es un operador de suma" + "\n";
                            listaTokens.Add(nuevoToken);
                        }
                        else if (lexema == "-")
                        {
                            nuevoToken = lexema + " es un operador de resta" + "\n";
                            listaTokens.Add(nuevoToken);
                        }
                        break;
                    case OPMUL:
                        if (lexema == "*")
                        {
                            nuevoToken = lexema + " es un operador de multiplicación" + "\n";
                            listaTokens.Add(nuevoToken);
                        }
                        else if (lexema == "/")
                        {
                            nuevoToken = lexema + " es un operador de división" + "\n";
                            listaTokens.Add(nuevoToken);
                        }
                        break;
                    case OPRELAC:
                        nuevoToken = lexema + " es un operador relacional" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case OPOR:
                        nuevoToken = lexema + " es un operador " + "OR" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case OPAND:
                        nuevoToken = lexema + " es un operador AND" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case OPNOT:
                        nuevoToken = lexema + " es un operador de negación" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case OPIGUALDAD:
                        nuevoToken = lexema + " es un operador de igualdad" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case PUNTOCOMA:
                        nuevoToken = lexema + " es un punto y coma (;)" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case COMA:
                        nuevoToken = lexema + " es una coma (,)" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case ABREPARENTESIS:
                        nuevoToken = lexema + " abre paréntesis" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case CIERRAPARENTESIS:
                        nuevoToken = lexema + " cierra paréntesis" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case ABRELLAVE:
                        nuevoToken = lexema + " abre llave" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case CIERRALLAVE:
                        nuevoToken = lexema + " cierra llave" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case IGUAL:
                        nuevoToken = lexema + " es un operador de igual (=)" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case IF:
                    case WHILE:
                    case RETURN:
                    case ELSE:
                        nuevoToken = lexema + " es una palabra reservada" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    case SIGNOPESOS:
                        nuevoToken = lexema + " es el signo $" + "\n";
                        listaTokens.Add(nuevoToken);
                        break;
                    default:
                        break;
                }
            }

            public void agregaError(String lexema)
            {
                //Añade un error
                String nuevoError;
                nuevoError = lexema + " es un carácter no admitido" + "\n";
                listaErrores.Add(nuevoError);
            }


            public void Analizador(String texto)
            {
                int estado = 0; //Identifica el estado actual del analizador
                String lexema = "";
                Char c;
                bool hayPunto = false; //Bandera para verificar si la expresión es un número y si tiene un punto
                texto = texto + "$";
                pila.push(new NoTerminal(0, "$"));
                listaSintactico.Add(dameListaPila());

                //Inicia el automata del analizador
                for (int i = 0; i < texto.Length; i++)
                {
                    c = texto[i];
                    switch (estado)
                    {
                        case INICIAL:
                            if (Char.IsLetter(c) || c == '_')
                            { //Verifica si es letra o empieza con un "_"
                                estado = IDENTIFICADOR;
                                lexema += c;
                            }
                            else if (Char.IsDigit(c))
                            { //Verifica si es digito
                                estado = ENTERO;
                                lexema += c;
                            }
                            else if (c == '"')
                            {
                                estado = CADENA;
                                lexema += c;
                            }
                            else if (c == '+' || c == '-')
                            {
                                lexema += c;

                                agregaToken(lexema, OPSUMA);
                                AnalizadorSintactico(OPSUMA, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else if (c == '*' || c == '/')
                            {
                                lexema += c;

                                agregaToken(lexema, OPMUL);
                                AnalizadorSintactico(OPMUL, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else if (c == '<' || c == '>')
                            {
                                estado = OPRELAC;
                                lexema += c;
                            }
                            else if (c == '|')
                            {
                                estado = OPOR;
                                lexema += c;
                            }
                            else if (c == '&')
                            {
                                estado = OPAND;
                                lexema += c;
                            }
                            else if (c == '=' || c == '!')
                            {
                                if (texto[i + 1] != '=')
                                {
                                    if (c == '=')
                                    {
                                        lexema += c;

                                        agregaToken(lexema, IGUAL);
                                        AnalizadorSintactico(IGUAL, lexema);
                                        lexema = "";
                                        estado = INICIAL;
                                    }
                                    else if (c == '!')
                                    {
                                        lexema += c;

                                        agregaToken(lexema, OPNOT);
                                        AnalizadorSintactico(OPNOT, lexema);
                                        estado = INICIAL;
                                        lexema = "";
                                    }
                                }
                                else
                                {
                                    estado = OPIGUALDAD;
                                    lexema += c;
                                }
                            }
                            else if (c == ';')
                            {
                                lexema += c;

                                agregaToken(lexema, PUNTOCOMA);
                                AnalizadorSintactico(PUNTOCOMA, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else if (c == ',')
                            {
                                lexema += c;

                                agregaToken(lexema, COMA);
                                AnalizadorSintactico(COMA, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else if (c == '(')
                            {
                                lexema += c;

                                agregaToken(lexema, ABREPARENTESIS);
                                AnalizadorSintactico(ABREPARENTESIS, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else if (c == ')')
                            {
                                lexema += c;

                                agregaToken(lexema, CIERRAPARENTESIS);
                                AnalizadorSintactico(CIERRAPARENTESIS, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else if (c == '{')
                            {
                                lexema += c;

                                agregaToken(lexema, ABRELLAVE);
                                AnalizadorSintactico(ABRELLAVE, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else if (c == '}')
                            {
                                lexema += c;

                                agregaToken(lexema, CIERRALLAVE);
                                AnalizadorSintactico(CIERRALLAVE, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else if (c == '$')
                            {
                                lexema += c;

                                agregaToken(lexema, SIGNOPESOS);
                                AnalizadorSintactico(SIGNOPESOS, lexema);
                                estado = INICIAL;
                                lexema = "";
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
                                if (esTipoDato(lexema))
                                {
                                    agregaToken(lexema, TIPO);
                                    AnalizadorSintactico(TIPO, lexema);
                                    estado = INICIAL;
                                    lexema = "";
                                }
                                else if (esReservada(lexema))
                                {
                                    agregaToken(lexema, tipoReservada(lexema));
                                    AnalizadorSintactico(tipoReservada(lexema), lexema);
                                    estado = INICIAL;
                                    lexema = "";
                                }
                                else
                                {
                                    agregaToken(lexema, IDENTIFICADOR);
                                    AnalizadorSintactico(IDENTIFICADOR, lexema);
                                    estado = INICIAL;
                                    lexema = "";
                                    i--;
                                }
                            }
                            break;
                        case ENTERO:
                            if (Char.IsDigit(c))
                            {
                                estado = ENTERO;
                                lexema += c;
                            }
                            else if (c == '.')
                            {
                                if (hayPunto == false)
                                {
                                    estado = REAL;
                                    lexema += c;
                                    hayPunto = true;

                                }
                                else
                                {
                                    lexema += c;
                                    agregaError(lexema);

                                    estado = INICIAL;
                                    lexema = "";
                                }
                            }
                            else
                            {
                                agregaToken(lexema, ENTERO);
                                AnalizadorSintactico(ENTERO, lexema);
                                estado = INICIAL;
                                lexema = "";
                                i--;
                            }
                            break;
                        case REAL:
                            if (Char.IsDigit(c))
                            {
                                estado = REAL;
                                lexema += c;
                            }
                            else if (c == '.')
                            {
                                if (hayPunto)
                                {
                                    lexema += c;
                                    agregaError(lexema);

                                    estado = INICIAL;
                                    lexema = "";
                                }
                            }
                            else
                            {
                                agregaToken(lexema, REAL);
                                AnalizadorSintactico(REAL, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            break;
                        case CADENA:
                            if (c == '"')
                            {
                                lexema += c;
                                agregaToken(lexema, CADENA);
                                AnalizadorSintactico(CADENA, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else
                            {
                                estado = CADENA;
                                lexema += c;
                            }
                            break;
                        case OPRELAC:
                            if (c == '=')
                            {
                                lexema += c;

                                agregaToken(lexema, OPRELAC);
                                AnalizadorSintactico(OPRELAC, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else
                            {
                                agregaToken(lexema, OPRELAC);
                                AnalizadorSintactico(OPRELAC, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            break;
                        case OPOR:
                            if (c == '|')
                            {
                                lexema += c;

                                agregaToken(lexema, OPOR);
                                AnalizadorSintactico(OPOR, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else
                            {
                                agregaToken(lexema, OPOR);
                                AnalizadorSintactico(OPOR, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            break;
                        case OPAND:
                            if (c == '&')
                            {
                                lexema += c;

                                agregaToken(lexema, OPAND);
                                AnalizadorSintactico(OPAND, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else
                            {
                                agregaToken(lexema, OPAND);
                                AnalizadorSintactico(OPAND, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            break;
                        case OPIGUALDAD:
                            lexema += c;

                            agregaToken(lexema, OPIGUALDAD);
                            AnalizadorSintactico(OPIGUALDAD, lexema);
                            estado = INICIAL;
                            lexema = "";
                            break;
                        default:
                            break;
                    }
                }
                //Termina el automata
            }

            public void AnalizadorSintactico(int estado, String simb) //Analizador sintáctico
            {
                if (estado == SIGNOPESOS)
                {
                    int i = (matriz[cont, estado] * -1) - 2;
                    if (i == -1)
                    {
                        salidaSintactico.Add("R" + 0);
                        return;
                    }
                    else
                    {
                        if (listaReglas[i].num_va == 0)
                        {
                            int num_regla = listaReglas[i].num;
                            cont = matriz[cont, num_regla];
                            pila.push(new Terminal(cont, listaReglas[i].nombre));
                            listaSintactico.Add(dameListaPila());
                            salidaSintactico.Add("R" + (i + 1));
                            AnalizadorSintactico(estado, simb);
                        }
                        else
                        {
                            int num_regla = listaReglas[i].num;
                            pila.vaciarPila();
                            pila.push(new NoTerminal(0, "$"));
                            cont = matriz[0, num_regla];
                            pila.push(new Terminal(cont, listaReglas[i].nombre));
                            listaSintactico.Add(dameListaPila());
                            salidaSintactico.Add("R" + (i + 1));
                            AnalizadorSintactico(estado, simb);
                        }
                    }
                }
                else
                {
                    if (matriz[cont, estado] > 0)
                    {
                        cont = matriz[cont, estado];
                        pila.push(new NoTerminal(cont, simb));
                        listaSintactico.Add(dameListaPila());
                        salidaSintactico.Add("D" + cont);
                    }
                    else if (matriz[cont, estado] < 0)
                    {
                        int i = (matriz[cont, estado] * -1) - 1;
                        int num_regla = listaReglas[i].num;
                        cont = matriz[cont, num_regla];
                        pila.push(new NoTerminal(cont, listaReglas[i].nombre));
                        listaSintactico.Add(dameListaPila());
                        salidaSintactico.Add("R" + i);
                        AnalizadorSintactico(estado, simb);
                    }
                }
            }

            public Boolean esTipoDato(String lexema)
            {
                for (int i = 0; i < tipoDatos.Length; i++)
                {
                    if (tipoDatos[i].Equals(lexema))
                    {
                        return true;
                    }
                }
                return false;
            }

            public Boolean esReservada(String lexema)
            {
                for (int i = 0; i < reservadas.Length; i++)
                {
                    if (reservadas[i].Equals(lexema))
                    {
                        return true;
                    }
                }
                return false;
            }

            public int tipoReservada(String lexema)
            {
                switch (lexema)
                {
                    case "if":
                        return IF;
                    case "while":
                        return WHILE;
                    case "return":
                        return RETURN;
                    case "else":
                        return ELSE;
                    default:
                        return ERROR;
                }
            }

            public String dameListaToken()
            {
                String lista = String.Join(Environment.NewLine, listaTokens.ToArray());
                return lista;

            }

            public String dameListaErrores()
            {
                String lista = String.Join(Environment.NewLine, listaErrores.ToArray());
                return lista;
            }

            public String dameListaPila()
            {
                String s = "";
                foreach (ElementoPila dato in pila.listaPila)
                {
                    s = s + dato.simbolo + dato.tipo;
                }
                s = s + "\n";
                return s;
            }

            public List<String> dameListaSintactico()
            {
                return listaSintactico;
            }

            public List<String> dameSalida()
            {
                return salidaSintactico;
            }
        }

        class Reglas
        {
            public int num;
            public int num_va;
            public String nombre;
            public Reglas()
            {

            }
            public Reglas(int num, int num_va, String nombre)
            {
                this.num = num;
                this.num_va = num_va;
                this.nombre = nombre;
            }
        }

        class ElementoPila
        {
            public const int ERROR = -1;
            public const int IDENTIFICADOR = 0;
            public const int SIMBOLO = 1;
            public const int SIGNOPESO = 2;
            public const int E = 3;
            public const int INICIAL = 5;

            public int tipo;
            public String simbolo;

            public ElementoPila()
            {
                tipo = 5;
            }
            public String ToString()
            {
                return simbolo;
            }
        }
        class Terminal : ElementoPila
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
        class NoTerminal : ElementoPila
        {
            public NoTerminal(int id, String sim)
            {
                tipo = id;
                simbolo = sim;
            }
        }
        class Estado : ElementoPila
        {
            public Estado(int id, String estado)
            {
                tipo = id;
                simbolo = estado;
            }
        } 


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtResLexico.Text = "";
            txtErroresLexico.Text = "";
            txtExpresion.Text = "";
        }
        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            if (txtExpresion.Text != "")
            {
                AnalizadorLexico analizador = new AnalizadorLexico();

                analizador.Analizador(txtExpresion.Text.ToString());

                txtResLexico.Text = analizador.dameListaToken();
                txtErroresLexico.Text = analizador.dameListaErrores();
                mostrarSintactico(analizador.dameListaSintactico(), analizador.dameSalida());
            }
            else
            {
                MessageBox.Show("El cuadro de texto está vacío");
            }
        }
        private void mostrarSintactico(List<String> lista, List<String> salida)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                dgvSintactico.Rows.Add(lista[i], salida[i]);
            }
        }
    }
}