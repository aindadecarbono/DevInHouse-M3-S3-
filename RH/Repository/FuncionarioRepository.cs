using DTO;
using Enum;
using Models;
namespace Repository;

public static class FuncionarioRepository
{
  private static List<Funcionario> listaFuncionario = new List<Funcionario>
  {
    {
      new Funcionario
      {
        Id = 1,
        Nome = "Funcionario1",
        Senha = 123,
        Permissao = Permissoes.Admin,
        Salario = 2000.0
      }
    }
    ,
    {
       new Funcionario
      {
        Id = 2,
        Nome = "Funcionario2",
        Senha = 123,
        Permissao = Permissoes.Funcionario,
        Salario = 2000.0
      }
    }
  };

  public static List<Funcionario> ObterTodos()
  {
    return listaFuncionario;
  }

  public static Funcionario ObterPorNomeESenha(string nome, int senha)
  {
    var funcionario = listaFuncionario.
                      FirstOrDefault(x => x.Nome == nome && x.Senha == senha);
    return funcionario;
  }

  public static void Adicionar(FuncionarioDTO novoFuncionarioDTO)
  {
    Funcionario novoFuncionario = new Funcionario
    {
      Id = listaFuncionario.Count() + 1,
      Nome = novoFuncionarioDTO.Nome,
      Senha = novoFuncionarioDTO.Senha,
      Permissao = novoFuncionarioDTO.Permissao,
      Salario = novoFuncionarioDTO.Salario
    };

    listaFuncionario.Add(novoFuncionario);
  }

  public static void Editar(FuncionarioDTO funcionarioEdit, int id)
  {
    var funcionario = listaFuncionario.First(x => x.Id == id);

    if (funcionario == null)
    {
      throw new Exception("Funcionário não encontrado");
    }

    else
    {
      listaFuncionario.Remove(funcionario);

      funcionario.Nome = funcionarioEdit.Nome;
      funcionario.Senha = funcionarioEdit.Senha;
      funcionario.Permissao = funcionarioEdit.Permissao;
      funcionario.Salario = funcionarioEdit.Salario;

      listaFuncionario.Add(funcionario);

    }
  }

  public static void Remover(int id)
  {
    var funcionario = listaFuncionario.First(x => x.Id == id);

    if (funcionario == null)
    {
      throw new Exception("Funcionário não encontrado");
    }

    listaFuncionario.Remove(funcionario);
  }

}