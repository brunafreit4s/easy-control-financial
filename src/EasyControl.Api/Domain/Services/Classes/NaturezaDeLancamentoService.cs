using AutoMapper;
using EasyControl.Api.Contract.NaturezaLancamento;
using EasyControl.Api.Domain.Repository.Interfaces;
using EasyControl.Api.Domain.Services.Interfaces;

namespace EasyControl.Api.Domain.Services.Classes
{
    public class NaturezaDeLancamentoService : INaturezaDeLancamentoService
    {
        private readonly INaturezaDeLancamentoRepository _naturezaDeLancamentoRepository;
        private readonly IMapper _mapper;

        public NaturezaDeLancamentoService(INaturezaDeLancamentoRepository naturezaDeLancamentoRepository, IMapper mapper){
            _naturezaDeLancamentoRepository = naturezaDeLancamentoRepository;
            _mapper = mapper;
        }

        public Task<NaturezaDeLancamentoResponseContract> Add(NaturezaDeLancamentoRequestContract entidade, long idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id, long idUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NaturezaDeLancamentoResponseContract>> GetAll()
        {
            var usuario = await _naturezaDeLancamentoRepository.GetAll();
            return usuario.Select(usuario => _mapper.Map<NaturezaDeLancamentoResponseContract>(usuario));
        }

        public async Task<NaturezaDeLancamentoResponseContract> GetById(long id)
        {
            var usuario = await _naturezaDeLancamentoRepository.GetById(id);
            return _mapper.Map<NaturezaDeLancamentoResponseContract>(usuario);
        }

        public async Task<NaturezaDeLancamentoResponseContract> GetByIdUsuario(long idUsuario)
        {
            var usuario = await _naturezaDeLancamentoRepository.GetByIdUsuario(idUsuario);
            return _mapper.Map<NaturezaDeLancamentoResponseContract>(usuario);
        }

        public Task<NaturezaDeLancamentoResponseContract> Update(long id, NaturezaDeLancamentoRequestContract entidade, long idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}