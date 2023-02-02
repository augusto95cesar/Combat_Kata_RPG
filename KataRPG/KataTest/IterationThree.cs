
using KataModel.Entity;
using KataModel.Services;
using NUnit.Framework;

namespace KataTest
{
    [TestFixture]
    public class IterationThree
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
        /// Melee fighters have a range of 2 meters
        /// Ranged fighters have a range of 20 meters.
        /// </summary>
        [Test]
        public void AtaqueDoInimigoAoProtagonista()
        {
            _protagonista.SofrerDano(_campoBatalha, _inimigo, 900);

            if (_campoBatalha.DistanciaEntrePersonagemEseuAlvo == _inimigo.Alcance)
            {
                Assert.AreEqual(_protagonista.Saude, 0);
                Assert.AreEqual(_protagonista.Vivo, false);
            }
            else
            {
                Assert.AreEqual(_protagonista.Saude, 1000);
                Assert.AreEqual(_protagonista.Vivo, true);
            }
        }

        /// <summary>
        /// Melee fighters have a range of 2 meters
        /// Ranged fighters have a range of 20 meters.
        /// </summary>
        [Test]
        public void AtaqueDoProtagonistaAoInimigo()
        {
            _inimigo.SofrerDano(_campoBatalha, _protagonista, 900);

            if (_campoBatalha.DistanciaEntrePersonagemEseuAlvo == _protagonista.Alcance)
            {
                Assert.AreEqual(_inimigo.Saude, 0);
                Assert.AreEqual(_inimigo.Vivo, false);
            }
            else
            {
                Assert.AreEqual(_inimigo.Saude, 1000);
                Assert.AreEqual(_inimigo.Vivo, true);
            }

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
