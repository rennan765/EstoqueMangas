﻿using System;
using EstoqueMangas.Core.Arguments.Base;
using EstoqueMangas.Core.Entities;
using EstoqueMangas.Core.Interfaces.Arguments;

namespace EstoqueMangas.Core.Arguments
{
    public class AutenticarUsuarioResponse : ResponseBase, IResponse
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        #endregion

        #region Construtores
        public AutenticarUsuarioResponse()
        {

        }
        #endregion 

        #region Métodos
        public static explicit operator AutenticarUsuarioResponse(Usuario entidade)
        {
            return new AutenticarUsuarioResponse()
            {
                Id = entidade.Id,
                NomeCompleto = entidade.Nome.ToString(),
                Mensagem = "Operação realizada com sucesso"
            };
        } 
        #endregion
    }
}