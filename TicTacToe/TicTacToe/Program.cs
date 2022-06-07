// See https://aka.ms/new-console-template for more information
string[,] tablero = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
string[,] tableroReinicio = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
bool esTurnoCirculo = true;
Juega();

void Juega()
{
    bool hayGanador = false;

    string jugar = "jugar";
    while (jugar == "jugar")
    {
        while (ChecaFinaldelJuego())
        {
            DibujaTablero();
            TurnoJugador();

            hayGanador = RevisaGanador(esTurnoCirculo);

            if (hayGanador)
                break;

            esTurnoCirculo = !esTurnoCirculo;
        }

        DibujaTablero();
        if (hayGanador)
        {
            if (esTurnoCirculo)
                Console.WriteLine("Ganó el jugador que va O");
            else
                Console.WriteLine("Ganó el jugador que va X");
        }
        else
            Console.WriteLine("Hubo un empate");

        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("Si quieres volver a jugar escribe 'jugar', sino presiona cualquier tecla y presione Enter");
        jugar = Console.ReadLine();
        if (jugar == "jugar")
            tablero = tableroReinicio;
    }
}


void TurnoJugador()
{
    string mensaje;
    if (esTurnoCirculo)
        mensaje = "Jugador O, escoge una casilla válida para jugar";
    else
        mensaje = "Jugador X, escoge una casilla válida para jugar";

    bool esEntreadaValida;
    do
    {
        Console.WriteLine(mensaje);
        string posicion = Console.ReadLine();
        esEntreadaValida = VerificaEntradaValida(posicion);
    }
    while (esEntreadaValida == false);
}

bool VerificaEntradaValida(string? posicion)
{
    int posicionTablero = 0;
    if (posicion == null)
        return false;

    if (Int32.TryParse(posicion, out posicionTablero))
    {
        if (posicionTablero > 9 || posicionTablero < 1)
            return false;
        else
        {
            if (!ChecaPosicionOcupada(posicionTablero))
                return false;

            CambiaSeñalTablero(posicionTablero);
            return true;
        }

    }
    else
        return false;
}

bool ChecaPosicionOcupada(int posicionTablero)
{
    switch (posicionTablero)
    {
        case 1:
            if (tablero[0, 0] == "X" || tablero[0, 0] == "O")
                return false;
            else
                return true;
        case 2:
            if (tablero[0, 1] == "X" || tablero[0, 1] == "O")
                return false;
            else
                return true;
        case 3:
            if (tablero[0, 2] == "X" || tablero[0, 2] == "O")
                return false;
            else
                return true;
        case 4:
            if (tablero[1, 0] == "X" || tablero[1, 0] == "O")
                return false;
            else
                return true;
        case 5:
            if (tablero[1, 1] == "X" || tablero[1, 1] == "O")
                return false;
            else
                return true;
        case 6:
            if (tablero[1, 2] == "X" || tablero[1, 2] == "O")
                return false;
            else
                return true;
        case 7:
            if (tablero[2, 0] == "X" || tablero[2, 0] == "O")
                return false;
            else
                return true;
        case 8:
            if (tablero[2, 1] == "X" || tablero[2, 1] == "O")
                return false;
            else
                return true;
        case 9:
            if (tablero[2, 2] == "X" || tablero[2, 2] == "O")
                return false;
            else
                return true;
        default: return false;
    }
}

void CambiaSeñalTablero(int posicionTablero)
{
    switch (posicionTablero)
    {
        case 1:
            if (esTurnoCirculo)
                tablero[0, 0] = "O";
            else
                tablero[0, 0] = "X";
            break;
        case 2:
            if (esTurnoCirculo)
                tablero[0, 1] = "O";
            else
                tablero[0, 1] = "X";
            break;
        case 3:
            if (esTurnoCirculo)
                tablero[0, 2] = "O";
            else
                tablero[0, 2] = "X";
            break;
        case 4:
            if (esTurnoCirculo)
                tablero[1, 0] = "O";
            else
                tablero[1, 0] = "X";
            break;
        case 5:
            if (esTurnoCirculo)
                tablero[1, 1] = "O";
            else
                tablero[1, 1] = "X";
            break;
        case 6:
            if (esTurnoCirculo)
                tablero[1, 2] = "O";
            else
                tablero[1, 2] = "X";
            break;
        case 7:
            if (esTurnoCirculo)
                tablero[2, 0] = "O";
            else
                tablero[2, 0] = "X";
            break;
        case 8:
            if (esTurnoCirculo)
                tablero[2, 1] = "O";
            else
                tablero[2, 1] = "X";
            break;
        case 9:
            if (esTurnoCirculo)
                tablero[2, 2] = "O";
            else
                tablero[2, 2] = "X";
            break;
    }
}

void DibujaTablero()
{
    Console.Clear();
    Console.WriteLine("    |    |    ");
    Console.WriteLine(" {0}  | {1}  |  {2}  ", tablero[0, 0], tablero[0, 1], tablero[0, 2]);
    Console.WriteLine("____|____|____");
    Console.WriteLine("    |    |    ");
    Console.WriteLine(" {0}  | {1}  |  {2}  ", tablero[1, 0], tablero[1, 1], tablero[1, 2]);
    Console.WriteLine("____|____|____");
    Console.WriteLine("    |    |    ");
    Console.WriteLine(" {0}  | {1}  |  {2}  ", tablero[2, 0], tablero[2, 1], tablero[2, 2]);
    Console.WriteLine("    |    |    ");
}

bool RevisaGanador(bool esTurnoCirculo)
{
    bool esGanadorCruz = false;
    bool esGanadorCirculo = false;

    if (esTurnoCirculo)
    {
        esGanadorCirculo = RevisaGanadorCirculo();
        return esGanadorCirculo;
    }
    else
    {
        esGanadorCruz = RevisaGanadorCruz();
        return esGanadorCruz;
    }

}

bool RevisaGanadorCruz()
{
    // Revisa victoria con filas
    if (tablero[0, 0] == "X" && tablero[0, 1] == "X" && tablero[0, 2] == "X") // Revisa primera fila
        return true;
    if (tablero[1, 0] == "X" && tablero[1, 1] == "X" && tablero[1, 2] == "X") // Revisa segunda fila
        return true;
    if (tablero[2, 0] == "X" && tablero[2, 1] == "X" && tablero[2, 2] == "X") // Revisa tercer fila
        return true;

    // Revisa victoria con columna
    if (tablero[0, 0] == "X" && tablero[1, 0] == "X" && tablero[2, 0] == "X") // Revisa primer columna
        return true;
    if (tablero[0, 1] == "X" && tablero[1, 1] == "X" && tablero[2, 1] == "X") // Revisa segunda columna
        return true;
    if (tablero[0, 2] == "X" && tablero[1, 2] == "X" && tablero[2, 2] == "X") // Revisa tercer columna
        return true;


    // Revisa victoria con diagonales
    if (tablero[0, 0] == "X" && tablero[1, 1] == "X" && tablero[2, 2] == "X") // Revisa primer columna
        return true;
    if (tablero[0, 2] == "X" && tablero[1, 1] == "X" && tablero[2, 0] == "X") // Revisa segunda columna
        return true;

    return false;
}

bool RevisaGanadorCirculo()
{
    // Revisa victoria con filas
    if (tablero[0, 0] == "O" && tablero[0, 1] == "O" && tablero[0, 2] == "O") // Revisa primera fila
        return true;
    if (tablero[1, 0] == "O" && tablero[1, 1] == "O" && tablero[1, 2] == "O") // Revisa segunda fila
        return true;
    if (tablero[2, 0] == "O" && tablero[2, 1] == "O" && tablero[2, 2] == "O") // Revisa tercer fila
        return true;

    // Revisa victoria con columna
    if (tablero[0, 0] == "O" && tablero[1, 0] == "O" && tablero[2, 0] == "O") // Revisa primer columna
        return true;
    if (tablero[0, 1] == "O" && tablero[1, 1] == "O" && tablero[2, 1] == "O") // Revisa segunda columna
        return true;
    if (tablero[0, 2] == "O" && tablero[1, 2] == "O" && tablero[2, 2] == "O") // Revisa tercer columna
        return true;

    // Revisa victoria con diagonales
    if (tablero[0, 0] == "O" && tablero[1, 1] == "O" && tablero[2, 2] == "O") // Revisa primer columna
        return true;
    if (tablero[0, 2] == "O" && tablero[1, 1] == "O" && tablero[2, 0] == "O") // Revisa segunda columna
        return true;

    return false;
}

bool ChecaFinaldelJuego()
{
    bool hayCasillasDisponibles;
    int contadorCasillasDisponibles = 0;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            try
            {
                Int32.Parse(tablero[i, j]);
                contadorCasillasDisponibles++;
            }
            catch
            {

            }
        }
    }

    if (contadorCasillasDisponibles == 0)
        return false;
    else
        return true;
}