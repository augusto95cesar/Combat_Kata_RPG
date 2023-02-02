using System;

namespace KataModel.Entity
{
    public class CampoBatalha
    {
        public CampoBatalha()
        {
            GerarDistanciaEntreProtagonistaEseuInimigo();
        }

        public int DistanciaEntrePersonagemEseuAlvo { get; set; }

        public void SetDistaciaAfavorDoPersongem(Personagem personagem)
        {
            DistanciaEntrePersonagemEseuAlvo = personagem.Alcance;
        }

        private void GerarDistanciaEntreProtagonistaEseuInimigo()
        {
            var numero = new Random().Next(0, 10);
            DistanciaEntrePersonagemEseuAlvo = numero > 5 ? 2 : 20;
        }
    }
}
