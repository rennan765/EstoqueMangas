﻿using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Resources;
using System;

namespace EstoqueMangas.Domain.Arguments.UsuarioArguments
{
    public class EditarUsuarioResponse : Response
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        #endregion

        #region Métodos
        public static explicit operator EditarUsuarioResponse(Usuario entidade)
        {
            return new EditarUsuarioResponse()
            {
                Id = entidade.Id,
                NomeCompleto = entidade.Nome.ToString(),
                Email = entidade.Email.ToString(),
                Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        } 
        #endregion 
    }
}
