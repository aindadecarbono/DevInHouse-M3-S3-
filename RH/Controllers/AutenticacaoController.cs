using DTO;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;

namespace RH.Controllers;

[ApiController]
[Route("api/autenticacao")]
public class AutenticacaoController : ControllerBase
{

  [HttpPost("login")]
  public IActionResult Login([FromBody] FuncionarioDTO funcionarioDTO)
  {
    var funcionario = FuncionarioRepository.
                      ObterPorNomeESenha(funcionarioDTO.Nome, funcionarioDTO.Senha);

    if (funcionario == null)
      return Unauthorized();

    var token = TokenService.GenerateToken(funcionario);

    return Ok(new { token });
  }

}
