﻿using AmbienteEscolar.Business.BancoDeDados;
using AmbienteEscolar.Business.Classes;
using AmbienteEscolar.Business.Classes.Enum;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AmbienteEscolar.Business.Repositorios
{
    public class NivelAcessoRepository
    {
        public static List<NivelAcesso> ListarAcesso()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT id, descricao FROM nivel_acesso ORDER BY id;");

            List<NivelAcesso> listaNivelAcesso = new List<NivelAcesso>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    NivelAcesso na = new NivelAcesso();

                    na.Id = int.Parse(dataReader["id"].ToString());
                    na.Descricao = dataReader["descricao"].ToString();

                    listaNivelAcesso.Add(na);
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return listaNivelAcesso;
            }
            else
            {
                return listaNivelAcesso;
            }
        }

        public static int ListarAcessosDescricao(int id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT id, descricao FROM nivel_acesso");
            sb.AppendLine("WHERE id='" + id + "' ORDER BY descricao;");

            NivelAcesso na = new NivelAcesso();
            List<NivelAcesso> listaAcessos = new List<NivelAcesso>();

            if (BancoDados.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDados.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    na.Id = int.Parse(dataReader["id"].ToString());
                    na.Descricao = dataReader["descricao"].ToString();

                    listaAcessos.Add(na);
                }
                dataReader.Close();
                BancoDados.CloseConnection();

                return na.Id;
            }
            else
            {
                return na.Id;
            }
        }
    }
}