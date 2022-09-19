using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;
using ViewModel;

namespace RH.Controllers;

[ApiController]
[Route("api/funcionario")]
public class FuncionarioForecastController : ControllerBase
{

  [HttpPost("cadastro")]
  [Authorize(Roles = "Admin")]
  public IActionResult CadastrarNovoFuncionario(
                                      [FromBody] FuncionarioDTO funcionario)
  {
    FuncionarioRepository.Adicionar(funcionario);
    return Created("", funcionario);
  }

  [HttpDelete("{id}")]
  [Authorize(Roles = "Admin, Gerente")]
  public IActionResult Deletar([FromRoute] int id)
  {
    FuncionarioRepository.Remover(id);
    return NoContent();
  }

  [HttpPut("{id}")]
  [Authorize(Roles = "Gerente")]
  public IActionResult Editar([FromBody] FuncionarioDTO funcionarioEdit,
                              [FromRoute] int id)
  {
    FuncionarioRepository.Editar(funcionarioEdit, id);
    return Ok();
  }

  [HttpGet]
  [Authorize]
  public IActionResult ObterLista()
  {
    var lista = FuncionarioRepository.ObterTodos();

    var funcionario = User.IsInRole(Enum.Permissoes.Funcionario.ToString());

    if (funcionario)
    {

      var listaFiltrada = new List<ViewModelObject>();

      foreach (var item in lista)
      {
        listaFiltrada.Add(

          new ViewModelObject
          {
            Nome = $"{item.Nome}",
            Permissao = item.Permissao
          });

      }

      return Ok(listaFiltrada);

    }

    else
      return Ok(lista);
  }
}
