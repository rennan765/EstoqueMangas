﻿using System;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Arguments;
using EstoqueMangas.Domain.Resources;

namespace EstoqueMangas.Domain.Arguments.UsuarioArguments
{
    public class AutenticarUsuarioResponse : Response, IResponse
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string Email { get; set; }
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
                Email = entidade.Email.ToString(),
                Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        } 
        #endregion
    }
}
