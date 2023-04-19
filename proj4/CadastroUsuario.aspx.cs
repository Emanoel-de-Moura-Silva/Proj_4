using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Proj4;

namespace proj4
{
   public partial class CadastroUsuario : System.Web.UI.Page
   {
        private SqlConnection conexao;
        public void criarConexao()
        {
            try
            {
                string strcon =
                ConfigurationManager.ConnectionStrings["Usuario"].ToString();
                conexao = new SqlConnection(strcon);
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro Criação Conexão: " + ex.Message);
            }
        }
        public void IncluirUsuarioSessao(Usuario objUsu)
        {
            Session["usuario"] = objUsu;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtEmail.Text != "" && txtSenha.Text != "" && txtConfSenha.Text != "")
            {
                if (txtSenha.Text == txtConfSenha.Text)
                {
                    Usuario objUsu = new Usuario(txtNome.Text, txtEmail.Text, txtSenha.Text);
                    IncluirUsuarioSessao(objUsu);
                    msgGeral.Text = "Dados inseridos na sessão.";
                }
                else
                {
                    msgGeral.Text = "As senhas não coincidem.";
                }
            }
            else
            {
                msgGeral.Text = "Por favor, preencha todos os campos.";
            }
        }

        protected void btnConexao_Click(object sender, EventArgs e)
        {
            try
            {
                criarConexao();
                conexao.Open();
                msgGeral.Text = "Conexão com sucesso!";
            }
            catch (Exception ex)
            {
                msgGeral.Text = "Erro ao conectar: " + ex.Message;
            }
            finally
            {
                conexao.Close();
            }
        }
       
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            // Clear textboxes
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtConfSenha.Text = "";
        }

        protected void btnExibirDados_Click(object sender, EventArgs e)
        {
            Usuario objUsu = (Usuario)Session["usuario"];
            if (objUsu != null)
            {
                Response.Write("Nome: " + objUsu.Nome + "<br/>");
                Response.Write("E-mail: " + objUsu.Email + "<br/>");
                Response.Write("Senha: " + objUsu.Senha + "<br/>");
            }
        }
    }
}
