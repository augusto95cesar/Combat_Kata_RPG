using KataModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataModel.Entity
{
    public class Personagem
    {
        private Guid Id;
        private List<FaccoesPersonagem> _faccoes { get; set; }

        public Personagem()
        {
            Id = Guid.NewGuid();
            Saude = 1000;
            Nivel = 1;
            Vivo = true;
            DefinirAlcance();
            _faccoes = new List<FaccoesPersonagem>();
        }
        public double Saude { get; set; }
        public int Nivel { get; set; }
        public TipoPersonagem TipoPersonagem { get; set; }
        public int Alcance { get; set; }
        public bool Vivo { get; set; }
        public Guid GetId()
        {
            return Id;
        }
        private void DefinirAlcance()
        {
            var numero = new Random().Next(0, 10);
            Alcance = numero > 5 ? 2 : 20;
            TipoPersonagem = numero > 5 ? TipoPersonagem.Melee : TipoPersonagem.Ranged;
        }
        public void SofrerDano(Mapa campoBatalha, Personagem inimigo, int ataque)
        {
            if (Saude > 0
                && GetId() != inimigo.GetId()
                && inimigo.Alcance == campoBatalha.DistanciaEntrePersonagemEseuAlvo
                && !_faccoes.Intersect(inimigo._faccoes).Any()
                )
            {
                Saude -= (inimigo.Nivel - Nivel) >= 5 ? ataque / 2 : (ataque * 1.5);
            }

            if (Saude <= 0)
            {
                Saude = 0;
                Vivo = false;
            }
        }
        public void Curar(int cura)
        {
            if (Vivo && (cura + Saude) <= 1000)
            {
                Saude += cura;
            }
        }
        public void ReceberAjudaAliado(Personagem aliado, int cura)
        {
            if (Vivo && (cura + Saude) <= 1000
                && _faccoes.Intersect(aliado._faccoes).Any())
            {
                Saude += cura;
            }
        }
        public List<FaccoesPersonagem> GetListFaccoes()
        {
            return _faccoes;
        }
        public void SetFaccao(FaccoesPersonagem faccao)
        {
            if (!_faccoes.Contains(faccao))
            {
                _faccoes.Add(faccao);
            }
        }
        public void DeleteFaccao(FaccoesPersonagem faccao)
        {
            if (_faccoes.Contains(faccao))
            {
                _faccoes.Remove(faccao);
            }
        }

        public bool VerificarAlianca(Personagem aliado)
        {
            return _faccoes.Intersect(aliado._faccoes).Any();
        }
    }
}