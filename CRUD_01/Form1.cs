using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CRUD_01
{
    public partial class Form1 : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSQL;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("server=localhost;database=test;Uid=root;Pwd=;;");

                strSQL = "INSERT INTO TESTE (NOME, NUMERO) VALUES (@NOME, @NUMERO)";

                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@NOME",txt_nome.Text);
                comando.Parameters.AddWithValue("@NUMERO",txt_numero.Text);

                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("server=localhost;database=test;Uid=root;Pwd=;;");

                strSQL = "UPDATE TESTE SET NOME = @NOME, NUMERO = @NUMERO WHERE ID = @ID";

                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@ID", txt_id.Text);
                comando.Parameters.AddWithValue("@NOME", txt_nome.Text);
                comando.Parameters.AddWithValue("@NUMERO", txt_numero.Text);

                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("server=localhost;database=test;Uid=root;Pwd=;;");

                strSQL = "DELETE FROM TESTE WHERE ID = @ID";

                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@ID", txt_id.Text);

                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("server=localhost;database=test;Uid=root;Pwd=;;");

                strSQL = "SELECT * FROM TESTE WHERE ID = @ID";

                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@ID", txt_id.Text);

                conexao.Open();

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    txt_nome.Text = Convert.ToString(dr["nome"]);
                    txt_numero.Text = Convert.ToString(dr["numero"]);
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btn_exibir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("server=localhost;database=test;Uid=root;Pwd=;;");

                strSQL = "SELECT * FROM TESTE ";

                da = new MySqlDataAdapter(strSQL, conexao);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgv_dados.DataSource = dt;
                {
                    txt_nome.Text = Convert.ToString(dr["nome"]);
                    txt_numero.Text = Convert.ToString(dr["numero"]);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
