using System.Collections.Generic;
using Services.Dtos;
using Services.ServicesAbstractions;

namespace Services.ConcreteServices
{
    public class ContactService:IContactService
    {
        //  a linha 8 é a "assinatura do metodo/função" e da linha 9 até a 24, é o   "corpo da função/metodo"
        public string Create(Contact contato)
        {
            if (contato.Nome != "Jubiscleiton" && contato.Idade < 100)
            {
                var novoContato = new Contact()
                {
                    Id = contato.Id,
                    Nome = contato.Nome,
                    Idade = contato.Idade,
                };
                return "novoContato. criado";
            }
            else
            {
                return "contato não criado!";
            }
        }

        public List<ContactResponseDto> GetAll(string senha)
        {
            var listaDeContatos = new List<Contact>()
            {
                new Contact() { Id = 1, Nome = "Professor Davy", Idade = 24, SenhaDoCartao = "123cba" },
                new Contact() { Id = 2, Nome = "Tio Julio", Idade = 46, SenhaDoCartao = "321abc" }
            };

            if (senha == "123passatudo")
            {
                var listaDeDtosDeContatos=new List<ContactResponseDto>();

                foreach ( var contato in listaDeContatos)
                {
                    listaDeDtosDeContatos.Add(
                        new ContactResponseDto()
                        {
                            Id = contato.Id,
                            Nome = contato.Nome,
                            Idade = contato.Idade
                        }
                    );
                }
                return listaDeDtosDeContatos;
            }
            else
            {
                return new List<ContactResponseDto>();
            }
        }

        public string Update(Contact contato)
        {
            var contatoVazio = new Contact();
            if (contato.Nome.Length > 0 && contato.Idade > 0)
            {
                contatoVazio.Id = contato.Id;
                contatoVazio.Nome = contato.Nome;
                contatoVazio.Idade = contato.Idade;
                return "Contato Atualizado";
            }
            else
            {
                return "Contato não atualizado";
            }
        }
       
        //abaixo  O Metodo abaixo é o DELETE
        public string Delete(Contact contato)
        {
            var contatoParaDeletar = new Contact() { Id = 1, Nome = "João deletado", Idade = 35 };
            if (contato.Nome == contatoParaDeletar.Nome && contato.Idade == contatoParaDeletar.Idade)
            {
                contatoParaDeletar = null;
                return "contato apagado";
            }
            else
            {
                return "Contato não foi apagado";
            }

        }

    }
}