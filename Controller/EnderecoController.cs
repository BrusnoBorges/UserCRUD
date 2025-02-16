﻿using User.Data;
using User.DTO;
using User.Interface;
using User.Model;
using User.Records;
using User.Service;

namespace User.Controller
{
    public static class EnderecoController
    {

        public static void addEnderecoController(this WebApplication app)
        {
            var rout = app.MapGroup(prefix: "CEP");

            rout.MapGet("{CEP}", handler: async (string CEP, IBrasilApiService brasilApiService) =>
            {
                var request = await brasilApiService.GetEnderecoByCEP(CEP);

                var enderecoReturn = new EnderecoDTO() 
                {
                    CEP = request.cep,
                    Rua = request.street,
                    Bairro = request.neighborhood,
                    Cidade = request.city,
                    Estado = request.state,
                };

                return Results.Ok(enderecoReturn);
            });
        }
  }
}