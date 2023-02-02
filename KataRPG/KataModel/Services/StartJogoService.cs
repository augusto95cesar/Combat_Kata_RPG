using KataModel.Entity;

namespace KataModel.Services
{
    public static class StartJogoService
    {
        public static Personagem CriarPersonagem() 
        { 
            return new Personagem();
        }
        public static CampoBatalha CriarCampoBatalha () 
        { 
            return new CampoBatalha();
        }
    }
}
