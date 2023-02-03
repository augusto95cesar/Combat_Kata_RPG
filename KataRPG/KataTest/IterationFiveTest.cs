using KataModel.Entity.Interfaces;
using KataModel.Enums;
using KataModel.Services;
using NUnit.Framework;

namespace KataTest
{
    [TestFixture]
    internal class IterationFiveTest
    {
      
        private FactoryItens _fabricaItens;

        [SetUp]
        public void SetUp()
        {          
            _fabricaItens = new FactoryItens();
        }

        
        [Test]
        public void CriarItemArvore()
        {
            IItens arvore = _fabricaItens.Escolher_Item(TipoItens.Arvore);            
            Assert.AreEqual(arvore.GetPontosVida(), 2000);
        }

        [Test]
        public void CriarItemMesar()
        {
            IItens mesa = _fabricaItens.Escolher_Item(TipoItens.Mesa);
            Assert.AreNotEqual(mesa.GetPontosVida(), 2000);
            Assert.AreEqual(mesa.GetPontosVida(), 500);
        }

        [Test]
        public void DestruirMesa()
        {
            IItens mesa = _fabricaItens.Escolher_Item(TipoItens.Mesa);

            mesa.SofrerDano(600);
           
            Assert.AreEqual(mesa.GetPontosVida(), 0);
            Assert.IsTrue(mesa.GetStatusDestruido());
        }

        [Test]
        public void DanificarItemMesarDano100()
        {
            IItens mesa = _fabricaItens.Escolher_Item(TipoItens.Mesa);

            mesa.SofrerDano(100); 
            Assert.AreEqual(mesa.GetPontosVida(), 400);
            Assert.IsFalse(mesa.GetStatusDestruido());
        }

        [TearDown]
        public void TearDown()
        {          
            _fabricaItens = null;
        }
    }
}
