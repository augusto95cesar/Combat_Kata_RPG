using KataModel.Enums;
using System;

namespace KataModel.Entity
{
    public class Personagem
    {
        private Guid Id;
        public Personagem()
        {
            Id = Guid.NewGuid(); 
            Saude = 1000;
            Nivel = 1;
            Vivo = true;
            DefinirAlcance();
        }
        public double Saude { get; set; }
        public int Nivel { get; set; }
        public TipoPersonagem TipoPersonagem { get; set; }
        public int Alcance { get; set; }
        public bool Vivo { get; set; }       
        public Guid GetId()
        {
            return Id;
        }

        private void DefinirAlcance()
        {
            var numero = new Random().Next(0,10);
            Alcance = numero > 5 ? 2 : 20;
            TipoPersonagem = numero > 5 ? TipoPersonagem.Melee : TipoPersonagem.Ranged;
        }

        public  void SofrerDano(CampoBatalha campoBatalha, Personagem inimigo, int ataque)
        {

            if (Saude > 0
                &&  GetId() != inimigo.GetId()
                && inimigo.Alcance == campoBatalha.DistanciaEntrePersonagemEseuAlvo                
                )
            {
                 Saude -= (inimigo.Nivel - Nivel) >= 5 ? ataque / 2 : (ataque * 1.5);
            }

            if (Saude <= 0)
            {
                Saude = 0;
                Vivo = false;
            }
        }

        public void Curar(int cura)
        {
            if (Vivo && (cura + Saude) <= 1000)
            {
                Saude += cura;
            }
        } 
    }
}
