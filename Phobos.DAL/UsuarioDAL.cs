using MySql.Data.MySqlClient;//
using Phobos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Phobos.DAL
{
    public class UsuarioDAL : Conexao
    {
        //Create
        public void Cadastrar(UsuarioDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO Usuario(Nome,Email,Senha,DataNascUsuario,UsuaioTp) VALUES(@Nome,@Email,@Senha @DataNascUsuario,@UsuarioTp)", conn);
                cmd.Parameters.AddWithValue("@Nome", objCad.Nome);
                cmd.Parameters.AddWithValue("@Email", objCad.Email);
                cmd.Parameters.AddWithValue("@Senha", objCad.Senha);
                cmd.Parameters.AddWithValue("@DataNascUsuaio", objCad.DataNascUsuario);
                cmd.Parameters.AddWithValue("@Usuario", objCad.UsuarioTp);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw; new Exception("Erro ao casdastar !!" + ex.Message);

            }
            finally
            {
                Desconectar();
            }
        }

        //Read
        public List<UsuarioAutenticaDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("SELET Nome,Email,Descricao FROM Usuario INNER JOIN Tp Usuario ON Usuario.UsuarioTP" +
                    "TipoUsuario.Id", conn);
                dr = cmd.ExecuteReader();
                //ponteiro - Lista vazia
                LinkedList<UsuarioDTO> Lista = new LinkedList<UsuarioDTO>();
                while (dr.Read())
                {
                    UsuarioListDTO obj = new UsuarioListDTO();
                    obj.Nome = dr["Nome"].ToString();
                    obj.Nome = dr["Email"].ToString();
                    obj.Nome = dr["Descrição"].ToString();

                    //adicionar lista
                    Lista.AddLast(obj);


                    return Lista;
                
            catch (Exception ex)
            {

                throw; new Exception("Erro ao Listar registros !!" ex.Massage);
                
                    finally
            {
                Desconectar();
            }
        }



        //Update
        public void Editar(UsuarioDTO objEdit)
        {
            try
            {
                Conectar();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE Usuario SET Nome = @Nome,Email= @Email'." +
                    "senha = @senha,DataNascUsuario,@DataNascUsuario, UsuarioTp = @UsuarioTp WHERE Id= @Id", conn);
                cmd.Parameters.AddWithValue("@Nome", objEdit.Nome);
                cmd.Parameters.AddWithValue("@Email", objEdit.Senha);
                cmd.Parameters.AddWithValue("@Senha", objEdit.Email);
                cmd.Parameters.AddWithValue("@DataNascUsuario", objEdit.DataNascUsuario);
                cmd.Parameters.AddWithValue("@UsuarioTp", objEdit.UsuarioTp);
                cmd.Parameters.AddWithValue("@Id", objEdit.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw; new Exception("Erro ao editar usuario !!" + ex.Message);


            finally
            {
                Desconectar();
            }







            //Delete
            public void Excluir(int objDel)

            {
                try
                {
                    Conectar();
                    cmd = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM Usuario WHERE Id=@Id", conn);
                    cmd.Parameters.AddWithValue("@Id", objDel);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw; new Exception("Erro ao eliminar registro !!" + ex.Message);
                }
                finally
                {
                    Desconectar();
                }

            }
            

        
    


   
    //Autenticar

                public UsuarioAutenticaDTO Autendicar(string objNome, string objSenha)
                {
                    try
                    {
                        Conectar();
                        cmd = new MySqlCommand("SELECT  `nomecliente` `senhaClinte` * FROM cliente WHERE NomeClient = @NomeCliente AND Senha = @Senha",conn);
                        cmd.Parameters.AddWithValue("@Nome",objNome);
                        cmd.Parameters.AddWithValue("@Senha", objSenha);
                        dr = cmd.ExecuteReader();
                        UsuarioAutenticaDTO obj = null;
                        if (dr.Read())
                        {
                           obj = new UsuarioAutenticaDTO();   
                            obj.Nome = dr["Nome"].ToString();
                            obj.Senha = dr["Senha"].ToString();
                            obj.UsuarioTp = Convert.ToUInt32(dr["UsuarioTp"]);
                        }






                    }
                    catch (Exception ex)
                    {

                        throw; new Exception("Usuario não cadastrado !!"+ ex.Message);
                    }
                    finally 
                    {
                        Desconectar();
                    }



                //BuscarPorId
                public UsuarioDTO BuscarPorId(int Id)
                {
                    try
                    {
                        Conectar();
                        cmd = new MySqlCommand("SELETC * FROM Usuario WHERE Id = @Id",conn);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        dr = cmd.ExecuteReader();
                        UsuarioDTO obj = null;
                        if (dr.Read())
                        {
                            obj = new UsuarioDTO();
                            obj.Id = Convert.ToInt32(dr["Id"]);
                            obj.Nome = dr["Nome"].ToString();
                            obj.Email = dr["Email"].ToString();
                            obj.Senha = dr["Senha"].ToString();
                            obj.DataNascUsuario = Convert.ToDateTime(dr["DataNascUsuario"]);
                            obj.UsuarioTp = Convert.ToInt32(dr["UsuarioTp"]);



                        }
                    }
                    catch (Exception ex)
                    {

                        throw; new Exception("Erro ao buscar por registro !!"+ ex.Message);
                    }
                    finally
                    {
                        Desconectar();
                    }
                }