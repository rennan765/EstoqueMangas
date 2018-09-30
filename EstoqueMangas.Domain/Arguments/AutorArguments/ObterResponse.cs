using System;
using System.Collections.Generic;
using System.Linq;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Entities.Join;

namespace EstoqueMangas.Domain.Arguments.AutorArguments
{
    public class ObterResponse : Response
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string NomeCompleto { get; set; }
        public IList<ObterMangasResponse> Mangas { get; set; }
        #endregion

        #region Construtores
        public ObterResponse()
        {
            Mangas = new List<ObterMangasResponse>();
        }
        #endregion 

        #region Métodos
        public static explicit operator ObterResponse(Autor entidade)
        {
            var response = new ObterResponse()
            {
                Id = entidade.Id,
                NomeCompleto = entidade.NomeAutor.ToString(),
                PrimeiroNome = entidade.NomeAutor.PrimeiroNome,
                UltimoNome = entidade.NomeAutor.UltimoNome
            };

            if (!(entidade.Mangas is null) || entidade.Mangas.Count > 0)
            {
                response.Mangas = entidade.Mangas.Select(am => (ObterMangasResponse)am.Manga).ToList();
            }

            return response;
        }
        #endregion
    }
}
