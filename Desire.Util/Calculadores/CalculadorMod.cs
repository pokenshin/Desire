using Desire.Core;
using Desire.Core.Modificadores;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Desire.Util.Calculadores
{
    public class CalculadorMod
    {
        //ModAdicionaHabilidade
        public Ser AplicaModificador(ModAdicionaHabilidade modificador, Ser ser)
        {
            if (!ser.Habilidades.Contains(modificador.Alvo))
                ser.Habilidades.Add(modificador.Alvo);

            return ser;
        }
        public Ser RemoveModificador(ModAdicionaHabilidade mod, Ser ser)
        {
            if (ser.Habilidades.Contains(mod.Alvo))
                ser.Habilidades.Remove(mod.Alvo);

            return ser;
        }

        //ModRemoveHabilidade
        public Ser AplicaModificador(ModRemoveHabilidade mod, Ser ser)
        {
            if (ser.Habilidades.Contains(mod.Alvo))
                ser.Habilidades.Remove(mod.Alvo);

            return ser;
        }
        public Ser RemoveModificador(ModRemoveHabilidade mod, Ser ser)
        {
            if (!ser.Habilidades.Contains(mod.Alvo))
                ser.Habilidades.Add(mod.Alvo);

            return ser;
        }

        //ModSomaNumero
        public Ser AplicaModificador(ModSomaNumero mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double))
            {
                CalculadorNumero calculador = new CalculadorNumero();


                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) + (int)mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) + mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }

                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) + decimal.ToDouble(mod.Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", mod.Alvo);
        }
        public Ser RemoveModificador(ModSomaNumero mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double))
            {
                CalculadorNumero calculador = new CalculadorNumero();


                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) - (int)mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) - mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }

                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) - decimal.ToDouble(mod.Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", mod.Alvo);
        }

        //ModSubtraiNumero
        public Ser AplicaModificador(ModSubtraiNumero mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double))
            {
                CalculadorNumero calculador = new CalculadorNumero();


                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) - (int)mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) - mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) - decimal.ToDouble(mod.Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", mod.Alvo);
        }
        public Ser RemoveModificador(ModSubtraiNumero mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double))
            {
                CalculadorNumero calculador = new CalculadorNumero();


                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) + (int)mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) + mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }

                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) + decimal.ToDouble(mod.Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", mod.Alvo);
        }

        //ModMultiplicaNumero
        public Ser AplicaModificador(ModMultiplicaNumero mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double) && mod.Valor != 0)
            {
                CalculadorNumero calculador = new CalculadorNumero();

                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) * (int)mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) * mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) * decimal.ToDouble(mod.Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", mod.Alvo);
        }
        public Ser RemoveModificador(ModMultiplicaNumero mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double) && mod.Valor != 0)
            {
                CalculadorNumero calculador = new CalculadorNumero();


                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) / (int)mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) / mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }

                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) / decimal.ToDouble(mod.Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", mod.Alvo);
        }

        //ModDivideNumero
        public Ser AplicaModificador(ModDivideNumero mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double) && mod.Valor != 0)
            {
                CalculadorNumero calculador = new CalculadorNumero();

                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) / (int)mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) / mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) / decimal.ToDouble(mod.Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", mod.Alvo);
        }
        public Ser RemoveModificador(ModDivideNumero mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(int) || propriedade.PropertyType == typeof(decimal) || propriedade.PropertyType == typeof(double) && mod.Valor != 0)
            {
                CalculadorNumero calculador = new CalculadorNumero();


                if (propriedade.PropertyType == typeof(int))
                {
                    int resultado = 0;
                    resultado = (int)propriedade.GetValue(ser, null) * (int)mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }
                else if (propriedade.PropertyType == typeof(decimal))
                {
                    decimal resultado = 0;
                    resultado = (decimal)propriedade.GetValue(ser, null) * mod.Valor;
                    propriedade.SetValue(ser, resultado);
                }

                else
                {
                    double resultado = 0;
                    resultado = (double)propriedade.GetValue(ser, null) * decimal.ToDouble(mod.Valor);
                    propriedade.SetValue(ser, resultado);
                }
                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é um int, decimal ou double.", mod.Alvo);
        }

        //ModZeraNumero
        public Ser AplicaModificador(ModZeraNumero mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);
            mod.ValorAnterior = (decimal)propriedade.GetValue(ser);
            propriedade.SetValue(ser, 0);
            return ser;
        }
        public Ser RemoveModificador(ModZeraNumero mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);
            propriedade.SetValue(ser, mod.ValorAnterior);
            return ser;
        }

        //ModAdicionaPericia
        public Ser AplicaModificador(ModAdicionaPericia mod, Ser ser)
        {
            if (!ser.Pericias.Contains(mod.Alvo))
                ser.Pericias.Add(mod.Alvo);
            return ser;
        }
        public Ser RemoveModificador(ModAdicionaPericia mod, Ser ser)
        {
            if (ser.Pericias.Contains(mod.Alvo))
                ser.Pericias.Remove(mod.Alvo);
            return ser;
        }

        //ModRemovePericia
        public Ser AplicaModificador(ModRemovePericia mod, Ser ser)
        {
            if (ser.Pericias.Contains(mod.Alvo))
                ser.Pericias.Remove(mod.Alvo);
            return ser;
        }
        public Ser RemoveModificador(ModRemovePericia mod, Ser ser)
        {
            if (!ser.Pericias.Contains(mod.Alvo))
                ser.Pericias.Add(mod.Alvo);
            return ser;
        }

        //ModSomaValorMag
        public Ser AplicaModificador(ModSomaValorMag mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.SomaValorMag((ValorMag)propriedade.GetValue(ser, null), mod.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", mod.Alvo);
        }
        public Ser RemoveModificador(ModSomaValorMag mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.SubtraiValorMag((ValorMag)propriedade.GetValue(ser, null), mod.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", mod.Alvo);
        }

        //ModSubtraiValorMag
        public Ser AplicaModificador(ModSubtraiValorMag mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.SubtraiValorMag((ValorMag)propriedade.GetValue(ser, null), mod.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", mod.Alvo);
        }
        public Ser RemoveModificador(ModSubtraiValorMag mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.SomaValorMag((ValorMag)propriedade.GetValue(ser, null), mod.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", mod.Alvo);
        }

        //ModMultiplicaValorMag
        public Ser AplicaModificador(ModMultiplicaValorMag mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.MultiplicaValorMag((ValorMag)propriedade.GetValue(ser, null), mod.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", mod.Alvo);
        }
        public Ser RemoveModificador(ModMultiplicaValorMag mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.MultiplicaValorMag((ValorMag)propriedade.GetValue(ser, null), mod.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", mod.Alvo);
        }

        //ModDivideValorMag
        public Ser AplicaModificador(ModDivideValorMag mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.MultiplicaValorMag((ValorMag)propriedade.GetValue(ser, null), mod.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", mod.Alvo);
        }
        public Ser RemoveModificador(ModDivideValorMag mod, Ser ser)
        {
            PropertyInfo propriedade = ser.GetType().GetProperty(mod.Alvo);

            if (propriedade.PropertyType == typeof(ValorMag))
            {
                CalculadorNumero calculador = new CalculadorNumero();
                ValorMag resultado = new ValorMag();

                resultado = calculador.MultiplicaValorMag((ValorMag)propriedade.GetValue(ser, null), mod.Valor);

                propriedade.SetValue(ser, resultado);

                return ser;
            }
            else
                throw new System.ArgumentException("Propriedade não é ValorMag.", mod.Alvo);
        }
    }
}
