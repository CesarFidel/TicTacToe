// See https://aka.ms/new-console-template for more information
string[,] tablero = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
bool esTurnoCirculo = true;
IniciaJuego();

void IniciaJuego()
{
    bool hayGanador = false;

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
            CambiaSeñalTablero(posicionTablero);
            return true;
        }

    }
    else
        return false;
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
    string marcadorTablero = "";
    int lenght = tablero.Length;
    for (int fila = 1; fila <= 9; fila++)
    {
        for (int columna = 1; columna <= 14; columna++)
        {
            if (ChecaPosicionJugar(fila, columna, out marcadorTablero))
            {
                Console.Write(marcadorTablero);
            }
            else if (columna % 5 == 0 && columna != 0 && columna + 1 != 15)
            {
                Console.Write("|");
            }
            else if (fila % 3 == 0 && fila != 0 && fila + 1 != 10)
            {
                Console.Write("_");
            }
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }
}

bool ChecaPosicionJugar(int i, int j, out string marcadorTablero)
{
    marcadorTablero = "-";

    // Renglon 1
    bool esPosicionRenglon11 = i == 2 && j == 2;
    bool esPosicionRenglon12 = i == 2 && j == 7;
    bool esPosicionRenglon13 = i == 2 && j == 12;
    if (esPosicionRenglon11)
        marcadorTablero = tablero[0, 0];
    if (esPosicionRenglon12)
        marcadorTablero = tablero[0, 1];
    if (esPosicionRenglon13)
        marcadorTablero = tablero[0, 2];
    bool esPosicionPrimerRenglon = esPosicionRenglon11 || esPosicionRenglon12 || esPosicionRenglon13;

    // Renglon 2
    bool esPosicionRenglon21 = i == 5 && j == 2;
    bool esPosicionRenglon22 = i == 5 && j == 7;
    bool esPosicionRenglon23 = i == 5 && j == 12;
    if (esPosicionRenglon21)
        marcadorTablero = tablero[1, 0];
    if (esPosicionRenglon22)
        marcadorTablero = tablero[1, 1];
    if (esPosicionRenglon23)
        marcadorTablero = tablero[1, 2];
    bool esPosicionSegundoRenglon = esPosicionRenglon21 || esPosicionRenglon22 || esPosicionRenglon23;

    // Renglon 3
    bool esPosicionRenglon31 = i == 8 && j == 2;
    bool esPosicionRenglon32 = i == 8 && j == 7;
    bool esPosicionRenglon33 = i == 8 && j == 12;
    if (esPosicionRenglon31)
        marcadorTablero = tablero[2, 0];
    if (esPosicionRenglon32)
        marcadorTablero = tablero[2, 1];
    if (esPosicionRenglon33)
        marcadorTablero = tablero[2, 2];
    bool esPosicionTercerRenglon = esPosicionRenglon31 || esPosicionRenglon32 || esPosicionRenglon33;

    return esPosicionPrimerRenglon || esPosicionSegundoRenglon || esPosicionTercerRenglon;
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
    int posocionesLibres = 0;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 2; j++)
        {
            if (posocionesLibres > 0)
                return true;
            if (tablero[i, j] != "-")
                posocionesLibres++;
        }
    }
    return false;
}