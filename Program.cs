using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using Microsoft.VisualBasic;

namespace TicTacToe
{
    class Programa
    {
        static void Main(string[] args)
        {
            Tauler board = new Tauler();
            Ordinador PC = new Ordinador(board);
            int[] jugada = { 0, 0 };

            int actual = 1;
            bool guanyaJugador = false, guanyaPC = false;

            board.Mostrar();

            do
            {
                Console.WriteLine("És el torn de :" + actual);
                if (actual == 1) jugada = board.tirada();
                if (actual == 2) jugada = PC.tirada();

                board.PintarMoviment(jugada[0], jugada[1], actual);
                guanyaJugador = board.TresRatlla();
                guanyaPC = board.TresRatlla();
                if (guanyaJugador || guanyaPC)
                    Console.WriteLine("TRES EN RATLLA DEL JUGADOR " + actual);
                actual = actual == 1 ? 2 : 1;
                board.Mostrar();
                if(board.Ple())   Console.WriteLine("Empat");
            } while (!guanyaJugador && !guanyaPC && !board.Ple());
            Console.WriteLine("");
            Console.WriteLine("Game over");
        }
    }
}


class Cela
{
    public Cela() { }
    public void pintaCela()
    {
        Console.WriteLine("┌───┐");
        Console.WriteLine("│ ⁕ │");
        Console.WriteLine("└───┘");
        /* Console.WriteLine("⏺ ● ◉ ✖ ✘ ■ ✔ "); */
    }

}