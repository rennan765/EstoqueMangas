using EstoqueMangas.Domain.Arguments.EditoraArguments;
using EstoqueMangas.Domain.Entities.Base;
using EstoqueMangas.Domain.Resources;
using EstoqueMangas.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;

namespace EstoqueMangas.Domain.Entities
{
    public class Editora : Entity
    {
        #region Propriedades
        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; }
        public Telefone Telefone { get; private set; }
        public IList<Manga> Mangas { get; private set; }
        #endregion

        #region Editora
        protected Editora()
        {
            Mangas = new List<Manga>();
        }

        public Editora(string nome, Endereco endereco, Telefone telefone)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Mangas = new List<Manga>();

            Notificar();
        }

        public Editora(string nome, Endereco endereco, Telefone telefone, IList<Manga> mangas)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Mangas = mangas;

            Notificar();
        }
        #endregion

        #region Métodos
        private void Notificar()
        {
            new AddNotifications<Editora>(this)
                .IfNullOrInvalidLength(e => e.Nome, 1, 200, Message.O_CAMPO_X0_DEVE_TER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Nome da editora", "1", "200"));

            if (!(Endereco is null))
            {
                AddNotifications(Endereco);
            }

            if (!(Telefone is null))
            {
                AddNotifications(Telefone);
            }
        }

        public void Editar(EditarEditoraRequest request)
        {
            Nome = request.Nome;
            Endereco = new Endereco(request.EnderecoLogradouro, request.EnderecoNumero, request.EnderecoComplemento, request.EnderecoBairro, request.EnderecoCidade, request.EnderecoEstado, request.EnderecoCep);
            Telefone = new Telefone(request.TelefoneDdd, request.TelefoneNumero);

            new AddNotifications<Editora>(this)
                .IfNullOrInvalidLength(e => e.Nome, 1, 200, Message.O_CAMPO_X0_DEVE_TER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Nome da editora", "1", "200"));

            AddNotifications(Endereco, Telefone);
        }
        #endregion 
    }
}
