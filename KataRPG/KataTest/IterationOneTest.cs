using KataModel.Entity;
using KataModel.Services;
using NUnit.Framework;

namespace KataTest
{
    [TestFixture]
    public class IterationOneTest
    {
       private Personagem _protagonista;
       private Personagem _inimigo;
       private Mapa _campoBatalha;

        [SetUp]
        public void SetUp()
        {
            _protagonista = StartJogoService.CriarPersonagem();
            _inimigo = StartJogoService.CriarPersonagem();
            _campoBatalha = StartJogoService.CriarCampoBatalha();
        }

        /// <summary>
        /// Health, starting at 1000
        /// </summary>
        [Test]
        public void SaudeMil()
        {
            Assert.AreEqual(_protagonista.Saude, 1000);
            Assert.AreEqual(_inimigo.Saude, 1000);
        }

        /// <summary>
        /// Level, starting at 1
        /// </summary>
        [Test]
        public void NivelUm()
        {
            Assert.AreEqual(_protagonista.Nivel, 1);
            Assert.AreEqual(_inimigo.Nivel, 1);
        }

        /// <summary>
        ///  May be Alive or Dead, starting Alive (Alive may be a true/false)
        /// </summary>
        [Test]
        public void EstãoVivo()
        {
            Assert.AreEqual(_protagonista.Vivo, true);
            Assert.AreEqual(_inimigo.Vivo, true);
        }

        /// <summary>
        /// Damage is subtracted from Health
        /// </summary>
        [Test]
        public void Ataque()
        {
            var ataqueInimigo = 200;
            _protagonista.SofrerDano(_campoBatalha,_inimigo, ataqueInimigo);

            var ataque = (_inimigo.Nivel - _protagonista.Nivel) >= 5 ? ataqueInimigo / 2 : (ataqueInimigo * 1.5);

            Assert.AreEqual(_protagonista.Saude, 1000 - ataque);

        }

        /// <summary>
        /// When damage received exceeds current Health, Health becomes 0 and the character dies
        /// </summary>
        [Test]
        public void AtaqueExcedeASaude()
        {
            var ataqueInimigo = 900;
            _protagonista.SofrerDano(_campoBatalha,_inimigo, ataqueInimigo); 

            Assert.AreEqual(_protagonista.Saude, 0);
            Assert.AreEqual(_protagonista.Vivo, false);
        }

        /// <summary>
        /// Dead characters cannot be healed
        /// </summary>
        [Test]
        public void CurarPersonagemMorto()
        {
            var ataqueInimigo = 900;
            _protagonista.SofrerDano(_campoBatalha,_inimigo, ataqueInimigo);

            _protagonista.Curar(500);

            Assert.AreEqual(_protagonista.Saude,0);
            Assert.AreEqual(_protagonista.Vivo, false);
        }

        /// <summary>
        /// Healing cannot raise health above 1000

        /// </summary>
        [Test]
        public void CurarAcimaDeMil()
        {           
            _protagonista.Curar(500);

            Assert.AreEqual(_protagonista.Saude, 1000);
            Assert.AreEqual(_protagonista.Vivo, true);
        }

        /// <summary>
        /// Cura 500
        /// </summary>

        [Test]
        public void CuraQuinhentos()
        {
            var ataqueInimigo = 500;
            _protagonista.SofrerDano(_campoBatalha,_inimigo, ataqueInimigo);

            _protagonista.Curar(700);
 
            Assert.AreEqual(_protagonista.Saude, 950);

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
