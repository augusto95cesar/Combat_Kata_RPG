using KataModel.Entity.Interfaces;
using KataModel.Entity.Itens;
using KataModel.Enums;

namespace KataModel.Services
{
    public class FactoryItens
    {
        public IItens Escolher_Item(TipoItens item)
        {
            switch (item)
            {
                case TipoItens.Arvore: return new Arvore();
                case TipoItens.Mesa: return new Mesa();
                case TipoItens.Bau: return new Bau();
                default: return null;
            }
        }
    }
}