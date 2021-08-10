using System.Data;
using Pets.Application.Repositories.VaccineContext;
using Pets.Domain.Entities.VaccineContext;
using Dapper;
using Pets.Application.AbsFactory;
using System.Threading.Tasks;
using Pets.Application.Output.Requests.VaccineRequest;
using System;
using Pets.Application.Output.Results;
using Pets.Application.Output.DTO;
using System.Collections.Generic;

namespace Pets.Infrastructure.Repositories.VaccineContext
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly IDbConnection _connection;
        public VaccineRepository(AbsDBFactory factory)
        {
            _connection = factory.GetSqlConnection().CreateConnection();
        }

        public async Task<VaccineRequest> GetVaccinesByPetIdAsync(Guid petId)
        {
            var vaccineRequest = new VaccineRequest();
            try
            {
                using (_connection)
                {
                    var query = Queries.VaccineQueries.GetVaccineByPetId(petId);
                    vaccineRequest.Vaccines = await _connection.QueryAsync<VaccineDTO>(query[0].ToString(), query[1]) as List<VaccineDTO>;
                    vaccineRequest.Result = (vaccineRequest.Vaccines as List<VaccineDTO>).Count != 0 ? new Result(200, "Requisição realizada com sucesso", true)
                    : new Result(404, "Nenhuma vacina encontrada", false);
                    return vaccineRequest;
                }
            }
            catch (Exception ex)
            {
                vaccineRequest.Result = new Result(500, $"Erro interno do servidor, detalhes: {ex.Message}", false);
            }
            return vaccineRequest;
        }

        public void InsertVaccine(Vaccine vaccine)
        {
            using (_connection)
            {
                var query = Queries.VaccineQueries.InsertVaccine(vaccine);
                _connection.Execute(query[0].ToString(), query[1]);
            }
        }
    }
}