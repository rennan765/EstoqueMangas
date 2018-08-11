﻿using System;
using EstoqueMangas.Domain.Arguments.Base;
using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Interfaces.Arguments;
using EstoqueMangas.Domain.Resources;

namespace EstoqueMangas.Domain.Arguments
{
    public class EditarUsuarioResponse : Response, IResponse
    {
        #region Propriedades
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        #endregion

        #region Construtores
        public EditarUsuarioResponse()
        {

        }
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