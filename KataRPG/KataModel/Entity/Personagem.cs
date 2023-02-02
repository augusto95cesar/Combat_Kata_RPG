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
        }
        public double Saude { get; set; }
        public int Nivel { get; set; }
        public bool Vivo { get; set; }       
        public Guid GetId()
        {
            return Id;
        }     
    }
}
