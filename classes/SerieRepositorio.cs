using System;
using System.Collections.Generic;
using Criando_um_APP_Simples_de_Cadastro_de_Séries_em_.NET.interfaces;

namespace Criando_um_APP_Simples_de_Cadastro_de_Séries_em_.NET.classes
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> listaseries = new List<Series>();
        public void Atualiza(int id, Series Objeto)
        {
            listaseries[id] = Objeto;
        }

        public void Exclui(int id)
        {
            listaseries[id].excluir();
        }

        public void Insere(Series Objeto)
        {
            listaseries.Add(Objeto);
        }

        public List<Series> Lista()
        {
            return listaseries;
        }

        public int proximoID()
        {
            return listaseries.Count;
        }

        public Series RetornaporID(int id)
        {
           return listaseries[id];
        }

    }
}