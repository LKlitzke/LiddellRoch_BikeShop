using LiddellRoch.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LiddellRoch.Application.Services.Interfaces
{
    public interface IAvaliacaoService
    {
        List<Avaliacao> GetAvaliacoesByBikeId(int bikeId);
        Avaliacao GetAvaliacaoById(int id);
        bool AvaliacaoExists(int bikeHeaderId);
        double GetMediaAvaliacoes(int bikeId);
        void CreateAvaliacao(Avaliacao avaliacao);
        void UpdateAvaliacao(Avaliacao avaliacao);
        bool DeleteAvaliacao(int id);
        IEnumerable<Avaliacao> GetAll();
    }
}