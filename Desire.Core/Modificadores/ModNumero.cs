using Desire.Core.Util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Desire.Core.Modificadores
{
    public abstract class ModNumero : Modificador
    {
        public decimal Valor { get; set; }
        public abstract char Operador { get; }
        public string Alvo { get; set; }

        public override string ToString()
        {
            return this.Alvo + this.Operador + this.Valor.ToString() + " (" + this.Origem + ")";
        }
    }

    public class ModSomaNumero : ModNumero
    {
        public override char Operador { get => '-'; }

        public override Ser AplicaModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double))
            {
                CalculadorNumero calculador = new CalculadorNumero();


                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) + (int)this.Valor;
                    propriedade.SetValue(ser, resultado);
                }
            else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) + this.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                
            else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) + decimal.ToDouble(Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", this.Alvo);
        }

        public override Ser RemoveModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double))
            {
                CalculadorNumero calculador = new CalculadorNumero();


                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) - (int)this.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) - this.Valor;
                    propriedade.SetValue(ser, resultado);
                }

                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) - decimal.ToDouble(Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", this.Alvo);
        }
    }

    public class ModSubtraiNumero : ModNumero
    {
        public override char Operador { get => '-'; }

        public override Ser AplicaModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double))
            {
                CalculadorNumero calculador = new CalculadorNumero();


                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) - (int)this.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) - this.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) - decimal.ToDouble(Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", this.Alvo);
        }

        public override Ser RemoveModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double))
            {
                CalculadorNumero calculador = new CalculadorNumero();


                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) + (int)this.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) + this.Valor;
                    propriedade.SetValue(ser, resultado);
                }

                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) + decimal.ToDouble(Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", this.Alvo);
        }
    }

    public class ModMultiplicaNumero : ModNumero
    {
        public override char Operador { get => '-'; }

        public override Ser AplicaModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double) && this.Valor != 0)
            {
                CalculadorNumero calculador = new CalculadorNumero();

                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) * (int)this.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) * this.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) * decimal.ToDouble(Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", this.Alvo);
        }

        public override Ser RemoveModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double) && this.Valor != 0)
            {
                CalculadorNumero calculador = new CalculadorNumero();


                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) / (int)this.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) / this.Valor;
                    propriedade.SetValue(ser, resultado);
                }

                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) / decimal.ToDouble(Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", this.Alvo);
        }
    }

    public class ModDivideNumero : ModNumero
    {
        public override char Operador { get => '-'; }

        public override Ser AplicaModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double) && this.Valor != 0)
            {
                CalculadorNumero calculador = new CalculadorNumero();

                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) / (int)this.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) / this.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) / decimal.ToDouble(Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", this.Alvo);
        }

        public override Ser RemoveModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double) && this.Valor != 0)
            {
                CalculadorNumero calculador = new CalculadorNumero();


                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) * (int)this.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) * this.Valor;
                    propriedade.SetValue(ser, resultado);
                }

                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) * decimal.ToDouble(Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", this.Alvo);
        }
    }

    public class ModZeraNumero : ModNumero
    {
        public override char Operador => '0';
        public decimal ValorAnterior;

        public override Ser AplicaModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);
            this.ValorAnterior = (decimal)propriedade.GetValue(ser);
            propriedade.SetValue(ser, 0);
            return ser;
        }

        public override Ser RemoveModificador(Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(this.Alvo);
            propriedade.SetValue(ser, this.ValorAnterior);
            return ser;
        }
    }

}

