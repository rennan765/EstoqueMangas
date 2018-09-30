using System;
using EstoqueMangas.Domain.Entities;

namespace EstoqueMangas.Domain.Arguments.AutorArguments
{
    public class ObterAutorMangaResponse
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public int AnoLancamento { get; set; }
        public Guid EditoraId { get; private set; }
        public string EditoraNome { get; private set; }
        #endregion

        #region Métodos
        public static explicit operator ObterAutorMangaResponse(Manga entidade)
        {
            return new ObterAutorMangaResponse()
            {
                Id = entidade.Id,
                Titulo = entidade.Titulo,
                AnoLancamento = entidade.AnoLancamento,
                EditoraId = entidade.EditoraId,
                EditoraNome = !string.IsNullOrEmpty(entidade.Editora.Nome) ? entidade.Editora.Nome : ""
            };
        }
        #endregion
    }
}
