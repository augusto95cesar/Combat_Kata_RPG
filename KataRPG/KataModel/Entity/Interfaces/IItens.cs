using System;

namespace KataModel.Entity.Interfaces
{
    public interface IItens
    {
        void SofrerDano(int dano);
        int GetPontosVida();
        Guid GetIdentificador();
        bool GetStatusDestruido();
    }
}
