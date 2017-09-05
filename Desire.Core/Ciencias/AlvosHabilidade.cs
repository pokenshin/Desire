using System;
using System.Collections.Generic;

namespace Desire.Core.Ciencias
{
    public interface IAlvoHabilidade
    {
        int Id { get;}
        string Nome { get;}
    }

    /// <summary>
    /// Somente si mesmo.
    /// </summary>
    public class AlvoEgo : IAlvoHabilidade
    {
        public int Id => 1;
        public string Nome => "Ego";
    }

    /// <summary>
    /// Necessário Contato com o Alvo.
    /// </summary>
    public class AlvoPonto : IAlvoHabilidade
    {
        public int Id => 2;
        public string Nome => "Ponto";
        public Ser Alvo { get; set; }
    }

    /// <summary>
    /// Se desenvolve em linha até certo ponto, podendo ser teleguiado.
    /// </summary>
    public class AlvoLinha : IAlvoHabilidade
    {
        public int Id => 3;
        public string Nome => "Linha";
        public ValorMag DistanciaMaxima { get; set; }
        public ValorMag Velocidade { get; set; }
        public Ser Alvo { get; set; }
    }

    /// <summary>
    /// Afeta area declarada.
    /// </summary>
    public class AlvoCirculo : IAlvoHabilidade
    {
        public int Id => 4;
        public string Nome => "Circulo";
        public ValorMag RaioMaximo { get; set; }
        public List<Ser> Alvos { get; set; }
    }

    /// <summary>
    /// Pula de alvo em alvo declarado. Se um resistir, a cadeia se quebra			
    /// </summary>
    public class AlvoVetor : IAlvoHabilidade
    {
        public int Id => 5;
        public string Nome => "Vetor";
        public ValorMag PulosMaximos { get; set; }
        public List<Ser> Alvos { get; set; }
    }

    /// <summary>
    /// Afeta todos os alvos declarados na área.			
    /// </summary>
    public class AlvoLosango : IAlvoHabilidade
    {
        public int Id => 6;
        public string Nome => "Losango";
        public ValorMag RaioMaximo { get; set; }
        public List<Ser> AlvosDeclarados { get; set; }
    }

    /// <summary>
    /// Afeta diretamente o alvo declarado, sem viajar			.			
    /// </summary>
    public class AlvoTriangulo : IAlvoHabilidade
    {
        public int Id => 7;
        public string Nome => "Triângulo";
        public Ser AlvoDeclarado { get; set; }
    }

    /// <summary>
    /// Afeta baseado em regras pre-definidas			.			
    /// </summary>
    public class AlvoElipse : IAlvoHabilidade
    {
        public int Id => 8;
        public string Nome => "Elipse";
        public string Regras { get; set; }
        public List<Ser> AlvosAfetados { get; set; }
    }
}