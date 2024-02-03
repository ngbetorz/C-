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

    class Tauler : IJugadors
    {
        int[,] mat;
        public Tauler()
        {
            this.mat = new int[3, 3]; // mat[i,j] == 0 si la casella (i,j) esta buida, 1 si hi ha el jugador ✘ i 2 si és el jugador ✔
        }

        public void Mostrar()
        {
            Console.WriteLine("");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    switch (mat[i, j])
                    {
                        case 1:
                            Console.Write(" ✘ ");
                            break;
                        case 2:
                            Console.Write(" ✔ ");
                            break;
                        default:
                            Console.Write(" · ");
                            break;

                    }
                }
                Console.WriteLine("");
            }
        }


        public int[] tirada()
        {
            int fila, columna;

            do
            {
                Console.WriteLine("Quina fila?");
                fila = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Quina columna?");
                columna = Int32.Parse(Console.ReadLine()) - 1;
            } while (fila > 2 || fila < 0 || columna > 2 || columna < 0 || Ocupat(fila, columna));
            return [fila, columna];
        }

        public bool Ocupat(int i, int j)
        {
            if (mat[i, j] != 0) return true;
            return false;
        }

        public void PintarMoviment(int fil, int col, int jugador)
        {
            mat[fil, col] = jugador;
        }

        public bool TresRatlla()
        {
            for (int i = 0; i < 3; i++)
            {
                // Columna i
                if (this.Ocupat(i, 0) && mat[i, 0] == mat[i, 1] && mat[i, 1] == mat[i, 2]) return true;

                if (this.Ocupat(0, i) && mat[0, i] == mat[1, i] && mat[1, i] == mat[2, i]) return true;
            }

            // Diagonal \  
            if (this.Ocupat(1, 1) && mat[0, 0] == mat[1, 1] && mat[1, 1] == mat[2, 2]) return true;

            // Diagonal /
            if (this.Ocupat(1, 1) && mat[0, 2] == mat[1, 1] && mat[1, 1] == mat[2, 0]) return true;

            return false;
        }

        public bool Ple()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!this.Ocupat(i, j)) return false;
                }
            }
            return true;
        }
    }
}