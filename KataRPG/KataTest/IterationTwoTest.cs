using KataModel.Entity;
using KataModel.Services;
using NUnit.Framework; 

namespace KataTest
{
    [TestFixture]
    public class IterationTwoTest
    {
        private Personagem _protagonista;
        private Personagem _inimigo;
        private CampoBatalha _campoBatalha;

        [SetUp]
        public void SetUp()
        {
            _protagonista = StartJogoService.CriarPersonagem();
            _inimigo = StartJogoService.CriarPersonagem();
            _campoBatalha = StartJogoService.CriarCampoBatalha();
        }

        /// <summary>
        /// A Character cannot Deal Damage to itself
        /// </summary>
        [Test]
        public void NaoPodeAtacarSiMesmo()
        {
            _protagonista.SofrerDano(_campoBatalha,_protagonista, 900);
            
            Assert.AreEqual(_protagonista.Saude, 1000);
            Assert.AreEqual(_protagonista.Vivo, true);
        }

        /// <summary>
        /// A Character can only Heal itself.
        /// </summary>
        [Test]
        public void NaoPodeCurarOInimigo()
        {
            _inimigo.SofrerDano(_campoBatalha,_protagonista, 200);
            Assert.AreEqual(_inimigo.Saude, 700);

            _inimigo.Curar(300);

            Assert.AreEqual(_inimigo.Saude, 1000);
            Assert.AreEqual(_inimigo.Vivo, true);
        }

        /// <summary>
        /// When dealing damage:
        /// ❍ If the target is 5 or more Levels above the attacker, Damage is reduced by 50%
        /// </summary>
        [Test]
        public void InimigoNivel10ProtagonistaNivel2()
        {
            _protagonista.Nivel = 2;
            _inimigo.Nivel = 10;

            _protagonista.SofrerDano(_campoBatalha,_inimigo, 200);

            Assert.AreEqual(_protagonista.Saude, 900);
        }

        /// <summary>
        /// When dealing damage:
        /// If the target is 5 or more levels below the attacker, Damage is increased by 50%
        /// </summary>
        [Test]
        public void InimigoNivel2ProtagonistaNivel10()
        {
            _protagonista.Nivel = 10;
            _inimigo.Nivel = 2;

            _protagonista.SofrerDano(_campoBatalha,_inimigo, 200);

            Assert.AreEqual(_protagonista.Saude, 700);
        }

        [TearDown]
        public void TearDown()
        {
            _protagonista = null;
            _inimigo = null;
            _campoBatalha = null;
        }
    }
}
