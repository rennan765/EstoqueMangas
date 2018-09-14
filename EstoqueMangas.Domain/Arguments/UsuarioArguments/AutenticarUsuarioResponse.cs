﻿using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Resources;
using System;

namespace EstoqueMangas.Domain.Arguments.UsuarioArguments
{
    public class AutenticarUsuarioResponse : Response
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string Email { get; set; }
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
