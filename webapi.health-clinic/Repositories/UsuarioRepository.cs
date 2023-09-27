﻿using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domain;
using webapi.health_clinic.Interfaces;
using webapi.health_clinic.Utils;

namespace webapi.health_clinic.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext ctx;

        public UsuarioRepository()
        {
            ctx = new HealthClinicContext();
        }

        //==================================================================

        public void Atualizar(Guid id, Usuario usuario)
        {
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(x => x.IdUsuario == id)!;

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Nome = usuario.Nome;
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
                usuarioBuscado.TipoUsuario = usuario.TipoUsuario;
            }

            ctx.Usuario.Update(usuarioBuscado!);

            ctx.SaveChanges();
        }

        //==================================================================

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            Usuario usuarioBuscado = ctx.Usuario
                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        Titulo = u.TipoUsuario!.Titulo
                    }
                }).FirstOrDefault(u => u.Email == email)!;

            if (usuarioBuscado != null)
            {
                bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                if (confere)
                {
                    return usuarioBuscado;
                }
            }
            return null;
        }

        //==================================================================

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,

                        TipoUsuario = new TipoUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TipoUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //==================================================================

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GeraHash(usuario.Senha!);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //==================================================================

        public void Deletar(Guid id)
        {
            Usuario usuario = ctx.Usuario.FirstOrDefault(x => x.IdUsuario == id)!;

            ctx.Usuario.Remove(usuario);

            ctx.SaveChanges();
        }

        //==================================================================

        public List<Usuario> Listar()
        {
            List<Usuario> usuarios = ctx.Usuario.ToList();

            return usuarios;
        }
    }
}
