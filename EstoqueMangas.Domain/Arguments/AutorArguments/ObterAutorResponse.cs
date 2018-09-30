using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueMangas.Domain.Arguments.AutorArguments
{
    public class ObterAutorResponse : Response
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string NomeCompleto { get; set; }
        public IList<ObterAutorMangaResponse> Mangas { get; set; }
        #endregion

        #region Construtores
        public ObterAutorResponse()
        {
            Mangas = new List<ObterAutorMangaResponse>();
        }
        #endregion 

        #region Métodos
        public static explicit operator ObterAutorResponse(Autor entidade)
        {
            var response = new ObterAutorResponse()
            {
                Id = entidade.Id,
                NomeCompleto = entidade.NomeAutor.ToString(),
                PrimeiroNome = entidade.NomeAutor.PrimeiroNome,
                UltimoNome = entidade.NomeAutor.UltimoNome
            };

            if (!(entidade.Mangas is null) || entidade.Mangas.Count > 0)
            {
                response.Mangas = entidade.Mangas.Select(am => (ObterAutorMangaResponse)am.Manga).ToList();
            }

            return response;
        }
        #endregion
    }
}
