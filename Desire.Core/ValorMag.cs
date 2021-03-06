﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Desire.Core
{
    public class ValorMag: IComparable
    {
        public int Valor { get; set; }
        public int Magnitude { get; set; }
        public string ValorReal { get; set; }

        public ValorMag()
        {
            this.Valor = 0;
            this.Magnitude = 0;
            this.ValorReal = "0";
        }

        public ValorMag(int valor, int magnitude)
        {
            Conversor conversor = new Conversor();
            this.Valor = valor;
            this.Magnitude = magnitude;
            this.ValorReal = conversor.ValorMagParaString(valor, magnitude);
        }

        public ValorMag(string valorMag)
        {
            Conversor conversor = new Conversor();
            if (valorMag.Contains("m"))
            {
                string[] matriz = valorMag.Split('m');
                this.Valor = Convert.ToInt32(matriz[0]);
                this.Magnitude = Convert.ToInt32(matriz[1]);
                this.ValorReal = conversor.ValorMagParaString(Convert.ToInt32(matriz[0]), Convert.ToInt32(matriz[1]));
            }
            else
            {
                ValorMag valor = conversor.StringParaValorMag(valorMag);
                this.ValorReal = valorMag;
                this.Valor = valor.Valor;
                this.Magnitude = valor.Magnitude;
            }
        }

        public override string ToString()
        {
            return this.Valor + "m" + this.Magnitude;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            ValorMag outroValorMag = obj as ValorMag;

            if (this.Magnitude == outroValorMag.Magnitude)
            {
                if (this.Valor == outroValorMag.Valor)
                    return 0;
                else if (this.Valor > outroValorMag.Valor)
                    return 1;
                else if (this.Valor < outroValorMag.Valor)
                    return -1;
            }
            if (this.Magnitude > outroValorMag.Magnitude)
                return 1;
            if (this.Magnitude < outroValorMag.Magnitude)
                return -1;

            return 0;
        }
    }
}
