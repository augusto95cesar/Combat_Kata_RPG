using KataModel.Entity;
using KataModel.Enums;
using KataModel.Services;
using NUnit.Framework;

namespace KataTest
{
    [TestFixture]
    public class IterationFourTest
    {
        private Personagem _protagonista;
        private Personagem _companheiro;
        private Personagem _inimigo;
        private CampoBatalha _campoBatalha;

        [SetUp]
        public void SetUp()
        {
            _protagonista = StartJogoService.CriarPersonagem();
            _companheiro = StartJogoService.CriarPersonagem();
            _inimigo = StartJogoService.CriarPersonagem();
            _campoBatalha = StartJogoService.CriarCampoBatalha();
        }

        /// <summary>
        /// Newly created Characters belong to no Faction
        /// </summary>
        [Test]
        public void NenhumaFaction()
        { 
            Assert.AreEqual(_protagonista.GetListFaccoes().Count, 0); 
        }

        /// <summary>
        ///  Characters may belong to one or more Factions.
        /// </summary>
        [Test]
        public void UmaFaction()
        { 
            _protagonista.SetFaccao(FaccoesPersonagem.Faccao01);
            Assert.AreEqual(_protagonista.GetListFaccoes().Count, 1);
        }

        /// <summary>
        ///  Characters may belong to one or more Factions.
        /// </summary>
        [Test]
        public void DuasFaction()
        {
            _protagonista.SetFaccao(FaccoesPersonagem.Faccao01);
            _protagonista.SetFaccao(FaccoesPersonagem.Faccao02);
            Assert.AreEqual(_protagonista.GetListFaccoes().Count, 2);
        }

        /// <summary>
        ///  A Character may Join or Leave one or more Factions.
        /// </summary>
        [Test]
        public void SairFaction()
        {
            _protagonista.SetFaccao(FaccoesPersonagem.Faccao01);
            Assert.AreEqual(_protagonista.GetListFaccoes().Count,1);

            _protagonista.DeleteFaccao(FaccoesPersonagem.Faccao01);
            Assert.AreEqual(_protagonista.GetListFaccoes().Count,0);
        }

        /// <summary>
        ///  Players belonging to the same Faction are considered Allies
        /// </summary>
        [Test]
        public void VerificarAlianca()
        {
            _protagonista.SetFaccao(FaccoesPersonagem.Faccao01);
            _companheiro.SetFaccao(FaccoesPersonagem.Faccao01);

            Assert.IsTrue(_protagonista.VerificarAlianca(_companheiro));
            Assert.IsTrue(_companheiro.VerificarAlianca(_protagonista));
        }


        /// <summary>
        ///  Allies cannot Deal Damage to one another.
        /// </summary>
        [Test]
        public void VerificarAtaqueAlidadoSofreuDano()
        {
            _protagonista.SetFaccao(FaccoesPersonagem.Faccao01);
            _companheiro.SetFaccao(FaccoesPersonagem.Faccao01);
            _campoBatalha.SetDistaciaAfavorDoPersongem(_companheiro);

            _protagonista.SofrerDano(_campoBatalha, _companheiro, 900);

            Assert.AreEqual(_protagonista.Saude, 1000);
        }

        /// <summary>
        /// Allies can Heal one another
        /// </summary>
        [Test]
        public void CurarAlidado()
        {
            _protagonista.SetFaccao(FaccoesPersonagem.Faccao01);
            _companheiro.SetFaccao(FaccoesPersonagem.Faccao01);

            _campoBatalha.SetDistaciaAfavorDoPersongem(_inimigo);

            _protagonista.SofrerDano(_campoBatalha, _inimigo, 200);

            _protagonista.ReceberAjudaAliado(_companheiro, 200);

            Assert.AreEqual(_protagonista.Saude, 900);
            Assert.AreEqual(_protagonista.Vivo, true);
        }

        [TearDown]
        public void TearDown()
        {
            _protagonista = null;
            _companheiro = null;
            _inimigo = null;
            _campoBatalha = null;
        }
    }
}
