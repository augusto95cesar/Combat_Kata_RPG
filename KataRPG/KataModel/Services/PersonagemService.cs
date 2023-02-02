using KataModel.Entity;

namespace KataModel.Services
{
    public static class PersonagemService
    {
        public static Personagem CriarPersonagem() 
        { 
            return new Personagem();
        }

        public static void Dano(this Personagem personagem, Personagem inimigo, int ataque)
        {

            if (personagem.Saude > 0 
                && personagem.GetId() != inimigo.GetId())
            {
                personagem.Saude -= (inimigo.Nivel - personagem.Nivel ) >= 5 ? ataque / 2 :  (ataque * 1.5);
            }

            if (personagem.Saude <= 0)
            {
                personagem.Saude = 0;
                personagem.Vivo = false;
            }
        }

        public static void Curar(this Personagem personagem,  int cura)
        {
            if (personagem.Vivo 
                && (cura + personagem.Saude) <= 1000 
                && personagem.GetId() == personagem.GetId() 
                )
            {
                personagem.Saude += cura;
            }
        }

    }
}
