using KataModel.Entity.Interfaces;
using System;

namespace KataModel.Entity
{
    public class Item : IItens
    {
        protected Guid Id  = Guid.NewGuid();
        protected int PontosDeVida { get; set; }
        protected bool Destruido { get; set; } = false;

        public Guid GetIdentificador()
        {
            return Id;
        }

        public int GetPontosVida()
        {
            return PontosDeVida;
        }

        public void SofrerDano(int dano)
        {
            if((PontosDeVida - dano) > 0)
            {
                PontosDeVida -= dano;
            }
            else
            {
                PontosDeVida = 0;
                Destruido = true;
            }
        }

        public bool GetStatusDestruido()
        {
            return Destruido;
        }
    }
}
