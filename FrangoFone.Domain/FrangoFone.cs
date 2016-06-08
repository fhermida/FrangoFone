namespace FrangoFone.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FrangoFone : DbContext
    {
        public FrangoFone()
            : base("name=FrangoFone")
        {
        }

        public virtual DbSet<CategoriaSet> CategoriaSet { get; set; }
        public virtual DbSet<ClienteSet> ClienteSet { get; set; }
        public virtual DbSet<ContatoSet> ContatoSet { get; set; }
        public virtual DbSet<EnderecoSet> EnderecoSet { get; set; }
        public virtual DbSet<ItemPedidoSet> ItemPedidoSet { get; set; }
        public virtual DbSet<MenuSet> MenuSet { get; set; }
        public virtual DbSet<PedidoSet> PedidoSet { get; set; }
        public virtual DbSet<PermissaoMenuSet> PermissaoMenuSet { get; set; }
        public virtual DbSet<PermissaoSet> PermissaoSet { get; set; }
        public virtual DbSet<ProdutoPrecoSet> ProdutoPrecoSet { get; set; }
        public virtual DbSet<ProdutoSet> ProdutoSet { get; set; }
        public virtual DbSet<TipoContatoSet> TipoContatoSet { get; set; }
        public virtual DbSet<TipoEntregaSet> TipoEntregaSet { get; set; }
        public virtual DbSet<TipoPagamentoSet> TipoPagamentoSet { get; set; }
        public virtual DbSet<UsuarioSet> UsuarioSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaSet>()
                .HasMany(e => e.ProdutoSet)
                .WithRequired(e => e.CategoriaSet)
                .HasForeignKey(e => e.CategoriaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClienteSet>()
                .HasMany(e => e.ContatoSet)
                .WithRequired(e => e.ClienteSet)
                .HasForeignKey(e => e.ClienteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClienteSet>()
                .HasMany(e => e.EnderecoSet)
                .WithRequired(e => e.ClienteSet)
                .HasForeignKey(e => e.ClienteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClienteSet>()
                .HasMany(e => e.PedidoSet)
                .WithRequired(e => e.ClienteSet)
                .HasForeignKey(e => e.ClienteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContatoSet>()
                .Property(e => e.Valor)
                .IsUnicode(false);

            modelBuilder.Entity<EnderecoSet>()
                .HasMany(e => e.PedidoSet)
                .WithRequired(e => e.EnderecoSet)
                .HasForeignKey(e => e.Endereco_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuSet>()
                .HasMany(e => e.PermissaoMenuSet)
                .WithRequired(e => e.MenuSet)
                .HasForeignKey(e => e.Menu_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PedidoSet>()
                .HasMany(e => e.ItemPedidoSet)
                .WithRequired(e => e.PedidoSet)
                .HasForeignKey(e => e.PedidoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PermissaoSet>()
                .HasMany(e => e.PermissaoMenuSet)
                .WithRequired(e => e.PermissaoSet)
                .HasForeignKey(e => e.Permissao_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PermissaoSet>()
                .HasMany(e => e.UsuarioSet)
                .WithRequired(e => e.PermissaoSet)
                .HasForeignKey(e => e.Permissao_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProdutoPrecoSet>()
                .Property(e => e.Valor)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ProdutoSet>()
                .Property(e => e.Valor)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProdutoSet>()
                .HasMany(e => e.ItemPedidoSet)
                .WithRequired(e => e.ProdutoSet)
                .HasForeignKey(e => e.ProdutoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProdutoSet>()
                .HasMany(e => e.ProdutoPrecoSet)
                .WithRequired(e => e.ProdutoSet)
                .HasForeignKey(e => e.ProdutoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoContatoSet>()
                .HasMany(e => e.ContatoSet)
                .WithRequired(e => e.TipoContatoSet)
                .HasForeignKey(e => e.TipoContatoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoEntregaSet>()
                .HasMany(e => e.PedidoSet)
                .WithRequired(e => e.TipoEntregaSet)
                .HasForeignKey(e => e.TipoEntregaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoPagamentoSet>()
                .HasMany(e => e.PedidoSet)
                .WithRequired(e => e.TipoPagamentoSet)
                .HasForeignKey(e => e.TipoPagamentoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsuarioSet>()
                .HasMany(e => e.ClienteSet)
                .WithRequired(e => e.UsuarioSet)
                .HasForeignKey(e => e.UsuarioId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsuarioSet>()
               .HasMany(e => e.PedidoSet)
               .WithRequired(e => e.UsuarioSet)
               .HasForeignKey(e => e.UsuarioId)
               .WillCascadeOnDelete(false);
        }
    }
}
