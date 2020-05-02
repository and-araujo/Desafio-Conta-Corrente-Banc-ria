using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Banco.App.Models;
using Banco.Business.Interfaces;
using Banco.App.ViewModels;
using AutoMapper;
using Banco.Business.Models;
using Banco.App.Extensions;
using Banco.Business.Models.Base;

namespace Banco.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContaCorrenteService _contaCorrenteService;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IContaCorrenteTransacaoRepository _contaCorrenteTransacaoRepository;
        private readonly IMapper _mapper;

        public HomeController(IContaCorrenteService contaCorrenteService,
                              IContaCorrenteRepository contaCorrenteRepository,
                              IContaCorrenteTransacaoRepository contaCorrenteTransacaoRepository,
                              IMapper mapper)
        {
            _contaCorrenteService = contaCorrenteService;
            _contaCorrenteRepository = contaCorrenteRepository;
            _contaCorrenteTransacaoRepository = contaCorrenteTransacaoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int contaId)
        {
            ContaCorrenteViewModel contaAberta;
            if (contaId > 0)
            {
                ContaCorrente contaCorrente = await _contaCorrenteRepository.ObterPorId(contaId);
                contaCorrente.Transacoes = await _contaCorrenteTransacaoRepository.Buscar(c => c.ContaCorrenteId == contaId);
                contaAberta = _mapper.Map<ContaCorrenteViewModel>(contaCorrente);
            }
            else
            {
                ContaCorrente contaCorrente = new ContaCorrente(1, new Random().Next(1, 9999), 1, DateTime.Now, 0);               

                await _contaCorrenteService.Adicionar(contaCorrente);
                contaAberta = _mapper.Map<ContaCorrenteViewModel>(contaCorrente);
            }            

            return View(contaAberta);
        }
  
        public async Task<JsonResult> Depositar(int contaId, decimal valor)
        {
            try
            {
                await _contaCorrenteService.Depositar(contaId, valor);
                return await AtualizarDados(contaId);
            }
            catch (ExcecaoDeDominio ex)
            {
                return Json(new { message = ex.MensagensDeErro[0] });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }        

        public async Task<IActionResult> Retirar(int contaId, decimal valor)
        {
            try
            {
                await _contaCorrenteService.Retirar(contaId, valor);
                return await AtualizarDados(contaId);

            }
            catch (ExcecaoDeDominio ex)
            {
                return Json(new { message = ex.MensagensDeErro[0] });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }

        public async Task<IActionResult> PagarConta(int contaId, decimal valor)
        {
            try
            {
                await _contaCorrenteService.PagarConta(contaId, valor);
                return await AtualizarDados(contaId);
            }
            catch (ExcecaoDeDominio ex)
            {
                return Json(new { message = ex.MensagensDeErro[0] });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }

        }
        private async Task<JsonResult> AtualizarDados(int contaId)
        {
            ContaCorrenteViewModel dadosConta = await BuscarDadosAtualizados(contaId);
            var responseGrid = await this.RenderViewAsync("_Extrato", dadosConta, true);
            return Json(new { grid = responseGrid, saldoAtualizado = dadosConta.SaldoAtual });
        }

        private async Task<ContaCorrenteViewModel> BuscarDadosAtualizados(int contaId)
        {
            ContaCorrente contaCorrente = await _contaCorrenteRepository.ObterPorId(contaId);
            contaCorrente.Transacoes = await _contaCorrenteTransacaoRepository.Buscar(c => c.ContaCorrenteId == contaId);
            var dadosConta = _mapper.Map<ContaCorrenteViewModel>(contaCorrente);
            return dadosConta;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }        
    }
}
