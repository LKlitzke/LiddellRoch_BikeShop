using LiddellRoch.Application.Services.Interfaces;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Application.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AvaliacaoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Avaliacao> GetAvaliacoesByBikeId(int bikeId)
        {
            return _unitOfWork.Avaliacao.GetAll(u => u.BicicletaId == bikeId).ToList();
        }

        public Avaliacao GetAvaliacaoById(int id)
        {
            return _unitOfWork.Avaliacao.GetFirstOrDefault(u => u.Id == id);
        }

        public bool AvaliacaoExists(int bikeHeaderId)
        {
            return _unitOfWork.Avaliacao.GetFirstOrDefault(e => e.PedidoHeaderId == bikeHeaderId) != null;
        }

        public double GetMediaAvaliacoes(int bikeId)
        {
            var avaliacoes = GetAvaliacoesByBikeId(bikeId);
            return avaliacoes.Sum(e => e.AvaliacaoCompra) / avaliacoes.Count;
        }

        public void CreateAvaliacao(Avaliacao avaliacao)
        {
            _unitOfWork.Avaliacao.Add(avaliacao);
            _unitOfWork.Save();
        }
        public void UpdateAvaliacao(Avaliacao avaliacao)
        {
            _unitOfWork.Avaliacao.Update(avaliacao);
            _unitOfWork.Save();
        }

        public bool DeleteAvaliacao(int id)
        {
            try
            {
                Avaliacao categoria = GetAvaliacaoById(id);

                _unitOfWork.Avaliacao.Remove(categoria);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Avaliacao> GetAll()
        {
            return _unitOfWork.Avaliacao.GetAll().ToList();
        }
    }
}
