using AutoMapper;
using EasyControl.Api.Contract.NaturezaLancamento;
using EasyControl.Api.Domain.Models;
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

        public async Task<NaturezaDeLancamentoResponseContract> Add(NaturezaDeLancamentoRequestContract entidade, long idUsuario)
        {
            NaturezaDeLancamento naturezaDeLancamento = _mapper.Map<NaturezaDeLancamento>(entidade);
            
            naturezaDeLancamento.DataCadastro = DateTime.Now;
            naturezaDeLancamento.IdUsuario = idUsuario;
            naturezaDeLancamento = await _naturezaDeLancamentoRepository.Add(naturezaDeLancamento);

            return _mapper.Map<NaturezaDeLancamentoResponseContract>(naturezaDeLancamento);
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

        public async Task<NaturezaDeLancamentoResponseContract> GetByIdUsuario(long id, long idUsuario)
        {
            var usuario = await _naturezaDeLancamentoRepository.GetByIdUsuario(id, idUsuario);
            return _mapper.Map<NaturezaDeLancamentoResponseContract>(usuario);
        }

        public async Task<NaturezaDeLancamentoResponseContract> Update(long id, NaturezaDeLancamentoRequestContract entidade, long idUsuario)
        {
            _ = await _naturezaDeLancamentoRepository.GetByIdUsuario(id, idUsuario) ?? throw new Exception("Natureza de Lançamento não encontrada para atualização!");

            NaturezaDeLancamento naturezaDeLancamento = _mapper.Map<NaturezaDeLancamento>(entidade);
            
            naturezaDeLancamento.IdUsuario = idUsuario;
            naturezaDeLancamento = await _naturezaDeLancamentoRepository.Update(naturezaDeLancamento);

            return _mapper.Map<NaturezaDeLancamentoResponseContract>(naturezaDeLancamento);
        }

        public async Task Delete(long id, long idUsuario)
        {
            var entidade = await _naturezaDeLancamentoRepository.GetByIdUsuario(id, idUsuario) ?? throw new Exception("Natureza de Lançamento não encontrada para atualização!");
            NaturezaDeLancamento natureza = _mapper.Map<NaturezaDeLancamento>(entidade);
            await _naturezaDeLancamentoRepository.Delete(natureza);
        }
    }
}