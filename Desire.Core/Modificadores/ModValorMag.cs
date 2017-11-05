using Desire.Core.Util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Desire.Core.Modificadores
{
    public abstract class ModValorMag : Modificador
    {
        public ValorMag Valor { get; set; }
        public abstract char Operador { get; }
        public string Alvo { get; set; }

        public override string ToString()
        {
            return this.Alvo + this.Operador + this.Valor.ToString() + " (" + this.Origem + ")";
        }
    }

    public class ModSomaValorMag : ModValorMag
    {
        public override char Operador { get => '+'; }

        public override Ser AplicaModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.SomaValorMag((ValorMag)propriedade.GetValue(ser, null), this.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", this.Alvo);
        }

        public override Ser RemoveModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.SubtraiValorMag((ValorMag)propriedade.GetValue(ser, null), this.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", this.Alvo);
        }
    }

    public class ModSubtraiValorMag : ModValorMag
    {
        public override char Operador { get => '-'; }

        public override Ser AplicaModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.SubtraiValorMag((ValorMag)propriedade.GetValue(ser, null), this.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", this.Alvo);
        }

        public override Ser RemoveModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.SomaValorMag((ValorMag)propriedade.GetValue(ser, null), this.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", this.Alvo);
        }
    }

    public class ModMultiplicaValorMag : ModValorMag
    {
        public override char Operador { get => '-'; }

        public override Ser AplicaModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.MultiplicaValorMag((ValorMag)propriedade.GetValue(ser, null), this.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", this.Alvo);
        }

        public override Ser RemoveModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.MultiplicaValorMag((ValorMag)propriedade.GetValue(ser, null), this.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", this.Alvo);
        }
    }

    public class ModDivideValorMag : ModValorMag
    {
        public override char Operador { get => '-'; }

        public override Ser AplicaModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.MultiplicaValorMag((ValorMag)propriedade.GetValue(ser, null), this.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", this.Alvo);
        }

        public override Ser RemoveModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.MultiplicaValorMag((ValorMag)propriedade.GetValue(ser, null), this.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", this.Alvo);
        }
    }
}
