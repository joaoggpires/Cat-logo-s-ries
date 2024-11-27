using System.Collections.Generic;

namespace Criando_um_APP_Simples_de_Cadastro_de_Séries_em_.NET.interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaporID(int id);
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id, T entidade);
         int proximoID();
    }
}