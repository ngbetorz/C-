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

    class Ordinador : IJugadors
    {
        Tauler board;
        public Ordinador(Tauler board){
            this.board = board;
        }
        public int[] tirada()
        {
            bool buit = true;
            int fila, columna;
            Random random = new Random();

            /*Primer moviment si el tauler està buit*/
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board.Ocupat(i, j)) buit = false;
            if (buit == true) return [1, 1];

            /*Buscar una casella en la que si l'altre jugador tirés faria Tres en Ratlla*/
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.Ocupat(i, j)) continue;
                    board.PintarMoviment(i, j, 2);
                    bool movimentGuanya = board.TresRatlla();
                    board.PintarMoviment(i, j, 0);
                    if (movimentGuanya) return [i, j];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.Ocupat(i, j)) continue;
                    board.PintarMoviment(i, j, 1);
                    bool movimentPerd = board.TresRatlla();
                    board.PintarMoviment(i, j, 0);
                    if (movimentPerd) return [i, j];
                }
            }


            do
            {
                fila = random.Next(0, 3);
                columna = random.Next(0, 3);
            } while (board.Ocupat(fila, columna)) /* (mat[fila, columna] == " ✘ " || mat[fila, columna] == " ✔ ") */;

            return [fila, columna];
        }
    }
}